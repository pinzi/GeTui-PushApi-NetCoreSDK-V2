namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-【推送】查询消息明细输入参数
    /// </summary>
    public class TaskDetailInDto
    {
        /// <summary>
        /// 必填项，任务id
        /// </summary>
        public string taskId { get; set; }
        /// <summary>
        /// 必填项，用户唯一标识
        /// </summary>
        public string cid { get; set; }
    }
}
