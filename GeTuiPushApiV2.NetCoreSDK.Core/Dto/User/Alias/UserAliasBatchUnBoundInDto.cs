namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 用户API-【别名】批量解绑别名输入参数
    /// </summary>
    public class UserAliasBatchUnBoundInDto
    {
        /// <summary>
        /// 别名数据列表，数组长度不大于1000
        /// </summary>
        public data_listDto[] data_list { get; set; }
    }
}
