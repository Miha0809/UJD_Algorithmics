// Task 1 and 2
char[] letters = ['E', 'A', 'S', 'Y', 'Q', 'U', 'E', 'S', 'T', 'I', 'O', 'N'];
char[] lettersTask6 = (char[])letters.Clone();

// Task1And2.QuickSort(letters, letters.Length - 1);
// Task1And2.Show(letters);

// Task5
Task5.QuickSort(letters);

// Task6
Task6.QuickSort(lettersTask6, 0, lettersTask6.Length - 1);

// Task7
int[] numbers = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
Task17.CountingSort(numbers);

class Task1And2
{
    public static char[] QuickSort(char[] letters, int length, int leftIndex = 0)
    {
        var left = leftIndex;
        var right = length;
        var pivot = letters[leftIndex];

        while (left <= right)
        {
            while (letters[left] < pivot)
            {
                left++;
            }

            while (letters[right] > pivot)
            {
                right--;
            }

            if (left <= right)
            {
                (letters[left], letters[right]) = (letters[right], letters[left]);
                left++;
                right--;
            }
        }

        if (leftIndex < right)
        {
            QuickSort(letters, right, leftIndex);
        }

        if (left < length)
        {
            QuickSort(letters, length, left);
        }

        return letters;
    }

    public static void Show(char[] letters)
    {
        foreach (var item in letters)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }
}

class Task5
{
    private const int SMALL = 10;

    public static void QuickSort(char[] letters)
    {
        int length = letters.Length - 1;

        if (length <= SMALL)
        {
            SelectSort(letters, length);
            Task1And2.Show(letters);
            return;
        }

        Task1And2.QuickSort(letters, length);
        Task1And2.Show(letters);
    }

    private static void SelectSort(char[] letters, int length)
    {
        for (int i = 0; i < length; i++)
        {
            var minIndex = MinIndex(letters, i, length);
            (letters[i], letters[minIndex]) = (letters[minIndex], letters[i]);
        }
    }

    private static int MinIndex(char[] letters, int start, int length)
    {
        char min = char.MaxValue;
        int minIndex = 0;

        for (int i = start; i < length; i++)
        {
            if (letters[i] < min)
            {
                min = letters[i];
                minIndex = i;
            }
        }

        if (minIndex < start)
        {
            return start;
        }

        return minIndex;
    }
}

class Task6
{
    public static void QuickSort(char[] array, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            char pivot = MedianOfThree(array, left, mid, right);

            int i = left;
            int j = right;

            while (true)
            {
                while (array[i] < pivot) i++;
                while (array[j] > pivot) j--;

                if (i >= j)
                    break;

                (array[i], array[j]) = (array[j], array[i]);

                i++;
                j--;
            }

            QuickSort(array, left, j);
            QuickSort(array, j + 1, right);
        }

        Task1And2.Show(array);
    }

    public static char MedianOfThree(char[] array, int left, int mid, int right)
    {
        if (array[left] > array[mid])
        {
            (array[left], array[mid]) = (array[mid], array[left]);
        }

        if (array[left] > array[right])
        {
            (array[left], array[right]) = (array[right], array[left]);
        }

        if (array[mid] > array[right])
        {
            (array[mid], array[right]) = (array[right], array[right]);
        }

        return array[mid];
    }
}

class Task17
{
    public static void CountingSort(int[] numbers)
    {
        if (numbers.Length == 0)
        {
            return;
        }

        int min = numbers[0];
        int max = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
            else if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        int[] count = new int[max - min + 1];

        for (int i = 0; i < numbers.Length; i++)
        {
            count[numbers[i] - min]++;
        }

        int index = 0;

        for (int i = 0; i < count.Length; i++)
        {
            while (count[i] > 0)
            {
                numbers[index] = i + min;
                index++;
                count[i]--;
            }
        }

        Show(numbers);
    }

    private static void Show(int[] numbers)
    {
        foreach (var number in numbers)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
    }
}
