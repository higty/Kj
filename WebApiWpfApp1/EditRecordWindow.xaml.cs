using DbAccessDatabase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WebApiWpfApp1
{
    /// <summary>
    /// EditRecordWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class EditRecordWindow : Window
    {
        private PaymentRecord _Record = null;
        public Boolean Deleted { get; set; } = false;

        /// <summary>
        /// 追加の時に呼ばれるコンストラクタ
        /// </summary>
        public EditRecordWindow()
        {
            InitializeComponent();
            this.DeleteButton.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// 編集（保存・削除）の時に呼ばれるコンストラクタ
        /// </summary>
        public EditRecordWindow(PaymentRecord record)
        {
            InitializeComponent();
            this._Record = record;
            this.DeleteButton.Visibility = Visibility.Visible;
            this.SetControlValue();
        }
        private void SetControlValue()
        {
            this.TitleTextbox.Text = _Record.Title;
            this.DateTextbox.Text = _Record.Date.ToString("yyyy/MM/dd");
            this.PriceTextbox.Text = _Record.Price.ToString();
        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //入力値の検証処理
            if (DateTime.TryParse(this.DateTextbox.Text, out var date) == false)
            {
                MessageBox.Show("日付の値が間違っています！日付に変換可能な文字を入力してください。(2020/08/03)");
                return;
            }
            if (Int32.TryParse(this.PriceTextbox.Text, out var price) == false)
            {
                MessageBox.Show("価格の値が間違っています！数字を入力してください。");
                return;
            }

            var cl = new HttpClient();
            if (_Record == null)
            {
                //追加の時
                var p = new PaymentRecord();
                p.Title = this.TitleTextbox.Text;
                p.Date = DateTime.Parse(this.DateTextbox.Text);
                p.Price = Int32.Parse(this.PriceTextbox.Text);
                var requestJson = JsonConvert.SerializeObject(p);
                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
                var res = await cl.PostAsync("https://localhost:5001/Api/Payment/Add", content);
                var json = await res.Content.ReadAsStringAsync();
            }
            else
            {
                //更新の時
                _Record.Title = this.TitleTextbox.Text;
                _Record.Date = DateTime.Parse(this.DateTextbox.Text);
                _Record.Price = Int32.Parse(this.PriceTextbox.Text);
                var requestJson = JsonConvert.SerializeObject(_Record);
                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
                var res = await cl.PostAsync("https://localhost:5001/Api/Payment/Edit", content);
                var json = await res.Content.ReadAsStringAsync();
            }
            this.Close();
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var cl = new HttpClient();
            var requestJson = JsonConvert.SerializeObject(_Record);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var res = await cl.PostAsync("https://localhost:5001/Api/Payment/Delete", content);
            var json = await res.Content.ReadAsStringAsync();

            this.Deleted = true;

            this.Close();
        }
    }
}
