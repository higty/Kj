using DbAccessDatabase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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

namespace WebApiWpfApp1
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
        }
        protected async override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            var json = await this.GetPaymentListJson();
            var l = JsonConvert.DeserializeObject<List<PaymentRecord>>(json);
            foreach (var item in l)
            {
                _PaymentList.Add(item);
            }
            this.PaymentListBox.ItemsSource = this._PaymentList;
        }
        private async Task<String> GetPaymentListJson()
        {
            //Web APIから取得
            var cl = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(new { }), Encoding.UTF8, "application/json");
            //C#5.0 非同期 状態マシーン State Machine
            var res = await cl.PostAsync("https://localhost:5001/Api/Payment/List/Get", content);
            var json = await res.Content.ReadAsStringAsync();

            return json;
        }
        private void PaymentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var paymentRecord = this.PaymentListBox.SelectedItem as DbAccessDatabase.PaymentRecord;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //this.AddByApi();
        }
        private void PaymentListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var r = this.PaymentListBox.SelectedItem as PaymentRecord;
            //var w = new EditRecordWindow(r);
            //w.ShowDialog();

            //if (w.Deleted == true)
            //{
            //    this._PaymentList.Remove(r);
            //}
        }
    }
}
