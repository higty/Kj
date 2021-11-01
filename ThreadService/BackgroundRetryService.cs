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
        public abstract void Execute();
    }
    public class LogTableInsertCommand : ServiceCommand
    {
        public override void Execute()
        {
            //DBにInsertする処理...
            if (DateTime.Now.Millisecond % 2 == 0)
            {
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
                if (_CommandList.TryDequeue(out var cm))
                {
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
                Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " BackgroundRetryService executed.");

                Thread.Sleep(10 * 1000);
            }
        }
        public void AddCommand(ServiceCommand command)
        {
            _CommandList.Enqueue(command);
        }
    }
}
