using GeTuiPushApiV2.NetCoreSDK.Core.Utility;

namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 个推推送服务-鉴权API
    /// </summary>
    public partial class GeTuiPushService
    {
        #region 鉴权API
        #region 鉴权API-获取鉴权token
        /// <summary>
        /// 鉴权-获取鉴权token
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiAuthOutDto>> AuthAsync()
        {
            long _timestamp = GetTimeStamp();
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
                long expire_time = result.data.expire_time - GetTimeStamp() - 30 * 1000;
                _iStorage.SaveToken(_options.AppID, result.data.token, TimeSpan.FromMilliseconds(expire_time));
            }
            return result;
        }
        #endregion

        #region 鉴权API-删除鉴权token
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
        #endregion
    }
}
