namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口-统计API-推送
    /// </summary>
    public partial class GeTuiPushV2Api
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
        public async Task<ApiResultOutDto<Dictionary<string, ReportPushDataOutDto>>> ReportPushTaskAsync(ApiReportPushTaskInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiReportPushTaskInDto, Dictionary<string, ReportPushDataOutDto>>($"{ApiBaseUrl}{inDto.appId}/report/push/task/{inDto.taskIds}", inDto);
            return result;
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
        public async Task<ApiResultOutDto<Dictionary<string, ReportPushDataOutDto>>> ReportPushTaskActionAsync(ApiReportPushTaskActionInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiReportPushTaskActionInDto, Dictionary<string, ReportPushDataOutDto>>($"{ApiBaseUrl}{inDto.appId}/report/push/task/{inDto.taskIds}?actionIdList={inDto.actionIds}", inDto);
            return result;
        }
        #endregion

        #region 统计API-【推送】任务组名查报表
        /// <summary>
        ///  统计API-【推送】任务组名查报表
        ///  根据任务组名查询推送结果，返回结果包括消息可下发数、下发数，接收数、展示数、点击数。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<Dictionary<string, ReportPushDataOutDto>>> ReportPushTaskGroupAsync(ApiReportPushTaskGroupInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiReportPushTaskGroupInDto, Dictionary<string, ReportPushDataOutDto>>($"{ApiBaseUrl}{inDto.appId}/report/push/task/task_group/{inDto.group_name}", inDto);
            return result;
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
        public async Task<ApiResultOutDto<Dictionary<string, ApiReportPushTaskDetailOutDto>>> ReportPushTaskDetailAsync(ApiReportPushTaskDetailInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiReportPushTaskDetailInDto, Dictionary<string, ApiReportPushTaskDetailOutDto>>($"{ApiBaseUrl}{inDto.appId}/report/push/task/{inDto.taskid}/detail", inDto);
            return result;
        }
        #endregion

        #region 统计API-【推送】获取单日推送数据【空缺】

        #endregion

        #region 统计API-【推送】查询推送量【空缺】

        #endregion
        #endregion
    }
}
