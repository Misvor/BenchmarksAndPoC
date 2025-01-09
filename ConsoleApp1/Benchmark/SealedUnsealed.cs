using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ConsoleApp1.Benchmark;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net70)]
[SimpleJob(RuntimeMoniker.Net60)]
[HideColumns("Error", "StdDev", "Median", "RatioSD", "left", "right")]
[MemoryDiagnoser(displayGenColumns: true)]
public class SealedUnsealed
{
    private SealedType _sealedInstance = new();
    private SealedType[] _sealedArray = new SealedType[1_000_000];

    private NonSealedType _nonSealedInstance = new();
    private NonSealedType[] _nonSealedArray = new NonSealedType[1_000_000];

    [Benchmark(Baseline = true)]
    public void NonSealed()
    {
        NonSealedType inst = _nonSealedInstance;
        NonSealedType[] arr = _nonSealedArray;
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = inst;
        }
    }

    [Benchmark]
    public void Sealed()
    {
        SealedType inst = _sealedInstance;
        SealedType[] arr = _sealedArray;
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = inst;
        }
    }

    public class NonSealedType { }
    public sealed class SealedType { }
}
