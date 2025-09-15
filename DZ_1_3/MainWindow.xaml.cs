using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Core.Input;

namespace DZ_1_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Process process;
        private ProcessStartInfo calculate;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (dud_Num1.Text != null && dud_Num2.Text != null && cbx_Operation.SelectedItem != null)
            {
                double.TryParse(dud_Num1.Text, out double num1);
                double.TryParse(dud_Num2.Text, out double num2);
                var operation = ((ComboBoxItem)cbx_Operation.SelectedItem).Content.ToString();

                var command = $"{num1} {operation} {num2}";

                calculate = new()
                {
                    FileName = "powershell.exe",
                    Arguments = $"{command}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
            }

            using (process = Process.Start(calculate))
            {
                var res = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                tbk_Result.Text = res.Trim();
            }
        }
    }
}