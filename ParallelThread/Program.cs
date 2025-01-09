using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Data.SqlClient;
using ParallelThread.Middleware;
using ParallelThread.Models;

namespace ParallelThread;
using ParallelThread.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
        //builder.Services.AddAuthorization(options =>
        //{
        //    options.FallbackPolicy = options.DefaultPolicy; 
        //});

        builder.Services.AddSwaggerGen();
        builder.Services.AddEnyimMemcached();
        builder.Services.AddSingleton<IDatabase, DatabaseMock>();
        builder.Services.AddSingleton<IAppLevelLockCache, AppLayerLockCacheService>();
        builder.Services.AddSingleton<ICoreLevelLockCache, CoreLayerLockCacheService>();
        builder.Services.AddSingleton<IHybridLockCache, HybridLockCacheService>();
        builder.Services.AddScoped<HybridCachingMiddleware>();
        builder.Services.AddScoped<MemcachedMiddleware>();
        builder.Services.AddScoped<CoreCachingMiddleware>();
        builder.Services.AddScoped<AppCachingMiddleware>();
        
        //Dapper
        var connectionString = new SqlConnectionStringBuilder()
        {
            DataSource = "127.0.0.0",
            InitialCatalog = "Dev_fragebogen_db",
            UserID = "postgres",
            Password = "my_secret_password"
        };
           
        builder.Services.AddTransient<IDapperRepository, DapperRepository>(provider => new DapperRepository("Host=localhost;Port=5432;Database=Dev_fragebogen_db;Username=postgres;Password=my_secret_password"));


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DisplayRequestDuration();
            });
        }

        //app.UseRateLimiter(new RateLimiterOptions()
            //.AddConcurrencyLimiter(policyName:"get", options => options.PermitLimit = 1) // Prevents even entering short-circuiting middleware
        //);

        app.UseHttpsRedirection();
        //app.UseResponseCaching(); // easy way for caching
        app.UseWhen(path => path.Request.Path.StartsWithSegments("/Heavylocked/GetHybridLocked"), app => app.UseHybridCaching());
        app.UseWhen(path => path.Request.Path.StartsWithSegments("/Heavylocked/GetApplocked"), app => app.UseAppCaching());
        app.UseWhen(path => path.Request.Path.StartsWithSegments("/Heavylocked/GetCoreLocked"), app => app.UseCoreCaching());
        app.UseWhen(path => path.Request.Path.StartsWithSegments("/Heavylocked/Memcached"), app => app.UseMemcachedMiddleware());
        app.UseAuthorization();
        app.UseEnyimMemcached();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

