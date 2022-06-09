namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-【toList】执行cid批量推输入参数
    /// </summary>
    public class PushToListCIDInDto : PushMessageInDto
    {
        /// <summary>
        /// 必填项，使用创建消息接口返回的taskId，可以多次使用
        /// </summary>
        public string taskid { get; set; }
    }
}
