namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 统计API-【用户】获取24个小时在线用户数输出参数
    /// </summary>
    public class ApiReportOnlineUserOutDto
    {
        /// <summary>
        /// 在线用户统计数据
        /// key: 毫秒时间戳，value: 在线用户数
        /// </summary>
        public Dictionary<long, int> online_statics { get; set; }
    }
}
