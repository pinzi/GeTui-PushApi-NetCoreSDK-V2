using Newtonsoft.Json;

namespace GeTuiPushApiV2.ServerSDK.Core
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
    }
}
