using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ConsoleApp1.Benchmark;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net70)]
[SimpleJob(RuntimeMoniker.Net60)]
[HideColumns("Error", "StdDev", "Median", "RatioSD", "left", "right")]
[MemoryDiagnoser(displayGenColumns: false)]
public class ListAddition
{
    private const int initSize = int.MaxValue / 2;
    
    [Benchmark(Baseline = true)]
    public List<long> AddToListSmall()
    {
        var list = new List<long>();
        for (var i = 0; i < 100000; i++)
        {
            list.Add(i);
        }

        return list;
    }
    
    // [Benchmark]
    // public List<long> AddToListLarge()
    // {
    //     var list = new List<long>(initSize);
    //     for (var i = 0; i < 10000; i++)
    //     {
    //         list.Add(i);
    //     }
    //
    //     return list;
    // }
    
    [Benchmark]
    public LinkedList<int> AddToLinkedListLarge()
    {
        var list = new LinkedList<int>();
        for (var i = 0; i < 100000; i++)
        {
            list.AddLast(i);
        }

        return list;
    }
}