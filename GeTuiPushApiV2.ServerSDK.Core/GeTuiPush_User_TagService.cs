using GeTuiPushApiV2.ServerSDK.Core.Utility;

namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推推送服务-用户-标签
    /// </summary>
    public partial class GeTuiPushService
    {
        #region 用户
        #region 标签
        #region 用户-【标签】一个用户绑定一批标签
        /// <summary>
        /// 用户-【标签】一个用户绑定一批标签
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserTagBindOutDto>> UserTagBindAsync(UserTagBindInDto inDto)
        {
            long _timestamp = GetTimeStamp();
            var result = await _api.UserTagBindAsync(new ApiUserTagBindInDto()
            {
                token = await GetTokenAsync(_options.AppID),
                appkey = _options.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(_options.AppKey + _timestamp + _options.MasterSecret),
                appId = _options.AppID,
                cid = inDto.cid,
                custom_tag = inDto.custom_tag
            });
            if (result.code.Equals(0))
            {
                //缓存用户标签
                inDto.custom_tag.GroupBy(g => g).ToList().ForEach(g =>
                {
                    _iStorage.SaveTag(g.Key, inDto.cid);
                });
            }
            return result;
        }
        #endregion

        #region 用户-【标签】一批用户绑定一个标签
        /// <summary>
        /// 用户-【标签】一批用户绑定一个标签
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserTagBatchBindOutDto>> UserTagBatchBindAsync(UserTagBatchBindInDto inDto)
        {
            long _timestamp = GetTimeStamp();
            var result = await _api.UserTagBatchBindAsync(new ApiUserTagBatchBindInDto()
            {
                token = await GetTokenAsync(_options.AppID),
                appkey = _options.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(_options.AppKey + _timestamp + _options.MasterSecret),
                appId = _options.AppID,
                custom_tag = inDto.custom_tag,
                cid = inDto.cid
            });
            if (result.code.Equals(0))
            {
                //缓存用户标签
                _iStorage.SaveTag(inDto.custom_tag, inDto.cid.ToList());
            }
            return result;
        }
        #endregion

        #region 用户-【标签】一批用户解绑一个标签
        /// <summary>
        /// 用户-【标签】一批用户解绑一个标签
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns>key为cid，value为结果，true表示成功，否则失败</returns>
        public async Task<ApiResultOutDto<Dictionary<string, bool>>> UserTagBatchUnBindAsync(UserTagBatchUnBindInDto inDto)
        {
            long _timestamp = GetTimeStamp();
            var result = await _api.UserTagBatchUnBindAsync(new ApiUserTagBatchUnBindInDto()
            {
                token = await GetTokenAsync(_options.AppID),
                appkey = _options.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(_options.AppKey + _timestamp + _options.MasterSecret),
                appId = _options.AppID,
                custom_tag = inDto.custom_tag,
                cid = inDto.cid
            });
            if (result.code.Equals(0))
            {
                //移除缓存标签cid
                _iStorage.DeleteTag(inDto.custom_tag, result.data.Where(t => t.Value == true).Select(t => t.Key).ToList());
            }
            return result;
        }
        #endregion

        #region 用户-【标签】查询用户标签
        /// <summary>
        /// 用户-【标签】查询用户标签
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns>key: cid，value: 标签列表，列表中只会有一个元素，多个以空格隔开</returns>
        public async Task<ApiResultOutDto<Dictionary<string, string[]>>> UserTagQueryAsync(UserTagQueryInDto inDto)
        {
            long _timestamp = GetTimeStamp();
            var result = await _api.UserTagQueryAsync(new ApiUserTagQueryInDto()
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
        #endregion
        #endregion        
    }
}
