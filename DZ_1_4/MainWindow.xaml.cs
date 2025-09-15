using Microsoft.Win32;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DZ_1_4
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

        private void bt_Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (ofd.ShowDialog() == true)
            {
                tbx_FilePath.Text = ofd.FileName;
            }
        }

        private void bt_Search_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbx_FilePath.Text) || string.IsNullOrWhiteSpace(tbx_SearchWord.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            var filePath = tbx_FilePath.Text;
            var searchWord = tbx_SearchWord.Text;

            var command =
                $@"
                    if (Test-Path '{filePath}') {{
                        $count = (Select-String -Path '{filePath}' -Pattern '{searchWord}' -AllMatches).Count
                        Write-Host 'File: {filePath}'
                        Write-Host 'The search word: {searchWord}'
                        Write-Host 'Matches found: ' $count
                    }} else {{
                        Write-Host 'Error: File not found!'
                    }}
                ";

            ProcessStartInfo search = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"{command}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WorkingDirectory = Environment.CurrentDirectory,
            };

            using (Process process = Process.Start(search))
            {
                var res = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(error))
                {
                    tbk_Result.Text = $"ОШИБКА:\n{error}\n\nВЫВОД:\n{res}";
                }
                else
                {
                    tbk_Result.Text = res;
                }
            }
        }

        private string EncodingUTFto1251(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            byte[] newBytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(866), bytes);
            string newStr = Encoding.GetEncoding(1251).GetString(newBytes);

            return newStr;
        }
    }
}