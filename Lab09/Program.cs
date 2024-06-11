BinaryTree<int> tree = new BinaryTree<int>();
tree.Add(5);
tree.Add(3);
tree.Add(7);
tree.Add(2);
tree.Add(4);
tree.Add(6);
tree.Add(8);

Console.WriteLine("In-order Traversal:");
tree.InOrderTraversal(value => Console.WriteLine(value));

Console.WriteLine("Pre-order Traversal:");
tree.PreOrderTraversal(value => Console.WriteLine(value));

Console.WriteLine("Post-order Traversal:");
tree.PostOrderTraversal(value => Console.WriteLine(value));

Console.WriteLine("Searching for 4: " + tree.Search(4));
Console.WriteLine("Searching for 10: " + tree.Search(10));

tree.Remove(3);
Console.WriteLine("In-order Traversal after removing 3:");
tree.InOrderTraversal(value => Console.WriteLine(value));


public class BinaryTree<T> where T : IComparable<T>
{
  public class Node
  {
    public T Value;
    public Node Left;
    public Node Right;

    public Node(T value)
    {
      Value = value;
      Left = null;
      Right = null;
    }
  }

  private Node root;

  public BinaryTree()
  {
    root = null;
  }

  public void Add(T value)
  {
    root = AddRecursive(root, value);
  }

  private Node AddRecursive(Node node, T value)
  {
    if (node == null)
    {
      return new Node(value);
    }

    int comparison = value.CompareTo(node.Value);
    if (comparison < 0)
    {
      node.Left = AddRecursive(node.Left, value);
    }
    else if (comparison > 0)
    {
      node.Right = AddRecursive(node.Right, value);
    }

    return node;
  }

  public bool Search(T value)
  {
    return SearchRecursive(root, value);
  }

  private bool SearchRecursive(Node node, T value)
  {
    if (node == null)
    {
      return false;
    }

    int comparison = value.CompareTo(node.Value);
    if (comparison == 0)
    {
      return true;
    }
    else if (comparison < 0)
    {
      return SearchRecursive(node.Left, value);
    }
    else
    {
      return SearchRecursive(node.Right, value);
    }
  }

  public void Remove(T value)
  {
    root = RemoveRecursive(root, value);
  }

  private Node RemoveRecursive(Node node, T value)
  {
    if (node == null)
    {
      return null;
    }

    int comparison = value.CompareTo(node.Value);
    if (comparison < 0)
    {
      node.Left = RemoveRecursive(node.Left, value);
    }
    else if (comparison > 0)
    {
      node.Right = RemoveRecursive(node.Right, value);
    }
    else
    {
      if (node.Left == null)
      {
        return node.Right;
      }
      else if (node.Right == null)
      {
        return node.Left;
      }

      node.Value = FindMin(node.Right).Value;
      node.Right = RemoveRecursive(node.Right, node.Value);
    }

    return node;
  }

  private Node FindMin(Node node)
  {
    while (node.Left != null)
    {
      node = node.Left;
    }
    return node;
  }

  public void InOrderTraversal(Action<T> action)
  {
    InOrderTraversalRecursive(root, action);
  }

  private void InOrderTraversalRecursive(Node node, Action<T> action)
  {
    if (node != null)
    {
      InOrderTraversalRecursive(node.Left, action);
      action(node.Value);
      InOrderTraversalRecursive(node.Right, action);
    }
  }

  public void PreOrderTraversal(Action<T> action)
  {
    PreOrderTraversalRecursive(root, action);
  }

  private void PreOrderTraversalRecursive(Node node, Action<T> action)
  {
    if (node != null)
    {
      action(node.Value);
      PreOrderTraversalRecursive(node.Left, action);
      PreOrderTraversalRecursive(node.Right, action);
    }
  }

  public void PostOrderTraversal(Action<T> action)
  {
    PostOrderTraversalRecursive(root, action);
  }

  private void PostOrderTraversalRecursive(Node node, Action<T> action)
  {
    if (node != null)
    {
      PostOrderTraversalRecursive(node.Left, action);
      PostOrderTraversalRecursive(node.Right, action);
      action(node.Value);
    }
  }
}
