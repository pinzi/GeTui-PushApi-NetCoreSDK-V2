namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 个推消息推送服务-推送API-推送
    /// </summary>
    public partial class GeTuiPushService
    {
        #region 推送
        #region 推送-【推送】查询消息明细
        /// <summary>
        ///  推送-【推送】查询消息明细
        ///  调用此接口可以查询某任务下某cid的具体实时推送路径情况
        ///  使用该接口需要申请权限，若有需要，请点击右侧“技术咨询”了解详情
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<List<ApiTaskDetailOutDto>> TaskDetailAsync(TaskDetailInDto inDto)
        {
            var apiInDto = new ApiTaskDetailInDto()
            {
                taskId = inDto.taskId,
                cid = inDto.cid
            };
            apiInDto.token = await GetTokenAsync(_options.AppID);
            apiInDto.appId = _options.AppID;
            var result = await _api.TaskDetailAsync(apiInDto);
            if (result.code.Equals(10001))
            {
                //token已过期，刷新token
                apiInDto.token = await GetTokenAsync(_options.AppID, true);
                //重新推送
                result = await _api.TaskDetailAsync(apiInDto);
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
