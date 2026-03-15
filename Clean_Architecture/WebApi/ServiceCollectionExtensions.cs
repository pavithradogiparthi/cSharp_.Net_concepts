using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Models;

namespace WebApi
{
    public  static class ServiceCollectionExtensions
    {
        public static CacheSettings GetCacheSettings(this IServiceCollection services,IConfiguration configuration)
        {
            var cachesettingsConfiguration = configuration.GetSection("CacheSettings");
            services.Configure<CacheSettings>(cachesettingsConfiguration);
            return cachesettingsConfiguration.Get<CacheSettings>();
        }
    }
}
