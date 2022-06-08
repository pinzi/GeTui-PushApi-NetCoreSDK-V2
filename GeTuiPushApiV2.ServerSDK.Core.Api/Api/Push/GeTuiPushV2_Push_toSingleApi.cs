namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口-推送API-toSingle
    /// </summary>
    public partial class GeTuiPushV2Api
    {
        #region toSingle
        #region 推送API-【toSingle】执行cid单推
        /// <summary>
        ///  推送API-【toSingle】执行cid单推
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<Dictionary<string, Dictionary<string, string>>>> PushToSingleCIDAsync(ApiPushToSingleCIDInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiPushToSingleCIDInDto, Dictionary<string, Dictionary<string, string>>>($"{ApiBaseUrl}{inDto.appId}/push/single/cid", inDto);
            return result;
        }
        #endregion

        #region 推送API-【toSingle】执行别名单推
        /// <summary>
        ///  推送API-【toSingle】执行别名单推
        ///  通过别名推送消息，绑定别名请参考接口
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<Dictionary<string, Dictionary<string, string>>>> PushToSingleAliasAsync(ApiPushToSingleAliasInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiPushToSingleAliasInDto, Dictionary<string, Dictionary<string, string>>>($"{ApiBaseUrl}{inDto.appId}/push/single/alias", inDto);
            return result;
        }
        #endregion

        #region 推送API-【toSingle】执行cid批量单推
        /// <summary>
        ///  推送API-【toSingle】执行cid批量单推
        ///  批量发送单推消息，每个cid用户的推送内容都不同的情况下，使用此接口，可提升推送效率。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<dynamic> PushToSingleBatchCIDAsync(ApiPushToSingleBatchCIDInDto inDto)
        {
            if (inDto.is_async)
            {
                //异步
                return await HttpPostGeTuiApiNoDataAsync<ApiPushToSingleBatchCIDInDto>($"{ApiBaseUrl}{inDto.appId}/push/single/batch/cid", inDto);
            }
            else
            {
                //同步
                return await HttpPostGeTuiApiAsync<ApiPushToSingleBatchCIDInDto, Dictionary<string, Dictionary<string, string>>>($"{ApiBaseUrl}{inDto.appId}/push/single/batch/cid", inDto);
            }
        }
        #endregion

        #region 推送API-【toSingle】执行别名批量单推
        /// <summary>
        ///  推送API-【toSingle】执行别名批量单推
        ///  批量发送单推消息，在给每个别名用户的推送内容都不同的情况下，可以使用此接口。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<dynamic> PushToSingleBatchAliasAsync(ApiPushToSingleBatchAliasInDto inDto)
        {
            if (inDto.is_async)
            {
                //异步
                return await HttpPostGeTuiApiNoDataAsync<ApiPushToSingleBatchAliasInDto>($"{ApiBaseUrl}{inDto.appId}/push/single/batch/alias", inDto);
            }
            else
            {
                //同步
                return await HttpPostGeTuiApiAsync<ApiPushToSingleBatchAliasInDto, Dictionary<string, Dictionary<string, string>>>($"{ApiBaseUrl}{inDto.appId}/push/single/batch/alias", inDto);
            }
        }
        #endregion
        #endregion
    }
}
