namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 推送-【toSingle】执行cid单推输入参数
    /// </summary>
    public class ApiPushToSingleInDto : ApiPushToBaseInDto
    {
    }

    /// <summary>
    /// 推送目标用户
    /// </summary>
    public class audience_cidDto
    {
        /// <summary>
        /// 必填项，cid数组，只能填一个cid
        /// </summary>
        public string[] cid { get; set; }
    }
}
