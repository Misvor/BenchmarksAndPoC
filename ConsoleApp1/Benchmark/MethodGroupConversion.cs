using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ConsoleApp1.Benchmark;

[SimpleJob(RuntimeMoniker.Net80)]
[HideColumns("Error", "StdDev", "Median", "RatioSD", "left", "right")]
[MemoryDiagnoser(displayGenColumns: true)]
public class MethodGroupConversion
{
    private int[] _array;

    public MethodGroupConversion()
    {
        _array = Enumerable.Range(0, 100).ToArray();
    }

    [Benchmark(Baseline = true)]
    public bool[] GroupConverted()
    {
        return _array.Select(IsEven).ToArray();
    }
    
    [Benchmark]
    public bool[] GroupNotConverted()
    {
        int x = 0;
        int y = 0;
        int z = 0;
        x++;
        y += 1;
        z = z + 1;
        return _array.Select(x => IsEven(x)).ToArray();
    }
    
    [Benchmark]
    public bool[] GroupConvertedParallel()
    {
        return _array.AsParallel().Select(IsEven).ToArray();
    }
    
    [Benchmark]
    public bool[] GroupNotConvertedParallel()
    {
        return _array.AsParallel().Select(x => IsEven(x)).ToArray();
    }

    private static bool IsEven(int value)
    {
        return value % 2 == 0;
    }
}