namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口-推送API-toApp
    /// </summary>
    public partial class GeTuiPushV2Api
    {
        #region toApp
        #region 推送API-【toApp】执行群推
        /// <summary>
        ///  推送API-【toApp】执行群推
        ///  对指定应用的所有用户群发推送消息。支持定时、定速功能，查询任务推送情况请见接口查询定时任务。
        ///  注：此接口频次限制100次/天，每分钟不能超过5次(推送限制和接口根据条件筛选用户推送共享限制)
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToAppOutDto>> PushToAppAsync(ApiPushToAppInDto inDto)
        {
            inDto.audience = "all";
            var result = await HttpPostGeTuiApiAsync<ApiPushToAppInDto, ApiPushToAppOutDto>($"{ApiBaseUrl}{inDto.appId}/push/all", inDto);
            return result;
        }
        #endregion

        #region 推送API-【toApp】根据条件筛选用户推送
        /// <summary>
        ///  推送API-【toApp】根据条件筛选用户推送
        ///  对指定应用的符合筛选条件的用户群发推送消息。支持定时、定速功能。
        ///  注：此接口频次限制100次/天，每分钟不能超过5次(推送限制和接口执行群推共享限制)，定时推送功能需要申请开通才可以使用，申请修改请点击右侧“技术咨询”了解详情。
        ///  注：个推用户画像中的“016100|中小学生“标签将于2022年5月31日下线，请开发者及时关注和处理
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToAppTagOutDto>> PushToAppTagAsync(ApiPushToAppTagInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiPushToAppTagInDto, ApiPushToAppTagOutDto>($"{ApiBaseUrl}{inDto.appId}/push/tag", inDto);
            return result;
        }
        #endregion

        #region 推送API-【toApp】使用标签快速推送
        /// <summary>
        ///  推送API-【toApp】使用标签快速推送
        ///  根据标签过滤用户并推送。支持定时、定速功能。
        ///  注：该功能需要申请相关套餐，请点击右侧“技术咨询”了解详情 。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToAppFastCustomTagOutDto>> PushToAppFastCustomTagAsync(ApiPushToAppFastCustomTagInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiPushToAppFastCustomTagInDto, ApiPushToAppFastCustomTagOutDto>($"{ApiBaseUrl}{inDto.appId}/push/fast_custom_tag", inDto);
            return result;
        }
        #endregion
        #endregion
    }
}
