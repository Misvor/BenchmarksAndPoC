using System.Collections.Concurrent;
namespace ParallelThread.Services
{
    public class HybridLockCacheService : IHybridLockCache
    {
        public HybridLockCacheService()
        {
            _lock = new HybridLock();
        }

        private readonly HybridLock _lock;

        private CacheObject m_value = new CacheObject(String.Empty);
        public CacheObject m_cacheObject
        {
            get
            {
                return m_value;
            }
            set
            {
                m_value = value;
            }
        }

        public void Set(string data)
        {
            _lock.Enter();
            m_cacheObject = new CacheObject(data);
            _lock.Leave();
        }

        public string Get()
        {
            _lock.Enter();
            string result = string.Empty;
            if (m_cacheObject.ExpireTime > DateTime.Now)
            {
                result = m_cacheObject.Value;
            }
            _lock.Leave();
            return result;
        }
    }
}
