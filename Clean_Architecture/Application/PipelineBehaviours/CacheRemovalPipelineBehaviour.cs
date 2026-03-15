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

namespace Application.PipelineBehaviours
{
    public class CacheRemovalPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ICacheRemoval
    {
        private readonly IDistributedCache _distributedCache;
        private readonly CacheSettings _cacheSettings;
        public CacheRemovalPipelineBehaviour(IDistributedCache distributedcache, IOptions<CacheSettings> cachesettings)
        {
            _distributedCache = distributedcache;
            _cacheSettings = cachesettings.Value;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response = await next();
            foreach (var key in request.CacheKeys)
            {
                string cachekey = $"{_cacheSettings.ApplicationName}:{key}";
                var cacheResponse = await _distributedCache.GetAsync(cachekey, cancellationToken);
                if (cacheResponse != null)
                {
                    await _distributedCache.RemoveAsync(cachekey, cancellationToken);

                }
            }
            return response;

        }
    }
}
