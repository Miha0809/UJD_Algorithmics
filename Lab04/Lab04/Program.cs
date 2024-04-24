// See https://aka.ms/new-console-template for more information

using System.Diagnostics.SymbolStore;

static void Task1(int n) {
    if (n <= 0)
    {
        return;
    }

    Console.WriteLine(n);
    
    Task1(n-2);
    Task1(n-3);
    
    Console.WriteLine(n);
}

static void Task2(int n) {
    if (n <= 0)
    {
        return;
    }
    
    Task2(n-3);
    Console.WriteLine(n);
    
    Task2(n-2);
    Console.WriteLine(n);
}

static void Task3(int n) {
    if (n <= 0) return;
    Task3(n-2);
    Task3(n-3);
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

Task11(2);
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