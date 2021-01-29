using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ehaiker.TimerEvent
{
    public class TimerEventBase
    {
        public static object locker = new object();//添加一个对象作为锁
        //每一小時，檢查一次
        private System.Timers.Timer writeTimer = new System.Timers.Timer();
        public event EventHandler<CountItemdEventArgs<string>> DoCountEvent;
        public event EventHandler<CountItemdEventArgs<string>> GetItemCountEvent;
        public void Start()
        {
            writeTimer.Stop();
            writeTimer.Elapsed += new System.Timers.ElapsedEventHandler(WriteFunc);
            writeTimer.AutoReset = true;
            writeTimer.Enabled = true;
        }
        public void Stop()
        {
            writeTimer.Stop();
            writeTimer.Enabled = false;
        }
        public double Intervel(double intmax=100)
        {
            double tmp = writeTimer.Interval;
            writeTimer.Interval = intmax;
            writeTimer.Stop();
            writeTimer.Enabled = true;
            return tmp;
        }
        public virtual void InitData()
        {
        }
        public virtual void WriteFunc(object source, System.Timers.ElapsedEventArgs e)
        {
            lock (locker)
            {

                DateTime dt = DateTime.Now;
                if ((dt.Hour == 0 && dt.Minute == 0) ||
                    (dt.Hour == 24 && dt.Minute == 0))
                {

                    InitData();
                }
            }
        }
        private void RaiseSaveItemCount(string uri, int count)
        {
            if (DoCountEvent != null)
            {
                DoCountEvent(this, new CountItemdEventArgs<string>(uri, count));
            }
        }
        private int RaiseGetItemCount(string uri, int count)
        {
            if (GetItemCountEvent != null)
            {
                CountItemdEventArgs<string> refCount = new CountItemdEventArgs<string>(uri, count);
                GetItemCountEvent(this, refCount);
                return refCount.count;
            }
            return count;
        }
    }
}