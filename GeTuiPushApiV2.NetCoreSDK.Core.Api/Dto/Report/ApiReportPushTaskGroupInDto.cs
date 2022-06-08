namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 统计API-【推送】任务组名查报表输入参数
    /// </summary>
    public class ApiReportPushTaskGroupInDto : ApiInDto
    {
        /// <summary>
        /// 必填项，任务组名
        /// </summary>
        public string group_name { get; set; }
    }
}
