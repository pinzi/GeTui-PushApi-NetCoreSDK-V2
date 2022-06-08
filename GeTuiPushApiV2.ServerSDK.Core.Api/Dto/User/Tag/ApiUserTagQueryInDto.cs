namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 用户API-【标签】查询用户标签输入参数
    /// </summary>
    public class ApiUserTagQueryInDto : ApiInDto
    {
        /// <summary>
        /// 必填项，用户标识
        /// </summary>
        public string cid { get; set; }
    }
}
