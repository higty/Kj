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

namespace DbAccessWpfApp4
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

        private void ShowRecordButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new DbAccessDatabase.Database();
            db.ConnectionString = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");

            foreach (var title in db.SelectTitleList())
            {
                this.RecordListLabel.Content += title + Environment.NewLine;
            }
        }
        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new EditRecordWindow();
            w.Title = "レコードの編集ウィンドウ";
            w.ShowDialog();
        }

    }
}
