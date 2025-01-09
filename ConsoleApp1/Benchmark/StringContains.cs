using BenchmarkDotNet.Attributes;

namespace ConsoleApp1;

[DisassemblyDiagnoser]
public class MyBenchmarks
{
    [Benchmark]
    public void UsingCharArray()
    {
        var proof = "My Loooooong testing string1";
        var i = '1';
        var convertedProof = proof.ToCharArray();
        var a = Task.Run(() => Console.WriteLine()).ConfigureAwait(false);

        var result = convertedProof.Contains(i);
    }
    [Benchmark]
    public void UsingString()
    {
        var proof = "My Loooooong testing string1";
        var i = '1';
        
        var result = proof.Contains(i);
        
    }
    [Benchmark]
    public void UsingSpanString()
    {
        var proof = "My Loooooong testing string1".AsSpan();
        var i = '1';
        var result = proof.IndexOf(i) > 0;
    }
}