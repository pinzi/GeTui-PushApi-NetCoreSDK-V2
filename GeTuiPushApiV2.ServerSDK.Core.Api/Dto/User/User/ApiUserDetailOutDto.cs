namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 用户API-用户-【用户】查询用户信息输出参数
    /// </summary>
    public class ApiUserDetailOutDto
    {
        /// <summary>
        /// 无效cid列表
        /// </summary>
        public string[] invalidCids { get; set; }
        /// <summary>
        /// 用户信息列表
        /// </summary>
        public Dictionary<string, ApiValidCidsOutDto> validCids { get; set; }
    }

    /// <summary>
    /// 用户信息
    /// </summary>
    public class ApiValidCidsOutDto
    {
        /// <summary>
        /// 应用id
        /// </summary>
        public string client_app_id { get; set; }
        /// <summary>
        /// 包名
        /// </summary>
        public string package_name { get; set; }
        /// <summary>
        ///  厂商token
        /// </summary>
        public string device_token { get; set; }
        /// <summary>
        /// 手机系统 1-安卓 2-ios
        /// </summary>
        public int phone_type { get; set; }
        /// <summary>
        /// 机型
        /// </summary>
        public string phoneModel { get; set; }
        /// <summary>
        /// 系统通知栏开关
        /// </summary>
        public bool notificationSwitch { get; set; }
        /// <summary>
        /// 首次登录时间
        /// </summary>
        public DateTime? createTime { get; set; }
        /// <summary>
        /// 登录频次
        /// </summary>
        public int loginFreq { get; set; }
    }
}
