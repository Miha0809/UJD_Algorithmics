namespace Task3;

class Task3
{
  public static void Init()
  {
    SinglyLinkedList<int> singlyLinkedList = new SinglyLinkedList<int>();

    singlyLinkedList.AddSorted(3);
    singlyLinkedList.AddSorted(1);
    singlyLinkedList.AddSorted(2);
    singlyLinkedList.PrintList();

    singlyLinkedList.Reverse();
    singlyLinkedList.PrintList();

    singlyLinkedList.RemoveAll(2);
    singlyLinkedList.PrintList();

    singlyLinkedList.InsertAt(4, 1);
    singlyLinkedList.PrintList();

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();

    DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();

    doublyLinkedList.AddSorted(3);
    doublyLinkedList.AddSorted(1);
    doublyLinkedList.AddSorted(2);
    doublyLinkedList.PrintList();

    doublyLinkedList.Reverse();
    doublyLinkedList.PrintList();

    doublyLinkedList.RemoveAll(2);
    doublyLinkedList.PrintList();

    doublyLinkedList.InsertAt(4, 1);
    doublyLinkedList.PrintList();
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

public class SinglyLinkedList<T> where T : IComparable<T>
{
  private SinglyLinkedListNode<T> head;

  // (a) Dodawanie elementu w sposób uporządkowany
  public void AddSorted(T data)
  {
    SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(data);
    if (head == null || head.Data.CompareTo(data) >= 0)
    {
      newNode.Next = head;
      head = newNode;
    }
    else
    {
      SinglyLinkedListNode<T> current = head;
      while (current.Next != null && current.Next.Data.CompareTo(data) < 0)
      {
        current = current.Next;
      }
      newNode.Next = current.Next;
      current.Next = newNode;
    }
  }

  // (b) Odwracanie listy
  public void Reverse()
  {
    SinglyLinkedListNode<T> prev = null;
    SinglyLinkedListNode<T> current = head;
    SinglyLinkedListNode<T> next = null;
    while (current != null)
    {
      next = current.Next;
      current.Next = prev;
      prev = current;
      current = next;
    }
    head = prev;
  }

  // (c) Usuwanie wszystkich kluczy o wartości key
  public void RemoveAll(T key)
  {
    while (head != null && head.Data.CompareTo(key) == 0)
    {
      head = head.Next;
    }

    SinglyLinkedListNode<T> current = head;
    while (current != null && current.Next != null)
    {
      if (current.Next.Data.CompareTo(key) == 0)
      {
        current.Next = current.Next.Next;
      }
      else
      {
        current = current.Next;
      }
    }
  }

  // (d) Wstawianie elementu w określone miejsce na liście
  public void InsertAt(T data, int position)
  {
    if (position < 0)
    {
      throw new ArgumentOutOfRangeException(nameof(position));
    }

    SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(data);
    if (position == 0)
    {
      newNode.Next = head;
      head = newNode;
      return;
    }

    SinglyLinkedListNode<T> current = head;
    for (int i = 0; i < position - 1; i++)
    {
      if (current == null)
      {
        throw new ArgumentOutOfRangeException(nameof(position));
      }
      current = current.Next;
    }

    newNode.Next = current.Next;
    current.Next = newNode;
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

public class DoublyLinkedListNode<T>
{
  public T Data { get; set; }
  public DoublyLinkedListNode<T> Next { get; set; }
  public DoublyLinkedListNode<T> Previous { get; set; }

  public DoublyLinkedListNode(T data)
  {
    Data = data;
    Next = null;
    Previous = null;
  }
}

public class DoublyLinkedList<T> where T : IComparable<T>
{
  private DoublyLinkedListNode<T> head;
  private DoublyLinkedListNode<T> tail;

  // (a) Dodawanie elementu w sposób uporządkowany
  public void AddSorted(T data)
  {
    DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(data);
    if (head == null || head.Data.CompareTo(data) >= 0)
    {
      newNode.Next = head;
      if (head != null)
      {
        head.Previous = newNode;
      }
      head = newNode;
      if (tail == null)
      {
        tail = newNode;
      }
    }
    else
    {
      DoublyLinkedListNode<T> current = head;
      while (current.Next != null && current.Next.Data.CompareTo(data) < 0)
      {
        current = current.Next;
      }
      newNode.Next = current.Next;
      if (current.Next != null)
      {
        current.Next.Previous = newNode;
      }
      current.Next = newNode;
      newNode.Previous = current;
      if (newNode.Next == null)
      {
        tail = newNode;
      }
    }
  }

  // (b) Odwracanie listy
  public void Reverse()
  {
    DoublyLinkedListNode<T> current = head;
    DoublyLinkedListNode<T> temp = null;
    while (current != null)
    {
      temp = current.Previous;
      current.Previous = current.Next;
      current.Next = temp;
      current = current.Previous;
    }
    if (temp != null)
    {
      head = temp.Previous;
    }
  }

  // (c) Usuwanie wszystkich kluczy o wartości key
  public void RemoveAll(T key)
  {
    DoublyLinkedListNode<T> current = head;
    while (current != null)
    {
      if (current.Data.CompareTo(key) == 0)
      {
        if (current.Previous != null)
        {
          current.Previous.Next = current.Next;
        }
        else
        {
          head = current.Next;
        }
        if (current.Next != null)
        {
          current.Next.Previous = current.Previous;
        }
        else
        {
          tail = current.Previous;
        }
      }
      current = current.Next;
    }
  }

  // (d) Wstawianie elementu w określone miejsce na liście
  public void InsertAt(T data, int position)
  {
    if (position < 0)
    {
      throw new ArgumentOutOfRangeException(nameof(position));
    }

    DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(data);
    if (position == 0)
    {
      newNode.Next = head;
      if (head != null)
      {
        head.Previous = newNode;
      }
      head = newNode;
      if (tail == null)
      {
        tail = newNode;
      }
      return;
    }

    DoublyLinkedListNode<T> current = head;
    for (int i = 0; i < position - 1; i++)
    {
      if (current == null)
      {
        throw new ArgumentOutOfRangeException(nameof(position));
      }
      current = current.Next;
    }

    newNode.Next = current.Next;
    if (current.Next != null)
    {
      current.Next.Previous = newNode;
    }
    current.Next = newNode;
    newNode.Previous = current;

    if (newNode.Next == null)
    {
      tail = newNode;
    }
  }

  public void PrintList()
  {
    DoublyLinkedListNode<T> current = head;
    while (current != null)
    {
      Console.Write(current.Data + " <-> ");
      current = current.Next;
    }
    Console.WriteLine("null");
  }
}


