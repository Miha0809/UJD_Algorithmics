while (true)
{
    Console.WriteLine("\t\tNAVIGATION");
    Console.WriteLine("Task 1 - enter 1");
    Console.WriteLine("Task 2 - enter 2");
    Console.WriteLine("Task 3 - enter 3");
    Console.WriteLine("Task 4 - enter 4");
    Console.WriteLine("Task 5 - enter 5");
    Console.WriteLine("Task 6 - enter 6");
    Console.WriteLine("Task 7 - enter 7");
    Console.WriteLine("Task 8 - enter 8");
    Console.WriteLine("Task 9 - enter 9");
    Console.WriteLine("Task 10 - enter 10");
    Console.WriteLine("Other - EXIT");
    Console.Write(">>> ");
    int.TryParse(Console.ReadLine(), out var task);
    
    switch(task)
    {
        case 1: Console.WriteLine(Find([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 4));
            break;
        case 2: Console.WriteLine(Find([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 41));
            break;
        case 3: Console.WriteLine(FindBin([9, 4, 2, 1, 3, 8, 6, 7], 7));
            break;
        case 4: Reverse([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
            break;
        case 5: Console.WriteLine(Max([10, 2, 425, 3, 1, 999, 0]));
            break;
        case 6: Remove([1, 2, 3, 4, 5], 3);
            break;
        case 7: Console.WriteLine(Average([-1, 4, 6, 9, -5, -1, -3, 2]));
            break;
        case 8: Console.WriteLine(Even([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]));
            break;
        case 9: Console.WriteLine(Odd([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]));
            break;
        case 10: Console.WriteLine(NumberInstances([1, 2, 3, 4, 5, 6, 7, 8, 3, 9, 10, 3], 4));
            break;
        default:
            return;
    };
}

static bool Find(long[] numbers, long key)
{
    foreach (var number in numbers)
    {
        if (number.Equals(key))
        {
            return true;
        }
    }

    return false;
}

static bool FindBin(long[] numbers, long key)
{
    numbers = Sort(numbers);
    int min = 0;
    int max = numbers.Length - 1;

    while (min <= max)
    {
        int mid = (min + max) / 2;

        if (key == numbers[mid])
        {
            return true;
        }
        else if (key < numbers[mid])
        {
            max = mid - 1;
        }
        else
        {
            min = mid + 1;
        }
    }

    return false;
}

static long[] Sort(long[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        for (int j = i + 1; j < numbers.Length; j++)
        {
            if (numbers[i] > numbers[j])
            {
                (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
            }
        }
    }

    return numbers;
}

static void Reverse(long[] numbers)
{
    int lastIndex = numbers.Length;
    
    for (int i = 0; i < numbers.Length / 2; i++)
    {
        (numbers[i], numbers[lastIndex - i - 1]) = (numbers[lastIndex - i - 1], numbers[i]);
    }

    foreach (var number in numbers)
    {
        Console.WriteLine(number);
    }
}

static long Max(long[] numbers)
{
    var max = long.MinValue;

    foreach (var number in numbers)
    {
        if (max < number)
        {
            max = number;
        }
    }

    return max;
}

static long Min(long[] numbers)
{
    var min = long.MaxValue;

    foreach (var number in numbers)
    {
        if (min < number)
        {
            min = number;
        }
    }

    return min;
}

static void Remove(long[] numbers, long key)
{
    var numbersRemove = new long[numbers.Length - 1];
    var indexNumbers = 0;
    var indexNumbersRemove = 0;

    while (indexNumbersRemove != numbers.Length - 1)
    {
        if (numbers[indexNumbers] != key)
        {
            numbersRemove[indexNumbersRemove] = numbers[indexNumbers];
            indexNumbersRemove++;
        }

        indexNumbers++;
    }

    foreach (var number in numbersRemove)
    {
        Console.WriteLine(number);
    }
}

static long Average(long[] numbers)
{
    var countPositive = 0L;
    var sumaPositive = 0L;

    foreach (var number in numbers)
    {
        if (number >= 0)
        {
            countPositive++;
            sumaPositive += number;
        }
    }

    return sumaPositive / countPositive;
}

static int Even(long[] numbers)
{
    var count = 0;

    foreach (var number in numbers)
    {
        if (number % 2 == 0)
        {
            count++;
        }
    }

    return count;
}

static int Odd(long[] numbers)
{
    var count = 0;

    foreach (var number in numbers)
    {
        if (number % 2 != 0)
        {
            count++;
        }
    }

    return count;
}

static int NumberInstances(long[] numbers, long key)
{
    var count = 0;
    
    foreach (var number in numbers)
    {
        if (number == key)
        {
            count++;
        }
    }

    return count;
}