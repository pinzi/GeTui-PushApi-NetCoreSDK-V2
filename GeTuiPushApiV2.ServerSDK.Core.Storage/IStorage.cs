using GeTuiPushApiV2.ServerSDK.Core;

namespace GeTuiPushApiV2.ServerSDK.Storage
{
    /// <summary>
    /// 存储方式抽象接口
    /// </summary>
    public interface IStorage
    {
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
        /// <summary>
        /// 存储CID
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        /// <param name="expireTime">CID有效期</param>
        public void AddCID(string uid, string cid, TimeSpan? expireTime = null);
        /// <summary>
        /// 获取用户关联的个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns>个推SDK的唯一识别号</returns>
        public string GetCID(string uid);
        /// <summary>
        /// 删除用户关联的个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户id</param>
        public void DeleteCID(string uid);
        /// <summary>
        /// 保存别名数据列表
        /// </summary>
        /// <param name="data_list">别名数据列表</param>
        public void SaveAlias(data_listDto[] data_list);
        /// <summary>
        /// 获取用户cid关联的别名
        /// </summary>
        /// <param name="cid">个推SDK的唯一识别号</param>
        /// <returns>用户cid关联的别名</returns>
        public string GetAlias(string cid);
        /// <summary>
        /// 删除别名数据列表
        /// </summary>
        /// <param name="data_list">别名数据列表</param>
        public void RemoveAlias(data_listDto[] data_list);
    }
}
