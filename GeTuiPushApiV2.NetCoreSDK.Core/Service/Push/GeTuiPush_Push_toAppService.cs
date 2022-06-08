namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 个推消息推送服务-推送API-toApp
    /// </summary>
    public partial class GeTuiPushService
    {
        #region toApp
        #region 推送-【toApp】执行群推
        /// <summary>
        ///  推送-【toApp】执行群推
        ///  对指定应用的所有用户群发推送消息。支持定时、定速功能，查询任务推送情况请见接口查询定时任务。
        ///  注：此接口频次限制100次/天，每分钟不能超过5次(推送限制和接口根据条件筛选用户推送共享限制)
        /// </summary>
        /// <param name="inDto">消息推送参数</param>
        /// <returns></returns>
        public async Task<string> PushToAppAsync(PushToAppInDto inDto)
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
                //重新推送
                result = await _api.PushToAppAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
            return result.data.taskid;
        }
        #endregion

        #region 推送-【toApp】根据条件筛选用户推送
        /// <summary>
        ///  推送-【toApp】根据条件筛选用户推送
        ///  对指定应用的符合筛选条件的用户群发推送消息。支持定时、定速功能。
        ///  注：此接口频次限制100次/天，每分钟不能超过5次(推送限制和接口执行群推共享限制)，定时推送功能需要申请开通才可以使用，申请修改请点击右侧“技术咨询”了解详情。
        ///  注：个推用户画像中的“016100|中小学生“标签将于2022年5月31日下线，请开发者及时关注和处理
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<string> PushToAppTagAsync(PushToAppTagInDto inDto)
        {
            var apiInDto = new ApiPushToAppTagInDto()
            {
                request_id = Guid.NewGuid().ToString(),
                audience = inDto.tags,
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
            var result = await _api.PushToAppTagAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.PushToAppTagAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
            return result.data.taskid;
        }
        #endregion

        #region 推送-【toApp】使用标签快速推送
        /// <summary>
        ///  推送-【toApp】使用标签快速推送
        ///  根据标签过滤用户并推送。支持定时、定速功能。
        ///  注：该功能需要申请相关套餐，请点击右侧“技术咨询”了解详情 。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<string> PushToAppFastCustomTagAsync(PushToAppFastCustomTagInDto inDto)
        {
            var apiInDto = new ApiPushToAppFastCustomTagInDto()
            {
                request_id = Guid.NewGuid().ToString(),
                audience = new audience_fastcustomtagDto() { fast_custom_tag = inDto.fastcustomtag },
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
            var result = await _api.PushToAppFastCustomTagAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.PushToAppFastCustomTagAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
            return result.data.taskid;
        }
        #endregion
        #endregion
    }
}
