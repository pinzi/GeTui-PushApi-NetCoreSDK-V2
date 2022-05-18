using GeTuiPushApiV2.ServerSDK.Core.Utility;
using GeTuiPushApiV2.ServerSDK.Storage;

namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推消息推送服务
    /// </summary>
    public class GeTuiPushService
    {
        #region 字段
        /// <summary>
        /// 存储方式
        /// </summary>
        private readonly IStorage _iStorage;
        /// <summary>
        /// 个推消息推送V2接口
        /// </summary>
        private readonly GeTuiPushV2Api _api;
        /// <summary>
        /// 个推消息推送配置信息
        /// </summary>
        private readonly GeTuiPushOptions _options;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="cacheManager">存储方式</param>
        /// <param name="option">个推消息推送配置信息</param>
        /// <param name="api">个推消息推送V2接口</param>
        public GeTuiPushService(IStorage iStorage, GeTuiPushOptions options, GeTuiPushV2Api api)
        {
            _iStorage = iStorage;
            _api = api;
            _options = options;
        }
        #endregion

        #region 鉴权-获取鉴权token
        /// <summary>
        /// 鉴权-获取鉴权token
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiAuthOutDto>> AuthAsync()
        {
            long _timestamp = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
            var result = await _api.AuthAsync(new ApiAuthInDto()
            {
                appkey = _options.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(_options.AppKey + _timestamp + _options.MasterSecret),
                appId = _options.AppID
            });
            //缓存token
            if (result.code.Equals(0))
            {
                //token有效期，毫秒时间戳，将缓存有效期在token有效期基础上减少30秒，防止因网络传输导致获取到已过期的token，并提前刷新token
                long expire_time = result.data.expire_time - 30 * 1000;
                _iStorage.SaveToken(_options.AppID, result.data.token, TimeSpan.FromMilliseconds(expire_time));
            }
            return result;
        }
        #endregion

        #region 鉴权-删除鉴权token
        /// <summary>
        /// 鉴权-删除鉴权token
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiAuthDeleteOutDto>> AuthDeleteAsync()
        {
            //读取token缓存信息
            string token = _iStorage.GetToken(_options.AppID);
            if (string.IsNullOrEmpty(token))
            {
                return new ApiResultOutDto<ApiAuthDeleteOutDto>()
                {
                    code = -1,
                    msg = "token不存在"
                };
            }
            var result = await _api.AuthDeleteAsync(new ApiInDto()
            {
                token = token,
                appId = _options.AppID
            });
            //缓存token
            if (result.code.Equals(0))
            {
                _iStorage.DeleteToken(_options.AppID);
            }
            return result;
        }
        #endregion

        #region 获取token
        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="appId">应用id</param>
        /// <param name="forceRefresh">是否强制刷新token</param>
        /// <returns></returns>
        private async Task<string> GetTokenAsync(string appId, bool forceRefresh = false)
        {
            //读取token缓存信息
            string token = _iStorage.GetToken(appId);
            if (string.IsNullOrEmpty(token) || forceRefresh)
            {
                //token已过期，刷新token
                var resultAuth = await AuthAsync();
                token = resultAuth.data.token;
            }
            return token;
        }
        #endregion

        #region 获取用户的CID
        /// <summary>
        /// 获取用户的CID
        /// </summary>
        /// <param name="UIDs">用户ID</param>
        /// <returns></returns>
        public async Task<string[]> GetUserCIDAsync(string[] UIDs)
        {
            List<string> CIDs = new List<string>();
            foreach (string uid in UIDs)
            {
                //从redis读取token缓存信息
                string CID = _iStorage.GetCID(uid);
                if (!string.IsNullOrEmpty(CID))
                {
                    CIDs.Add(CID);
                }
            }
            return await Task.FromResult(CIDs.ToArray());
        }
        #endregion

        #region 推送-【toApp】执行群推
        /// <summary>
        ///  推送-【toApp】执行群推
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

        #region 推送-【toSingle】执行cid单推
        /// <summary>
        ///  推送-【toSingle】执行cid单推
        /// </summary>
        /// <param name="inDto">消息推送参数</param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToSingleOutDto>> PushToSingleAsync(PushToSingleInDto inDto)
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
            var result = await _api.PushToSingleAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //Console.WriteLine($"token已过期，刷新token=>{apiInDto.token}");
                //重新推送
                result = await _api.PushToSingleAsync(apiInDto);
            }
            return result;
        }
        #endregion

        #region 推送-【toList】执行cid批量推
        /// <summary>
        ///  推送-【toList】执行cid批量推
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
            var apiInDto = new ApiCreateListMessageInDto()
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

        #region 推送消息给APP
        /// <summary>
        /// 推送消息给APP
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task PushMessageAsync(PushMessageInDto inDto)
        {
            inDto.cid = await GetUserCIDAsync(inDto.uid);
            string[] cids = inDto.cid;
            if (inDto.isall)
            {
                #region 群推
                var dto = new PushToAppInDto()
                {
                    title = inDto.title,
                    body = inDto.body,
                    payload = inDto.payload,
                    istransmsg = inDto.istransmsg,
                    isall = inDto.isall,
                    cid = inDto.cid
                };
                var result = await PushToAppAsync(dto);
                if (!result.code.Equals(0))
                {
                    throw new Exception(result.msg);
                }
                #endregion
            }
            else if (cids.Length.Equals(1))
            {
                #region 单推
                var dto = new PushToSingleInDto()
                {
                    title = inDto.title,
                    body = inDto.body,
                    payload = inDto.payload,
                    istransmsg = inDto.istransmsg,
                    isall = inDto.isall,
                    cid = inDto.cid
                };
                var result = await PushToSingleAsync(dto);
                if (!result.code.Equals(0))
                {
                    throw new Exception(result.msg);
                }
                #endregion
            }
            else if (cids.Length > 1)
            {
                #region 批量推
                var dto = new PushToListInDto()
                {
                    title = inDto.title,
                    body = inDto.body,
                    payload = inDto.payload,
                    istransmsg = inDto.istransmsg,
                    isall = inDto.isall,
                    cid = inDto.cid,
                    is_async = false,
                    taskid = await CreateListMessageAsync(inDto)//创建消息
                };
                //执行cid批量推
                var result = await PushToListAsync(dto);
                if (!result.code.Equals(0))
                {
                    throw new Exception(result.msg);
                }
                #endregion
            }
            else
            {
                throw new Exception("未指定接收人设备cid");
            }
        }
        #endregion
    }
}
