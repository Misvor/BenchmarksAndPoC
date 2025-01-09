using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.HeaderValue
{
    public static class HeaderHelper
    {
        public static string? GetHeader(Dictionary<string,string> headers, string name)
        {
            if (headers.TryGetValue(name, out var header))
            {
                return header ?? string.Empty;
            }

            return string.Empty;
        }
    }
}
