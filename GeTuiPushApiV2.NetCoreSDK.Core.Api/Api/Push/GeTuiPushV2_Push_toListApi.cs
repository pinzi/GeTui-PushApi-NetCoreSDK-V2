namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口-推送API-toList
    /// </summary>
    public partial class GeTuiPushV2Api
    {
        #region toList
        #region 推送API-【toList】创建消息
        /// <summary>
        ///  推送API-【toList】创建消息
        ///  此接口用来创建消息体，并返回taskid，为批量推的前置步骤
        ///  注：此接口频次限制200万次/天(和执行别名批量推共享限制)，申请修改请点击右侧“技术咨询”了解详情。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushCreateListMessageOutDto>> CreateListMessageAsync(ApiPushCreateListMessageInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiPushCreateListMessageInDto, ApiPushCreateListMessageOutDto>($"{ApiBaseUrl}{inDto.appId}/push/list/message", inDto);
            return result;
        }
        #endregion

        #region 推送API-【toList】执行cid批量推
        /// <summary>
        ///  推送API-【toList】执行cid批量推
        ///  对列表中所有cid进行消息推送。调用此接口前需调用创建消息接口设置消息内容。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<dynamic> PushToListCIDAsync(ApiPushToListCIDInDto inDto)
        {
            if (inDto.is_async)
            {
                //异步
                return await HttpPostGeTuiApiNoDataAsync<ApiPushToListCIDInDto>($"{ApiBaseUrl}{inDto.appId}/push/list/cid", inDto);
            }
            else
            {
                //同步
                return await HttpPostGeTuiApiAsync<ApiPushToListCIDInDto, Dictionary<string, Dictionary<string, string>>>($"{ApiBaseUrl}{inDto.appId}/push/list/cid", inDto);
            }
        }
        #endregion

        #region 推送API-【toList】执行别名批量推
        /// <summary>
        ///  推送API-【toList】执行别名批量推
        ///  对列表中所有别名进行消息推送。调用此接口前需调用创建消息接口设置消息内容。
        ///  注：此接口频次限制200万次/天(和执行cid批量推共享限制)，申请修改请点击右侧“技术咨询”了解详情。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<dynamic> PushToListAliasAsync(ApiPushToListAliasInDto inDto)
        {
            if (inDto.is_async)
            {
                //异步
                return await HttpPostGeTuiApiNoDataAsync<ApiPushToListAliasInDto>($"{ApiBaseUrl}{inDto.appId}/push/list/alias", inDto);
            }
            else
            {
                //同步
                return await HttpPostGeTuiApiAsync<ApiPushToListAliasInDto, Dictionary<string, Dictionary<string, Dictionary<string, string>>>>($"{ApiBaseUrl}{inDto.appId}/push/list/alias", inDto);
            }
        }
        #endregion
        #endregion
    }
}
