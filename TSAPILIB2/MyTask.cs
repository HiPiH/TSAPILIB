using System;
using System.Threading;
using System.Threading.Tasks;


namespace TSAPILIB2
{
    public class MyTask:IDisposable
    {
        private readonly string _command;
        private readonly int _timeoutMs;


        private Timer _time;
        private readonly object _locktask = new object();
        private readonly TaskCompletionSource<object> _task = new TaskCompletionSource<object>();

        public delegate void TimeoutEvent(MyTask t);

        public event TimeoutEvent OnTimeout;

        protected virtual void OnOnTimeout(MyTask t)
        {
            var handler = OnTimeout;
            handler?.Invoke(t);
        }


        public Task<object> Task
        {
            get { return _task.Task; }
        }

        public string Command
        {
            get { return _command; }
        }

        public Int32 CountElapsend = 0;
        private bool _disposed;

        public MyTask( Int32 timeoutMs, String command)
        {
            _command = command;
            _timeoutMs = timeoutMs*1000;
           
            _time = new Timer(SetTimeout, this, _timeoutMs, Timeout.Infinite);
        }

        private void SetTimeout(object state)
        {
            lock (_locktask)
            {
                if (!_task.Task.IsCompleted)
                {
                    _task.SetException(new CstaExeption(CSTAUniversalFailure_t.operationTimeout));
                    OnOnTimeout(this);
                }
            }
        }

        public void UpdateTimeout()
        {
            lock (_locktask)
            {
                if (_time != null)
                {
                    _time.Change(_timeoutMs, Timeout.Infinite);
                }
            }
        }



        protected virtual void Dispose(Boolean disposing)
        {
            if (_disposed)return; // Ресурсы уже освобождены
            if (disposing)
            {
                lock (_locktask)
                {
                    _time.Dispose();
                    _time = null;
                }
            }
            _disposed = true;

        }


        public void Dispose()
        {
            Dispose(true);
        }


        public void Set(object ret)
        {
            lock (_locktask)
            {
                _task.TrySetResult(ret);
            }
        }

        public void SetError( CSTAUniversalFailure_t error)
        {
            lock (_locktask)
            {
                _task.TrySetException(new CstaExeption(error));
            }
        }
        
    }
}
