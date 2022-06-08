namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口-统计API-用户
    /// </summary>
    public partial class GeTuiPushV2Api
    {
        #region 用户
        #region 统计API-【用户】获取单日用户数据接口
        /// <summary>
        ///  统计API-【推送】获取单日用户数据接口
        ///  调用此接口可以获取某个应用单日的用户数据(用户数据包括：新增用户数，累计注册用户总数，在线峰值，日联网用户数)(目前只支持查询非当天的数据)
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<Dictionary<string, ApiReportUserDateOutDto>>> ReportUserDateAsync(ApiReportUserDateInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiReportUserDateInDto, Dictionary<string, ApiReportUserDateOutDto>>($"{ApiBaseUrl}{inDto.appId}//report/user/date/$date", inDto);
            return result;
        }
        #endregion

        #region 统计API-【用户】获取24个小时在线用户数
        /// <summary>
        ///  统计API-【推送】获取24个小时在线用户数
        ///  查询当前时间一天内的在线用户数(10分钟一个点，1个小时六个点)
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiReportOnlineUserOutDto>> ReportOnlineUserAsync(ApiInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiInDto, ApiReportOnlineUserOutDto>($"{ApiBaseUrl}{inDto.appId}//report/online_user", inDto);
            return result;
        }
        #endregion
        #endregion
    }
}
