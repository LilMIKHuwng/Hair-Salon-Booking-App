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

            // Deserialize directly
            return JsonSerializer.Deserialize<T>(cachedData);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration, string prefix = null)
        {
            // Serialize the data to be cached
            var serializedData = JsonSerializer.Serialize(value);

            // Set the cache value with expiration
            await _cache.SetStringAsync(key, serializedData, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration
            });

            // If a prefix is provided, add the key to a Redis Set to track it by prefix
            if (!string.IsNullOrEmpty(prefix))
            {
                var db = _redis.GetDatabase();
                await db.SetAddAsync($"{prefix}_keys", key);  // Add key to the set
            }
        }

        public async Task RemoveByPrefixAsync(string prefix)
        {
            var db = _redis.GetDatabase();
            var keySet = $"{prefix}_keys";  // Set name that stores keys with the given prefix

            // Retrieve all keys in the set associated with the prefix
            var keys = await db.SetMembersAsync(keySet);

            // Remove each key individually from the cache
            foreach (var key in keys)
            {
                await _cache.RemoveAsync(key.ToString());
            }

            // Delete the key set after removing all associated keys
            await db.KeyDeleteAsync(keySet);
        }

    }
}
