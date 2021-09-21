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
using System.Threading;
using System.Diagnostics;

namespace MultiThreadWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            var thd = new Thread(this.ExecuteOnBackgroundThread);
            thd.IsBackground = true;
            thd.Start();
        }
        private void ExecuteOnBackgroundThread()
        {
            while (true)
            {
                var now = DateTime.Now.ToString("HH:MM:ss.fffffff");
                this.Dispatcher.Invoke(() =>
                {
                    this.LogTextbox.Text += now + Environment.NewLine;
                });
                Debug.WriteLine(now);
                Thread.Sleep(1000);
            }
        }
    }
}
