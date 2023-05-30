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

namespace BackgroundServiceApplication
{
    public partial class MainWindow : Window
    {
        public BackgroundService BackgroundService { get; set; }
        public ObservableCollection<CommandResult> CommandResultList { get; init; } = new();

        public MainWindow()
        {
            InitializeComponent();

            this.CommandResultListView.ItemsSource = this.CommandResultList;
            this.BackgroundService = new BackgroundService();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            this.BackgroundService.StartThead();
            this.ThreadStateLabel.Content = "Started...";
        }

        private void AddCommandButton_Click(object sender, RoutedEventArgs e)
        {
            var cm = new LoadUrlListCommand();
            cm.Executing += LoadUrlListCommand_Executing;
            this.BackgroundService.CommandList.Add(cm);
        }

        private void LoadUrlListCommand_Executing(object? sender, LoadUrlListCommandExecutingEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                var result = new CommandResult(e.Url);
                this.CommandResultList.Add(result);
                this.CommandResultListView.ScrollIntoView(result);
            });
        }
    }
}
