using Microsoft.AspNetCore.Mvc.Filters;
using ParallelThread.Services;

namespace ParallelThread.Filters
{
    public class CoreLevelCacheFilter : IActionFilter
    {
        private readonly ICoreLevelLockCache _coreLockCache;
        private readonly IDatabase _database;
        private readonly Semaphore _canAccessProperty;

        public CoreLevelCacheFilter(ICoreLevelLockCache coreLevelLockCache, IDatabase database)
        {
            _coreLockCache = coreLevelLockCache;
            _database = database;
            _canAccessProperty = new Semaphore(1, 1, "UniqueName");
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _canAccessProperty.WaitOne();
            if (_coreLockCache.Get() != string.Empty)
            {
                _canAccessProperty.Release(1);
            }
            else
            {
                //_coreLockCache.Set(_database.GetBigData());
                _canAccessProperty.Release(1);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }
    }
}
