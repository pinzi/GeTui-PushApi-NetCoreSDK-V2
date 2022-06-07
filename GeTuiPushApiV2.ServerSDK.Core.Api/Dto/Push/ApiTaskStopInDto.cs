﻿namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 推送-【任务】停止任务输入参数
    /// </summary>
    public class ApiTaskStopInDto : ApiInDto
    {
        /// <summary>
        /// 任务id (格式RASL-MMdd_XXXXXX或RASA-MMdd_XXXXXX)
        /// </summary>
        public string taskId { get; set; }
    }
}