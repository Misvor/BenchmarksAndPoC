using BenchmarkDotNet.Attributes;

namespace ConsoleApp1;

public class AnyContains
{
    private string[] FileExtensions = new string[] { "Doo", "Foo", "Moo", "Loo" };

    private string[] filesExtWrong = new[] { "Doo", "Boo", "Soo","Doo", "Boo", "Soo","Doo", "Boo", "Soo","Doo", "Boo", "Soo","Doo", "Boo", "Soo" };

    private string[] filesExtRight = new[] { "Doo", "Foo", "Foo","Doo", "Foo", "Foo","Doo", "Foo", "Foo","Doo", "Foo", "Foo","Doo", "Foo", "Foo","Doo", "Foo", "Foo","Doo", "Foo", "Foo" };
    
    [Benchmark]
    public void TestContainsNew()
    {
        var resultWrong = filesExtWrong.Any(f => !FileExtensions.Contains(f));
        var resultRight = filesExtRight.Any(f => !FileExtensions.Contains(f));
    }
    
    [Benchmark(Baseline = true)]
    public void TestContainsOld()
    {
        var resultWrong = !filesExtWrong.All(f => FileExtensions.Contains(f));
        var resultRight = !filesExtRight.All(f => FileExtensions.Contains(f));  
    }
}