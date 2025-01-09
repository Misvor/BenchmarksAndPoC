using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BadJsonSerialize
{
    public class Type1
    {
        public string blaBla { get; set; } = "123123123";
        public string blaBlaSecond { get; set; } = "321321321";
        public DateTime blaBlaTime { get; set; } = DateTime.Now;
        public int SomeInt { get; set; } = Int32.MinValue;
    }
}
