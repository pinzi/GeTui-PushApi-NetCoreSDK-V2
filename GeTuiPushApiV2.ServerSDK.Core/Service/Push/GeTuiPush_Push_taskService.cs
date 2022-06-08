namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推消息推送服务-推送API-任务
    /// </summary>
    public partial class GeTuiPushService
    {
        #region 任务
        #region 推送-【任务】停止任务
        /// <summary>
        ///  推送-【任务】停止任务
        ///  对正处于推送状态，或者未接收的消息停止下发（只支持批量推和群推任务）
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task TaskStopAsync(TaskStopInDto inDto)
        {
            var apiInDto = new ApiTaskStopInDto()
            {
                taskId = inDto.taskId
            };
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.TaskStopAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.TaskStopAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
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
        public async Task<ApiTaskScheduleOutDto> TaskScheduleAsync(TaskScheduleInDto inDto)
        {
            var apiInDto = new ApiTaskScheduleInDto()
            {
                taskId = inDto.taskId
            };
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.TaskScheduleAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.TaskScheduleAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
            return result.data[inDto.taskId];
        }
        #endregion

        #region 推送-【任务】删除定时任务
        /// <summary>
        ///  推送-【任务】删除定时任务
        ///  用来删除还未下发的任务，删除后定时任务不再触发(距离下发还有一分钟的任务，将无法删除，后续可以调用停止任务接口。)
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task TaskDeleteAsync(TaskDeleteInDto inDto)
        {
            var apiInDto = new ApiTaskDeleteInDto()
            {
                taskId = inDto.taskId
            };
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.TaskDeleteAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.TaskDeleteAsync(apiInDto);
            }
            if (!result.code.Equals(0))
            {
                throw new Exception(result.msg);
            }
        }
        #endregion
        #endregion
    }
}
