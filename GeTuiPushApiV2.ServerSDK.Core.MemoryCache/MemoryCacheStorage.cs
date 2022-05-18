using GeTuiPushApiV2.ServerSDK.Storage;

namespace GeTuiPushApiV2.ServerSDK.Core.MemoryCache
{
    /// <summary>
    /// 使用内存缓存存储数据
    /// </summary>
    public class MemoryCacheStorage : IStorage
    {
        /// <summary>
        /// 内存缓存对象
        /// </summary>
        private readonly MemoryManager _memoryManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="memoryCache">内存缓存对象</param>
        public MemoryCacheStorage()
        {
            _memoryManager = MemoryManager.Default;
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
                _memoryManager.Set_AbsoluteExpire<string>(appId, token, expireTime.Value);
            }
            else
            {
                _memoryManager.Set_NotExpire<string>(appId, token);
            }
        }
        /// <summary>
        /// 删除接口调用凭据
        /// </summary>
        /// <param name="appId">应用id</param>
        public void DeleteToken(string appId)
        {
            _memoryManager.Remove(appId);
        }
        /// <summary>
        /// 获取接口调用凭据
        /// </summary>
        /// <param name="appId">应用id</param>
        /// <returns>接口调用凭据</returns>
        public string GetToken(string appId)
        {
            return _memoryManager.Get<string>(appId);
        }
        /// <summary>
        /// 存储CID
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        /// <param name="expireTime">CID有效期</param>
        public void AddCID(string uid, string cid, TimeSpan? expireTime = null)
        {
            if (expireTime.HasValue)
            {
                _memoryManager.Set_AbsoluteExpire<string>(uid, cid, expireTime.Value);
            }
            else
            {
                _memoryManager.Set_NotExpire<string>(uid, cid);
            }
        }
        /// <summary>
        /// 获取用户关联的个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns>个推SDK的唯一识别号</returns>
        public string GetCID(string uid)
        {
            return _memoryManager.Get<string>(uid);
        }
        /// <summary>
        /// 删除用户关联的个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        public void DeleteCID(string uid)
        {
            _memoryManager.Remove(uid);
        }
        /// <summary>
        /// 保存别名数据列表
        /// </summary>
        /// <param name="data_list">别名数据列表</param>
        public void SaveAlias(data_listDto[] data_list)
        {
            foreach (var item in data_list)
            {
                _memoryManager.Set_NotExpire<string>(item.cid, item.alias);
            }
        }
        /// <summary>
        /// 获取用户cid关联的别名
        /// </summary>
        /// <param name="cid">个推SDK的唯一识别号</param>
        /// <returns>用户cid关联的别名</returns>
        public string GetAlias(string cid)
        {
            return _memoryManager.Get<string>(cid);
        } 
    }
}