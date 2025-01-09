using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Class
{
    public class AsyncRetry
    {
        private int _mockCount = 0;


        public async Task TestRetry()
        {
           var result = await TryWithDelayAsync(PrintToConsole, 123, 5);
           Console.WriteLine($"Retry result: {result}");
        }

        public async Task<T> TryWithDelayAsync<T>(Func<int, Task<T>> action, int orderId, int maxTryCount = 3)
        {
            var receiptInfo = default(T);
            var tries = 0;
            while (receiptInfo == null && tries < maxTryCount)
            {
                receiptInfo = await action(orderId);
                await Task.Delay(1000);
                tries++;
            }

            return receiptInfo;
        }

        private async Task<int?> PrintToConsole(int someValue)
        {
            Console.WriteLine("Another try for value");
            if (++_mockCount > 4)
            {
                return someValue;
            }
            else
            {
                return null;
            }
        }

    }
}
