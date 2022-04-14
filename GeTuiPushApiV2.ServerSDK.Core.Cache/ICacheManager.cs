namespace GeTuiPushApiV2.ServerSDK.Core.Cache
{
    /// <summary>
    /// 缓存管理抽象
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// 删除指定关键字缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        bool Del(string key);

        /// <summary>
        /// 删除指定关键字缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        Task<bool> DelAsync(string key);

        /// <summary>
        /// 删除指定关键字数组缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        Task<bool> DelAsync(string[] key);

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        bool Set(string key, object value);

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="timeSpan">过期时间</param>
        /// <returns></returns>
        bool Set(string key, object value, TimeSpan timeSpan);

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        Task<bool> SetAsync(string key, object value);

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="timeSpan">过期时间</param>
        /// <returns></returns>
        Task<bool> SetAsync(string key, object value, TimeSpan timeSpan);

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        string Get(string key);

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        Task<string> GetAsync(string key);

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="key">键</param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="key">键</param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string key);

        /// <summary>
        /// 检查给定 key 是否存在
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        bool Exists(string key);

        /// <summary>
        /// 异步检查给定 key 是否存在
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        Task<bool> ExistsAsync(string key);
    }
}