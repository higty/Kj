using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundServiceApplication
{
    public class LoadUrlListCommandExecutingEventArgs
    {
        public String Url { get; set; } = "";
        public LoadUrlListCommandExecutingEventArgs(string url)
        {
            Url = url;
        }
    }
    public class LoadUrlListCommand : ServiceCommand
    {
        public event EventHandler<LoadUrlListCommandExecutingEventArgs>? Executing;

        public List<CommandResult> UrlList { get; set; } = new();

        public override Task ExecuteAsync()
        {
            var l = this.UrlList;
            for (int i = 0; i < 4; i++)
            {
                {
                    var url = $"{DateTime.Now.ToString("HH:mm:ss.fff")} Yahoo";
                    l.Add(new CommandResult(url));
                    Thread.Sleep(300);
                    this.OnExecuting(new LoadUrlListCommandExecutingEventArgs(url));
                }
                {
                    var url = $"{DateTime.Now.ToString("HH:mm:ss.fff")} Google";
                    l.Add(new CommandResult(url));
                    Thread.Sleep(300);
                    this.OnExecuting(new LoadUrlListCommandExecutingEventArgs(url));
                }
                {
                    var url = $"{DateTime.Now.ToString("HH:mm:ss.fff")} Amazon";
                    l.Add(new CommandResult(url));
                    Thread.Sleep(300);
                    this.OnExecuting(new LoadUrlListCommandExecutingEventArgs(url));
                }
                {
                    var url = $"{DateTime.Now.ToString("HH:mm:ss.fff")} Microsoft";
                    l.Add(new CommandResult(url));
                    Thread.Sleep(300);
                    this.OnExecuting(new LoadUrlListCommandExecutingEventArgs(url));
                }
            }
            this.OnCompleted(new CommandCompletedEventArgs(this));

            return Task.CompletedTask;
        }
        protected void OnExecuting(LoadUrlListCommandExecutingEventArgs e)
        {
            this.Executing?.Invoke(this, e);
        }
    }
}
