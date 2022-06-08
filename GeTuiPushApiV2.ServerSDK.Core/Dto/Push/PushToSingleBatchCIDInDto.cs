namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 推送API-【toSingle】执行cid批量单推输入参数
    /// </summary>
    public class PushToSingleBatchCIDInDto : PushMessageInDto
    {
        /// <summary>
        /// 是否异步推送，true是异步，false同步。异步推送不会返回data详情
        /// </summary>
        public bool is_async { get; set; }
        /// <summary>
        /// 消息内容，数组长度不大于 200
        /// </summary>
        public ApiPushToSingleCIDInDto[] msg_list { get; set; }
    }
}
