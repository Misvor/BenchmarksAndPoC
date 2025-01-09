using System.Collections.Specialized;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ParallelThread.Services;

class Program
{
    static void Main(string[] args)
    {
        var Summary = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}

public class Benchmarks
{
    //    HybridLockCacheService hybrid = new HybridLockCacheService();
    //    AppLayerLockCacheService app = new AppLayerLockCacheService();
    //    CoreLayerLockCacheService core = new CoreLayerLockCacheService();

    //[Benchmark]
    //public void HybridLock()
    //{
    //    hybrid.Set("123");
    //    hybrid.Get();
    //}

    //[Benchmark]
    //public void AppLock()
    //{
    //    app.Set("123");
    //    app.Get();
    //}

    //[Benchmark]
    //public void CoreLock()
    //{
    //    core.Set("123");
    //    core.Get();
    //}

    [Params(1, 2, 3)]
    public int n;
    [Params(1, 2, 3)]
    public int m;

    [Benchmark(Baseline = true)]
    public int Baseline()
    {
        return Ackermann(m, n);

        int Ackermann(int m, int n) => (m, n) switch
        {
            (0, _) => n + 1,
            (_, 0) => Ackermann(m - 1, 1),
            _ => Ackermann(m - 1, Ackermann(m, n - 1)),
        };
    }

    [Benchmark]
    public ValueTask<int> ValueTask()
    {
        return Ackermann(m, n);

        async ValueTask<int> Ackermann(int m, int n) => (m, n) switch
        {
            (0, _) => n + 1,
            (_, 0) => await Ackermann(m - 1, 1),
            _ => await Ackermann(m - 1, await Ackermann(m, n - 1)),
        };
    }

    [Benchmark]
    public Task<int> Task()
    {
        return Ackermann(m, n);

        async Task<int> Ackermann(int m, int n) => (m, n) switch
        {
            (0, _) => n + 1,
            (_, 0) => await Ackermann(m - 1, 1),
            _ => await Ackermann(m - 1, await Ackermann(m, n - 1)),
        };
    }


}