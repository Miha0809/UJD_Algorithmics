using System.Numerics;

namespace Task4;

interface IItem : IComparable<IItem>
{
}

public class NumberItem<T> : IItem where T : INumber<T>
{
  public T Value { get; set; }

  public NumberItem(T value)
  {
    Value = value;
  }

  int IComparable<IItem>.CompareTo(IItem? other)
  {
    if (other is NumberItem<T>)
    {
      return Value.CompareTo(((NumberItem<T>)other).Value);
    }

    return int.MinValue;
  }

  public override string ToString()
  {
    return $"({typeof(T)}) Value: {Value}\n";
  }
}

public class StringItem : IItem
{
  public string Value { get; set; }

  public StringItem(string value)
  {
    this.Value = value;
  }

  int IComparable<IItem>.CompareTo(IItem? other)
  {
    if (other is StringItem)
    {
      return Value.Length.CompareTo(((StringItem)other).Value.Length);
    }

    return int.MinValue;
  }

  public override string ToString()
  {
    return $"(string) Value: {Value}\n";
  }
}

class Student : IItem
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public int Age { get; set; }

  public Student(string firstName, string lastName, int age)
  {
    FirstName = firstName;
    LastName = lastName;
    Age = age;
  }

  int IComparable<IItem>.CompareTo(IItem? other)
  {
    if (other is Student)
    {
      return Age.CompareTo(((Student)other).Age);
    }

    return int.MinValue;
  }

  public override string ToString()
  {
    return $"FirstName: {FirstName}\n" +
           $"LastName: {LastName}\n" +
           $"Age: {Age}\n";
  }
}

public class Task4
{
  public static void Init()
  {
    IItem[] ints = {
      new NumberItem<int>(7),
      new NumberItem<int>(6),
      new NumberItem<int>(5),
      new NumberItem<int>(4),
      new NumberItem<int>(3),
      new NumberItem<int>(2),
      new NumberItem<int>(1),
      new NumberItem<int>(0),
    };

    IItem[] doubles = {
      new NumberItem<double>(7.5),
      new NumberItem<double>(6.5),
      new NumberItem<double>(5.5),
      new NumberItem<double>(4.5),
      new NumberItem<double>(3.5),
      new NumberItem<double>(2.5),
      new NumberItem<double>(1.5),
      new NumberItem<double>(0.5),
    };

    IItem[] strings = {
      new StringItem("12345"),
      new StringItem("1234"),
      new StringItem("123"),
      new StringItem("12"),
      new StringItem("1"),
    };

    IItem[] students = {
      new Student("A", "A", 20),
      new Student("B", "B", 19),
      new Student("C", "C", 18),
      new Student("D", "D", 17),
      new Student("E", "E", 16),
    };

    Ints(ints);
    Doubles(doubles);
    Strings(strings);
    Students(students);
  }

  private static void Ints(IItem[] ints)
  {
    var intsSelect = (IItem[])ints.Clone();

    Console.WriteLine("\n\tBefore intsSelect");
    Show(intsSelect);
    SelectSort(intsSelect);
    Console.WriteLine("\tAfter intsSelect");
    Show(intsSelect);

    var intsInsert = (IItem[])ints.Clone();

    Console.WriteLine("\n\tBefore intsInsert");
    Show(intsInsert);
    InsertSort(intsInsert);
    Console.WriteLine("\tAfter intsInsert");
    Show(intsInsert);

    var intsBubble = (IItem[])ints.Clone();

    Console.WriteLine("\n\tBefore intsBubble");
    Show(intsBubble);
    BubbleSort(intsBubble);
    Console.WriteLine("\tAfter intsBubble");
    Show(intsBubble);
  }

