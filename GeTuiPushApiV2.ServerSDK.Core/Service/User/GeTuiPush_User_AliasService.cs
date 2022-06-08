using GeTuiPushApiV2.ServerSDK.Core.Utility;

namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推推送服务-用户API-别名
    /// </summary>
    public partial class GeTuiPushService
    {
        #region 别名
        #region 用户API-【别名】绑定别名
        /// <summary>
        /// 用户API-【别名】绑定别名
        /// 一个cid只能绑定一个别名，若已绑定过别名的cid再次绑定新别名，则前一个别名会自动解绑，并绑定新别名。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserAliasOutDto>> UserAliasAsync(UserAliasInDto inDto)
        {
            long _timestamp = GetTimeStamp();
            var result = await _api.UserAliasAsync(new ApiUserAliasInDto()
            {
                token = await GetTokenAsync(_options.AppID),
                appkey = _options.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(_options.AppKey + _timestamp + _options.MasterSecret),
                appId = _options.AppID,
                data_list = inDto.data_list
            });
            //缓存别名
            if (result.code.Equals(0))
            {
                //按照别名分组缓存cid数据列表
                inDto.data_list.GroupBy(g => g.alias).ToList().ForEach(g =>
                {
                    _iStorage.SaveAlias(g.Key, g.Select(s => s.cid).ToList());
                });
            }
            return result;
        }
        #endregion

        #region 用户API-【别名】根据cid查询别名
        /// <summary>
        /// 用户API-【别名】根据cid查询别名
        /// 通过传入的cid查询对应的别名信息
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserAliasCidOutDto>> UserAliasCidAsync(UserAliasCidInDto inDto)
        {
            long _timestamp = GetTimeStamp();
            var result = await _api.UserAliasCidAsync(new ApiUserAliasCidInDto()
            {
                token = await GetTokenAsync(_options.AppID),
                appkey = _options.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(_options.AppKey + _timestamp + _options.MasterSecret),
                appId = _options.AppID,
                cid = inDto.cid
            });
            return result;
        }
        #endregion

        #region 用户API-【别名】根据别名查询cid
        /// <summary>
        /// 用户API-【别名】根据别名查询cid
        /// 通过传入的别名查询对应的cid信息
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserCidAliasOutDto>> UserAliasCidAsync(UserCidAliasInDto inDto)
        {
            long _timestamp = GetTimeStamp();
            var result = await _api.UserCidAliasAsync(new ApiUserCidAliasInDto()
            {
                token = await GetTokenAsync(_options.AppID),
                appkey = _options.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(_options.AppKey + _timestamp + _options.MasterSecret),
                appId = _options.AppID,
                alias = inDto.alias
            });
            return result;
        }
        #endregion

        #region 用户API-【别名】批量解绑别名
        /// <summary>
        /// 用户API-【别名】批量解绑别名
        /// 批量解除别名与cid的关系
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserAliasBatchUnBoundOutDto>> UserAliasBatchUnBoundAsync(UserAliasBatchUnBoundInDto inDto)
        {
            long _timestamp = GetTimeStamp();
            var result = await _api.UserAliasBatchUnBoundAsync(new ApiUserAliasBatchUnBoundInDto()
            {
                token = await GetTokenAsync(_options.AppID),
                appkey = _options.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(_options.AppKey + _timestamp + _options.MasterSecret),
                appId = _options.AppID,
                data_list = inDto.data_list
            });
            //删除别名缓存
            if (result.code.Equals(0))
            {
                //按照别名分组删除别名数据列表
                inDto.data_list.GroupBy(g => g.alias).ToList().ForEach(g =>
                {
                    _iStorage.DeleteAlias(g.Key, g.Select(s => s.cid).ToList());
                });
            }
            return result;
        }
        #endregion

        #region 用户API-【别名】解绑所有别名
        /// <summary>
        /// 用户API-【别名】解绑所有别名
        /// 解绑所有与该别名绑定的cid
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task UserAliasUnBoundAsync(UserAliasUnBoundInDto inDto)
        {
            long _timestamp = GetTimeStamp();
            var result = await _api.UserAliasUnBoundAsync(new ApiUserAliasUnBoundInDto()
            {
                token = await GetTokenAsync(_options.AppID),
                appkey = _options.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(_options.AppKey + _timestamp + _options.MasterSecret),
                appId = _options.AppID,
                alias = inDto.alias
            });
            if (result.code.Equals(0))
            {
                //删除别名缓存
                _iStorage.DeleteAlias(inDto.alias);
            }
            else
            {
                throw new Exception(result.msg);
            }
        }
        #endregion
        #endregion 
    }
}
