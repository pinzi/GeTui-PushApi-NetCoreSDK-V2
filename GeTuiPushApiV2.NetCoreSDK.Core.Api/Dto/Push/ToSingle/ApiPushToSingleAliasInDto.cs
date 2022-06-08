namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-【toSingle】执行别名单推输入参数
    /// </summary>
    public class ApiPushToSingleAliasInDto : ApiPushToBaseInDto
    {
    }

    /// <summary>
    /// 推送目标用户
    /// </summary>
    public class audience_aliasDto
    {
        /// <summary>
        /// 必填项，别名数组，只能填一个别名
        /// </summary>
        public string[] alias { get; set; }
    }
}
