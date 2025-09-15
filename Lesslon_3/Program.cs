using System.Runtime.InteropServices;

//ввести целое положительное число,
//если не соответствует - проиграть мелодию Windows и вывести MessageBox



[DllImport("user32.dll", CharSet = CharSet.Unicode)]
static extern int MessageBoxW(IntPtr hWnd, string lpText, string lpCaption, uint uType);

[DllImport("user32.dll")]
static extern bool MessageBeep(uint uType);

const int MB_OK = 0x00000000;
const int MB_OKCANCEL = 0x00000001;
const uint MB_ICONERROR = 0x00000010;
const uint MB_ICONQUESTION = 0x00000020;
const uint MB_ICONWARNING = 0x00000030;
const uint MB_ICONINFORMATION = 0x00000040;


Console.WriteLine("Введите число: ");
var num = Console.ReadLine();

int.TryParse(num, out int res);

if (res % 2 == 0)
{
    MessageBeep(MB_ICONINFORMATION);

    MessageBoxW(IntPtr.Zero, $"Число {res} чётное!", "Успех", MB_OK | MB_ICONINFORMATION);
}
else
{
    MessageBoxW(IntPtr.Zero, $"Число {res} не чётное!", "Ошибка", MB_OK | MB_ICONERROR);
}