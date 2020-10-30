using DbAccessDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace DbAccessWpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<PaymentRecord> _PaymentList = new ObservableCollection<PaymentRecord>();

        public MainWindow()
        {
            InitializeComponent();

            this.GetPaymentList();
        }
        private void GetPaymentList()
        {
            var db = new DbAccessDatabase.Database();
            db.ConnectionString = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");

            foreach (var item in db.SelectPaymentRecords())
            {
                this._PaymentList.Add(item);
            }
            this.PaymentListBox.ItemsSource = this._PaymentList;
        }

        private void PaymentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var paymentRecord = this.PaymentListBox.SelectedItem as DbAccessDatabase.PaymentRecord;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new EditRecordWindow();
            w.ShowDialog();

            var db = new DbAccessDatabase.Database();
            db.ConnectionString = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            var paymentList = db.SelectPaymentRecords();
            this.PaymentListBox.ItemsSource = paymentList;
        }

        private void PaymentListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var r = this.PaymentListBox.SelectedItem as PaymentRecord;
            var w = new EditRecordWindow(r);
            w.ShowDialog();

            if (w.Deleted == true)
            {
                this._PaymentList.Remove(r);
            }
        }
    }
}
