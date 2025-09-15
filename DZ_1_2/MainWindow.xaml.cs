using System.Diagnostics;
using System.Windows;

namespace DZ_1_2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Process proc;

    public MainWindow()
    {
        InitializeComponent();

        proc = new Process();
        proc.StartInfo.FileName = "notepad.exe";
    }

    private void bt_Start_Click(object sender, RoutedEventArgs e)
    {
        proc.Start();
        bt_Stop.IsEnabled = true;
        bt_WaitForExit.IsEnabled = true;
    }

    private void bt_Stop_Click(object sender, RoutedEventArgs e)
    {
        proc.CloseMainWindow();
        proc.Close();

        MessageBox.Show($"Процесс завершился принудительно");

        bt_Stop.IsEnabled = false;
        bt_WaitForExit.IsEnabled = false;
    }

    private void bt_WaitForExit_Click(object sender, RoutedEventArgs e)
    {
        proc.WaitForExit();

        MessageBox.Show($"Процесс завершился с кодом: {proc.ExitCode}");

        bt_WaitForExit.IsEnabled = false;
        bt_Stop.IsEnabled = false;
    }
}