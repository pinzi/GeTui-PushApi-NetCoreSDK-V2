namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 用户API-用户-【用户】查询用户状态输出参数
    /// </summary>
    public class UserStatusOutDto
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        public string cid { get; set; }
        /// <summary>
        /// 毫秒时间戳
        /// </summary>
        public long last_login_time { get; set; }
        /// <summary>
        /// 状态，online在线 offline离线
        /// </summary>
        public string status { get; set; }
    }
}
