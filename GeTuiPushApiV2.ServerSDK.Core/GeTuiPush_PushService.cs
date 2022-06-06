namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推推送服务-推送
    /// </summary>
    public partial class GeTuiPushService
    {
        #region 推送
        #region toSingle
        #region 推送-【toSingle】执行cid单推
        /// <summary>
        ///  推送-【toSingle】执行cid单推
        ///  向单个用户推送消息，可根据cid指定用户
        /// </summary>
        /// <param name="inDto">消息推送参数</param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToSingleOutDto>> PushToSingleCIDAsync(PushToSingleInDto inDto)
        {
            var apiInDto = new ApiPushToSingleInDto()
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
            var result = await _api.PushToSingleCIDAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.PushToSingleCIDAsync(apiInDto);
            }
            return result;
        }
        #endregion

        #region 推送-【toSingle】执行别名单推
        /// <summary>
        ///  推送-【toSingle】执行cid单推
        ///  向单个用户推送消息，可根据cid指定用户
        /// </summary>
        /// <param name="inDto">消息推送参数</param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToSingleAliasOutDto>> PushToSingleAliasAsync(PushToSingleAliasInDto inDto)
        {
            var apiInDto = new ApiPushToSingleAliasInDto()
            {
                request_id = Guid.NewGuid().ToString(),
                audience = new audience_aliasDto()
                {
                    alias = inDto.alias
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
            return result;
        }
        #endregion



        #endregion

        #region toList
        #region 推送-【toList】执行cid批量推
        /// <summary>
        ///  推送-【toList】执行cid批量推
        ///  批量发送单推消息，每个cid用户的推送内容都不同的情况下，使用此接口，可提升推送效率。
        /// </summary>
        /// <param name="inDto">消息推送参数</param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToListOutDto>> PushToListAsync(PushToListInDto inDto)
        {
            var apiInDto = new ApiPushToListInDto()
            {
                audience = new audience_listDto()
                {
                    cid = inDto.cid
                },
                is_async = inDto.is_async,
                taskid = inDto.taskid
            };
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.PushToListAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //Console.WriteLine($"token已过期，刷新token=>{apiInDto.token}");
                //重新推送
                result = await _api.PushToListAsync(apiInDto);
            }
            return result;
        }
        #endregion

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
                //Console.WriteLine($"token已过期，刷新token=>{apiInDto.token}");
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
        #endregion

        #region toApp
        #region 推送-【toApp】执行群推
        /// <summary>
        ///  推送-【toApp】执行群推
        ///  对指定应用的所有用户群发推送消息。支持定时、定速功能，查询任务推送情况请见接口查询定时任务。
        ///  注：此接口频次限制100次/天，每分钟不能超过5次(推送限制和接口根据条件筛选用户推送共享限制)
        /// </summary>
        /// <param name="inDto">消息推送参数</param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToAppOutDto>> PushToAppAsync(PushToAppInDto inDto)
        {
            var apiInDto = new ApiPushToAppInDto()
            {
                request_id = Guid.NewGuid().ToString(),
                audience = "all",
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
            var result = await _api.PushToAppAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //Console.WriteLine($"token已过期，刷新token=>{apiInDto.token}");
                //重新推送
                result = await _api.PushToAppAsync(apiInDto);
            }
            return result;
        }
        #endregion
        #endregion

        #region 任务

        #endregion

        #region 推送

        #endregion
        #endregion
    }
}
