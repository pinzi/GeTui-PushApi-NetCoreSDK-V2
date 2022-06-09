﻿namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 用户API-【别名】绑定别名输入参数
    /// </summary>
    public class UserAliasInDto
    {
        /// <summary>
        /// 别名数据列表，数组长度不大于1000
        /// </summary>
        public data_listDto[] data_list { get; set; }
    }
}
