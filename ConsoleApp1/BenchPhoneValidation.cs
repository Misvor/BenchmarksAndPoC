using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace ConsoleApp1;

public class BenchPhoneValidation
{
    [Benchmark(Baseline = true), Arguments("+7 (952) 108-77-97", 1)]
    public void ValidateWithHashMap(string PhoneToCheck, int numOfTimes)
    {
        var digits = "1234567890";
        Dictionary<int, string> phonePos = new()
        {
            {0, "+"}, {1, digits}, {2, " "}, {3, "("}, {4, digits}, {5, digits}, {6, digits},{
            7, ")"}, {8, " "}, {9, digits}, {10, digits}, {11, digits}, {12, "-"}, {13, digits},
            {14, digits}, {15, "-"}, {16, digits}, {17, digits}
        };

        for (var j = 0; j< numOfTimes; j++)
        {
            bool result = false;
            for(var i = 0; i < PhoneToCheck.Length; i++)
            {
                if (!phonePos[i].Contains(PhoneToCheck[i]))
                {
                    result = false;
                }
            }

            result = true;
        }

    }
    
    [Benchmark, Arguments("+7 (952) 108-77-97", 1)]
    public void ValidateWithRegex(string PhoneToCheck, int numOfTimes)
    {
        var pattern = "([8]?|[+7]{2})[ ]?\\(?[0-9]{3}\\)?[ ]?[0-9]{3}[-]?[0-9]{2}[-]?[0-9]{2}";
        var regex = new Regex(pattern, RegexOptions.Singleline);
        for (var j = 0; j < numOfTimes; j++)
        {
            var result = regex.Match(PhoneToCheck).Success;
        }
    }

    [Benchmark, Arguments("+7 (952) 108-77-97", 1)]
    public void ValidateWithCompiledRegex(string PhoneToCheck, int numOfTimes)
    {
        var pattern = "([8]?|[+7]{2})[ ]?\\(?[0-9]{3}\\)?[ ]?[0-9]{3}[-]?[0-9]{2}[-]?[0-9]{2}";
        var regex = new Regex(pattern, RegexOptions.Compiled);
        for (var j = 0; j < numOfTimes; j++)
        {
            var result = regex.Match(PhoneToCheck).Success;
        } 
    }
    
    [Benchmark, Arguments("+7 (952) 108-77-97", 1)]
    public void ValidateWithCompiledRegexRO(string PhoneToCheck, int numOfTimes)
    {
        var pattern = "([8]?|[+7]{2})[ ]?\\(?[0-9]{3}\\)?[ ]?[0-9]{3}[-]?[0-9]{2}[-]?[0-9]{2}";
        var regex = new Regex(pattern, RegexOptions.Compiled);
        for (var j = 0; j < numOfTimes; j++)
        {
            var result = regex.Match(PhoneToCheck).Success;
        } 
    }
}