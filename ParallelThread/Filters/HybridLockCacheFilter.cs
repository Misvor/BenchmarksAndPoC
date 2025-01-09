using Microsoft.AspNetCore.Mvc.Filters;
using ParallelThread.Services;

namespace ParallelThread.Filters
{
    public class HybridLockCacheFilter : IActionFilter
    {
        private readonly IHybridLockCache _hybridLockCache;
        private readonly IDatabase _database;

        public HybridLockCacheFilter(IHybridLockCache hybridLockCache, IDatabase database)
        {
            _hybridLockCache = hybridLockCache;
            _database = database;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            lock (_hybridLockCache)
            {
                if (_hybridLockCache.Get() == string.Empty)
                {
                    //_hybridLockCache.Set(_database.GetBigData());
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }
    }
}
