namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推消息推送配置信息
    /// </summary>
    public class GeTuiPushOptions
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppID { get; set; }
        /// <summary>
        /// 应用key
        /// </summary>
        public string AppKey { get; set; }
        /// <summary>
        /// 主密钥
        /// </summary>
        public string MasterSecret { get; set; }
    }
}
