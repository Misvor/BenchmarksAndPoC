using System.Diagnostics;
using Enyim.Caching;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using ParallelThread.Filters;
using ParallelThread.Services;

namespace ParallelThread.Controllers;

[ApiController]
[Route("[controller]")]
public class HeavylockedController : ControllerBase
{

    private readonly IAppLevelLockCache _applocked;
    private readonly ICoreLevelLockCache _coreLocked;
    private readonly IHybridLockCache _hybridLocked;
    private readonly IMemcachedClient _memcachedClient;
    private readonly IDatabase _database;
    private static readonly object _lockHybrid = new object();
    private static readonly object _lockApp = new object();
    private static readonly object _lockCore = new object();
    private static readonly object _lockMemc = new object();

    public HeavylockedController(IAppLevelLockCache _appLevelLock,
        ICoreLevelLockCache coreLevelLockCache, IHybridLockCache hybridLocked, IDatabase database, IMemcachedClient memcachedClient)
    {
        _applocked = _appLevelLock;
        _coreLocked = coreLevelLockCache;
        _hybridLocked = hybridLocked;
        _database = database;
        _memcachedClient = memcachedClient;
    }

    //[TypeFilter(typeof(AppLayerLockCacheFilter))]
    [EnableRateLimiting("get")]
    [HttpGet("GetApplocked")]
    public async Task<string> GetApplocked()
    {
        lock (_lockApp)
        {
            var data = _applocked.Get();
            if (string.IsNullOrEmpty(data))
            {
                data = _database.GetBigData();

                // We could've get it via Task.Run if we had other things to do.
                _applocked.Set(data);
            }

            return data;
        }
    } 

    //[TypeFilter(typeof(AppLayerLockCacheFilter))]
    [EnableRateLimiting("get")]
    [HttpGet("Memcached")]
    public async Task<string> Memcached()
    {
        lock (_lockMemc)
        {
            var data = _memcachedClient.Get<string>("123");
            if (string.IsNullOrEmpty(data))
            {
                data = _database.GetBigData();

                var saved = _memcachedClient.Set("123", data, 300);
                if (!saved)
                {
                    Debugger.Break();
                }
            }

            return data;
        }
    }

    //[TypeFilter(typeof(CoreLevelCacheFilter))]
    [EnableRateLimiting("get")]
    [HttpGet("GetCoreLocked")]
    public async Task<string> GetCoreLocked()
    {
        lock (_lockCore)
        {
            var data = _coreLocked.Get();
            if (string.IsNullOrEmpty(data))
            {
                data = _database.GetBigData();

                _coreLocked.Set(data);
            }

            return data;
        }
    }

    //[TypeFilter(typeof(HybridLockCacheFilter))]
    [EnableRateLimiting("get")]
    [HttpGet("GetHybridLocked")]
    public async Task<string> GetHybridLocked()
    {
        lock (_lockHybrid)
        {
            var data = _hybridLocked.Get();
            if (string.IsNullOrEmpty(data))
            {
                data = _database.GetBigData();

                _hybridLocked.Set(data);
            }

            return data;
        }
    }

}
