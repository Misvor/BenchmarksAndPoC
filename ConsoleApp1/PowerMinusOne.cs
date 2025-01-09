using BenchmarkDotNet.Attributes;

namespace ConsoleApp1;

[DisassemblyDiagnoser]
public class PowerMinusBench
{
    [Benchmark]
    public double UsingDiv()
    {
        double result = 0;
        for (double i = 1; i < 100; i++)
        {
            result = 1 / i;
        }

        return result;
    }
    [Benchmark]
    public void UsingPower()
    {
        double result = 0;
        for (double i = 1; i < 100; i++)
        {
            result = Math.Pow(i, -1);
        }
    }
    
    [Benchmark]
    public void SmallUsingDiv()
    {
        double result = 0;
        for (double i = 1; i < 50; i+=0.5d)
        {
            result = 1 / i;
        }
    }
    [Benchmark]
    public void SmallUsingPower()
    {
        double result = 0;
        for (double i = 1; i < 50; i+=0.5d)
        {
            result = Math.Pow(i, -1);
        }
    }
}