namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 个推消息推送服务-推送API-toList
    /// </summary>
    public partial class GeTuiPushService
    {
        #region toList
        #region 推送-【toList】创建消息
        /// <summary>
        /// 推送-【toList】创建消息
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<string> CreateListMessageAsync(PushMessageInDto inDto)
        {
            var apiInDto = new ApiPushCreateListMessageInDto()
            {
                request_id = Guid.NewGuid().ToString(),
                audience = new audience_cidDto()
                {
                    cid = inDto.cid
                },
                push_message = new push_messageDto()
            };
            if (inDto.istransmsg)
            {
                //透传消息
                apiInDto.push_message.transmission = inDto.payload;
            }
            else
            {
                //通知消息
                apiInDto.push_message.notification = new notificationDto()
                {
                    title = inDto.title,
                    body = inDto.body,
                    click_type = "payload",
                    payload = inDto.payload,
                    badge_add_num = 1,
                    channel_id = "Push",
                    channel_name = "Push",
                    channel_level = 4
                };
            }
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.CreateListMessageAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新创建消息
                result = await _api.CreateListMessageAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
            return result.data.taskid;
        }
        #endregion

        #region 推送-【toList】执行cid批量推
        /// <summary>
        ///  推送-【toList】执行cid批量推
        ///  批量发送单推消息，每个cid用户的推送内容都不同的情况下，使用此接口，可提升推送效率。
        /// </summary>
        /// <param name="inDto">消息推送参数</param>
        /// <returns></returns>
        public async Task<List<PushMessageOutDto>> PushToListAsync(PushToListCIDInDto inDto)
        {
            var apiInDto = new ApiPushToListCIDInDto()
            {
                audience = new audience_listcidDto()
                {
                    cid = inDto.cid
                },
                is_async = inDto.is_async,
                taskid = inDto.taskid
            };
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.PushToListCIDAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.PushToListCIDAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
            //同步
            if (!inDto.is_async && result.code.Equals(0))
            {
                return GetPushResultData(result.data);
            }
            else
            {
                //异步
                return new List<PushMessageOutDto>();
            }
        }
        #endregion

        #region 推送-【toList】执行别名批量推
        /// <summary>
        ///  推送-【toList】执行别名批量推
        ///  对列表中所有别名进行消息推送。调用此接口前需调用创建消息接口设置消息内容。
        ///  注：此接口频次限制200万次/天(和执行cid批量推共享限制)，申请修改请点击右侧“技术咨询”了解详情。
        /// </summary>
        /// <param name="inDto">消息推送参数</param>
        /// <returns></returns>
        public async Task<List<PushMessageOutDto>> PushToListAliasAsync(PushToListAliasInDto inDto)
        {
            var apiInDto = new ApiPushToListAliasInDto()
            {
                audience = new audience_listaliasDto()
                {
                    alias = inDto.alias
                },
                is_async = inDto.is_async,
                taskid = inDto.taskid
            };
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.PushToListAliasAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.PushToListAliasAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
            //同步
            if (!inDto.is_async && result.code.Equals(0))
            {
                return GetPushResultData(result.data);
            }
            else
            {
                //异步
                return new List<PushMessageOutDto>();
            }
        }
        #endregion
        #endregion
    }
}
