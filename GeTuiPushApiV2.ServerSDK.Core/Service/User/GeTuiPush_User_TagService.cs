using GeTuiPushApiV2.ServerSDK.Core.Utility;

namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推推送服务-用户API-标签
    /// </summary>
    public partial class GeTuiPushService
    {
        #region 标签
        #region 用户API-【标签】一个用户绑定一批标签
        /// <summary>
        /// 用户API-【标签】一个用户绑定一批标签
        /// 一个用户绑定一批标签，此操作为覆盖操作，会删除历史绑定的标签；
        /// 此接口对单个cid有频控限制，每天只能修改一次，最多设置100个标签；单个标签长度最大为32字符，标签总长度最大为512个字符，申请修改请点击右侧“技术咨询”了解详情 。
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

        #region 用户API-【标签】一批用户绑定一个标签
        /// <summary>
        /// 用户API-【标签】一批用户绑定一个标签
        /// 一批用户绑定一个标签，此接口为增量
        /// 此接口有频次控制(每分钟最多100次，每天最多10000次)，申请修改请点击右侧“技术咨询”了解详情
        /// 此接口是异步的，会有延迟
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task UserTagBatchBindAsync(UserTagBatchBindInDto inDto)
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
            else
            {
                throw new Exception(result.msg);
            }
        }
        #endregion

        #region 用户API-【标签】一批用户解绑一个标签
        /// <summary>
        /// 用户API-【标签】一批用户解绑一个标签
        /// 解绑用户的某个标签属性，不影响其它标签
        /// 此接口有频次控制(每分钟最多100次，每天最多10000次)，申请修改请点击右侧“技术咨询”了解详情
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
            else
            {
                throw new Exception(result.msg);
            }
            return result;
        }
        #endregion

        #region 用户API-【标签】查询用户标签
        /// <summary>
        /// 用户API-【标签】查询用户标签
        /// 根据cid查询用户标签列表
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
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
            return result;
        }
        #endregion
        #endregion
    }
}
