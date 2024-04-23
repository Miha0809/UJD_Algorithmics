// See https://aka.ms/new-console-template for more information

int[] numbers = [4, 5, 6, 7, 8, 9, 10, 0, 1, 2, -3, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];

var task1 = new Task1(numbers);
task1.Show();

Console.WriteLine();

Console.WriteLine(Problem4Sum(numbers));

Console.WriteLine();

Console.WriteLine(FindLocalMin(numbers));

static bool Problem4Sum(int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        for (int j = i + 1; j < numbers.Length; j++)
        {
            for (int k = j + 1; k < numbers.Length; k++)
            {
                for (int m = k + 1; m < numbers.Length; m++)
                {
                    if (numbers[i] + numbers[j] + numbers[k] + numbers[m] == 0)
                    {
                        return true;
                    }
                }
            }
        }
    }

    return false;
}

static int FindLocalMin(int[] arr)
{
    int left = 0;
    int right = arr.Length - 1;

    while (left <= right)
    {
        int mid = left + (right - left) / 2;

        if ((mid == 0 || arr[mid] < arr[mid - 1]) && (mid == arr.Length - 1 || arr[mid] < arr[mid + 1]))
        {
            return arr[mid];
        }

        if (mid > 0 && arr[mid - 1] < arr[mid])
        {
            right = mid - 1;
        }
        else
        {
            left = mid + 1;
        }
    }

    throw new InvalidOperationException("Local min not found");
}

class Task1
{
    public int[] Numbers { get; }

    private readonly int length;

    public Task1(int[] numbers)
    {
        Numbers = numbers;
        length = Numbers.Length;
    }

    public void Show()
    {
        Console.WriteLine("First: " + First());
        Console.WriteLine("Second: " + Second());
        Console.WriteLine("Third: " + Third());
    }

    private int First()
    {
        int sum = 0;
        
        for (int n = length; n > 0; n /= 2)
        {
            for (int i = 0; i < n; i++)
            {
                sum++;
            }
        }

        return sum;
    }

    private int Second()
    {
        int sum = 0;
        
        for (int i = 1; i < length; i *= 2)
        {
            for (int j = 0; j < i; j++)
            {
                sum++;
            }
        }

        return sum;
    }

    private int Third()
    {
        int sum = 0;
        
        for (int i = 1; i < length; i *= 2)
        {
            for (int j = 0; j < length; j++)
            {
                sum++;
            }
        }

        return sum;
    }
}