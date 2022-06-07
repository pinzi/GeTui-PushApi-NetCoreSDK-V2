﻿namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 推送-【任务】查询定时任务输入参数
    /// </summary>
    public class ApiTaskScheduleInDto : ApiInDto
    {
        /// <summary>
        /// 必填项，任务id
        /// </summary>
        public string taskId { get; set; }
    }
}