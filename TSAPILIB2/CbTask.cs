using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace TSAPILIB2
{
    public class CbTask<T> : ConcurrentDictionary<T, MyTask>
    {
        private readonly int _maxCapasiti;
        public CbTask(int maxCapasiti)
        {
            _maxCapasiti = maxCapasiti;
        }


        public string CurrentCommand()
        {
            return ToArray().Select(c=> $"{c.Key}:{c.Value.Command}").Aggregate("" ,(s, s1) => s + "\n" + s1);
        }

        public CbTask()
        {

        }
        public Task<object> Add(T key, MyTask task = null, string command = null, Int32 timeoutMs = 30)
        {
            var t = task ?? new MyTask(timeoutMs, command);

            t.OnTimeout += myTask =>
            {
                MyTask cb;
                TryRemove(key, out cb);
            };
        
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

        public bool Set(T invokeId, object ret)
        {
            MyTask cb;
            if (!TryRemove(invokeId, out cb))
                return false;
            cb.Set(ret);
            cb.Dispose();
            return true;
        }

        public bool SetError(T invokeId, CSTAUniversalFailure_t error)
        {
            MyTask cb;
            if (!TryRemove(invokeId, out cb))
                return false;
            cb.SetError(error);
            cb.Dispose();
            return true;

        }

        public bool UpdateTimeout(T invokeId)
        {
            MyTask cb;
            if (!TryGetValue(invokeId, out cb))
                return false;
            cb.UpdateTimeout();
            return true;
        }

        public MyTask GeTask(T invokeId)
        {
            MyTask cb;
            if (!TryRemove(invokeId, out cb))
                return null;
            cb.UpdateTimeout();
            return cb;
        }

    }
}