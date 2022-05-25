namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口-用户-用户
    /// </summary>
    public partial class GeTuiPushV2Api
    {
        #region 用户API-用户
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
        #endregion
    }
}
