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

namespace DbAccessWpfApp
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
            var textbox1_Value = this.Textbox1.Text;
            var textbox2_Value = this.Textbox2.Text;
            var number1 = Int32.Parse(textbox1_Value);
            var number2 = Int32.Parse(textbox2_Value);

            var result = number1 * number2;
            MessageBox.Show(result.ToString());
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            var s = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");

        }
    }
}
