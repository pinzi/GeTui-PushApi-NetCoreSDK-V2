namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口-鉴权
    /// </summary>
    public partial class GeTuiPushV2Api
    {
        #region 鉴权API
        #region 鉴权-获取鉴权token
        /// <summary>
        /// 鉴权-获取鉴权token
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiAuthOutDto>> AuthAsync(ApiAuthInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiAuthInDto, ApiAuthOutDto>($"{ApiBaseUrl}{inDto.appId}/auth", inDto);
            return result;
        }
        #endregion

        #region 鉴权-删除鉴权token
        /// <summary>
        /// 鉴权-删除鉴权token
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiAuthDeleteOutDto>> AuthDeleteAsync(ApiInDto inDto)
        {
            var result = await HttpDeleteGeTuiApiAsync<ApiInDto, ApiAuthDeleteOutDto>($"{ApiBaseUrl}{inDto.appId}/auth/{inDto.token}", inDto);
            return result;
        }
        #endregion
        #endregion
    }
}
