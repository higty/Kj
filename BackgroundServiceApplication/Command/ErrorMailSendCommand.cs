using HigLabo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServiceApplication.Command
{
    public class ErrorMailSendCommandExecutedEventArgs : EventArgs
    {
        public DateTime ExecuteTime { get; set; }
        public string MailAddress { get; set; } = "";
        public string Body { get; set; } = "";
        
        public ErrorMailSendCommandExecutedEventArgs(DateTime executeTime, string mailAddress, string body)
        {
            this.ExecuteTime = executeTime;
            this.MailAddress = mailAddress;
            this.Body = body;
        }
    }
    public class ErrorMailSendCommand : PeriodicCommand
    {
        public event EventHandler<ErrorMailSendCommandExecutedEventArgs>? Executed;

        private DateTime _ExecuteTime;

        public ErrorMailSendCommand(BackgroundService service)
            : base(service)
        {
        }
        public override bool IsExecute(DateTime utcNow)
        {
            _ExecuteTime = utcNow;
            return true;
        }
        public override void Execute()
        {
            var mailAddressList = new List<string>();
            mailAddressList.Add("hig@tb.com");
            mailAddressList.Add("komy@tb.com");
            mailAddressList.Add("izu@kj.com");

            //Send mail 

            foreach (var mailAddress in mailAddressList)
            {
                this.Executed?.Invoke(this, new ErrorMailSendCommandExecutedEventArgs(_ExecuteTime, mailAddress
                    , "エラーがあります！！！"));
            }
        }
    }
}
