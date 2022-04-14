namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 推送-【toSingle】执行cid单推
    /// </summary>
    public class ApiPushToAppInDto : ApiPushToBaseInDto
    {
    }

    /// <summary>
    /// 推送目标用户
    /// </summary>
    public class audience_tagDto
    {
        /// <summary>
        /// 必填项，推送条件，详见下方说明
        /// </summary>
        public tagDto[] tag { get; set; }
    }
}
