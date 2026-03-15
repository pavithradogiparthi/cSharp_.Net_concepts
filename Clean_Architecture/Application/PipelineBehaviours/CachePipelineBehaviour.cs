using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.PipelineBehaviours.Contract;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Application.PipelineBehaviours
{
    internal class CachePipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest:IRequest<TResponse>,ICachable
    {
        private readonly IDistributedCache _cache;
        private readonly CacheSettings _cacheSettings;
        public CachePipelineBehaviour(IDistributedCache cache,IOptions<CacheSettings>cacheSettings)
        {
            _cache = cache;
            _cacheSettings = cacheSettings.Value;
            
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request.BypassCache) return await next();
            TResponse response;
            string cacheKey = $"{_cacheSettings.ApplicationName}:{request.CacheKey}";
            var cacheResponse = await _cache.GetAsync(cacheKey, cancellationToken);
            if (cacheResponse != null)
            {
                response = JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cacheResponse));
            }
            else
            {
                response = await GetResponseandWritetoCacheAsync();
            }
            return response;
            async Task<TResponse> GetResponseandWritetoCacheAsync()
            { response = await next();
                if (response != null)
                {
                    var slidingexpiration = request.SlidingExpiration == TimeSpan.Zero?
                            TimeSpan.FromMinutes(_cacheSettings.slidingexpiration)
                            :request.SlidingExpiration;
                        var cacheOptions = new DistributedCacheEntryOptions { 
                            SlidingExpiration=slidingexpiration,
                            AbsoluteExpiration=DateTime.Now.AddDays(1)
                        };
                        var serializedData = Encoding.Default.GetBytes(
                            JsonConvert.SerializeObject(response, Formatting.Indented,
                            new JsonSerializerSettings()
                            { ReferenceLoopHandling=ReferenceLoopHandling.Ignore}));
                        await _cache.SetAsync(cacheKey, serializedData,cacheOptions,cancellationToken);

                    }

                    return response;
                
               
            }
        }
    }
}
