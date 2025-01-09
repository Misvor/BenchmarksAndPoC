using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Jobs;

namespace ConsoleApp1.Problems;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net60)]
[DisassemblyDiagnoser]
public class OddOrEven
{
    [Benchmark]
    public bool UsingDiv()
    {
        var result = false;
        for (var i = 0; i < int.MaxValue; i++)
        {
            result = i % 2 == 0; 
        }

        return result;
    }
    
    [Benchmark]
    public bool UsingBit()
    {
        var result = false;
        for (var i = 0; i < int.MaxValue; i++)
        {
            result = (i & 1) == 0;
        }

        return result;
    }
    
    [Benchmark]
    public bool UsingDivUlong()
    {
        var result = false;
        for (ulong i = 0; i < int.MaxValue; i++)
        {
            result = i % 2 == 0; 
        }

        return result;
    }
    
    [Benchmark]
    public bool UsingBitUlong()
    {
        var result = false;
        for (ulong i = 0; i < int.MaxValue; i++)
        {
            result = (i & 1) == 0;
        }

        return result;
    }
}