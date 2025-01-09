using System.Collections.Concurrent;
using Microsoft.AspNetCore.Routing.Constraints;

namespace ParallelThread.Services
{
    public class AppLayerLockCacheService : IAppLevelLockCache
    {
        private long _expireDate;
        private string value = string.Empty;
        private Int32 m_inUse = 0;

        public AppLayerLockCacheService()
        {
        }

        private DateTime ExpiryDate()
        {
            var expDate = Interlocked.CompareExchange(ref _expireDate, 0, 0);
            return DateTime.FromBinary(expDate);
        }

        public void Set(string data)
        {
            Interlocked.Exchange(ref this.value, data);
            Interlocked.Exchange(ref _expireDate, DateTime.Now.AddMinutes(5).ToBinary());
        }

        public string Get()
        {
            if (ExpiryDate() > DateTime.Now)
            {
                return value;
            }

            return string.Empty;
        }
        
    }
}
