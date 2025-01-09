using Enyim.Caching;
using Microsoft.Net.Http.Headers;
using ParallelThread.Services;
using System.Net.Mime;

namespace ParallelThread.Middleware
{
    public class MemcachedMiddleware : IMiddleware
    {
        private readonly IMemcachedClient _memcachedClient;

        public MemcachedMiddleware(IMemcachedClient memcachedClient)
        {
            _memcachedClient = memcachedClient;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // does not apply to unit tests, still easy way for caching
            //context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
            //{
            //    Public = true,
            //    MaxAge = TimeSpan.FromMinutes(5)
            //};

            var cached = _memcachedClient.Get<string>("123");
            if (!string.IsNullOrEmpty(cached))
            {
                using MemoryStream ms = new MemoryStream();
                await using var sw = new StreamWriter(ms);
                await sw.WriteAsync(cached);
                await sw.FlushAsync();
                ms.Seek(0, SeekOrigin.Begin);
                context.Response.ContentType = MediaTypeNames.Text.Plain;
                await ms.CopyToAsync(context.Response.Body);

                //await context.Response.WriteAsync(cached);
            }
            else
            {
                await next(context);
            }
        }

    }

    public static class MemcachedMiddlewareExtension
    {
        public static IApplicationBuilder UseMemcachedMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MemcachedMiddleware>();
        }
    }
}
