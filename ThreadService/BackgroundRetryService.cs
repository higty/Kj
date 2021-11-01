using Microsoft.Data.SqlClient;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace ThreadService
{
    public abstract class ServiceCommand
    {
        public DateTime PreviousExecutedTime { get; set; } = DateTime.MinValue;

        public abstract void Execute();
    }
    public class LogTableInsertCommand : ServiceCommand
    {
        public DateTime ReceiveTime { get; set; }
        public DateTime CanDataGetTime { get; set; }
        public String DateType { get; set; }
        public String DumpName { get; set; }
        public Int32 XXLevel { get; set; }
        public Int32 Latitude { get; set; }
        public Int32 Longitude { get; set; }

        public LogTableInsertCommand(DateTime receiveTime, DateTime canDataGetTime, String dataType)
        {
            this.ReceiveTime = receiveTime;
            this.CanDataGetTime = canDataGetTime;
            this.DateType = dataType;
        }
        public override void Execute()
        {
            this.PreviousExecutedTime = DateTime.Now;
            //たまに失敗するように実装
            if (DateTime.Now.Millisecond % 2 == 0)
            {
                var cm = new SqlCommand();
                cm.Parameters.AddWithValue("@ReceiveTime", this.ReceiveTime);
                //DBにInsertする処理...

                Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "Insert!!!");
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
    public class BackgroundRetryService
    {
        private Thread _Thread = null;
        public Int32 CommandIntervalSeconds { get; set; } = 10;

        private ConcurrentQueue<ServiceCommand> _CommandList = new ConcurrentQueue<ServiceCommand>();

        public void StartThread()
        {
            var thd = new Thread(this.Execute);
            _Thread = thd;
            thd.Name = "BackgroundRetryService";
            thd.IsBackground = true;
            thd.Start();
        }
        private void Execute()
        {
            while (true)
            {
                var now = DateTime.Now;
                var skipCommandList = new List<ServiceCommand>();
                while (_CommandList.TryDequeue(out var cm))
                {
                    //ガード句
                    if (cm.PreviousExecutedTime > now.AddSeconds(-this.CommandIntervalSeconds))
                    {
                        skipCommandList.Add(cm);
                        continue;
                    }

                    try
                    {
                        cm.Execute();
                        Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " BackgroundRetryService command executed successfully.");
                    }
                    catch
                    {
                        _CommandList.Enqueue(cm);
                        Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " BackgroundRetryService error.");
                    }
                }
                foreach (var cm in skipCommandList)
                {
                    _CommandList.Enqueue(cm);
                }
                Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " BackgroundRetryService executed.");
                Debug.WriteLine(_CommandList.Count + " command exists.");

                Thread.Sleep(4 * 1000);
            }
        }
        public void AddCommand(ServiceCommand command)
        {
            _CommandList.Enqueue(command);
        }
    }
}
