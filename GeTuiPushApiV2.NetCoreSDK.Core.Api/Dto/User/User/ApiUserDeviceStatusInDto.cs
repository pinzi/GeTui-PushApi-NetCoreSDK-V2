﻿namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 用户API-用户-【用户】查询设备状态输入参数
    /// </summary>
    public class ApiUserDeviceStatusInDto : ApiInDto
    {
        /// <summary>
        /// 用户标识，多个以英文逗号隔开，一次最多传100个
        /// </summary>
        public string cids { get; set; }
    }
}
