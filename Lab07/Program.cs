// Task1
Stack<string> stack = new Stack<string>();

// string text = Console.ReadLine();
string text = Console.ReadLine();
stack = InputToStack(text);

Console.WriteLine(Reverse(stack));

// Task2
Task2.Task2.Init();

// Task3
Task3.Task3.Init();

// Task7
Task7.Task7.Init();

static Stack<string> InputToStack(string text)
{
    string[] words = text.Split(' ');
    Stack<string> stackWords = new Stack<string>();

    foreach (string word in words)
    {
        stackWords.Push(word);
    }

    return stackWords;
}

static string Reverse(Stack<string> text)
{
    int length = text.Count;
    string reverse = "";

    for (int i = 0; i < length; i++)
    {
        string word = text.Pop();
        reverse += word + ' ';
    }

    return reverse;
}
