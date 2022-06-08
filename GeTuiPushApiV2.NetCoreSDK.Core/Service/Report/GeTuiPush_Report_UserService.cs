namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 个推消息推送服务-统计API-用户
    /// </summary>
    public partial class GeTuiPushService
    {
        #region 用户
        #region 统计API-【用户】获取单日用户数据接口
        /// <summary>
        ///  统计API-【推送】获取单日用户数据接口
        ///  调用此接口可以获取某个应用单日的用户数据(用户数据包括：新增用户数，累计注册用户总数，在线峰值，日联网用户数)(目前只支持查询非当天的数据)
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, ApiReportUserDateOutDto>> ReportUserDateAsync(ReportUserDateInDto inDto)
        {
            var apiInDto = new ApiReportUserDateInDto()
            {
                date = inDto.date,
            };
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.ReportUserDateAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.ReportUserDateAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
            return result.data;
        }
        #endregion

        #region 统计API-【用户】获取24个小时在线用户数
        /// <summary>
        ///  统计API-【推送】获取24个小时在线用户数
        ///  查询当前时间一天内的在线用户数(10分钟一个点，1个小时六个点)
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiReportOnlineUserOutDto> ReportOnlineUserAsync()
        {
            var apiInDto = new ApiInDto();
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.ReportOnlineUserAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.ReportOnlineUserAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
            return result.data;
        }
        #endregion
        #endregion
    }
}
