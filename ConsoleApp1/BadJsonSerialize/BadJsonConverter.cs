using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ConsoleApp1.BadJsonSerialize;
using static Program;

namespace ConsoleApp1
{
    [SimpleJob(RuntimeMoniker.Net80)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [Config(typeof(SerialiserBenchmarksConfig))]
    public class BadJsonConverter
    {

        public BadJsonConverter()
        {
            for (int i = 0; i < 100; i++)
            {
                Source.Add(new Type1());
            }
        }

        private List<object> Source = new List<object>();


        [Benchmark]
        public void BenchJsonConvert_Bad()
        {
            foreach (var objecto in Source)
            {
                objecto.JsonConvert_Bad();
            }
        }

        [Benchmark(Baseline = true)]
        public void BenchJsonConvert_Fine()
        {
            foreach (var objecto in Source)
            {
                objecto.JsonConvert_Fine();
            }
        }
    }

    internal static class JsonConverters
    {
        public static JsonSerializerSettings _cachedSettings = new JsonSerializerSettings()
        {
            ContractResolver = new DefaultContractResolver()
        };

        public static string JsonConvert_Bad(this object? source)
        {
            if (source is null)
            {
                return "null";
            }

            try
            {
                if (source.GetType().IsValueType || source is string || source is Stream)
                {
                    return source.ToString();
                }

                return JsonConvert.SerializeObject(source,
                    new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
            }
            catch (Exception ex)
            {
                return $"Exception{source.GetType().FullName} : {ex}";
            }
        }

        public static string JsonConvert_Fine(this object? source)
        {
            if (source is null)
            {
                return "null";
            }

            try
            {
                if (source.GetType().IsValueType || source is string || source is Stream)
                {
                    return source.ToString();
                }

                return JsonConvert.SerializeObject(source, _cachedSettings);
            }
            catch (Exception ex)
            {
                return $"Exception{source.GetType().FullName} : {ex}";
            }
        }
    }
}
