namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 鉴权API-获取鉴权token输出参数
    /// </summary>
    public class ApiAuthOutDto
    {
        /// <summary>
        /// token过期时间，ms时间戳
        /// </summary>
        public long expire_time { get; set; }
        /// <summary>
        /// 接口调用凭据
        /// </summary>
        public string token { get; set; }
    }
}
