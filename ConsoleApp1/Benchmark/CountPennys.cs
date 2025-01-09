using BenchmarkDotNet.Attributes;

namespace ConsoleApp1;

public class CountPennys
{
    public enum TestEnum
    {
        None = 0,
        SomeData = 1,
        AnotherData = 2
    }

    public CountPennys()
    {
        value = 0;
        value1 = (TestEnum)1;
        value2 = (TestEnum)2;
    }

    private TestEnum value;
    private TestEnum value1;
    private TestEnum value2;
   
    [Benchmark(Baseline = true)]
    public void TestBoolCheck()
    {
        var result = value >= TestEnum.AnotherData && value != TestEnum.None;
        var result1 = value1 >= TestEnum.AnotherData && value1 != TestEnum.None;
        var result2 = value2 >= TestEnum.AnotherData && value2 != TestEnum.None;
    }
    
    [Benchmark]
    public void TestBoolCheckReverse()
    {
        var result = value != TestEnum.None && value >= TestEnum.AnotherData;
        var result1 = value1 != TestEnum.None && value1 >= TestEnum.AnotherData;
        var result2 = value2 != TestEnum.None && value2 >= TestEnum.AnotherData;
    }
    
}