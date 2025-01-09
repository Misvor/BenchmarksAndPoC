using System.Linq.Expressions;

namespace ConsoleApp1;

public static class LambdaTreeInspection
{
    public static string GetTestString => "123";
    public static int SumByLambda (int first, int second) => first + second;

    public static Expression<Func<int, int, int>> adder = (x, y) => x + y;

    public static Func<int, int, int> executableAdder = adder.Compile();

    public static string ToChangedString(this int number)
    {
        return number.ToString();
    }
}