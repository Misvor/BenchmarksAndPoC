using System.Text.RegularExpressions;

namespace ConsoleApp1.Problems;

public class StringHalvesAlike
{
    public bool HalvesAreAlike(string s)
    {
        var length = s.Length / 2;
        var reg = $@"i[aeiou]";

        return Regex.Matches(s[..length], reg).Count == Regex.Matches(s[length..], reg).Count();
    }
}