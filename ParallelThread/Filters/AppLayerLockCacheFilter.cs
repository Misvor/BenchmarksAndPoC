using Microsoft.AspNetCore.Mvc.Filters;
using ParallelThread.Services;

namespace ParallelThread.Filters
{
    public class AppLayerLockCacheFilter : IActionFilter
    {
        private readonly IAppLevelLockCache _appLayerLock;
        private readonly IDatabase _database;
        //private static ManualResetEvent _lock;

        public AppLayerLockCacheFilter(IAppLevelLockCache appLayerLockCache, IDatabase database)
        {
            _appLayerLock = appLayerLockCache;
            _database = database;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //_lock ??= new ManualResetEvent(false);

            //_lock.WaitOne();

            lock (_appLayerLock)
            {
                if (_appLayerLock.Get() == string.Empty)
                {
                    //_appLayerLock.Set(_database.GetBigData());
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }

}
