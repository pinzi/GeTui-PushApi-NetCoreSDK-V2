namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口-用户API-别名
    /// </summary>
    public partial class GeTuiPushV2Api
    {
        #region 别名
        #region 用户API-【别名】绑定别名
        /// <summary>
        /// 用户API-【别名】绑定别名
        /// 一个cid只能绑定一个别名，若已绑定过别名的cid再次绑定新别名，则前一个别名会自动解绑，并绑定新别名。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserAliasOutDto>> UserAliasAsync(ApiUserAliasInDto inDto)
        {
            if (inDto.data_list == null || inDto.data_list.Length == 0)
            {
                return new ApiResultOutDto<ApiUserAliasOutDto>() { code = -1, msg = "data_list不能为空" };
            }
            if (inDto.data_list.Length > 1000)
            {
                return new ApiResultOutDto<ApiUserAliasOutDto>() { code = -1, msg = "data_list长度不能超过1000" };
            }
            var result = await HttpPostGeTuiApiAsync<ApiUserAliasInDto, ApiUserAliasOutDto>($"{ApiBaseUrl}{inDto.appId}/user/alias", inDto);
            return result;
        }
        #endregion

        #region 用户API-【别名】根据cid查询别名
        /// <summary>
        /// 用户API-【别名】根据cid查询别名
        /// 通过传入的cid查询对应的别名信息
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserAliasCidOutDto>> UserAliasCidAsync(ApiUserAliasCidInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiUserAliasCidInDto, ApiUserAliasCidOutDto>($"{ApiBaseUrl}{inDto.appId}/user/alias/cid/{inDto.cid}", inDto);
            return result;
        }
        #endregion

        #region 用户-【别名】根据别名查询cid
        /// <summary>
        /// 用户API-【别名】根据别名查询cid
        /// 通过传入的别名查询对应的cid信息
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserCidAliasOutDto>> UserCidAliasAsync(ApiUserCidAliasInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiUserCidAliasInDto, ApiUserCidAliasOutDto>($"{ApiBaseUrl}{inDto.appId}/user/cid/alias/{inDto.alias}", inDto);
            return result;
        }
        #endregion

        #region 用户API-【别名】批量解绑别名
        /// <summary>
        /// 用户API-【别名】批量解绑别名
        /// 批量解除别名与cid的关系
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserAliasBatchUnBoundOutDto>> UserAliasBatchUnBoundAsync(ApiUserAliasBatchUnBoundInDto inDto)
        {
            if (inDto.data_list == null || inDto.data_list.Length == 0)
            {
                return new ApiResultOutDto<ApiUserAliasBatchUnBoundOutDto>() { code = -1, msg = "data_list不能为空" };
            }
            if (inDto.data_list.Length > 1000)
            {
                return new ApiResultOutDto<ApiUserAliasBatchUnBoundOutDto>() { code = -1, msg = "data_list长度不能超过1000" };
            }
            var result = await HttpDeleteGeTuiApiAsync<ApiUserAliasBatchUnBoundInDto, ApiUserAliasBatchUnBoundOutDto>($"{ApiBaseUrl}{inDto.appId}/user/alias", inDto);
            return result;
        }
        #endregion

        #region 用户API-【别名】解绑所有别名
        /// <summary>
        /// 用户API-【别名】解绑所有别名
        /// 解绑所有与该别名绑定的cid
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto> UserAliasUnBoundAsync(ApiUserAliasUnBoundInDto inDto)
        {
            var result = await HttpDeleteGeTuiApiNoDataAsync<ApiUserAliasUnBoundInDto>($"{ApiBaseUrl}{inDto.appId}/user/alias/{inDto.alias}", inDto);
            return result;
        }
        #endregion
        #endregion
    }
}
