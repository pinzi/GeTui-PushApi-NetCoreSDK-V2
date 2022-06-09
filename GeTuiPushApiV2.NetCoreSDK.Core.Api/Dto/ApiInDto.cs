using Newtonsoft.Json;

namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 公共请求参数
    /// </summary>
    public class ApiInDto
    {
        /// <summary>
        /// 接口访问凭据，获取方式请参考获取鉴权token
        /// </summary>
        [JsonIgnore]
        public string appId { get; set; }
        /// <summary>
        /// 接口访问凭据，获取方式请参考获取鉴权token
        /// </summary>
        [JsonIgnore]
        public string token { get; set; }
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
