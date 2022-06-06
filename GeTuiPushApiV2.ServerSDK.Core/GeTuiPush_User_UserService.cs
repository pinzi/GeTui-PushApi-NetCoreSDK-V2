using GeTuiPushApiV2.ServerSDK.Core.Api;
using GeTuiPushApiV2.ServerSDK.Core.Utility;

namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推推送服务-用户-用户
    /// </summary>
    public partial class GeTuiPushService
    {
        #region 用户
        #region 用户
        #region 【用户】添加黑名单用户
        /// <summary>
        /// 用户-【用户】添加黑名单用户
        /// 将单个或多个用户加入黑名单，对于黑名单用户在推送过程中会被过滤掉。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto> UserBlackAddAsync(UserBlackAddInDto inDto)
        {
            long _timestamp = GetTimeStamp();
            var result = await _api.UserBlackAddAsync(new ApiUserBlackAddInDto()
            {
                token = await GetTokenAsync(_options.AppID),
                appkey = _options.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(_options.AppKey + _timestamp + _options.MasterSecret),
                appId = _options.AppID,
                cid = inDto.cid
            });
            //缓存用户黑名单用户
            if (result.code.Equals(0))
            {
                _iStorage.SaveUserBlack(inDto.cid);
            }
            return result;
        }
        #endregion

        #region 【用户】移除黑名单用户
        /// <summary>
        /// 用户-【用户】移除黑名单用户
        /// 将单个cid或多个cid用户移出黑名单，对于黑名单用户在推送过程中会被过滤掉的，不会给黑名单用户推送消息。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto> UserBlackRemoveAsync(UserBlackRemoveInDto inDto)
        {
            long _timestamp = GetTimeStamp();
            var result = await _api.UserBlackRemoveAsync(new ApiUserBlackRemoveInDto()
            {
                token = await GetTokenAsync(_options.AppID),
                appkey = _options.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(_options.AppKey + _timestamp + _options.MasterSecret),
                appId = _options.AppID,
                cid = inDto.cid
            });
            //删除缓存用户黑名单用户
            if (result.code.Equals(0))
            {
                _iStorage.DeleteUserBlack(inDto.cid);
            }
            return result;
        }
        #endregion

        #region 【用户】查询用户状态
        /// <summary>
        /// 用户-【用户】查询用户状态
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<List<UserStatusOutDto>> UserStatusAsync(UserStatusInDto inDto)
        {
            List<UserStatusOutDto> list = new List<UserStatusOutDto>();
            long _timestamp = GetTimeStamp();
            var result = await _api.UserStatusAsync(new ApiUserStatusInDto()
            {
                token = await GetTokenAsync(_options.AppID),
                appkey = _options.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(_options.AppKey + _timestamp + _options.MasterSecret),
                appId = _options.AppID,
                cids = string.Join(",", inDto.cids)
            });
            if (result.code.Equals(0))
            {
                foreach (string cid in result.data.Keys)
                {
                    list.Add(new UserStatusOutDto()
                    {
                        cid = cid,
                        last_login_time = result.data[cid].last_login_time,
                        status = result.data[cid].status
                    });
                }
            }
            return list;
        }
        #endregion

        #region 【用户】查询设备状态
        /// <summary>
        /// 用户-【用户】查询设备状态
        /// 注意：
        /// 1.该接口返回设备在线时，仅表示存在集成了个推SDK的应用在线
        /// 2.该接口返回设备不在线时，仅表示不存在集成了个推SDK的应用在线
        /// 3.该接口需要开通权限，如需开通，请联系右侧技术咨询
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<List<UserDeviceStatusOutDto>> UserDeviceStatusAsync(UserDeviceStatusInDto inDto)
        {

            List<UserDeviceStatusOutDto> list = new List<UserDeviceStatusOutDto>();
            long _timestamp = GetTimeStamp();
            var result = await _api.UserDeviceStatusAsync(new ApiUserDeviceStatusInDto()
            {
                token = await GetTokenAsync(_options.AppID),
                appkey = _options.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(_options.AppKey + _timestamp + _options.MasterSecret),
                appId = _options.AppID,
                cids = string.Join(",", inDto.cids)
            });
            if (result.code.Equals(0))
            {
                foreach (string cid in result.data.Keys)
                {
                    list.Add(new UserDeviceStatusOutDto()
                    {
                        cid = cid,
                        cid_status = result.data[cid].cid_status,
                        device_status = result.data[cid].device_status
                    });
                }
            }
            return list;
        }
        #endregion
        #endregion
        #endregion
    }
}
