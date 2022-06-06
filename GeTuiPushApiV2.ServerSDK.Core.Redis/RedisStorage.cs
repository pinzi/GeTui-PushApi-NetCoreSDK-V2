using GeTuiPushApiV2.ServerSDK.Core.Storage;
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
        /// 个推配置信息
        /// </summary>
        private readonly GeTuiPushOptions _geTuiPushOptions;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="iRedis">Redis操作对象</param>
        /// <param name="geTuiPushOptions">个推配置信息</param>
        public RedisStorage(IRedis iRedis, GeTuiPushOptions geTuiPushOptions)
        {
            _iRedis = iRedis;
            _geTuiPushOptions = geTuiPushOptions;
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
                _iRedis.Set($"{StorageKeyPrefix.AUTH_TOKEN}{appId}", token, expireTime.Value);
            }
            else
            {
                _iRedis.Set($"{StorageKeyPrefix.AUTH_TOKEN}{appId}", token);
            }
        }
        /// <summary>
        /// 删除接口调用凭据
        /// </summary>
        /// <param name="appId">应用id</param>
        public void DeleteToken(string appId)
        {
            _iRedis.Remove($"{StorageKeyPrefix.AUTH_TOKEN}{appId}");
        }
        /// <summary>
        /// 获取接口调用凭据
        /// </summary>
        /// <param name="appId">应用id</param>
        /// <returns>接口调用凭据</returns>
        public string GetToken(string appId)
        {
            return _iRedis.Get($"{StorageKeyPrefix.AUTH_TOKEN}{appId}");
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
            _iRedis.SetAdd($"{StorageKeyPrefix.PUSH_CID}{uid}", new List<string>() { cid });
        }
        /// <summary>
        /// 获取用户关联的个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns>个推SDK的唯一识别号</returns>
        public List<string> GetCID(string uid)
        {
            return _iRedis.GetList($"{StorageKeyPrefix.PUSH_CID}{uid}");
        }
        /// <summary>
        /// 删除用户关联的全部个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        public void DeleteCID(string uid)
        {
            _iRedis.Remove($"{StorageKeyPrefix.PUSH_CID}{uid}");
        }
        /// <summary>
        /// 删除用户关联的指定个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        public void DeleteCID(string uid, string cid)
        {
            _iRedis.SetRemove($"{StorageKeyPrefix.PUSH_CID}{uid}", cid);
        }
        #endregion

        #region 别名
        /// <summary>
        /// 保存别名数据
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void SaveAlias(string alias, string cids)
        {
            string key = $"{StorageKeyPrefix.PUSH_ALIAS}{alias}";
            _iRedis.SetAdd(key, new List<string>() { cids });
        }
        /// <summary>
        /// 批量保存别名数据列表
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void SaveAlias(string alias, List<string> cids)
        {
            string key = $"{StorageKeyPrefix.PUSH_ALIAS}{alias}";
            _iRedis.SetAdd(key, cids);
        }
        /// <summary>
        /// 删除别名关联的所有cid列表
        /// </summary>
        /// <param name="alias">别名</param>
        public void DeleteAlias(string alias)
        {
            string key = $"{StorageKeyPrefix.PUSH_ALIAS}{alias}";
            _iRedis.Remove(key);
        }
        /// <summary>
        /// 删除别名关联的指定cid
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        public void DeleteAlias(string alias, string cid)
        {
            string key = $"{StorageKeyPrefix.PUSH_ALIAS}{alias}";
            _iRedis.SetRemove(key, cid);
        }
        /// <summary>
        /// 批量删除别名关联的指定cid列表
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void DeleteAlias(string alias, List<string> cids)
        {
            string key = $"{StorageKeyPrefix.PUSH_ALIAS}{alias}";
            foreach (var cid in cids)
            {
                _iRedis.SetRemove(key, cid);
            }
        }
        /// <summary>
        /// 获取别名关联的cid列表
        /// </summary>
        /// <param name="alias">别名</param>
        /// <returns>个推SDK的唯一识别号列表</returns>
        public List<string> GetAlias(string alias)
        {
            string key = $"{StorageKeyPrefix.PUSH_ALIAS}{alias}";
            return _iRedis.GetList(key);
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
            SaveTag(tag, new List<string>() { cid });
        }
        /// <summary>
        /// 批量保存标签数据
        /// </summary>
        /// <param name="tag">别名</param>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void SaveTag(string tag, List<string> cids)
        {
            string key = $"{StorageKeyPrefix.PUSH_TAG}{tag}";
            _iRedis.SetAdd(key, cids);
        }
        /// <summary>
        /// 删除标签数据
        /// </summary>
        /// <param name="tag">别名</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        public void DeleteTag(string tag, string cid)
        {
            string key = $"{StorageKeyPrefix.PUSH_TAG}{tag}";
            _iRedis.SetRemove(key, cid);
        }
        /// <summary>
        /// 批量删除标签数据
        /// </summary>
        /// <param name="tag">别名</param>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void DeleteTag(string tag, List<string> cids)
        {
            string key = $"{StorageKeyPrefix.PUSH_TAG}{tag}";
            foreach (var cid in cids)
            {
                _iRedis.SetRemove(key, cid);
            }
        }
        #endregion

        #region 黑名单
        /// <summary>
        /// 保存用户黑名单
        /// </summary>
        /// <param name="cid">个推SDK的唯一识别号列表</param>
        public void SaveUserBlack(string cid)
        {
            SaveUserBlack(new List<string>() { cid });
        }
        /// <summary>
        /// 批量保存用户黑名单
        /// </summary>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void SaveUserBlack(List<string> cids)
        {
            string key = $"{StorageKeyPrefix.USER_BLACK}{_geTuiPushOptions.AppID}";
            _iRedis.SetAdd(key, cids);
        }
        /// <summary>
        /// 删除用户黑名单
        /// </summary>
        /// <param name="cid">个推SDK的唯一识别号</param>
        public void DeleteUserBlack(string cid)
        {
            string key = $"{StorageKeyPrefix.USER_BLACK}{_geTuiPushOptions.AppID}";
            _iRedis.SetRemove(key, cid);
        }
        /// <summary>
        /// 批量删除用户黑名单
        /// </summary>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void DeleteUserBlack(List<string> cids)
        {
            string key = $"{StorageKeyPrefix.USER_BLACK}{_geTuiPushOptions.AppID}";
            foreach (var cid in cids)
            {
                _iRedis.SetRemove(key, cid);
            }
        }
        #endregion
    }
}