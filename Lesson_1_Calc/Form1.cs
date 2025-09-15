using System.Diagnostics;
namespace Lesson_1_Calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            myProcess.StartInfo = new System.Diagnostics.ProcessStartInfo("calc.exe");
        }

        private void bt_Start_Click(object sender, EventArgs e)
        {
            myProcess.Start();
        }

        private void bt_Stop_Click(object sender, EventArgs e)
        {
            myProcess.CloseMainWindow();
            myProcess.Close();
        }
    }
}
