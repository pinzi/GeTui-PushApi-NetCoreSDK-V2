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
        #endregion

        #region CID
        /// <summary>
        /// 存储CID
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        public void SaveCID(string uid, string cid)
        {
            //读取缓存CID列表
            var list = _memoryManager.Get<List<string>>(uid);
            if (list == null)
            {
                list = new List<string>();
            }
            //添加新CID到缓存CID列表
            list.Add(cid);
            //去处重复CID
            list = list.Distinct().ToList();
            _memoryManager.SetList_NotExpire(uid, list);
        }
        /// <summary>
        /// 获取用户关联的个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns>个推SDK的唯一识别号</returns>
        public List<string> GetCID(string uid)
        {
            return _memoryManager.Get<List<string>>(uid);
        }
        /// <summary>
        /// 删除用户关联的全部个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        public void DeleteCID(string uid)
        {
            _memoryManager.Remove(uid);
        }
        /// <summary>
        /// 删除用户关联的指定个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        public void DeleteCID(string uid, string cid)
        {
            var list = _memoryManager.Get<List<string>>(uid);
            if (list != null)
            {
                list.Remove(cid);
                _memoryManager.SetList_NotExpire(uid, list);
            }
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
            //读取别名缓存列表
            var list = _memoryManager.Get<List<string>>(cid);
            if (list == null)
            {
                list = new List<string>();
            }
            //添加新的别名到缓存列表
            list.Add(alias);
            //去除重复别名
            list = list.Distinct().ToList();
            _memoryManager.SetList_NotExpire(cid, list);
        }
        /// <summary>
        /// 保存别名数据列表
        /// </summary>
        /// <param name="cid">个推SDK的唯一识别号</param>
        /// <param name="alias">别名数据列表</param>
        public void SaveAlias(string cid, List<string> alias)
        {
            //读取别名缓存列表
            var list = _memoryManager.Get<List<string>>(cid);
            if (list == null)
            {
                list = new List<string>();
            }
            //添加新的别名到缓存列表
            list.AddRange(alias);
            //去除重复别名
            list = list.Distinct().ToList();
            _memoryManager.SetList_NotExpire(cid, list);
        }
        /// <summary>
        /// 删除别名关联的所有cid列表
        /// </summary>
        /// <param name="alias">别名</param>
        public void DeleteAlias(string alias)
        {
            _memoryManager.Remove(alias);
        }
        /// <summary>
        /// 删除别名关联的指定cid
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        public void DeleteAlias(string alias, string cid)
        {
            DeleteAlias(alias, new List<string>() { cid });
        }
        /// <summary>
        /// 批量删除别名关联的指定cid列表
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void DeleteAlias(string alias, List<string> cids)
        {
            //读取缓存别名cid列表
            var list = _memoryManager.Get<List<string>>(alias);
            if (list == null)
            {
                list = new List<string>();
            }
            //移除指定的cid
            list.RemoveAll(a => cids.Contains(a));
            _memoryManager.SetList_NotExpire(alias, list);
        }
        /// <summary>
        /// 获取别名关联的cid列表
        /// </summary>
        /// <param name="alias">别名</param>
        /// <returns>个推SDK的唯一识别号列表</returns>
        public List<string> GetAlias(string alias)
        {
            return _memoryManager.Get<List<string>>(alias);
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
            //读取标签缓存列表
            var list = _memoryManager.Get<List<string>>(tag);
            if (list == null)
            {
                list = new List<string>();
            }
            list.Add(cid);
            SaveTag(tag, list);
        }
        /// <summary>
        /// 保存标签数据
        /// </summary>
        /// <param name="tag">别名</param>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void SaveTag(string tag, List<string> cids)
        {
            //读取标签缓存列表
            var list = _memoryManager.Get<List<string>>(tag);
            if (list == null)
            {
                list = new List<string>();
            }
            list.AddRange(cids);
            list = list.Distinct().ToList();
            _memoryManager.SetList_NotExpire(tag, list);
        }
        #endregion
    }
}