using System.Collections.Concurrent;
namespace ParallelThread.Services
{
    public class CoreLayerLockCacheService : ICoreLevelLockCache, IDisposable
    {
        public CoreLayerLockCacheService()
        {
            m_available = new AutoResetEvent(true);
        }

        private readonly AutoResetEvent m_available;

        private CacheObject? m_value = null;
        public CacheObject? m_cacheObject
        {
            get
            {
                m_available.WaitOne();
                var result =  m_value;
                m_available.Set();
                return result;
            }
            set
            {
                m_available.WaitOne();
                m_value = value;
                m_available.Set();
            }
        }

        public void Set(string data)
        {
            m_cacheObject = new CacheObject(data);
        }

        public string Get()
        {
            if (m_cacheObject?.ExpireTime > DateTime.Now)
            {
                return m_cacheObject?.Value ?? string.Empty;
            }
            return string.Empty;
        }

        public void Dispose()
        {
            m_available.Dispose();
        }
    }
}
