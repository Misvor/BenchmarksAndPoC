using BenchmarkDotNet.Attributes;

namespace ConsoleApp1.Benchmark;

[HideColumns("Error", "StdDev", "Median", "RatioSD", "left", "right")]
[MemoryDiagnoser(displayGenColumns: true)]
public class AnyVsCountZero
{
    IEnumerable<double> data = Enumerable.Range(0, 100).Select(x => (double)x);
    
    [Benchmark(Baseline = true)]
    public bool IsAny()
    {
        return data.Any();
    }
    
    [Benchmark]
    public bool CountNotZero()
    {
        return data.Count() > 0;
    }
}