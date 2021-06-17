﻿using DbAccessDatabase;
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

            this.GetPaymentList();
        }
        private void GetPaymentList()
        {
            var json = this.GetPaymentListJson().GetAwaiter().GetResult();
            var l = JsonConvert.DeserializeObject<List<PaymentRecord>>(json);
            foreach (var item in l)
            {
                _PaymentList.Add(item);
            }
            this.PaymentListBox.ItemsSource = this._PaymentList;
        }
        private String GetPaymentListJson_Dummy()
        {
            var db = new Database();
            db.ConnectionString = System.IO.File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            var l = db.SelectPaymentRecords();
            return JsonConvert.SerializeObject(l);
        }
        private async Task<String> GetPaymentListJson()
        {
            return this.GetPaymentListJson_Dummy();
            //Web APIから取得
            var cl = new HttpClient();
            var res = await cl.PostAsync("https://localhost:44387/Api/Payment/List/Get", new MultipartFormDataContent());
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
