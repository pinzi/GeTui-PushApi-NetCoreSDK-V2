namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推消息推送服务-统计API-推送
    /// </summary>
    public partial class GeTuiPushService
    {
        #region 推送
        #region 统计API-【推送】获取推送结果（不含自定义事件）
        /// <summary>
        ///  统计API-【推送】获取推送结果（不含自定义事件）
        ///  查询推送数据，可查询消息可下发数、下发数，接收数、展示数、点击数等结果。支持单个taskId查询和多个taskId查询。
        ///  此接口调用，仅可以查询toList或toApp的推送结果数据；不能查询toSingle的推送结果数据。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, ReportPushDataOutDto>> ReportPushTaskAsync(ReportPushTaskInDto inDto)
        {
            var apiInDto = new ApiReportPushTaskInDto()
            {
                taskIds = inDto.taskIds,
            };
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.ReportPushTaskAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.ReportPushTaskAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
            return result.data;
        }
        #endregion

        #region 统计API-【推送】获取推送结果（含自定义事件）
        /// <summary>
        ///  统计API-【推送】获取推送结果（含自定义事件）
        ///  查询推送数据，可查询消息可下发数、下发数，接收数、展示数、点击数等结果。支持单个taskId查询和多个taskId查询。
        ///  此接口调用，仅可以查询toList或toApp的推送结果数据；不能查询toSingle的推送结果数据。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, ReportPushDataOutDto>> ReportPushTaskActionAsync(ReportPushTaskActionInDto inDto)
        {
            var apiInDto = new ApiReportPushTaskActionInDto()
            {
                taskIds = inDto.taskIds,
                actionIds = inDto.actionIds
            };
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.ReportPushTaskActionAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.ReportPushTaskActionAsync(apiInDto);
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
