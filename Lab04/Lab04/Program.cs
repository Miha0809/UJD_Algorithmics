// See https://aka.ms/new-console-template for more information

static void Task1(int n)
{
    if (n <= 0)
    {
        return;
    }

    Console.WriteLine(n);

    Task1(n - 2);
    Task1(n - 3);

    Console.WriteLine(n);
}

static void Task2(int n)
{
    if (n <= 0)
    {
        return;
    }

    Task2(n - 3);
    Console.WriteLine(n);

    Task2(n - 2);
    Console.WriteLine(n);
}

static void Task3(int n)
{
    if (n <= 0) return;
    Task3(n - 2);
    Task3(n - 3);
    Console.WriteLine(n);
    Console.WriteLine(n);
}

// multiplication
static int Task4(int a, int b)
{
    if (b == 0)
    {
        return 0;
    }

    if (b % 2 == 0)
    {
        return Task4(a + a, b / 2);
    }

    return Task4(a + a, b / 2) + a;
}

// multiplication
static int Task5(int a, int b)
{
    if (b == 0)
    {
        return 0;
    }

    if (b % 2 == 0)
    {
        return Task5(a + a, b / 2);
    }

    return Task5(a + a, b / 2) + a;
}

// multiplication
static int Task6(int a, int b)
{
    if (b == 0)
    {
        return 0;
    }

    return a + Task6(a, b - 1);
}

// Nie wiem
static int Task7(int n)
{
    if (n == 0)
    {
        return 0;
    }

    if (n == 1)
    {
        return 1;
    }

    if (n == 2)
    {
        return 1;
    }

    return 2 * Task7(n - 2) + Task7(n - 3);
}

// IntToBinary(8);
static void IntToBinary(int decimalNumber)
{
    if (decimalNumber / 2 != 0)
    {
        IntToBinary(decimalNumber / 2);
    }

    Console.Write(decimalNumber % 2);
}

// Task9(5);
static void Task9(int width)
{
    for (int i = 0; i < width; i++)
    {
        for (int j = i; j < width; j++)
        {
            Console.Write('*');
        }

        Console.WriteLine(' ');
    }
}

// Task10(5);
static void Task10(int width)
{
    for (int i = 0; i <= width; i++)
    {
        for (int j = 0; j < i; j++)
        {
            Console.Write('*');
        }

        Console.WriteLine(' ');
    }
}

// Task11(2);
static void Task11(int n)
{
    Console.WriteLine("First: " + First(n));

    double First(int n)
    {
        if (n == 0)
        {
            return 0;
        }

        var suma = (1 / Math.Pow(n, 2));

        return suma + First(n - 1);
    }

    Console.WriteLine("Second: " + Second(n));

    int Second(int n)
    {
        if (n == 0)
        {
            return 0;
        }

        return n + Second(n - 1);
    }

    Console.WriteLine("Third: " + Third(n));

    int Third(int n)
    {
        if (n < 0)
        {
            return 0;
        }

        return (2 * n) + Third(n - 1);
    }
}

static double GoldenSection(int n)
{
    if (n <= 0)
    {
        return 1;
    }

    return (1 + 1) / GoldenSection(n - 1);
}

static double Task13(int n)
{
    if (n <= 1)
    {
        return -1;
    }

    return -GoldenSection(n - 1) * n - 3;
}

static void Task14(int length)
{
    var number = 0;

    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j <= i; j++)
        {
            if (i == 0 || j == 0)
            {
                number = 1;
            }
            else
            {
                number = number * (i - j + 1) / j;
            }

            Console.Write(number + " ");
        }

        Console.WriteLine();
    }
}

static int binaryNDW(int p, int q)
{
    if (q == 0)
    {
        return p;
    }

    if (p == 0)
    {
        return q;
    }

    if ((p % 2 == 0) && (q % 2 == 0))
    {
        return 2 * binaryNDW(p / 2, q / 2);
    }

    if ((p % 2 == 0) && (q % 2 != 0))
    {
        return binaryNDW(p / 2, q);
    }

    if ((p % 2 != 0) && (q % 2 == 0))
    {
        return binaryNDW(p, q / 2);
    }

    if (((p % 2 != 0) && (q % 2 != 0)) && (p >= q))
    {
        return binaryNDW((p - q) / 2, q);
    }

    if (((p % 2 != 0) && (q % 2 != 0)) && (p >= q))
    {
        return binaryNDW(p, (p - q) / 2);
    }

    throw new ArgumentException("The condition does not exist");
}

static void ShowArray(int[] numbers)
{
    foreach (var number in numbers)
    {
        Console.Write(number + " ");
    }

    Console.WriteLine();
}

static void Task16(int[] numbers, int end, int start = 0)
{
    if (start < end)
    {
        (numbers[start], numbers[end]) = (numbers[end], numbers[start]);
        Task16(numbers, end - 1, start + 1);
    }
}
int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
Task16(numbers, numbers.Length - 1);
ShowArray(numbers);

static bool Task17(int[] numbers, int searchNumber, int end, int start = 0)
{
    if (end >= start)
    {
        int middle = start + (end - start) / 2;

        if (numbers[middle] == searchNumber)
        {
            return true;
        }

        if (searchNumber < numbers[middle])
        {
            return Task17(numbers, searchNumber, middle);
        }

        if (searchNumber > numbers[middle])
        {
            return Task17(numbers, searchNumber, numbers.Length - 1, middle);
        }
    }

    return false;
}

int[] num = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];
Console.WriteLine(Task17(num, 1, num.Length - 1));
