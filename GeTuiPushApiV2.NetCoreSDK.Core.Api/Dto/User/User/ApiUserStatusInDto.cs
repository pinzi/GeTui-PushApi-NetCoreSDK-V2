﻿namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 用户API-用户-【用户】查询用户状态输入参数
    /// </summary>
    public class ApiUserStatusInDto : ApiInDto
    {
        /// <summary>
        /// 用户标识，多个以英文逗号隔开，一次最多传1000个
        /// </summary>
        public string cids { get; set; }
    }
}
