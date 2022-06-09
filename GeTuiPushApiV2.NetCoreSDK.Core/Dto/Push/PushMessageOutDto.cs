namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-公共输出参数
    /// </summary>
    public class PushMessageOutDto
    {
        /// <summary>
        /// 任务编号
        /// </summary>
        public string taskid { get; set; }
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string cid { get; set; }
        /// <summary>
        /// 推送结果: 
        /// successed_offline: 离线下发(包含厂商通道下发)，
        /// successed_online: 在线下发，
        /// successed_ignore: 最近90天内不活跃用户不下发
        /// </summary>
        public string status { get; set; }
    }
}
