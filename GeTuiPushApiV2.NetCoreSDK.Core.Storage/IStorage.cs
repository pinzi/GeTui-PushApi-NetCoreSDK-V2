using GeTuiPushApiV2.NetCoreSDK.Core;

namespace GeTuiPushApiV2.NetCoreSDK.Storage
{
    /// <summary>
    /// 存储方式抽象接口
    /// </summary>
    public interface IStorage
    {
        #region Token
        /// <summary>
        /// 保存接口调用凭据
        /// </summary>
        /// <param name="appId">应用id</param>
        /// <param name="token">推送接口调用凭据</param>
        /// <param name="expireTime">接口调用凭据有效期</param>
        public void SaveToken(string appId, string token, TimeSpan? expireTime = null);
        /// <summary>
        /// 删除接口调用凭据
        /// </summary>
        /// <param name="appId">应用id</param>
        public void DeleteToken(string appId);
        /// <summary>
        /// 获取接口调用凭据
        /// </summary>
        /// <param name="appId">应用id</param>
        /// <returns>接口调用凭据</returns>
        public string GetToken(string appId);
        #endregion

        #region CID
        /// <summary>
        /// 存储CID
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        public void SaveCID(string uid, string cid);
        /// <summary>
        /// 获取用户关联的个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns>个推SDK的唯一识别号</returns>
        public List<string> GetCID(string uid);
        /// <summary>
        /// 删除用户关联的全部个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        public void DeleteCID(string uid);
        /// <summary>
        /// 删除用户关联的指定个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        public void DeleteCID(string uid, string cid);
        #endregion

        #region 别名
        /// <summary>
        /// 保存别名数据
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        public void SaveAlias(string alias, string cid);
        /// <summary>
        /// 批量保存别名数据列表
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void SaveAlias(string alias, List<string> cids);
        /// <summary>
        /// 删除别名关联的所有cid列表
        /// </summary>
        /// <param name="alias">别名</param>
        public void DeleteAlias(string alias);
        /// <summary>
        /// 删除别名关联的指定cid
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        public void DeleteAlias(string alias, string cid);
        /// <summary>
        /// 批量删除别名关联的指定cid列表
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void DeleteAlias(string alias, List<string> cids);
        /// <summary>
        /// 获取别名关联的cid列表
        /// </summary>
        /// <param name="alias">别名</param>
        /// <returns>个推SDK的唯一识别号列表</returns>
        public List<string> GetAlias(string alias);
        #endregion

        #region 标签
        /// <summary>
        /// 保存标签数据
        /// </summary>
        /// <param name="tag">别名</param>
        /// <param name="cid">个推SDK的唯一识别号列表</param>
        public void SaveTag(string tag, string cid);
        /// <summary>
        /// 批量保存标签数据
        /// </summary>
        /// <param name="tag">别名</param>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void SaveTag(string tag, List<string> cids);
        /// <summary>
        /// 删除标签数据
        /// </summary>
        /// <param name="tag">别名</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        public void DeleteTag(string tag, string cid);
        /// <summary>
        /// 批量删除标签数据
        /// </summary>
        /// <param name="tag">别名</param>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void DeleteTag(string tag, List<string> cids);
        #endregion

        #region 黑名单
        /// <summary>
        /// 保存用户黑名单
        /// </summary>
        /// <param name="cid">个推SDK的唯一识别号列表</param>
        public void SaveUserBlack(string cid);
        /// <summary>
        /// 批量保存用户黑名单
        /// </summary>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void SaveUserBlack(List<string> cids);
        /// <summary>
        /// 删除用户黑名单
        /// </summary>
        /// <param name="cid">个推SDK的唯一识别号</param>
        public void DeleteUserBlack(string cid);
        /// <summary>
        /// 批量删除用户黑名单
        /// </summary>
        /// <param name="cids">个推SDK的唯一识别号列表</param>
        public void DeleteUserBlack(List<string> cids);
        #endregion
    }
}
