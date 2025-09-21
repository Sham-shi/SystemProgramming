using System.Collections.Concurrent;
using System.Diagnostics;

//Array36. Дан массив размера N.
//Найти максимальный из его элементов, не являющихся ни локальным минимумом, ни локальным максимумом
//локальный минимум - это элемент, который меньше любого из своих соседей
//локальный максимум - это элемент, который больше любого из своих соседей

var random = new Random();
//int[] sizes = { 1_000_000, 100_000_000, 1_000_000_000 };
int[] sizes = { 100_000, 10_000_000, 100_000_000 };

for (int i = 0; i < sizes.Length; i++)
{
    int[] nums = Enumerable.Range(0, sizes[i]).Select(x => random.Next(-1000, 1000)).ToArray();

    var watch = Stopwatch.StartNew();
    var elementsFromFor = GetMaxElementFromFor(nums);
    watch.Stop();

    var watchForParallel = Stopwatch.StartNew();
    var elementsFromParallelForeach = GetMaxElementFromParallelFor(nums);
    watchForParallel.Stop();

    Console.WriteLine($"Размер массива: {sizes[i]}");
    Console.WriteLine($"Обычный метод: максимальный элемент {elementsFromFor} | Время: {watch.ElapsedMilliseconds} ms.");
    Console.WriteLine($"Параллельный метод: максимальный элемент {elementsFromParallelForeach} | Время: {watchForParallel.ElapsedMilliseconds} ms.");
    Console.WriteLine("-------------------------------------------------------------------------------------------");
}

static bool IsLocalMin(int[] numbers, int index)
{
    if (index == 0)
    {
        return numbers[0] < numbers[1];
    }

    if (index == numbers.Length - 1)
    {
        return numbers[^1] < numbers[^2];
    }

    return (numbers[index] < numbers[index + 1]) && (numbers[index] < numbers[index - 1]);
}

static bool IsLocalMax(int[] numbers, int index)
{
    if (index == 0)
    {
        return numbers[0] > numbers[1];
    }

    if (index == numbers.Length - 1)
    {
        return numbers[^1] > numbers[^2];
    }

    return (numbers[index] > numbers[index + 1]) && (numbers[index] > numbers[index - 1]);
}

static int GetMaxElementFromFor(int[] numbers)
{
    var max = numbers[0];
    for (int i = 1; i < numbers.Length - 1; i++)
    {
        if (!IsLocalMin(numbers, i) && !IsLocalMax(numbers, i))
        {
            if (max < numbers[i])
            {
                max = numbers[i];
            }
        }
    }

    return max;
}

static int GetMaxElementFromParallelFor(int[] numbers)
{
    var res = new ConcurrentBag<int>();

    Parallel.For(0, numbers.Length, i =>
    {
        if (!IsLocalMin(numbers, i) && !IsLocalMax(numbers, i))
        {
            res.Add(numbers[i]);
        }
    });

    return res.Max();
}
