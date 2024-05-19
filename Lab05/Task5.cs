namespace Task5;

class Task5
{
  public static void Init()
  {
    const int LENGTH = 256;
    int[] numbers = new int[LENGTH];

    InitArray(numbers, LENGTH);

    int[] numbersForNaive = (int[])numbers.Clone();
    int[] numbersForDivide = (int[])numbers.Clone();

    var startNaiveTime = DateTime.UtcNow;
    NaiveMinMax(numbersForNaive);
    var endNaiveTime = DateTime.UtcNow;

    var startDivideTime = DateTime.UtcNow;
    FindMinMaxDivideAndConquer(numbersForNaive, 0, numbersForDivide.Length - 1);
    var endDivideTime = DateTime.UtcNow;

    Console.WriteLine("\n\nNaive time: " + (endNaiveTime - startNaiveTime));
    Console.WriteLine("Divide time: " + (endDivideTime - startNaiveTime));
  }

  private static void InitArray(int[] numbers, int length)
  {
    for (int i = 0; i < length; i++)
    {
      var random = new Random().Next(0, numbers.Length + 1);
      numbers[i] = random;
    }
  }

  public static (int, int) NaiveMinMax(int[] numbers)
  {
    int min = int.MaxValue;
    int max = int.MinValue;

    foreach (var number in numbers)
    {
      if (number < min)
      {
        min = number;
      }

      if (number > max)
      {
        max = number;
      }
    }

    return (min, max);
  }

  public static (int min, int max) FindMinMaxDivideAndConquer(int[] arr, int left, int right)
  {
    if (left == right)
    {
      return (arr[left], arr[left]);
    }

    if (right == left + 1)
    {
      if (arr[left] < arr[right])
      {
        return (arr[left], arr[right]);
      }
      else
      {
        return (arr[right], arr[left]);
      }
    }

    int mid = left + (right - left) / 2;
    var leftResult = FindMinMaxDivideAndConquer(arr, left, mid);
    var rightResult = FindMinMaxDivideAndConquer(arr, mid + 1, right);

    int min = Math.Min(leftResult.min, rightResult.min);
    int max = Math.Max(leftResult.max, rightResult.max);

    return (min, max);
  }
}
