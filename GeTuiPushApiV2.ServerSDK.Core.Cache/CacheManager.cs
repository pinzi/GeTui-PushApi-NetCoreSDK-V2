using Microsoft.Extensions.Options;

namespace GeTuiPushApiV2.ServerSDK.Core.Cache
{
    /// <summary>
    /// 缓存管理
    /// </summary>
    public class CacheManager : ICacheManager
    {
        private readonly CacheOptions _cacheOptions;
        private readonly ICache _cache;

        /// <summary>
        /// 初始化一个<see cref="CacheManager"/>类型的新实例
        /// </summary>
        public CacheManager(IOptions<CacheOptions> cacheOptions, Func<string, object> resolveNamed)
        {
            _cacheOptions = cacheOptions.Value;
            _cache = resolveNamed(_cacheOptions.CacheType.ToString()) as ICache;
        }

        /// <summary>
        /// 删除指定关键字缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool Del(string key)
        {
            _cache.Del(key);
            return true;
        }

        /// <summary>
        /// 删除指定关键字缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public Task<bool> DelAsync(string key)
        {
            _cache.DelAsync(key);
            return Task.FromResult(true);
        }

        /// <summary>
        /// 删除指定关键字数组缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public Task<bool> DelAsync(string[] key)
        {
            _cache.DelAsync(key);
            return Task.FromResult(true);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool Set(string key, object value)
        {
            return _cache.Set(key, value);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="timeSpan">过期时间</param>
        /// <returns></returns>
        public bool Set(string key, object value, TimeSpan timeSpan)
        {
            return _cache.Set(key, value, timeSpan);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public async Task<bool> SetAsync(string key, object value)
        {
            return await _cache.SetAsync(key, value);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="timeSpan">过期时间</param>
        /// <returns></returns>
        public async Task<bool> SetAsync(string key, object value, TimeSpan timeSpan)
        {
            return await _cache.SetAsync(key, value, timeSpan);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string Get(string key)
        {
            return _cache.Get(key);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public async Task<string> GetAsync(string key)
        {
            return await _cache.GetAsync(key);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="key">键</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="key">键</param>
        /// <returns></returns>
        public Task<T> GetAsync<T>(string key)
        {
            return _cache.GetAsync<T>(key);
        }

        /// <summary>
        /// 检查给定 key 是否存在
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            return _cache.Exists(key);
        }

        /// <summary>
        /// 检查给定 key 是否存在
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public Task<bool> ExistsAsync(string key)
        {
            return _cache.ExistsAsync(key);
        }
    }
}