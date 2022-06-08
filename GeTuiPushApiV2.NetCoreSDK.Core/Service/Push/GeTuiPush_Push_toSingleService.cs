namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 个推消息推送服务-推送API-toSingle
    /// </summary>
    public partial class GeTuiPushService
    {
        #region toSingle
        #region 推送-【toSingle】执行cid单推
        /// <summary>
        ///  推送-【toSingle】执行cid单推
        ///  向单个用户推送消息，可根据cid指定用户
        /// </summary>
        /// <param name="inDto">消息推送参数</param>
        /// <returns></returns>
        public async Task<List<PushMessageOutDto>> PushToSingleCIDAsync(PushToSingleInDto inDto)
        {
            var apiInDto = new ApiPushToSingleCIDInDto()
            {
                request_id = Guid.NewGuid().ToString(),
                audience = new audience_cidDto()
                {
                    cid = inDto.filterCondition
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
            var result = await _api.PushToSingleCIDAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.PushToSingleCIDAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
            return GetPushResultData(result.data);
        }
        #endregion

        #region 推送-【toSingle】执行别名单推
        /// <summary>
        ///  推送-【toSingle】执行cid单推
        ///  向单个用户推送消息，可根据cid指定用户
        /// </summary>
        /// <param name="inDto">消息推送参数</param>
        /// <returns></returns>
        public async Task<List<PushMessageOutDto>> PushToSingleAliasAsync(PushToSingleAliasInDto inDto)
        {
            var apiInDto = new ApiPushToSingleAliasInDto()
            {
                request_id = Guid.NewGuid().ToString(),
                audience = new audience_aliasDto()
                {
                    alias = inDto.filterCondition
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
            var result = await _api.PushToSingleAliasAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.PushToSingleAliasAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
            return GetPushResultData(result.data);
        }
        #endregion

        #region 推送-【toSingle】执行cid批量单推
        /// <summary>
        ///  推送-【toSingle】执行cid批量单推
        ///  批量发送单推消息，每个cid用户的推送内容都不同的情况下，使用此接口，可提升推送效率。
        /// </summary>
        /// <param name="inDto">消息推送参数</param>
        /// <returns></returns>
        public async Task<List<PushMessageOutDto>> PushToSingleBatchCIDAsync(PushToSingleBatchCIDInDto inDto)
        {
            List<ApiPushToSingleCIDInDto> _msg_list = new List<ApiPushToSingleCIDInDto>();
            foreach (var item in inDto.msg_list)
            {
                var _m = new ApiPushToSingleCIDInDto()
                {
                    request_id = Guid.NewGuid().ToString(),
                    audience = new audience_cidDto()
                    {
                        cid = inDto.filterCondition
                    },
                    push_message = new push_messageDto()
                };
                if (inDto.istransmsg)
                {
                    //透传消息
                    _m.push_message.transmission = inDto.payload;
                }
                else
                {
                    //通知消息
                    _m.push_message.notification = new notificationDto()
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
                _msg_list.Add(_m);
            }
            var apiInDto = new ApiPushToSingleBatchCIDInDto()
            {
                is_async = true,
                msg_list = _msg_list.ToArray()
            };
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.PushToSingleBatchCIDAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.PushToSingleBatchCIDAsync(apiInDto);
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

        #region 推送-【toSingle】执行别名批量单推
        /// <summary>
        ///  推送-【toSingle】执行别名批量单推
        ///  批量发送单推消息，在给每个别名用户的推送内容都不同的情况下，可以使用此接口。
        /// </summary>
        /// <param name="inDto">消息推送参数</param>
        /// <returns></returns>
        public async Task<List<PushMessageOutDto>> PushToSingleBatchAliasAsync(PushToSingleBatchAliasInDto inDto)
        {
            List<ApiPushToSingleAliasInDto> _msg_list = new List<ApiPushToSingleAliasInDto>();
            foreach (var item in inDto.msg_list)
            {
                var _m = new ApiPushToSingleAliasInDto()
                {
                    request_id = Guid.NewGuid().ToString(),
                    audience = new audience_cidDto()
                    {
                        cid = inDto.filterCondition
                    },
                    push_message = new push_messageDto()
                };
                if (inDto.istransmsg)
                {
                    //透传消息
                    _m.push_message.transmission = inDto.payload;
                }
                else
                {
                    //通知消息
                    _m.push_message.notification = new notificationDto()
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
                _msg_list.Add(_m);
            }
            var apiInDto = new ApiPushToSingleBatchAliasInDto()
            {
                is_async = true,
                msg_list = _msg_list.ToArray()
            };
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.PushToSingleBatchAliasAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.PushToSingleBatchAliasAsync(apiInDto);
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
