using System.Buffers;
using System.Numerics;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace ConsoleApp1.Benchmark;

[HideColumns("Error", "StdDev", "Median", "RatioSD", "left", "right")]
[MemoryDiagnoser(displayGenColumns: true)]
public partial class CheckIfNumber
{
    public string badNumber =
        "123123123123121231231231231212312312312312123123123123121231231231231212312312312312123123123123121231231231231212312312312312123123123123121231231231231212312312312312123123123123121231231231231212312312312312123123123123121231231231231212312312312312123123123123121231231231231212312312312312b";
    public string number =
        "123123123123121231231231231212312312312312123123123123121231231231231212312312312312123123123123121231231231231212312312312312123123123123121231231231231212312312312312123123123123121231231231231212312312312312123123123123121231231231231212312312312312123123123123121231231231231212312312312312b";

    // [Benchmark]
    // public bool IsNumberGeneratedRegex()
    // {
    //     return MyRegex().IsMatch(badNumber);
    // }
    
    [Benchmark]
    public bool IsNumberRegex()
    {
        return Regex.IsMatch(badNumber, "\\d*");
    }
    
    // [Benchmark]
    // public bool IsNumberSpan()
    // {
    //     var span = badNumber.AsSpan();
    //     return !span.ContainsAnyExcept(SearchValues.Create("1234567890"));
    // }
    
    [Benchmark(Baseline = true)]
    public bool IsNumberBigInt()
    {
        return BigInteger.TryParse(badNumber, out _);
    }

    // [GeneratedRegex("\\d*")]
    // private static partial Regex MyRegex();
}