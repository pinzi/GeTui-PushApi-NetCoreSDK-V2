namespace GeTuiPushApiV2.ServerSDK.Core.Service
{
    /// <summary>
    /// 消息推送参数
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
        /// 个推业务层中的对外用户标识，用于标识客户端身份，由第三方客户端获取并保存到第三方服务端，是个推SDK的唯一识别号,简称CID。
        /// </summary>
        public string[] cid { get; set; }
    }
}
