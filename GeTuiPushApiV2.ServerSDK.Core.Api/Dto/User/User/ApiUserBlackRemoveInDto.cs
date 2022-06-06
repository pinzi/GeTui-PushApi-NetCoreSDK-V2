namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 用户API-用户-【用户】移除黑名单用户输入参数
    /// </summary>
    public class ApiUserBlackRemoveInDto : ApiInDto
    {
        /// <summary>
        /// 必填项，用户标识，多个以英文逗号隔开，一次最多传200个
        /// </summary>
        public string cid { get; set; }
    }
}
