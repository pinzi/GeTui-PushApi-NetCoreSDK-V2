﻿namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-【toList】创建消息输出参数
    /// </summary>
    public class ApiPushCreateListMessageOutDto
    {
        /// <summary>
        /// 任务编号，用于执行cid批量推和执行别名批量推，此taskid可以多次使用，有效期为用户设置的离线时间
        /// </summary>
        public string taskid { get; set; }
    }
}
