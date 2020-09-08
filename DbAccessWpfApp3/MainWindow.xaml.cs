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
using System.IO;

namespace DbAccessWpfApp3
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var s = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");

            var db = new Database();
            db.ConnectionString = s;
            var titleList = db.SelectTitleList();

            this.Label1.Content = "";
            for (int i = 0; i < titleList.Count; i++)
            {
                this.Label1.Content += titleList[i] + Environment.NewLine;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var s = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");

            var db = new Database();
            db.ConnectionString = s;
            var recordList = db.SelectPaymentRecordList();

            this.Label1.Content = "";
            for (int i = 0; i < recordList.Count; i++)
            {
                this.Label1.Content += recordList[i].Date.ToString("yyyy/MM/dd") + " " + recordList[i].Title + Environment.NewLine;
            }
        }
    }
}
