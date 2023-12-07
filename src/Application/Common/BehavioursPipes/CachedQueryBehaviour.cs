using Application.Contract;
using Application.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace Application.Common.BehavioursPipes
{
    public class CachedQueryBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICacheQuery, IRequest<TResponse>
    {
        private readonly IDistributedCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CachedQueryBehaviour(IDistributedCache distributedCache, IHttpContextAccessor httpContextAccessor)
        {
            _cache = distributedCache;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response;

            var cachedResponse = await _cache.GetAsync(GenerateKey(), cancellationToken);
            if (cachedResponse != null)
            {
                response = JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedResponse));
            }
            else
            {
                response = await next();
                var serialized = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
                await CreateNewCache(request, cancellationToken, serialized);
            }
            return response;
        }

        private Task CreateNewCache(TRequest request, CancellationToken cancellationToken, byte[] serialized)
        {
            return _cache.SetAsync(GenerateKey(), serialized,
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeToLive(request)
                }, cancellationToken
                );
        }

        private TimeSpan? TimeToLive(TRequest request)
        {
            return new TimeSpan(request.HourSaveData, 0, 0);
        }

        private string GenerateKey()
        {
            return IdGenerator.GenerateCacheKeyFromRequest(_httpContextAccessor.HttpContext.Request);
        }
    }
}
