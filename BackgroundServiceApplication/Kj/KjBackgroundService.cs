using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BackgroundServiceApplication
{
    public class KjBackgroundService
    {
        public List<ServiceCommand> CommandList { get; init; } = new();

        public KjBackgroundService()
        {
        }

        public void StartThead()
        {
            var thd = new Thread(this.Execute);
            thd.IsBackground = true;
            thd.Start();
        }
        private void Execute()
        {
            //Background Thread
            while (true)
            {
                var commandList = this.CommandList.ToList();
                foreach (var cm in commandList)
                {
                    cm.ExecuteAsync();
                    this.CommandList.Remove(cm);
                }
                Thread.Sleep(1000);
            }
        }
    }
}
