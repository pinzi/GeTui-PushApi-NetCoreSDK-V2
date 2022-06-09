﻿namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-【toList】执行cid批量推输入参数
    /// </summary>
    public class PushToListAliasInDto : PushMessageInDto
    {
        /// <summary>
        /// 是否异步推送，true是异步，false同步。异步推送不会返回data详情
        /// </summary>
        public bool is_async { get; set; }
        /// <summary>
        /// 必填项，使用创建消息接口返回的taskId，可以多次使用
        /// </summary>
        public string taskid { get; set; }
    }
}
