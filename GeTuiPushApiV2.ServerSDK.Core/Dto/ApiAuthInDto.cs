namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 鉴权-获取鉴权token
    /// </summary>
    public class ApiAuthInDto : ApiInDto
    {
        /// <summary>
        /// 必填项，签名，加密算法: SHA256，格式: sha256(appkey+timestamp+mastersecret)
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 必填项，毫秒时间戳，请使用当前毫秒时间戳，误差太大可能出错
        /// </summary>
        public long timestamp { get; set; }
        /// <summary>
        /// 必填项，创建应用时生成的appkey
        /// </summary>
        public string appkey { get; set; }
    }
}
