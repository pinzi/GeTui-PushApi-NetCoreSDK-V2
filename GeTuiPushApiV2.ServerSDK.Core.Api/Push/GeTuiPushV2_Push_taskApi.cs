namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口-推送API-任务
    /// </summary>
    public partial class GeTuiPushV2Api
    {
        #region 任务
        #region 推送-【任务】停止任务
        /// <summary>
        ///  推送-【任务】停止任务
        ///  对正处于推送状态，或者未接收的消息停止下发（只支持批量推和群推任务）
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto> TaskStopAsync(ApiTaskStopInDto inDto)
        {
            var result = await HttpDeleteGeTuiApiNoDataAsync<ApiTaskStopInDto>($"{ApiBaseUrl}{inDto.appId}/task/{inDto.taskId}", inDto);
            return result;
        }
        #endregion

        #region 推送-【任务】查询定时任务
        /// <summary>
        ///  推送-【任务】查询定时任务
        ///  该接口支持在推送完定时任务之后，查看定时任务状态，定时任务是否发送成功。
        ///  创建定时任务请见接口执行群推
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<Dictionary<string, ApiTaskScheduleOutDto>>> TaskScheduleAsync(ApiTaskScheduleInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiTaskScheduleInDto, Dictionary<string, ApiTaskScheduleOutDto>>($"{ApiBaseUrl}{inDto.appId}/task/schedule/{inDto.taskId}", inDto);
            return result;
        }
        #endregion

        #region 推送-【任务】删除定时任务
        /// <summary>
        ///  推送-【任务】删除定时任务
        ///  用来删除还未下发的任务，删除后定时任务不再触发(距离下发还有一分钟的任务，将无法删除，后续可以调用停止任务接口。)
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto> TaskDeleteAsync(ApiTaskDeleteInDto inDto)
        {
            var result = await HttpDeleteGeTuiApiNoDataAsync<ApiTaskDeleteInDto>($"{ApiBaseUrl}{inDto.appId}/task/{inDto.taskId}", inDto);
            return result;
        }
        #endregion
        #endregion
    }
}
