const int LENGTH = 256;
int[] numbersIdentical = new int[LENGTH];
int[] numbersReverse = new int[LENGTH];

InitIdenticalArray(numbersIdentical);
InitReverseArray(numbersReverse);

// Task1
int[] numbersIdenticalSelect = (int[])numbersIdentical.Clone();
int[] numbersIdenticalInsert = (int[])numbersIdentical.Clone();
int[] numbersIdenticalBubble = (int[])numbersIdentical.Clone();
int[] numbersIdenticalCoctail = (int[])numbersIdentical.Clone();

var startTimeInsert = DateTime.UtcNow;
Task1And2.InsertSort(numbersIdenticalInsert);
var endTimeInsert = DateTime.UtcNow;

var startTimeSelect = DateTime.UtcNow;
Task1And2.SelectSort(numbersIdenticalSelect);
var endTimeSelect = DateTime.UtcNow;

var startTimeBubble = DateTime.UtcNow;
Task1And2.BubbleSort(numbersIdenticalBubble);
var endTimeBubble = DateTime.UtcNow;

var startTimeCoctail = DateTime.UtcNow;
Task3.CoctailSort(numbersIdenticalCoctail);
var endTimeCoctail = DateTime.UtcNow;

Console.WriteLine("Identical Insert: " + (endTimeInsert - startTimeInsert));
Console.WriteLine("Identical Select: " + (endTimeSelect - startTimeSelect));
Console.WriteLine("Identical Bubble: " + (endTimeBubble - startTimeBubble));
Console.WriteLine("Identical Coctail: " + (endTimeCoctail - startTimeCoctail));

Console.WriteLine();

// Task2
int[] numbersReverseInsert = (int[])numbersReverse.Clone();
int[] numbersReverseSelect = (int[])numbersReverse.Clone();
int[] numbersReverseBubble = (int[])numbersReverse.Clone();

startTimeInsert = DateTime.UtcNow;
Task1And2.InsertSort(numbersReverseInsert);
endTimeInsert = DateTime.UtcNow;

startTimeSelect = DateTime.UtcNow;
Task1And2.SelectSort(numbersReverseSelect);
endTimeSelect = DateTime.UtcNow;

startTimeBubble = DateTime.UtcNow;
Task1And2.BubbleSort(numbersReverseBubble);
endTimeBubble = DateTime.UtcNow;

Console.WriteLine("Reverse Insert: " + (endTimeInsert - startTimeInsert));
Console.WriteLine("Reverse Select: " + (endTimeSelect - startTimeSelect));
Console.WriteLine("Reverse Bubble: " + (endTimeBubble - startTimeBubble));

// Task3
int[] numbersReverseCoctail = (int[])numbersReverse.Clone();

startTimeCoctail = DateTime.UtcNow;
Task3.CoctailSort(numbersReverseCoctail);
endTimeCoctail = DateTime.UtcNow;

Console.WriteLine("Reverse Coctail: " + (endTimeCoctail - startTimeCoctail));

// Task4
Task4.Task4.Init();

// Task5
Task5.Task5.Init();

void InitReverseArray(int[] numbers)
{
  for (int i = 0, j = numbers.Length - 1; i < numbers.Length; i++, j--)
  {
    numbers[i] = j;
  }
}

void InitIdenticalArray(int[] numbers)
{
  for (int i = 0; i < numbers.Length; i++)
  {
    numbers[i] = 1;
  }
}

class Task1And2
{
  public static void SelectSort(int[] numbers)
  {
    for (int i = 0; i < numbers.Length; i++)
    {
      var minIndex = MinIndex(numbers, i, numbers.Length);
      (numbers[i], numbers[minIndex]) = (numbers[minIndex], numbers[i]);
    }
  }

  private static int MinIndex(int[] numbers, int start, int length)
  {
    int min = int.MaxValue;
    int minIndex = 0;

    for (int i = 0; i < length; i++)
    {
      if (min < numbers[i])
      {
        min = numbers[i];
        minIndex = i;
      }
    }

    if (minIndex < start)
    {
      return start;
    }

    return minIndex;
  }

  public static void InsertSort(int[] numbers)
  {
    for (int i = 1; i < numbers.Length; ++i)
    {
      int key = numbers[i];
      int j = i - 1;

      while (j >= 0 && numbers[j] > key)
      {
        numbers[j + 1] = numbers[j];
        j = j - 1;
      }

      numbers[j + 1] = key;
    }
  }

  public static void BubbleSort(int[] numbers)
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
  }
}

class Task3
{
  public static void CoctailSort(int[] numbers)
  {
    var swapped = true;
    int start = 0;
    int end = numbers.Length;

    while (swapped)
    {
      swapped = false;

      for (int i = start; i < end - 1; i++)
      {
        if (numbers[i] > numbers[i + 1])
        {
          (numbers[i], numbers[i + 1]) = (numbers[i + 1], numbers[i]);
          swapped = true;
        }
      }

      if (!swapped)
      {
        break;
      }

      swapped = false;

      end--;

      for (int i = end - 1; i >= start; i--)
      {
        if (numbers[i] > numbers[i + 1])
        {
          (numbers[i], numbers[i + 1]) = (numbers[i + 1], numbers[i]);
          swapped = true;
        }
      }

      start++;
    }
  }
}
