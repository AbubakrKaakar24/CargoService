using CargoService.Application.ServiceContracts;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CargoService.Application.Services
{
    public class RedisService : IRedisService
    {
        private readonly IDatabase _cache;
        public RedisService(IConnectionMultiplexer redis)
        {
            _cache = redis.GetDatabase();
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _cache.StringGetAsync(key);
            if (string.IsNullOrEmpty(value))
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(value!)!;
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? ttl = null)
        {
            var serialized = JsonSerializer.Serialize(value);
            await _cache.StringSetAsync(key, serialized, ttl ?? TimeSpan.FromMinutes(5));
        }

        public async Task<bool> RemoveAsync(string key)
        {
            return await _cache.KeyDeleteAsync(key);
        }
       }
}
