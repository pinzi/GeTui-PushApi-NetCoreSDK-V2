namespace GeTuiPushApiV2.ServerSDK.Core.Redis
{
    /// <summary>
    /// Redis操作对象抽象接口
    /// </summary>
    public interface IRedis
    {
        /// <summary>
        /// 设置键值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="expireTime">有效期</param>
        public void Set(string key, string value, TimeSpan? expireTime = null);
        ///// <summary>
        ///// 设置键值
        ///// </summary>
        ///// <typeparam name="T">值数据类型</typeparam>
        ///// <param name="key">键</param>
        ///// <param name="value">值</param>
        ///// <param name="expireTime">有效期</param>
        //public void Set<T>(string key, T value, TimeSpan? expireTime = null);
        /// <summary>
        /// 读取键值
        /// </summary>
        /// <param name="key">键</param>
        public string Get(string key);
        ///// <summary>
        ///// 读取键值
        ///// </summary>
        ///// <typeparam name="T">值数据类型</typeparam>
        ///// <param name="key">键</param>
        //public T Get<T>(string key);
        /// <summary>
        /// 删除键值
        /// </summary>
        /// <param name="key">键</param>
        public void Remove(string key);
    }
}
