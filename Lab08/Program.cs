SynglyLinkedList<int> sll = new SynglyLinkedList<int>();

sll.Append(1);
sll.Append(2);
sll.Append(3);
sll.Show();
sll.Reverse();
sll.Show();

Task2.Task2.Init();

Task3.Task3.Init();

Task4.Task4.Init();

class Node<T>
{
  public T Data { get; set; }
  public Node<T>? Next { get; set; }

  public Node(T data)
  {
    Data = data;
    Next = null;
  }
}

public class SynglyLinkedList<T>
{
  private Node<T>? _node;

  public void Append(T data)
  {
    Node<T> newNode = new Node<T>(data);

    if (_node is null)
    {
      _node = newNode;
      return;
    }

    Node<T> last = _node;

    while (last.Next is not null)
    {
      last = last.Next;
    }

    last.Next = newNode;
  }

  public void Prepend(T data)
  {
    Node<T> newNode = new Node<T>(data)
    {
      Next = _node
    };

    _node = newNode;
  }

  public void Delete(T value)
  {
    if (_node is null)
    {
      return;
    }

    if (_node.Data.Equals(value))
    {
      _node = _node.Next;
      return;
    }

    Node<T> current = _node;

    while (current.Next != null)
    {
      if (current.Next.Data.Equals(value))
      {
        current.Next = current.Next.Next;
        return;
      }

      current = current.Next;
    }
  }

  public bool Find(T value)
  {
    Node<T> current = _node;

    while (current is not null)
    {
      if (current.Data.Equals(value))
      {
        return true;
      }

      current = current.Next;
    }

    return false;
  }

  public void Reverse()
  {
    Node<T> prev = null;
    Node<T> current = _node;
    Node<T> next = null;

    while (current is not null)
    {
      next = current.Next;
      current.Next = prev;
      prev = current;
      current = next;
    }

    _node = prev;
  }

  public void Show()
  {
    Node<T> current = _node;

    while (current is not null)
    {
      Console.Write(current.Data + " ");
      current = current.Next;
    }

    Console.WriteLine("Null");
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

public class DoublyLinkedList<T>
{
  private DoublyLinkedListNode<T> head;
  private DoublyLinkedListNode<T> tail;

  public void AddFirst(T data)
  {
    DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(data);
    if (head == null)
    {
      head = newNode;
      tail = newNode;
    }
    else
    {
      newNode.Next = head;
      head.Previous = newNode;
      head = newNode;
    }
  }

  public void AddLast(T data)
  {
    DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(data);
    if (tail == null)
    {
      head = newNode;
      tail = newNode;
    }
    else
    {
      tail.Next = newNode;
      newNode.Previous = tail;
      tail = newNode;
    }
  }

  public bool Remove(T data)
  {
    DoublyLinkedListNode<T> current = head;
    while (current != null && !current.Data.Equals(data))
    {
      current = current.Next;
    }

    if (current == null)
    {
      return false;
    }

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

    return true;
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

