namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 用户API-【别名】根据别名查询cid输入参数
    /// </summary>
    public class ApiUserCidAliasInDto : ApiInDto
    {
        /// <summary>
        /// 必填项，别名
        /// </summary>
        public string alias { get; set; }
    }
}
