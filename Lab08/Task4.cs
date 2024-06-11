namespace Task4;

public class Task4
{
  public static void Init()
  {
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();

    SinglyLinkedList<int> listA = new SinglyLinkedList<int>();
    listA.AddLast(1);
    listA.AddLast(2);
    listA.AddLast(3);

    SinglyLinkedList<int> listB = new SinglyLinkedList<int>();
    listB.AddLast(3);
    listB.AddLast(4);
    listB.AddLast(5);

    Console.WriteLine(listA.Contains(2));

    SinglyLinkedList<int> intersection = listA.Intersection(listB);
    intersection.PrintList();

    SinglyLinkedList<int> union = listA.Union(listB);
    union.PrintList();

    Console.WriteLine(listA.IsSubsetOf(listB));

    SinglyLinkedList<int> listC = new SinglyLinkedList<int>();
    listC.AddLast(2);
    listC.AddLast(3);

    Console.WriteLine(listC.IsSubsetOf(listA));
  }
}

public class SinglyLinkedListNode<T>
{
  public T Data { get; set; }
  public SinglyLinkedListNode<T> Next { get; set; }

  public SinglyLinkedListNode(T data)
  {
    Data = data;
    Next = null;
  }
}

public class SinglyLinkedList<T>
{
  private SinglyLinkedListNode<T> head;

  // Dodawanie elementu na koniec listy
  public void AddLast(T data)
  {
    SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(data);
    if (head == null)
    {
      head = newNode;
    }
    else
    {
      SinglyLinkedListNode<T> current = head;
      while (current.Next != null)
      {
        current = current.Next;
      }
      current.Next = newNode;
    }
  }

  // (a) Sprawdzanie czy element należy do listy
  public bool Contains(T data)
  {
    SinglyLinkedListNode<T> current = head;
    while (current != null)
    {
      if (current.Data.Equals(data))
      {
        return true;
      }
      current = current.Next;
    }
    return false;
  }

  // (b) Przekrój A ∩ B
  public SinglyLinkedList<T> Intersection(SinglyLinkedList<T> otherList)
  {
    SinglyLinkedList<T> result = new SinglyLinkedList<T>();
    SinglyLinkedListNode<T> current = head;
    while (current != null)
    {
      if (otherList.Contains(current.Data))
      {
        result.AddLast(current.Data);
      }
      current = current.Next;
    }
    return result;
  }

  // (c) Suma A ∪ B
  public SinglyLinkedList<T> Union(SinglyLinkedList<T> otherList)
  {
    SinglyLinkedList<T> result = new SinglyLinkedList<T>();
    SinglyLinkedListNode<T> current = head;
    while (current != null)
    {
      result.AddLast(current.Data);
      current = current.Next;
    }
    current = otherList.head;
    while (current != null)
    {
      if (!result.Contains(current.Data))
      {
        result.AddLast(current.Data);
      }
      current = current.Next;
    }
    return result;
  }

  // (d) Sprawdzanie czy A ⊆ B
  public bool IsSubsetOf(SinglyLinkedList<T> otherList)
  {
    SinglyLinkedListNode<T> current = head;
    while (current != null)
    {
      if (!otherList.Contains(current.Data))
      {
        return false;
      }
      current = current.Next;
    }
    return true;
  }

  public void PrintList()
  {
    SinglyLinkedListNode<T> current = head;
    while (current != null)
    {
      Console.Write(current.Data + " -> ");
      current = current.Next;
    }
    Console.WriteLine("null");
  }
}
