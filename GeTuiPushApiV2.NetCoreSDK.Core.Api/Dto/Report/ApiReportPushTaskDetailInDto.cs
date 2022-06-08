namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 统计API-【推送】任务组名查报表输入参数
    /// </summary>
    public class ApiReportPushTaskDetailInDto : ApiInDto
    {
        /// <summary>
        /// 必选项，任务id，推送时返回，多个taskId以英文逗号隔开，一次最多传200个
        /// </summary>
        public string taskid { get; set; }
    }
}
