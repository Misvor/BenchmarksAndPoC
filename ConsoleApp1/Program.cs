using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using ConsoleApp1;
using ConsoleApp1.Benchmark;
using ConsoleApp1.Problems;

[MemoryDiagnoser(displayGenColumns: false)]
[DisassemblyDiagnoser]
public class Program
{
    // static void Main(string[] args)
    // {
    //     ulong i = 51;
    //     ulong j = 50;
    //     Console.WriteLine(i % 2 == 0);
    //     Console.WriteLine((i & 1) == 0);
    //     Console.WriteLine(j % 2 == 0);
    //     Console.WriteLine((j & 1) == 0);
    //     var something = (j & 1) == 0;
    //     var something2 = (j % 2) == 0;
    //     string b = "xyz";
    // }
    
// static void Main(string[] args)
//     {
//         CheckDefaultEnum? defaultData = default(CheckDefaultEnum);
//         Console.WriteLine(defaultData);
//
//         defaultData = null;
//         Console.WriteLine(defaultData);
//         Console.WriteLine(defaultData ?? CheckDefaultEnum.data);
//         
//         Console.ReadLine();
//     }
//     private enum CheckDefaultEnum
//     {
//         data = 1,
//         dataNext = 2
//     }

    static void Main(string[] args)
    {
        var first = new List<string>()
        {
            "123",
            "123",
            "123",
            "123",
            "123",
            "123",
            "345",
            "456"
        };
        var second = new List<string>()
        {
            "23",
            "45",
            "56"
        };
        var third = new List<string>()
        {
            "12",
            "34",
            "45"
        };

        var intersect = GetIntersection(new List<List<string>>()
        {
            first, second, third
        });

        Console.ReadLine();




        // //AClass.UsingLocalVariablesInTheCallbackCode(10);
        //
        // //var something = JsonConvert.DeserializeObject<AClass>(String.Empty);
        // //var somethingNext = JsonConvert.DeserializeObject<AClass>(null);
        //
        // // Task task = DemoCompleteAsync();
        // // Console.WriteLine("Method returned");
        // // task.Wait();
        // // Console.WriteLine("Task completed");
        // // var list = new List<int>();
        // // object obj = list;
        //
        // var dict = new Dictionary<string, string>()
        // {
        //     {"1", "123"},
        //     {"2", "12333"}
        // };
        //
        // var someResult = dict.TryGetValue("3", out var data);
        // Console.WriteLine(data);
        // Console.ReadKey();
        //
    }
    public static IEnumerable<T> GetIntersection<T>(IEnumerable<IEnumerable<T>> input)
    {
        var allData = new List<T>();
        foreach (var arr in input)
        {
            allData.AddRange(arr.Distinct());
        }

        var intersect = allData
            .GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key);
        return intersect;
    }
    // static async Task DemoCompleteAsync()
    // {
    //     Console.WriteLine("Before first await");
    //
    //     await Task.FromResult(10);
    //     Console.WriteLine("Between awaits");
    //     await Task.Delay(1000);
    //     await Task.Yield();
    //     Console.WriteLine("After second wait");
    //
    //     var items = new List<string>();
    //
    //     var nonUnique = items.GroupBy(x => x).Where(x => x.Count() > 1).SelectMany(x=> x);
    //     
    // }
    
    //static void Main(string[] args) => BenchmarkRunner.Run<ListAddition>();
    //static void Main(string[] args) => BenchmarkRunner.Run<SealedUnsealed>();
    //static void Main(string[] args) => BenchmarkRunner.Run<CountPennys>();
    //static void Main(string[] args) => BenchmarkRunner.Run<TernaryVsMathMax>();
    //static void Main(string[] args) => BenchmarkRunner.Run<FromUnixConverter>();
    //static void Main(string[] args) => BenchmarkRunner.Run<OddOrEven>();
    //static void Main(string[] args) => BenchmarkRunner.Run<BadJsonConverter>();
    //static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    //class C
    //{
    //    static C()
    //    {
    //        Console.WriteLine("Object created");
    //    }
    //    public C()
    //    {
    //        Console.WriteLine("Entity created");
    //    }
    //}
    public class SerialiserBenchmarksConfig : ManualConfig
    {
        public SerialiserBenchmarksConfig()
        {
            AddDiagnoser(MemoryDiagnoser.Default);
            AddLogger(ConsoleLogger.Default);
            AddColumn(TargetMethodColumn.Method, StatisticColumn.Median, StatisticColumn.StdDev,
                StatisticColumn.Q1, StatisticColumn.Q3, new ParamColumn("Size"));
        }
    }
    //static async Task Main()
    //{
    //    //var c1 = new C();
    //    //var c2 = new C();


    //    var retryHandler = new AsyncRetry();

    //    await retryHandler.TestRetry();

    //    //var converter = new FromUnixConverter();

    //    //var testTimeString = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();

    //    //var obscureImpl = converter.FromUnixMS_Obscure(testTimeString);
    //    //var fineImpl = converter.FromUnixMS_Fine(testTimeString);

    //    //Console.WriteLine(string.Equals(obscureImpl, fineImpl));

    //    //var someID = 123;
    //    //var idArray = new[] { someID };

    //    //var emptyTextArray = Array.Empty<int>();

    //    //var someIds = idArray.Where(x => !emptyTextArray.Contains(x));

    //    //Console.WriteLine(someIds.FirstOrDefault());


    //}



}

internal sealed class AClass
{
    public static void UsingLocalVariablesInTheCallbackCode(Int32 numToDo)
    {
        int[] squares = new int[numToDo];

        AutoResetEvent done = new AutoResetEvent(false);
        
        for (var n = 0; n < squares.Length; n++)
        {
            ThreadPool.QueueUserWorkItem(obj =>
            {
                Int32 num = (int)obj;
                squares[num] = num * num;

                if (Interlocked.Decrement(ref numToDo) == 0)
                {
                    done.Set();
                }
            }, n);

        }

        done.WaitOne();

        for (int n = 0; n < squares.Length; n++)
        {
            Console.WriteLine("Index {0}, Square {1}", n, squares[n]);
        }
    }
}