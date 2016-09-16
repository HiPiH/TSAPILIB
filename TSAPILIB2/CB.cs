using System;
using System.Linq;
using System.Threading;
using System.Collections.Concurrent;
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
                    _task.SetException(new CSTAExeption(CSTAUniversalFailure_t.operationTimeout));    
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
                _task.TrySetException(new CSTAExeption(error));
            }
        }
        
    }

    public class CBTask<T> : ConcurrentDictionary<T, MyTask>
    {
        private readonly int _maxCapasiti;
        public CBTask(Int32 maxCapasiti)
        {
            _maxCapasiti = maxCapasiti;
        }


        public String CurrentCommand()
        {
            return ToArray().Select(c=>String.Format("{0}:{1}",c.Key,c.Value.Command)).Aggregate("" ,(s, s1) => s + "\n" + s1);
        }

        public CBTask()
        {

        }
        public Task<object> Add(T key, MyTask task = null, string command = null, Int32 timeoutMs = 30)
        {
            var t =task ?? new MyTask(timeoutMs, command);
            if (_maxCapasiti != 0 && Count >= _maxCapasiti)
            {
                t.SetError(CSTAUniversalFailure_t.CBTaskIsFull);

            }
            else
            {
                if (!TryAdd(key, t))
                {
                    t.SetError(CSTAUniversalFailure_t.genericOperationRejection);
                }
            }
            return t.Task;
        }

        public Boolean Set(T invokeID, object ret)
        {
            MyTask cb;
            if (!TryRemove(invokeID, out cb))
                return false;
            cb.Set(ret);
            cb.Dispose();
            return true;
        }

        public Boolean SetError(T invokeID, CSTAUniversalFailure_t error)
        {
            MyTask cb;
            if (!TryRemove(invokeID, out cb))
                return false;
            cb.SetError(error);
            cb.Dispose();
            return true;

        }

        public Boolean UpdateTimeout(T invokeID)
        {
            MyTask cb;
            if (!TryGetValue(invokeID, out cb))
                return false;
           cb.UpdateTimeout();
           return true;
        }

        public MyTask GeTask(T invokeID)
        {
            MyTask cb;
            if (!TryRemove(invokeID, out cb))
                return null;
            cb.UpdateTimeout();
            return cb;
        }

    }

       
        

   
}
