﻿namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 用户API-用户-【用户】查询设备状态输出参数
    /// </summary>
    public class ApiUserDeviceStatusOutDto
    {
        /// <summary>
        /// cid在线状态，online在线 offline离线
        /// </summary>
        public string cid_status { get; set; }
        /// <summary>
        /// 设备在线状态，online在线 offline离线
        /// </summary>
        public string device_status { get; set; }
    }
}
