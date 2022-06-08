namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口-推送API-推送
    /// </summary>
    public partial class GeTuiPushV2Api
    {
        #region 推送
        #region 推送API-【推送】查询消息明细
        /// <summary>
        ///  推送API-【推送】查询消息明细
        ///  调用此接口可以查询某任务下某cid的具体实时推送路径情况
        ///  使用该接口需要申请权限，若有需要，请点击右侧“技术咨询”了解详情
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<List<ApiTaskDetailOutDto>>> TaskDetailAsync(ApiTaskDetailInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiTaskDetailInDto, List<ApiTaskDetailOutDto>>($"{ApiBaseUrl}{inDto.appId}/task/detail/{inDto.cid}/{inDto.taskId}", inDto);
            return result;
        }
        #endregion
        #endregion
    }
}
