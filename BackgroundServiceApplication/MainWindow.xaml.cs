using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Threading;
using HigLabo.Service;
using BackgroundServiceApplication.Command;

namespace BackgroundServiceApplication
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<CommandResult> CommandResultList { get; init; } = new();

        public PeriodicCommandService PeriodicCommandService { get; set; } = new("PeriodicCommandService");
        public BackgroundService ErrorMailSendService { get; set; } = new BackgroundService("ErrorMailSendService", 0);
        public BackgroundService ReportMailSendService { get; set; } = new BackgroundService("ReportMailSendService", 0);
        public BackgroundService DeleteService { get; set; } = new BackgroundService("DeleteService", 0);

        public MainWindow()
        {
            InitializeComponent();
            this.CommandResultListView.ItemsSource = this.CommandResultList;
            this.PeriodicCommandService.IntervalSeconds = 1;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            this.ThreadStateLabel.Content = "Started...";

            if (this.PeriodicCommandService.IsStarted)
            {
                return;
            }
            this.PeriodicCommandService.Available = true;
            this.PeriodicCommandService.StartThread();
            this.ErrorMailSendService.StartThread();
            this.ReportMailSendService.StartThread();
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            this.PeriodicCommandService.Available = false;
            this.ThreadStateLabel.Content = "Supended...";
        }

        private void AddCommandButton_Click(object sender, RoutedEventArgs e)
        {
            {
                var cm = new ErrorMailSendCommand(this.ErrorMailSendService);
                cm.Executed += ErrorMailSendCommand_Executed;
                this.PeriodicCommandService.AddCommand(cm);
            }

            foreach (var mailAddress in new[] { "control@kj.com", "dump@kj.com", "giken@kj.com", "hig@tb.com" })
            {
                var cm = new ReportMailSendCommand(this.ReportMailSendService, mailAddress);
                cm.Executed += ReportMailSendCommnad_Executed;
                this.PeriodicCommandService.AddCommand(cm);
            }
        }

        private void ErrorMailSendCommand_Executed(object? sender, ErrorMailSendCommandExecutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                var result = new CommandResult(DateTime.Now.ToString("HH:mm:ss.fff") + Environment.NewLine +
                    $"{e.ExecuteTime.ToString("HH:mm:ss.fff")} {e.MailAddress} Body:{e.Body}");
                this.CommandResultList.Add(result);
                this.CommandResultListView.ScrollIntoView(result);
            });
        }
        private void ReportMailSendCommnad_Executed(object? sender, ReportMailSendCommandExecutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                var result = new CommandResult(DateTime.Now.ToString("HH:mm:ss.fff") + Environment.NewLine +
                    $"{e.ExecuteTime.ToString("HH:mm:ss.fff")} {e.MailAddress} Body:{e.Body}");
                this.CommandResultList.Add(result);
                this.CommandResultListView.ScrollIntoView(result);
            });
        }


    }
}
