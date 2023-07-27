using HigLabo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundServiceApplication.Command
{
    public class ReportMailSendCommandExecutedEventArgs : EventArgs
    {
        public DateTime ExecuteTime { get; set; }
        public string MailAddress { get; set; } = "";
        public string Body { get; set; } = "";
       
        public ReportMailSendCommandExecutedEventArgs(DateTime executeTime, string mailAddress, string body)
        {
            this.ExecuteTime = executeTime;
            this.MailAddress = mailAddress;
            this.Body = body;
        }
    }
    public class ReportMailSendCommand : PeriodicCommand
    {
        public event EventHandler<ReportMailSendCommandExecutedEventArgs>? Executed;

        private DateTime _ExecuteTime;

        public string MailAddress { get; set; }

        public ReportMailSendCommand(BackgroundService service, string mailAddress) : base(service)
        {
            this.MailAddress = mailAddress;
        }
        public override bool IsExecute(DateTime utcNow)
        {
            _ExecuteTime = utcNow;
            return utcNow.Second % 3 == 0;
        }
        public override void Execute()
        {
            Thread.Sleep(1000);
            this.Executed?.Invoke(this, new ReportMailSendCommandExecutedEventArgs(_ExecuteTime
                , this.MailAddress, "施工状況：実行時間が78%です。"));
        }
    }
}