  private static void Doubles(IItem[] doubles)
  {
    var doublesSelect = (IItem[])doubles.Clone();

    Console.WriteLine("\n\tBefore doublesSelect");
    Show(doublesSelect);
    SelectSort(doublesSelect);
    Console.WriteLine("\tAfter doublesSelect");
    Show(doublesSelect);

    var doublesInsert = (IItem[])doubles.Clone();

    Console.WriteLine("\n\tBefore doublesInsert");
    Show(doublesInsert);
    InsertSort(doublesInsert);
    Console.WriteLine("\tAfter doublesInsert");
    Show(doublesInsert);

    var doublesBubble = (IItem[])doubles.Clone();

    Console.WriteLine("\n\tBefore doublesBubble");
    Show(doublesBubble);
    BubbleSort(doublesBubble);
    Console.WriteLine("\tAfter doublesBubble");
    Show(doublesBubble);
  }

  private static void Strings(IItem[] strings)
  {
    var stringsSelect = (IItem[])strings.Clone();

    Console.WriteLine("\n\tBefore stringsSelect");
    Show(stringsSelect);
    SelectSort(stringsSelect);
    Console.WriteLine("\tAfter stringsSelect");
    Show(stringsSelect);

    var stringsInsert = (IItem[])strings.Clone();

    Console.WriteLine("\n\tBefore stringsInsert");
    Show(stringsInsert);
    InsertSort(stringsInsert);
    Console.WriteLine("\tAfter stringsInsert");
    Show(stringsInsert);

    var stringsBubble = (IItem[])strings.Clone();

    Console.WriteLine("\n\tBefore stringsBubble");
    Show(stringsBubble);
    BubbleSort(stringsBubble);
    Console.WriteLine("\tAfter stringsBubble");
    Show(stringsBubble);
  }

  private static void Students(IItem[] students)
  {
    var studentsSelect = (IItem[])students.Clone();

    Console.WriteLine("\n\tBefore studentsSelect");
    Show(studentsSelect);
    SelectSort(studentsSelect);
    Console.WriteLine("\tAfter studentsSelect");
    Show(studentsSelect);

    var studentsInsert = (IItem[])students.Clone();

    Console.WriteLine("\n\tBefore studentsInsert");
    Show(studentsInsert);
    InsertSort(studentsInsert);
    Console.WriteLine("\tAfter studentsInsert");
    Show(studentsInsert);

    var studentsBubble = (IItem[])students.Clone();

    Console.WriteLine("\n\tBefore studentsBubble");
    Show(studentsBubble);
    BubbleSort(studentsBubble);
    Console.WriteLine("\tAfter studentsBubble");
    Show(studentsBubble);
  }

  private static void Show<T>(T[] array)
  {
    foreach (var item in array)
    {
      Console.Write(item + " ");
    }
  }

  private static void SelectSort<T>(T[] array) where T : IComparable<T>
  {
    for (int i = 0; i < array.Length; i++)
    {
      var minIndex = MinIndex(array, i);
      (array[i], array[minIndex]) = (array[minIndex], array[i]);
    }

  }

  private static int MinIndex<T>(T[] array, int start) where T : IComparable<T>
  {
    T min = array[0];
    int minIndex = 0;

    for (int i = start; i < array.Length; i++)
    {
      if (array[i].CompareTo(min) < 0)
      {
        min = array[i];
        minIndex = i;
      }
    }

    if (minIndex < start)
    {
      return start;
    }

    return minIndex;
  }

  private static void InsertSort<T>(T[] array) where T : IComparable<T>
  {
    for (int i = 1; i < array.Length; ++i)
    {
      T key = array[i];
      int j = i - 1;

      while (j >= 0 && array[j].CompareTo(key) > 0)
      {
        array[j + 1] = array[j];
        j = j - 1;
      }

      array[j + 1] = key;
    }
  }

  private static void BubbleSort<T>(T[] array) where T : IComparable<T>
  {
    for (int i = 0; i < array.Length; i++)
    {
      for (int j = i + 1; j < array.Length; j++)
      {
        if (array[j].CompareTo(array[i]) < 0)
        {
          (array[i], array[j]) = (array[j], array[i]);
        }
      }
    }
  }
}
