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
        /// <param name="uid">用户唯一标示</param>
        /// <param name="cid">个推SDK的唯一识别号</param>
        /// <param name="expireTime">CID有效期</param>
        public void AddCID(string uid, string cid, TimeSpan? expireTime = null);
        /// <summary>
        /// 获取用户关联的个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户唯一标示</param>
        /// <returns>个推SDK的唯一识别号</returns>
        public string GetCID(string uid);
        /// <summary>
        /// 删除用户关联的个推SDK的唯一识别号
        /// </summary>
        /// <param name="uid">用户唯一标示</param>
        public void DeleteCID(string uid);
    }
}
