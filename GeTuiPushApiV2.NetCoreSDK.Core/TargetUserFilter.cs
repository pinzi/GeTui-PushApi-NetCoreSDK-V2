namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送目标用户筛选方式
    /// </summary>
    public enum TargetUserFilter
    {
        /// <summary>
        /// 全部
        /// </summary>
        all = 0,
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        cid = 1,
        /// <summary>
        /// 业务系统用户ID
        /// </summary>
        uid = 2,
        /// <summary>
        /// 别名
        /// </summary>
        alias = 3,
        /// <summary>
        /// 标签
        /// </summary>
        tag = 4
    }
}
