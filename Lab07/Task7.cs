namespace Task7;

class Task7
{
  public static void Init()
  {
    QueueWithTwoStacks<int> queue = new QueueWithTwoStacks<int>();

    queue.Push(1);
    queue.Push(2);
    queue.Push(3);

    Console.WriteLine(queue.Pop());
    Console.WriteLine(queue.Peek());
    Console.WriteLine(queue.Pop());

    queue.Push(4);
    Console.WriteLine(queue.Pop());
    Console.WriteLine(queue.Pop());
  }
}

public class QueueWithTwoStacks<T>
{
  private Stack<T> stack1;
  private Stack<T> stack2;

  public QueueWithTwoStacks()
  {
    stack1 = new Stack<T>();
    stack2 = new Stack<T>();
  }

  public void Push(T item)
  {
    stack1.Push(item);
  }

  public T Pop()
  {
    if (IsEmpty())
    {
      throw new InvalidOperationException("Queue is empty.");
    }

    if (stack2.Count == 0)
    {
      while (stack1.Count > 0)
      {
        stack2.Push(stack1.Pop());
      }
    }

    return stack2.Pop();
  }

  public T Peek()
  {
    if (IsEmpty())
    {
      throw new InvalidOperationException("Queue is empty.");
    }

    if (stack2.Count == 0)
    {
      while (stack1.Count > 0)
      {
        stack2.Push(stack1.Pop());
      }
    }

    return stack2.Peek();
  }

  public bool IsEmpty()
  {
    return stack1.Count == 0 && stack2.Count == 0;
  }

  public int Count()
  {
    return stack1.Count + stack2.Count;
  }
}

