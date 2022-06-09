namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-【任务】查询定时任务输出参数
    /// </summary>
    public class ApiTaskScheduleOutDto
    {
        /// <summary>
        /// 定时任务创建时间，毫秒时间戳
        /// </summary>
        public long create_time { get; set; }
        /// <summary>
        /// 定时任务状态：success/failed
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 透传内容
        /// </summary>
        public string transmission_content { get; set; }
        /// <summary>
        /// 定时任务推送时间，毫秒时间戳
        /// </summary>
        public long push_time { get; set; }
    }
}
