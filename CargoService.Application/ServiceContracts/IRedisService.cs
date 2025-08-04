using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoService.Application.ServiceContracts
{
    public interface IRedisService
    {
        public Task<T> GetAsync<T>(string key);
        public Task SetAsync<T>(string key, T value, TimeSpan? ttl = null);
        public Task<bool> RemoveAsync(string key);


    }
}
