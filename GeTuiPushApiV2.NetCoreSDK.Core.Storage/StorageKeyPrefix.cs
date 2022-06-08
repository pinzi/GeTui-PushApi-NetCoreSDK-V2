namespace GeTuiPushApiV2.NetCoreSDK.Core.Storage
{
    /// <summary>
    /// 缓存key前缀
    /// </summary>
    public class StorageKeyPrefix
    {
        #region 鉴权
        /// <summary>
        /// 鉴权token
        /// </summary>
        public static string AUTH_TOKEN = "GeTui:AuthToken:";
        #endregion

        #region 推送
        /// <summary>
        /// 个推用户唯一标识CID
        /// </summary>
        public static string PUSH_CID = "GeTui:CID:";
        #endregion

        #region 别名
        /// <summary>
        /// 别名
        /// </summary>
        public static string PUSH_ALIAS = "GeTui:Alias:";
        #endregion

        #region 标签
        /// <summary>
        /// 标签
        /// </summary>
        public static string PUSH_TAG = "GeTui:Tag:";
        #endregion

        #region 用户
        #endregion

        #region 黑名单
        /// <summary>
        /// 用户黑名单
        /// </summary>
        public static string USER_BLACK = "GeTui:Black:";
        #endregion
    }
}
