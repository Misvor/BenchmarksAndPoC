using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace ConsoleApp1;

[DisassemblyDiagnoser]
public class StackAllocDemo
{
    [Benchmark]
    public void StackAllocStringReverse()
    {
        unsafe
        {
            string s = "1234567890";
            Char* charPointer = stackalloc Char[s.Length];


            for (var i = 0; i < s.Length; i++)
            {
                charPointer[s.Length - i - 1] = s[i] ;
            }
            var result = new String(charPointer, 0, s.Length );

        }
    }

    [Benchmark]
    public void InlineArrayReverse()
    {
        unsafe
        {
            CharArray ca;
            int widthInBytes = sizeof(CharArray);
            int width = widthInBytes / 2;

            String s = "1234567890";

            for (var i = 0; i < width; i++)
            {
                ca.Characters[width - i - 1] = s[i];
            }
            var result = new String(ca.Characters, 0, width );
        }
    }

    [Benchmark]
    public void ClassicStringReverse()
    {
        String s = "1234567890";
        var reversed = s.Reverse();
    }

    internal unsafe struct CharArray
    {
        public fixed Char Characters[10];
    }
}