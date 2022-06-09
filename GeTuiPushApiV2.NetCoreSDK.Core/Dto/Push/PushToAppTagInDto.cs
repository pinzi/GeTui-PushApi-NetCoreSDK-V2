﻿namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-【toApp】根据条件筛选用户推送输入参数
    /// </summary>
    public class PushToAppTagInDto : PushMessageInDto
    {
        /// <summary>
        /// 推送条件
        /// </summary>
        public audienceTagInDto tags { get; set; }
    }
}
