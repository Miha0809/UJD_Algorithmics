namespace Task2;

public class Task2
{
  public static void Init()
  {
    Stack<int> stack = new Stack<int>();
    stack.Push(1);
    stack.Push(2);
    stack.Push(3);
    stack.PrintStack();

    Console.WriteLine(stack.Pop());
    stack.PrintStack();


    Queue<int> queue = new Queue<int>();
    queue.Enqueue(1);
    queue.Enqueue(2);
    queue.Enqueue(3);
    queue.PrintQueue();

    Console.WriteLine(queue.Dequeue());
    queue.PrintQueue();
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
  private SinglyLinkedListNode<T> tail;

  public void AddFirst(T data)
  {
    SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(data);
    if (head == null)
    {
      head = newNode;
      tail = newNode;
    }
    else
    {
      newNode.Next = head;
      head = newNode;
    }
  }

  public void AddLast(T data)
  {
    SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(data);
    if (tail == null)
    {
      head = newNode;
      tail = newNode;
    }
    else
    {
      tail.Next = newNode;
      tail = newNode;
    }
  }

  public T RemoveFirst()
  {
    if (head == null)
    {
      throw new InvalidOperationException("The list is empty.");
    }

    T data = head.Data;
    head = head.Next;
    if (head == null)
    {
      tail = null;
    }
    return data;
  }

  public bool IsEmpty()
  {
    return head == null;
  }
}

public class Stack<T>
{
  private SinglyLinkedList<T> list = new SinglyLinkedList<T>();

  public void Push(T data)
  {
    list.AddFirst(data);
  }

  public T Pop()
  {
    if (list.IsEmpty())
    {
      throw new InvalidOperationException("The stack is empty.");
    }
    return list.RemoveFirst();
  }

  public T Peek()
  {
    if (list.IsEmpty())
    {
      throw new InvalidOperationException("The stack is empty.");
    }

    return list.RemoveFirst();
  }

  public bool IsEmpty()
  {
    return list.IsEmpty();
  }

  public void PrintStack()
  {
    var tempStack = new Stack<T>();
    while (!this.IsEmpty())
    {
      T data = this.Pop();
      Console.Write(data + " ");
      tempStack.Push(data);
    }
    while (!tempStack.IsEmpty())
    {
      this.Push(tempStack.Pop());
    }
    Console.WriteLine();
  }
}

public class Queue<T>
{
  private SinglyLinkedList<T> list = new SinglyLinkedList<T>();

  public void Enqueue(T data)
  {
    list.AddLast(data);
  }

  public T Dequeue()
  {
    if (list.IsEmpty())
    {
      throw new InvalidOperationException("The queue is empty.");
    }
    return list.RemoveFirst();
  }

  public T Peek()
  {
    if (list.IsEmpty())
    {
      throw new InvalidOperationException("The queue is empty.");
    }

    return list.RemoveFirst();
  }

  public bool IsEmpty()
  {
    return list.IsEmpty();
  }

  public void PrintQueue()
  {
    var tempQueue = new Queue<T>();
    while (!this.IsEmpty())
    {
      T data = this.Dequeue();
      Console.Write(data + " ");
      tempQueue.Enqueue(data);
    }
    while (!tempQueue.IsEmpty())
    {
      this.Enqueue(tempQueue.Dequeue());
    }
    Console.WriteLine();
  }
}


