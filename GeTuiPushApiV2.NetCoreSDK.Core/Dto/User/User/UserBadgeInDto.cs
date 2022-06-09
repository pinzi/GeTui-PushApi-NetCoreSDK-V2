namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 用户API-【用户】设置角标(仅支持IOS)输入参数
    /// </summary>
    public class UserBadgeInDto
    {
        /// <summary>
        /// 必填项，用户标识，一次最多传200个
        /// </summary>
        public string[] cids { get; set; }
        /// <summary>
        /// 必填项，用户应用icon上显示的数字
        /// +N: 在原有badge上+N
        /// -N: 在原有badge上-N
        /// N: 直接设置badge(数字，会覆盖原有的badge值)
        /// </summary>
        public int badge { get; set; }
    }
}
