namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 别名-根据cid查询别名输入参数
    /// </summary>
    public class ApiAliasCidInDto : ApiInDto
    {
        /// <summary>
        /// 必填项，用户唯一标识
        /// </summary>
        public string cid { get; set; }
    }
}
