namespace GeTuiPushApiV2.ServerSDK.Core.Redis
{
    /// <summary>
    /// Redis操作对象抽象接口
    /// </summary>
    public interface IRedis
    {
        /// <summary>
        /// 删除键值
        /// </summary>
        /// <param name="key">键</param>
        public void Remove(string key);
        /// <summary>
        /// 批量删除键值
        /// </summary>
        /// <param name="keys">键列表</param>
        public void Remove(List<string> keys);

        #region 单键值
        /// <summary>
        /// 设置键值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="expireTime">有效期</param>
        public void Set(string key, string value, TimeSpan? expireTime = null);
        /// <summary>
        /// 读取键值
        /// </summary>
        /// <param name="key">键</param>
        public string Get(string key);
        #endregion

        #region Set集合键值
        /// <summary>
        /// 设置Set集合键值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">Set集合键值</param>
        public void SetAdd(string key, string value);
        /// <summary>
        /// 设置Set集合键值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">Set集合键值</param>
        public void SetAdd(string key, List<string> value);
        /// <summary>
        /// 读取Set集合键值
        /// </summary>
        /// <param name="key">键</param>
        public List<string> GetList(string key);
        /// <summary>
        /// 删除指定的Set集合键值
        /// </summary>
        /// <param name="key">键</param>
        public void SetRemove(string key, string value);
        #endregion
    }
}
