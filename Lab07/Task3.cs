namespace Task3;

public class Task3
{
  public static void Init()
  {
    MyStack<string> operators = new MyStack<string>();
    MyStack<double> values = new MyStack<double>();

    String expression = "( ( 1 + sqrt ( 5.0 ) ) / 2.0 )";
    String[] tokens = expression.Split(" ");

    foreach (var token in tokens)
    {
      if (!token.Equals("("))
      {
        if (token.Equals("+"))
        {
          operators.Push(token);
        }
        else if (token.Equals("-"))
        {
          operators.Push(token);
        }
        else if (token.Equals("*"))
        {
          operators.Push(token);
        }
        else if (token.Equals("/"))
        {
          operators.Push(token);
        }
        else if (token.Equals("^"))
        {
          operators.Push(token);
        }
        else if (token.Equals("sqrt"))
        {
          operators.Push(token);
        }
        else if (token.Equals(")"))
        {
          string _operator = operators.Pop();
          double value = values.Pop();

          if (_operator.Equals("+"))
          {
            value = values.Pop() + value;
          }
          else if (_operator.Equals("-"))
          {
            value = values.Pop() - value;
          }
          else if (_operator.Equals("*"))
          {
            value = values.Pop() * value;
          }
          else if (_operator.Equals("/"))
          {
            value = values.Pop() / value;
          }
          else if (_operator.Equals("^"))
          {
            value = Math.Pow(values.Pop(), value);
          }
          else if (_operator.Equals("sqrt"))
          {
            value = Math.Sqrt(value);
          }

          values.Push(value);
        }
        else
        {
          values.Push(double.Parse(token));
        }
      }
    }

    Console.WriteLine(values.Peek());
  }
}

public class MyStack<T>
{
  public class Node
  {
    public required T Item { get; set; }
    public Node? Next { get; set; }
  }

  public Node? Top { get; set; }
  public int Count { get; set; }

  public MyStack()
  {
    Top = null;
    Count = 0;
  }

  public bool IsEmpty()
  {
    return Top is null;
  }

  public void Push(T item)
  {
    Node oldTop = Top;

    Top = new Node()
    {
      Item = item,
      Next = oldTop
    };

    Count++;
  }

  public T Pop()
  {
    if (IsEmpty())
    {
      throw new ArgumentNullException();
    }

    T item = Top!.Item;
    Top = Top.Next;
    Count--;

    return item;
  }

  public T Peek()
  {
    if (IsEmpty())
    {
      throw new ArgumentNullException();
    }

    return Top!.Item;
  }
}
