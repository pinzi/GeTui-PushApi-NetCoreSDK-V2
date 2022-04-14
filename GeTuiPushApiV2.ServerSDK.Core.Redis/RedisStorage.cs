using GeTuiPushApiV2.ServerSDK.Storage;

namespace GeTuiPushApiV2.ServerSDK.Core.Redis
{
    /// <summary>
    /// 使用Redis存储数据
    /// </summary>
    public class RedisStorage : IStorage
    {
        /// <summary>
        /// Redis操作对象
        /// </summary>
        private readonly IRedis _iRedis;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="iRedis">Redis操作对象</param>
        public RedisStorage(IRedis iRedis)
        {
            _iRedis = iRedis;
        }

        /// <summary>
        /// 保存接口调用凭据
        /// </summary>
        /// <param name="appId">应用id</param>
        /// <param name="token">推送接口调用凭据</param>
        /// <param name="expireTime">接口调用凭据有效期</param>
        public void SaveToken(string appId, string token, TimeSpan? expireTime = null)
        {
            if (expireTime.HasValue)
            {
                _iRedis.Set(appId, token, expireTime.Value);
            }
            else
            {
                _iRedis.Set(appId, token);
            }
        }
        /// <summary>
        /// 获取接口调用凭据
        /// </summary>
        /// <param name="appId">应用id</param>
        /// <returns>接口调用凭据</returns>
        public string GetToken(string appId)
        {
            return _iRedis.Get(appId);
        }
        /// <summary>
        /// 存储CID
        /// </summary>
        /// <param name="uid">用户唯一标示</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        /// <param name="expireTime">CID有效期</param>
        public void AddCID(string uid, string cid, TimeSpan? expireTime = null)
        {
            if (expireTime.HasValue)
            {
                _iRedis.Set(uid, cid, expireTime.Value);
            }
            else
            {
                _iRedis.Set(uid, cid);
            }
        }
        /// <summary>
        /// 获取用户关联的个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户唯一标示</param>
        /// <returns>个推SDK的唯一识别号</returns>
        public string GetCID(string uid)
        {
            return _iRedis.Get(uid);
        }
        /// <summary>
        /// 删除用户关联的个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户唯一标示</param>
        public void DeleteCID(string uid)
        {
            _iRedis.Remove(uid);
        }
    }
}