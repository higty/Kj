using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServiceApplication
{
    public class CommandCompletedEventArgs
    {
        public ServiceCommand Command { get; init; }
        public CommandCompletedEventArgs(ServiceCommand command)
        {
            Command = command;
        }
    }
    public abstract class ServiceCommand
    {
        public event EventHandler<CommandCompletedEventArgs>? Completed;

        public ServiceCommand() { }
        public abstract Task ExecuteAsync();

        protected void OnCompleted(CommandCompletedEventArgs e)
        {
            this.Completed?.Invoke(this, e);
        }
    }
}
