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

        #region 统计API-【推送】任务组名查报表
        /// <summary>
        ///  统计API-【推送】任务组名查报表
        ///  根据任务组名查询推送结果，返回结果包括消息可下发数、下发数，接收数、展示数、点击数。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, ReportPushDataOutDto>> ReportPushTaskGroupAsync(ReportPushTaskGroupInDto inDto)
        {
            var apiInDto = new ApiReportPushTaskGroupInDto()
            {
                group_name = inDto.group_name,
            };
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.ReportPushTaskGroupAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.ReportPushTaskGroupAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
            return result.data;
        }
        #endregion

        #region 统计API-【推送】获取推送实时结果
        /// <summary>
        ///  统计API-【推送】获取推送实时结果
        ///  获取推送实时结果，可查询消息下发数，接收数、展示数、点击数和消息折损详情等结果。支持单个taskId查询和多个taskId查询。
        ///  注意：该接口需要开通权限，如需开通，请联系对应的商务同学开通
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, ApiReportPushTaskDetailOutDto>> ReportPushTaskDetailAsync(ReportPushTaskDetailInDto inDto)
        {
            var apiInDto = new ApiReportPushTaskDetailInDto()
            {
                taskid = inDto.taskid,
            };
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.ReportPushTaskDetailAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.ReportPushTaskDetailAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
            return result.data;
        }
        #endregion

        #region 统计API-【推送】获取单日推送数据【空缺】

        #endregion

        #region 统计API-【推送】查询推送量【空缺】

        #endregion
        #endregion
    }
}
