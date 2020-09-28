using DbAccessDatabase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DbAccessWpfApp5
{
    /// <summary>
    /// EditRecordWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class EditRecordWindow : Window
    {
        public EditRecordWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
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

            //DBへInsert
            var r = new PaymentRecord();
            r.Title = this.TitleTextbox.Text;
            r.Date = date;
            r.Price = price;

            var db = new Database();
            db.ConnectionString = System.IO.File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            db.Insert(r);

            this.Close();
        }
    }
}
