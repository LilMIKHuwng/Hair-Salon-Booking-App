using HairSalon.Contract.Services.Cache;
using Microsoft.Extensions.Caching.Distributed;
using Polly;
using System.Text.Json;

namespace HairSalon.Services.Cache
{
	public class RedisCacheService : ICacheService
	{
		private readonly IDistributedCache _cache;

		public RedisCacheService(IDistributedCache cache)
		{
			_cache = cache;
		}

		public async Task<T?> GetListAsync<T>(string key)
		{
			var cachedData = await _cache.GetStringAsync(key);

			if (cachedData is null)
			{
				return default;
			}

			// Deserialize directly, as the BasePaginatedList<T> now has a parameterless constructor and public setters.
			return JsonSerializer.Deserialize<T>(cachedData);
		}



		public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
		{
			var serializedData = JsonSerializer.Serialize(value);
			await _cache.SetStringAsync(key, serializedData, new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = expiration
			});
		}

		public async Task RemoveAsync(string key)
		{
			await _cache.RemoveAsync(key);
		}
	}
}
