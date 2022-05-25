namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口-推送
    /// </summary>
    public partial class GeTuiPushV2Api
    {
        #region 推送API
        #region 推送-【toSingle】执行cid单推
        /// <summary>
        ///  推送-【toSingle】执行cid单推
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToSingleOutDto>> PushToSingleAsync(ApiPushToSingleInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiPushToSingleInDto, ApiPushToSingleOutDto>($"{ApiBaseUrl}{inDto.appId}/push/single/cid", inDto);
            return result;
        }
        #endregion

        #region 推送-【toSingle】执行别名单推
        /// <summary>
        ///  推送-【toSingle】执行别名单推
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToSingleAliasOutDto>> PushToSingleAliasAsync(ApiPushToSingleAliasInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiPushToSingleAliasInDto, ApiPushToSingleAliasOutDto>($"{ApiBaseUrl}{inDto.appId}/push/single/alias", inDto);
            return result;
        }
        #endregion

        #region 推送-【toList】创建消息
        /// <summary>
        ///  推送-【toList】创建消息
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushCreateListMessageOutDto>> CreateListMessageAsync(ApiPushCreateListMessageInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiPushCreateListMessageInDto, ApiPushCreateListMessageOutDto>($"{ApiBaseUrl}{inDto.appId}/push/list/message", inDto);
            return result;
        }
        #endregion

        #region 推送-【toList】执行cid批量推
        /// <summary>
        ///  推送-【toList】执行cid批量推
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToListOutDto>> PushToListAsync(ApiPushToListInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiPushToListInDto, ApiPushToListOutDto>($"{ApiBaseUrl}{inDto.appId}/push/list/cid", inDto);
            return result;
        }
        #endregion

        #region 推送-【toApp】执行群推
        /// <summary>
        ///  推送-【toApp】执行群推
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToAppOutDto>> PushToAppAsync(ApiPushToAppInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiPushToAppInDto, ApiPushToAppOutDto>($"{ApiBaseUrl}{inDto.appId}/push/all", inDto);
            return result;
        }
        #endregion
        #endregion
    }
}
