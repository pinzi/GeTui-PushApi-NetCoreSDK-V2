namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-【任务】停止任务输入参数
    /// </summary>
    public class TaskStopInDto
    {
        /// <summary>
        /// 任务id (格式RASL-MMdd_XXXXXX或RASA-MMdd_XXXXXX)
        /// </summary>
        public string taskId { get; set; }
    }
}
