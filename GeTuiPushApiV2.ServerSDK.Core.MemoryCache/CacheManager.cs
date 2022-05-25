using Microsoft.Extensions.Caching.Memory;

namespace GeTuiPushApiV2.ServerSDK.Core.MemoryCache
{
    /// <summary>
    /// 内存缓存管理对象
    /// </summary>
    public class MemoryManager
    {
        /// <summary>
        /// 内存缓存管理对象
        /// </summary>
        public static MemoryManager Default = new MemoryManager();
        /// <summary>
        /// 内存缓存对象
        /// </summary>
        private IMemoryCache _cache = new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions());

        /// <summary>
        /// 取得缓存数据
        /// </summary>
        /// <typeparam name="T">类型值</typeparam>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            _cache.TryGetValue<T>(key, out T value);
            return value;
        }

        /// <summary>
        /// 设置缓存(永不过期)
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存值</param>
        public void Set_NotExpire<T>(string key, T value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            T v;
            if (_cache.TryGetValue(key, out v))
                _cache.Remove(key);
            _cache.Set(key, value);
        }

        /// <summary>
        /// 设置集合缓存(永不过期)
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存值</param>
        public void SetList_NotExpire<T>(string key, T value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            if (_cache.TryGetValue(key, out List<T> vlist))
            {
                //读取已有缓存数据成功
                vlist.Add(value);
                vlist = vlist.Distinct().ToList();
                _cache.Set(key, vlist);
            }
            else
            {
                //读取已有缓存数据失败
                _cache.Set(key, new List<T>() { value });
            }
        }

        /// <summary>
        /// 设置集合缓存(永不过期)
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存值</param>
        public void SetList_NotExpire<T>(string key, List<T> value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            if (_cache.TryGetValue(key, out List<T> vlist))
            {
                //读取已有缓存数据成功
                vlist.AddRange(value);
                vlist = vlist.Distinct().ToList();
                _cache.Set(key, vlist);
            }
            else
            {
                //读取已有缓存数据失败
                _cache.Set(key, value);
            }
        }

        /// <summary>
        /// 设置缓存(滑动过期:超过一段时间不访问就会过期,一直访问就一直不过期)
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存值</param>
        public void Set_SlidingExpire<T>(string key, T value, TimeSpan span)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            T v;
            if (_cache.TryGetValue(key, out v))
                _cache.Remove(key);
            _cache.Set(key, value, new MemoryCacheEntryOptions()
            {
                SlidingExpiration = span
            });
        }

        /// <summary>
        /// 设置缓存(绝对时间过期:从缓存开始持续指定的时间段后就过期,无论有没有持续的访问)
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存值</param>
        public void Set_AbsoluteExpire<T>(string key, T value, TimeSpan span)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            T v;
            if (_cache.TryGetValue(key, out v))
                _cache.Remove(key);
            _cache.Set(key, value, span);
        }

        /// <summary>
        /// 设置缓存(绝对时间过期+滑动过期:比如滑动过期设置半小时,绝对过期时间设置2个小时，那么缓存开始后只要半小时内没有访问就会立马过期,如果半小时内有访问就会向后顺延半小时，但最多只能缓存2个小时)
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存值</param>
        public void Set_SlidingAndAbsoluteExpire<T>(string key, T value, TimeSpan slidingSpan, TimeSpan absoluteSpan)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            T v;
            if (_cache.TryGetValue(key, out v))
                _cache.Remove(key);
            _cache.Set(key, value, new MemoryCacheEntryOptions()
            {
                SlidingExpiration = slidingSpan,
                AbsoluteExpiration = DateTimeOffset.Now.AddMilliseconds(absoluteSpan.TotalMilliseconds)
            });
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">关键字</param>
        public void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            _cache.Remove(key);
        }

        /// <summary>
        /// 移除集合缓存指定元素
        /// </summary>
        /// <typeparam name="T">集合数据类型</typeparam>
        /// <param name="key">关键字</param>
        /// <param name="value">集合元素值</param>
        /// <exception cref="ArgumentNullException">关键字不存在</exception>
        public void SetRemove<T>(string key, T value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            var list = Get<List<T>>(key);
            if (list != null)
            {
                list.RemoveAll(t => value!.Equals(t));
                _cache.Set(key, list);
            }
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            if (_cache != null)
                _cache.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
