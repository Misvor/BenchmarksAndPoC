using Microsoft.Net.Http.Headers;
using ParallelThread.Services;
using System.Net.Mime;

namespace ParallelThread.Middleware
{
    public class HybridCachingMiddleware : IMiddleware
    {
        private readonly IHybridLockCache _lockCache;

        public HybridCachingMiddleware(IHybridLockCache lockCache)
        {
            _lockCache = lockCache;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // does not apply to unit tests, still easy way for caching
            //context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
            //{
            //    Public = true,
            //    MaxAge = TimeSpan.FromMinutes(5)
            //};
            var cached = _lockCache.Get();
            if (!string.IsNullOrEmpty(cached))
            {
                using MemoryStream ms = new MemoryStream();
                await using var sw = new StreamWriter(ms);
                await sw.WriteAsync(cached);
                await sw.FlushAsync();
                if (!context.Response.HasStarted)
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    context.Response.ContentType = MediaTypeNames.Text.Plain;
                    await ms.CopyToAsync(context.Response.Body);
                }
                //await context.Response.WriteAsync(cached);
            }
            else
            {
                await next(context);
            }
        }

    }

    public static class HybridCachingMiddlewareExtensions
    {
        public static IApplicationBuilder UseHybridCaching(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HybridCachingMiddleware>();
        }
    }
}
