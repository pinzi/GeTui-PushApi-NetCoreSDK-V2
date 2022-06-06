namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口-用户-用户
    /// </summary>
    public partial class GeTuiPushV2Api
    {
        #region 用户API-用户
        #region 用户
        #region 【用户】添加黑名单用户
        /// <summary>
        /// 用户-【用户】添加黑名单用户
        /// 将单个或多个用户加入黑名单，对于黑名单用户在推送过程中会被过滤掉。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto> UserBlackAddAsync(ApiUserBlackAddInDto inDto)
        {
            var result = await HttpPostGeTuiApiNoDataAsync<ApiUserBlackAddInDto>($"{ApiBaseUrl}{inDto.appId}/user/black/cid/{inDto.cid}", inDto);
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
        public async Task<ApiResultOutDto> UserBlackRemoveAsync(ApiUserBlackRemoveInDto inDto)
        {
            var result = await HttpPostGeTuiApiNoDataAsync<ApiUserBlackRemoveInDto>($"{ApiBaseUrl}{inDto.appId}/user/black/cid/{inDto.cid}", inDto);
            return result;
        }
        #endregion

        #region 【用户】查询用户状态
        /// <summary>
        /// 用户-【用户】查询用户状态
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<Dictionary<string, ApiUserStatusOutDto>>> UserStatusAsync(ApiUserStatusInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiUserStatusInDto, Dictionary<string, ApiUserStatusOutDto>>($"{ApiBaseUrl}{inDto.appId}/user/status/{inDto.cids}", inDto);
            return result;
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
        public async Task<ApiResultOutDto<Dictionary<string, ApiUserDeviceStatusOutDto>>> UserDeviceStatusAsync(ApiUserDeviceStatusInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiUserDeviceStatusInDto, Dictionary<string, ApiUserDeviceStatusOutDto>>($"{ApiBaseUrl}{inDto.appId}/user/deviceStatus/{inDto.cids}", inDto);
            return result;
        }
        #endregion

        #region 【用户】查询用户信息
        /// <summary>
        /// 用户-【用户】查询用户信息
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserDetailOutDto>> UserDetailAsync(ApiUserDetailInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiUserDetailInDto, ApiUserDetailOutDto>($"{ApiBaseUrl}{inDto.appId}/user/detail/{inDto.cids}", inDto);
            return result;
        }
        #endregion

        #region 【用户】设置角标(仅支持IOS)
        /// <summary>
        /// 用户-【用户】设置角标(仅支持IOS)
        /// 通过cid通知个推服务器当前iOS设备的角标情况
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto> UserBadgeAsync(ApiUserBadgeInDto inDto)
        {
            var result = await HttpPostGeTuiApiNoDataAsync<ApiUserBadgeInDto>($"{ApiBaseUrl}{inDto.appId}/user/badge/cid/{inDto.cids}", inDto);
            return result;
        }
        #endregion

        #region 【用户】查询用户总量
        /// <summary>
        /// 用户-【用户】查询用户总量
        /// 通过指定查询条件来查询满足条件的用户数量
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserCountOutDto>> UserCountAsync(ApiUserCountInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiUserCountInDto, ApiUserCountOutDto>($"{ApiBaseUrl}{inDto.appId}/user/count", inDto);
            return result;
        }
        #endregion
        #endregion        
        #endregion
    }
}
