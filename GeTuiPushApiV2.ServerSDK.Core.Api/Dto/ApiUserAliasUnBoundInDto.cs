namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 用户-【别名】解绑所有别名输入参数
    /// </summary>
    public class ApiUserAliasUnBoundInDto : ApiInDto
    {
        /// <summary>
        /// 必填项，用户别名
        /// </summary>
        public string alias { get; set; }
    }
}
