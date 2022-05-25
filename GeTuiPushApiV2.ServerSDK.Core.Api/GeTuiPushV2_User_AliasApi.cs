namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口-用户-别名
    /// </summary>
    public partial class GeTuiPushV2Api
    {
        #region 用户API-别名
        #region 别名
        #region 用户-【别名】绑定别名
        /// <summary>
        /// 用户-【别名】绑定别名
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

        #region 用户-【别名】根据cid查询别名
        /// <summary>
        /// 用户-【别名】根据cid查询别名
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
        /// 用户-【别名】根据别名查询cid
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserCidAliasOutDto>> UserCidAliasAsync(ApiUserCidAliasInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiUserCidAliasInDto, ApiUserCidAliasOutDto>($"{ApiBaseUrl}{inDto.appId}/user/cid/alias/{inDto.alias}", inDto);
            return result;
        }
        #endregion

        #region 用户-【别名】批量解绑别名
        /// <summary>
        /// 用户-【别名】批量解绑别名
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

        #region 用户-【别名】解绑所有别名
        /// <summary>
        /// 用户-【别名】解绑所有别名
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserAliasUnBoundOutDto>> UserAliasUnBoundAsync(ApiUserAliasUnBoundInDto inDto)
        {
            var result = await HttpDeleteGeTuiApiAsync<ApiUserAliasUnBoundInDto, ApiUserAliasUnBoundOutDto>($"{ApiBaseUrl}{inDto.appId}/user/alias/{inDto.alias}", inDto);
            return result;
        }
        #endregion
        #endregion
        #endregion
    }
}
