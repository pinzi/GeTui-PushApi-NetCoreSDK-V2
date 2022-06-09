namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-消息推送公共参数
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
        /// 推送目标用户筛选方式，默认为cid方式
        /// </summary>
        public TargetUserFilter filter { get; set; }
        /// <summary>
        /// 推送目标用户筛选条件
        /// 用户CID数组，单推或批量单推时只能填一个cid，批量推时数组长度不大于1000。
        /// 用户UID数组
        /// 别名数组，单推或批量单推时只能填一个别名，批量推时数组长度不大于1000。
        /// 目标用户标签数组，只能填写一个。
        /// </summary>
        public string[] filterCondition { get; set; }
        /// <summary>
        /// 是否异步推送，true是异步，false同步。异步推送不会返回data详情
        /// </summary>
        public bool is_async { get; set; }
    }
}
