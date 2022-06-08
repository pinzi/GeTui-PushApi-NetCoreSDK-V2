namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-【toApp】使用标签快速推送输入参数
    /// </summary>
    public class ApiPushToAppFastCustomTagInDto : ApiPushToBaseInDto
    {
    }

    /// <summary>
    /// 用户标签
    /// </summary>
    public class audience_fastcustomtagDto
    {
        /// <summary>
        /// 必填项，使用用户标签筛选目标用户，绑定标签请参考接口
        /// </summary>
        public string fast_custom_tag { get; set; }
    }
}
