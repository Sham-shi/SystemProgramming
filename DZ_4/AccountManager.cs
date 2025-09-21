using Newtonsoft.Json;
using System.Threading;

namespace DZ_4;

public class AccountManager
{
    private readonly string _filePath;
    private readonly object _lockObject = new object(); // Для lock и Monitor
    private readonly Mutex _mutex = new Mutex(); // Для Mutex
    private readonly Semaphore _semaphore = new Semaphore(1, 1); // Для Semaphore

    public AccountManager(string filePath)
    {
        _filePath = filePath;
    }

    public void UpdateAccount(string clientName, decimal amount)
    {
        // пример использования lock
        lock (_lockObject)
        {
            UpdateAccountInternal(clientName, amount);
        }

        //// пример использования Monitor
        //Monitor.Enter(_lockObject);
        //try
        //{
        //    UpdateAccountInternal(clientName, amount);
        //}
        //finally
        //{
        //    Monitor.Exit(_lockObject);
        //}

        //// пример использования Mutex
        //_mutex.WaitOne();
        //try
        //{
        //    UpdateAccountInternal(clientName, amount);
        //}
        //finally
        //{
        //    _mutex.ReleaseMutex();
        //}

        //// пример использования Semaphore
        //_semaphore.WaitOne();
        //try
        //{
        //    UpdateAccountInternal(clientName, amount);
        //}
        //finally
        //{
        //    _semaphore.Release();
        //}

        //// пример использования WaitHandle (для ожидания)
        //using (var waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset))
        //{
        //    // Здесь можно сделать что-то, что требует ожидания
        //    waitHandle.Set(); // Сигнализировать о завершении
        //}
    }

    private void UpdateAccountInternal(string clientName, decimal amount)
    {
        var accounts = LoadAccounts();

        if (accounts.ContainsKey(clientName))
        {
            accounts[clientName].Balance += amount;
        }
        else
        {
            accounts[clientName] = new ClientAccount { Name = clientName, Balance = amount };
        }
        SaveAccounts(accounts);
    }

    private Dictionary<string, ClientAccount> LoadAccounts()
    {
        if (!File.Exists(_filePath))
        {
            var initialAccounts = new Dictionary<string, ClientAccount>()
            {
                { "Иван", new ClientAccount {Name = "Иван", Balance = 1000m } },
                { "Юлия", new ClientAccount {Name = "Юлия", Balance = 2000m } },
                { "Тимур", new ClientAccount {Name = "Тимур", Balance = 500m } },
                { "Лейсан", new ClientAccount {Name = "Лейсан", Balance = 1500m } },
                { "Пётр", new ClientAccount {Name = "Пётр", Balance = 90m } }
            };

            SaveAccounts(initialAccounts);
            return initialAccounts;
        }

        var json = File.ReadAllText(_filePath);

        return JsonConvert.DeserializeObject<Dictionary<string, ClientAccount>>(json);
    }

    public void SaveAccounts(Dictionary<string, ClientAccount> accounts)
    {
        var json = JsonConvert.SerializeObject(accounts, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }
}