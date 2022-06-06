﻿using GeTuiPushApiV2.ServerSDK.Core.Utility;

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
            return result;
        }
        #endregion
        #endregion
        #endregion
    }
}