namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 统计API-【用户】获取单日用户数据接口输出参数
    /// </summary>
    public class ApiReportUserDateOutDto
    {
        /// <summary>
        /// 累计注册用户数
        /// </summary>
        public int accumulative_num { get; set; }
        /// <summary>
        /// 注册用户数
        /// </summary>
        public int register_num { get; set; }
        /// <summary>
        /// 活跃用户数
        /// </summary>
        public int active_num { get; set; }
        /// <summary>
        /// 在线用户数
        /// </summary>
        public int online_num { get; set; }
    }
}
