namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 消息推送-根据用户标识cid输入参数
    /// </summary>
    public class PushMessageInDto
    {
        /// <summary>
        /// 通知栏标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 通知栏内容
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// 通知消息（istransmsg=false）：点击通知时，附加自定义透传消息，长度 ≤ 3072
        /// 透传消息（istransmsg=true）：纯透传消息内容，安卓和iOS均支持，与notification、revoke 三选一，都填写时报错，长度 ≤ 3072
        /// </summary>
        public string payload { get; set; }
        /// <summary>
        /// 是否是透传消息，默认false，通知消息
        /// </summary>
        public bool istransmsg { get; set; }
        /// <summary>
        /// 是否群推
        /// </summary>
        public bool isall { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string[] uid { get; set; }
        /// <summary>
        /// cid数组，单推或批量单推时只能填一个cid，批量推时数组长度不大于1000。
        /// </summary>
        public string[] cid { get; set; }
        /// <summary>
        /// 别名数组，单推或批量单推时只能填一个别名，批量推时数组长度不大于1000。
        /// </summary>
        public string[] alias { get; set; }
    }
}
