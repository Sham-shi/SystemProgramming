using System.Diagnostics;

//Process proc  = new Process();
//proc.StartInfo.FileName = "notepad.exe";
//proc.Start();

//Console.WriteLine("Запущен процесс: " + proc.ProcessName);

//proc.WaitForExit();

//Console.WriteLine("Процесс завершился с кодом: " + proc.ExitCode);

//Console.WriteLine("Текущий процесс имеет имя: " + Process.GetCurrentProcess().ProcessName);

//-----------------------------------------------------------------------------------------------

Console.Title = "Список процессов";

Console.WindowWidth = 40;
Console.BufferWidth = 40;

Process[] processes = Process.GetProcesses();

Console.WriteLine(" {0,-28}{1,-10}", "Имя процесса: ","PID: ");

foreach (Process p in processes)
{
    Console.Write(" {0,-28}{1,-10}", p.ProcessName, p.Id);
}
