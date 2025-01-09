namespace ConsoleApp1;

public class Problem
{
    public static void CheckAnything()
    {
        var charSpan = "123123123".AsSpan();
        var compareSpan = "123123123".AsSpan();
        if (charSpan.SequenceEqual(compareSpan))
        {
            Console.WriteLine("Spans are equal");
        }
    }
    public static bool IsValid(string s) 
    {
        var parenthesis = new Stack<char>();
        foreach(var letter in s)
        {
            if(!parenthesis.Any())
            {
                parenthesis.Push(letter);
            }
            else
            {
                switch(letter)
                {
                    case '(':
                    case '{':
                    case '[':
                        parenthesis.Push(letter);
                        break;
                    case ')':
                        if(parenthesis.Peek() == '(')
                        {
                            parenthesis.Pop();
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case ']':
                        if(parenthesis.Peek() ==  '[')
                        {
                            parenthesis.Pop();
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case '}':
                        if(parenthesis.Peek() == '{')
                        {
                            parenthesis.Pop();
                        }
                        else
                        {
                            return false;
                        }
                        break;
                } 
            }
        }
        
        if(parenthesis.TryPeek(out var nonEmpty))
        {
            return false;
        }
        return true;
    }
    
}