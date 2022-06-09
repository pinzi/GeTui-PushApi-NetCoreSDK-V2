namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-推送-【toSingle】执行别名批量单推输入参数
    /// </summary>
    public class PushToSingleBatchAliasInDto : PushMessageInDto
    {
        /// <summary>
        /// 消息内容，数组长度不大于 200
        /// </summary>
        public ApiPushToSingleCIDInDto[] msg_list { get; set; }
    }
}
