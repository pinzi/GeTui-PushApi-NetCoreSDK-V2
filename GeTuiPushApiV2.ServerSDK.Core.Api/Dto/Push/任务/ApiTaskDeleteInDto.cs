namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 推送API-【任务】删除定时任务输入参数
    /// </summary>
    public class ApiTaskDeleteInDto : ApiInDto
    {
        /// <summary>
        /// 任务id (格式RASL-MMdd_XXXXXX或RASA-MMdd_XXXXXX)
        /// </summary>
        public string taskId { get; set; }
    }
}
