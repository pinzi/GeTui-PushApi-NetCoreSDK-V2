namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 统计API-【推送】获取推送结果（含自定义事件）输入参数
    /// </summary>
    public class ApiReportPushTaskActionInDto : ApiInDto
    {
        /// <summary>
        /// 必填项，任务id，推送时返回，多个taskId以英文逗号隔开，一次最多传200个
        /// </summary>
        public string taskIds { get; set; }
        /// <summary>
        /// 必填项，任务id，推送时返回，多个taskId以英文逗号隔开，一次最多传200个
        /// </summary>
        public string actionIds { get; set; }
    }
}
