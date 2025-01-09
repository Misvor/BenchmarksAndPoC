using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.FromUnixHypothesis
{
    public class FromUnixConverter
    {
        [Benchmark(Baseline = true), Arguments("1679495725295")]
        public string FromUnixMS_Obscure(string unixTimeOffset)
        {
            var unixTimeStamp = int.Parse(unixTimeOffset.Substring(0, unixTimeOffset.Length - 3));
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
        }
        [Benchmark, Arguments("1679495725295")]
        public string FromUnixMS_Fine(string unixTimeOffset)
        {
            if (!long.TryParse(unixTimeOffset, out var unixMsOffset)) return DateTime.MinValue.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            var unixOffset = DateTimeOffset.FromUnixTimeMilliseconds(unixMsOffset);
            return unixOffset.LocalDateTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
        }
    }
}
