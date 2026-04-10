using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System.Collections.Concurrent;

namespace GeTuiPushApiV2.NetCoreSDK.Core.Redis
{
    /// <summary>
    /// 使用 StackExchange.Redis 客户端操作 Redis
    /// </summary>
    public class StackExchangeRedis : IRedis
    {
        /// <summary>
        /// Redis 配置信息
        /// </summary>
        private readonly RedisOptions _redisOptions;
        /// <summary>
        /// Redis 连接对象
        /// </summary>
        private ConnectionMultiplexer redis;
        /// <summary>
        ///  Redis 数据库
        /// </summary>
        private IDatabase db;
        /// <summary>
        /// Redis 连接对象池，线程安全
        /// </summary>
        private static readonly ConcurrentDictionary<string, ConnectionMultiplexer> ConnectionPool = new ConcurrentDictionary<string, ConnectionMultiplexer>();

        /// <summary>
        /// 构造函数，单例模式
        /// </summary>
        /// <param name="options">redis 连接配置</param>
        public StackExchangeRedis(RedisOptions options)
        {
            _redisOptions = options;
            
            // 使用 ConfigurationOptions 构建连接字符串，避免特殊字符问题和安全风险
            var configOptions = new ConfigurationOptions
            {
                EndPoints = { { _redisOptions.Host, _redisOptions.Port } },
                Password = string.IsNullOrEmpty(_redisOptions.Pass) ? null : _redisOptions.Pass,
                DefaultDatabase = _redisOptions.DbNum,
                Ssl = false,
                AbortOnConnectFail = false,
                ConnectTimeout = 5000,
                SyncTimeout = 5000
            };
            
            string connString = configOptions.ToString();
            
            if (ConnectionPool.TryGetValue(connString, out var existingConnection))
            {
                redis = existingConnection;
            }
            else
            {
                redis = ConnectionMultiplexer.Connect(configOptions);
                ConnectionPool.TryAdd(connString, redis);
            }
            db = redis.GetDatabase(_redisOptions.DbNum);
        }


        #region 删除键
        /// <summary>
        /// 删除键值
        /// </summary>
        /// <param name="key">键</param>
        public void Remove(string key)
        {
            db.KeyDelete(key);
        }
        /// <summary>
        /// 批量删除键值
        /// </summary>
        /// <param name="keys">键列表</param>
        public void Remove(List<string> keys)
        {
            db.KeyDelete(keys.Select(s => new RedisKey(s)).ToArray());
        }
        #endregion

        #region 单键值
        /// <summary>
        /// 设置键值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="expireTime">有效期</param>
        public void Set(string key, string value, TimeSpan? expireTime = null)
        {
            db.StringSet(key, value, expireTime);
        }
        /// <summary>
        /// 读取键值
        /// </summary>
        /// <param name="key">键</param>
        public string Get(string key)
        {
            return db.StringGet(key);
        }
        #endregion

        #region Set 集合键值
        /// <summary>
        /// 设置 Set 集合键值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">Set 集合键值</param>
        public void SetAdd(string key, string value)
        {
            db.SetAdd(key, value);
        }
        /// <summary>
        /// 设置 Set 集合键值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">Set 集合键值</param>
        public void SetAdd(string key, List<string> value)
        {
            db.SetAdd(key, value.Select(i => new RedisValue(i)).ToArray());
        }
        /// <summary>
        /// 读取 Set 集合键值
        /// </summary>
        /// <param name="key">键</param>
        public List<string> GetList(string key)
        {
            return db.SetMembers(key).Select(s => s.ToString()).ToList();
        }
        /// <summary>
        /// 删除指定的 Set 集合键值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void SetRemove(string key, string value)
        {
            db.SetRemove(key, value);
        }
        #endregion
    }
}
