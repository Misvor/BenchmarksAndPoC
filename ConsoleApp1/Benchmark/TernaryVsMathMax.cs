using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ConsoleApp1;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net70)]
[SimpleJob(RuntimeMoniker.Net60)]
public class TernaryVsMathMax
{
    private readonly Random rand = new Random(1);
    private readonly Random rand2 = new Random(1);

    [Benchmark(Baseline = true)]
    public void Ternary()
    {
        var firstVal = rand.Next();
        var second = rand.Next();

        var someMore = firstVal >= second ? firstVal : second;
    }

    [Benchmark]
    public void MathMax()
    {
        var firstVal = rand2.Next();
        var second = rand2.Next();

        var maxVal = Math.Max(firstVal, second);
    }
    
}