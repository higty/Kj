using System;
using System.Collections.Generic;
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

namespace DbAccessWpfApp2
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

        /// <summary>
        /// 保守性
        /// 可読性
        /// 堅牢性
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var connectionString = File.ReadAllText("C:\\Study\\ConnectionString_Kj_Wpf.txt");

            var query1 = String.Format("insert into MDumpCar(CarCD,DisplayName,CreateTime,LoadCapacity,ProductCode,Price)"
                + "values(NEWID(), '{0}', GETDATE(), {1}, '{2}', {3})"
                , this.DisplayNameTextbox.Text, this.LoadCapacityTextbox.Text, this.ProductCodeTextbox.Text, this.PriceTextbox.Text);

            var db = new Database();
            db.ConnectionString = connectionString;
            db.ExecuteNonQuery(query1);

            MessageBox.Show("追加しました！");
        }
    }
}
