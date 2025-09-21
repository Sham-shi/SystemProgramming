using DZ_4;

var accountManager = new AccountManager("accounts.json");

// Создание и запуск нескольких потоков

//Thread thread1 = new Thread(() => accountManager.UpdateAccount("Иван", 100));
//Thread thread2 = new Thread(() => accountManager.UpdateAccount("Юлия", -50));
//Thread thread3 = new Thread(() => accountManager.UpdateAccount("Тимур", -30));
//Thread thread4 = new Thread(() => accountManager.UpdateAccount("Лейсан", 40));
//thread1.Start();
//thread2.Start();
//thread3.Start();
//thread4.Start();
//thread1.Join();
//thread2.Join();
//thread3.Join();
//thread4.Join();

Task task1 = new Task(() => accountManager.UpdateAccount("Иван", 100));
task1.Start();

Task task2 = Task.Factory.StartNew(() => accountManager.UpdateAccount("Юлия", -50));
Task task3 = Task.Factory.StartNew(() => accountManager.UpdateAccount("Тимур", -30));
Task task4 = Task.Run(() => accountManager.UpdateAccount("Лейсан", 40));

task1.Wait();
task2.Wait();
task3.Wait();
task4.Wait();

if (task1.IsCompletedSuccessfully &&  task2.IsCompletedSuccessfully &&
    task3.IsCompletedSuccessfully && task4.IsCompletedSuccessfully)
{
    Console.WriteLine("Обновления аккаунтов завершены.");
}
