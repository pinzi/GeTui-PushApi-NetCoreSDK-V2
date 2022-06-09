﻿namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 用户API-【别名】解绑所有别名输入参数
    /// </summary>
    public class ApiUserAliasUnBoundInDto : ApiInDto
    {
        /// <summary>
        /// 必填项，用户别名
        /// </summary>
        public string alias { get; set; }
    }
}
