using Microsoft.Extensions.Caching.Memory;

namespace GeTuiPushApiV2.ServerSDK.Core.Cache
{
    /// <summary>
    /// 内存缓存
    /// </summary>
    public class MemoryCache : ICache
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public long Del(params string[] key)
        {
            foreach (var k in key)
            {
                _memoryCache.Remove(k);
            }
            return key.Length;
        }

        public Task<long> DelAsync(params string[] key)
        {
            foreach (var k in key)
            {
                _memoryCache.Remove(k);
            }

            return Task.FromResult((long)key.Length);
        }
        public bool Exists(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public Task<bool> ExistsAsync(string key)
        {
            return Task.FromResult(_memoryCache.TryGetValue(key, out _));
        }

        public string Get(string key)
        {

            return _memoryCache.GetOrCreate(key, entry => { return entry.Value; })?.ToString();
        }

        public T Get<T>(string key)
        {
            var entry = _memoryCache.Get<ICacheEntry>(key);
            return entry == null ? default(T) : (T)(entry.Value);
        }

        public Task<string> GetAsync(string key)
        {
            return Task.FromResult(Get(key));
        }

        public Task<T> GetAsync<T>(string key)
        {
            return Task.FromResult(Get<T>(key));
        }

        public bool Set(string key, object value)
        {
            var entry = _memoryCache.CreateEntry(key);
            entry.Value = value;
            _memoryCache.Set(key, entry);
            return true;
        }

        public bool Set(string key, object value, TimeSpan expire)
        {
            var entry = _memoryCache.CreateEntry(key);
            entry.Value = value;
            _memoryCache.Set(key, entry, expire);
            return true;
        }

        public Task<bool> SetAsync(string key, object value)
        {
            var entry = _memoryCache.CreateEntry(key);
            entry.Value = value;
            Set(key, entry);
            return Task.FromResult(true);
        }

        public Task<bool> SetAsync(string key, object value, TimeSpan expire)
        {
            var entry = _memoryCache.CreateEntry(key);
            entry.Value = value;
            Set(key, entry, expire);
            return Task.FromResult(true);
        }
    }
}
