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


        #region Token        
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
        /// 删除接口调用凭据
        /// </summary>
        /// <param name="appId">应用id</param>
        public void DeleteToken(string appId)
        {
            _iRedis.Remove(appId);
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
        #endregion

        #region CID
        /// <summary>
        /// 存储CID
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        /// <param name="expireTime">CID有效期</param>
        public void SaveCID(string uid, string cid)
        {
            _iRedis.SetAdd(uid, new List<string>() { cid });
        }
        /// <summary>
        /// 获取用户关联的个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns>个推SDK的唯一识别号</returns>
        public List<string> GetCID(string uid)
        {
            return _iRedis.GetList(uid);
        }
        /// <summary>
        /// 删除用户关联的全部个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        public void DeleteCID(string uid)
        {
            _iRedis.Remove(uid);
        }
        /// <summary>
        /// 删除用户关联的指定个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        public void DeleteCID(string uid, string cid)
        {
            _iRedis.SetRemove(uid, cid);
        }
        #endregion

        #region 别名
        /// <summary>
        /// 保存别名数据
        /// </summary>
        /// <param name="cid">个推SDK的唯一识别号</param>
        /// <param name="alias">别名数据列表</param>
        public void SaveAlias(string cid, string alias)
        {
            _iRedis.SetAdd(cid, new List<string>() { alias });
        }
        /// <summary>
        /// 保存别名数据列表
        /// </summary>
        /// <param name="cid">个推SDK的唯一识别号</param>
        /// <param name="alias">别名数据列表</param>
        public void SaveAlias(string cid, List<string> alias)
        {
            _iRedis.SetAdd(cid, alias);
        }
        /// <summary>
        /// 删除别名关联的所有cid列表
        /// </summary>
        /// <param name="alias">别名</param>
        public void DeleteAlias(string alias)
        {
            _iRedis.Remove(alias);
        }
        /// <summary>
        /// 删除别名关联的指定cid
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        public void DeleteAlias(string alias, string cid)
        {
            _iRedis.SetRemove(alias, cid);
        }
        /// <summary>
        /// 批量删除别名关联的指定cid列表
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void DeleteAlias(string alias, List<string> cids)
        {
            foreach (var cid in cids)
            {
                _iRedis.SetRemove(alias, cid);
            }
        }
        /// <summary>
        /// 获取别名关联的cid列表
        /// </summary>
        /// <param name="alias">别名</param>
        /// <returns>个推SDK的唯一识别号列表</returns>
        public List<string> GetAlias(string alias)
        {
            return _iRedis.GetList(alias);
        }
        #endregion

        #region 标签
        /// <summary>
        /// 保存标签数据
        /// </summary>
        /// <param name="tag">别名</param>
        /// <param name="cid">个推SDK的唯一识别号列表</param>
        public void SaveTag(string tag, string cid)
        {
            SaveTag(cid, new List<string>() { cid });
        }
        /// <summary>
        /// 保存标签数据
        /// </summary>
        /// <param name="tag">别名</param>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void SaveTag(string tag, List<string> cids)
        {
            _iRedis.SetAdd(tag, cids);
        }
        #endregion
    }
}