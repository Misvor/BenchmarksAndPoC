namespace ConsoleApp1;

public static class refForObjects
{
    public static void Shuffle(ref List<string> strings)
    {
        strings.Reverse();
    }
}