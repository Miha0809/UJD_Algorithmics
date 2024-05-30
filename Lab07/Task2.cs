namespace Task2;

public class Task2
{
    public static void Init()
    {
        string text = Console.ReadLine();
        Console.WriteLine(isBalanced(text));
    }

    private static bool isBalanced(string text)
    {
        Stack<char> brackets = new Stack<char>();

        foreach (char bracket in text)
        {
            if (bracket == '(' || bracket == '{' || bracket == '[')
            {
                brackets.Push(bracket);
            }
            else if (bracket == ')')
            {
                if (brackets.Count == 0 || brackets.Pop() != '(')
                {
                    return false;
                }
            }
            else if (bracket == '}')
            {
                if (brackets.Count == 0 || brackets.Pop() != '{')
                {
                    return false;
                }
            }
            else if (bracket == ']')
            {
                if (brackets.Count == 0 || brackets.Pop() != '[')
                {
                    return false;
                }
            }
        }

        return true;
    }
}
