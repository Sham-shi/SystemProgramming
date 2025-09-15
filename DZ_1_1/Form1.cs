using System.Diagnostics;

namespace DZ_1_1;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void bt_Start_Click(object sender, EventArgs e)
    {
        Process proc = new Process();
        proc.StartInfo.FileName = "notepad.exe";
        proc.Start();

        MessageBox.Show($"Запущен процесс: {proc.ProcessName}");

        proc.WaitForExit();

        MessageBox.Show($"Процесс завершился с кодом: {proc.ExitCode}");

        MessageBox.Show($"Текущий процесс имеет имя: {Process.GetCurrentProcess()}");
    }
}
