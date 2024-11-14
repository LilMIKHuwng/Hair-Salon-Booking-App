using HairSalon.Contract.Services.Cache;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System.Text.Json;

namespace HairSalon.Services.Cache
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        private readonly IConnectionMultiplexer _redis;

        public RedisCacheService(IDistributedCache cache, IConnectionMultiplexer redis)
        {
            _cache = cache;
            _redis = redis;
        }

        public async Task<T?> GetListAsync<T>(string key)
        {
            var cachedData = await _cache.GetStringAsync(key);

            if (cachedData is null)
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(cachedData);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration, string prefix = null)
        {
            var serializedData = JsonSerializer.Serialize(value);

            await _cache.SetStringAsync(key, serializedData, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration
            });

            if (!string.IsNullOrEmpty(prefix))
            {
                var db = _redis.GetDatabase();
                await db.SetAddAsync($"{prefix}_keys", key); 
            }
        }

        public async Task RemoveByPrefixAsync(string prefix)
        {
            var db = _redis.GetDatabase();
            var keySet = $"{prefix}_keys"; 

            var keys = await db.SetMembersAsync(keySet);

            foreach (var key in keys)
            {
                await _cache.RemoveAsync(key.ToString());
            }

            await db.KeyDeleteAsync(keySet);
        }

    }
}
