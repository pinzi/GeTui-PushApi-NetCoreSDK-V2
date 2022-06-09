﻿namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 用户API-【标签】一个用户绑定一批标签输入参数
    /// </summary>
    public class UserTagBindInDto
    {
        /// <summary>
        /// 必填项，个推SDK的唯一识别号
        /// </summary>
        public string cid { get; set; }
        /// <summary>
        /// 必填项，标签列表，标签中不能包含空格
        /// </summary>
        public string[] custom_tag { get; set; }
    }
}
