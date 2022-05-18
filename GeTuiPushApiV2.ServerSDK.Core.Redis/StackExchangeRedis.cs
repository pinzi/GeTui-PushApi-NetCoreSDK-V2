using StackExchange.Redis;
using System.Collections.Concurrent;

namespace GeTuiPushApiV2.ServerSDK.Core.Redis
{
    /// <summary>
    /// 使用StackExchange.Redis客户端操作Redis
    /// </summary>
    public class StackExchangeRedis : IRedis
    {
        /// <summary>
        /// Redis配置信息
        /// </summary>
        private readonly RedisOptions _redisOptions;
        /// <summary>
        /// Redis连接对象
        /// </summary>
        private ConnectionMultiplexer redis;
        /// <summary>
        ///  Redis数据库
        /// </summary>
        private IDatabase db;
        /// <summary>
        /// Redis连接对象池，线程安全
        /// </summary>
        private static readonly ConcurrentDictionary<string, ConnectionMultiplexer> ConnectionPool = new ConcurrentDictionary<string, ConnectionMultiplexer>();

        /// <summary>
        /// 构造函数，单例模式
        /// </summary>
        /// <param name="ConnString">redis连接字符串</param>
        /// <param name="DbNum">数据库编号</param>
        public StackExchangeRedis(RedisOptions options)
        {
            _redisOptions = options;
            string ConnString = $"{_redisOptions.Host}:{_redisOptions.Port},password={_redisOptions.Pass}";
            if (ConnectionPool.ContainsKey(ConnString))
            {
                redis = ConnectionPool[ConnString];
                //Console.WriteLine("redis来自对象池");
            }
            else
            {
                redis = ConnectionMultiplexer.Connect(ConnString);
                ConnectionPool.TryAdd(ConnString, redis);
                //Console.WriteLine("redis初始化成功");
            }
            db = redis.GetDatabase(_redisOptions.DbNum);
        }


        /// <summary>
        /// 删除键值
        /// </summary>
        /// <param name="key">键</param>
        public void Remove(string key)
        {
            db.KeyDelete(key);
        }

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

        #region Set集合键值
        /// <summary>
        /// 设置Set集合键值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">Set集合键值</param>
        public void SetAdd(string key, List<string> value)
        {
            db.SetAdd(key, value.Select(i => new RedisValue(i)).ToArray());
        }
        /// <summary>
        /// 读取Set集合键值
        /// </summary>
        /// <param name="key">键</param>
        public List<string> GetList(string key)
        {
            return db.SetMembers(key).Select(s => s.ToString()).ToList();
        }
        /// <summary>
        /// 删除指定的Set集合键值
        /// </summary>
        /// <param name="key">键</param>
        public void SetRemove(string key, string value)
        {
            db.SetRemove(key, value);
        }
        #endregion
    }
}
