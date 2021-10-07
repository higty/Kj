using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace ThreadService
{
    public class WorkerThreadServiceEventArgs  : EventArgs
    {
        public DateTime ExecuteTime { get; private set; }

        public WorkerThreadServiceEventArgs(DateTime executeTime)
        {
            this.ExecuteTime = executeTime;
        }
    }
    public class WorkerThreadService
    {
        public event EventHandler<WorkerThreadServiceEventArgs> Executing;

        public DatabaseSetting Setting { get; private set; }

        public WorkerThreadService(DatabaseSetting setting)
        {
            this.Setting = setting;
        }

        public void StartThread()
        {
            var thd = new Thread(this.Execute);
            thd.Name = "MyThread1";
            thd.IsBackground = true;
            thd.Start();
        }

        private void Execute()
        {
            while (true)
            {
                var now = DateTime.Now;
                this.Executing?.Invoke(this, new WorkerThreadServiceEventArgs(now));
                Debug.WriteLine(now.ToString("HH:MM:ss.fffffff"));
                Thread.Sleep(1000);
            }
        }
    }
}
