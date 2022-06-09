﻿namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-【toApp】使用标签快速推送输入参数
    /// </summary>
    public class PushToAppFastCustomTagInDto : PushMessageInDto
    {
        /// <summary>
        /// 必填项，目标用户标签
        /// </summary>
        public string fastcustomtag { get; set; }
    }
}
