namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口-用户API-标签
    /// </summary>
    public partial class GeTuiPushV2Api
    {
        #region 标签
        #region 用户API-【标签】一个用户绑定一批标签
        /// <summary>
        /// 用户API-【标签】一个用户绑定一批标签
        /// 一个用户绑定一批标签，此操作为覆盖操作，会删除历史绑定的标签；
        /// 此接口对单个cid有频控限制，每天只能修改一次，最多设置100个标签；单个标签长度最大为32字符，标签总长度最大为512个字符，申请修改请点击右侧“技术咨询”了解详情 。
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserTagBindOutDto>> UserTagBindAsync(ApiUserTagBindInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiUserTagBindInDto, ApiUserTagBindOutDto>($"{ApiBaseUrl}{inDto.appId}/user/custom_tag/cid/{inDto.cid}", inDto);
            return result;
        }
        #endregion

        #region 用户API-【标签】一批用户绑定一个标签
        /// <summary>
        /// 用户API-【标签】一批用户绑定一个标签
        /// 一批用户绑定一个标签，此接口为增量
        /// 此接口有频次控制(每分钟最多100次，每天最多10000次)，申请修改请点击右侧“技术咨询”了解详情
        /// 此接口是异步的，会有延迟
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto> UserTagBatchBindAsync(ApiUserTagBatchBindInDto inDto)
        {
            var result = await HttpPutGeTuiApiNoDataAsync<ApiUserTagBatchBindInDto>($"{ApiBaseUrl}{inDto.appId}/user/custom_tag/batch/{inDto.custom_tag}", inDto);
            return result;
        }
        #endregion

        #region 用户API-【标签】一批用户解绑一个标签
        /// <summary>
        /// 用户API-【标签】一批用户解绑一个标签
        /// 解绑用户的某个标签属性，不影响其它标签
        /// 此接口有频次控制(每分钟最多100次，每天最多10000次)，申请修改请点击右侧“技术咨询”了解详情
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns>key为cid，value为结果，true表示成功，否则失败</returns>
        public async Task<ApiResultOutDto<Dictionary<string, bool>>> UserTagBatchUnBindAsync(ApiUserTagBatchUnBindInDto inDto)
        {
            var result = await HttpDeleteGeTuiApiAsync<ApiUserTagBatchUnBindInDto, Dictionary<string, bool>>($"{ApiBaseUrl}{inDto.appId}/user/custom_tag/batch/{inDto.custom_tag}", inDto);
            return result;
        }
        #endregion

        #region 用户API-【标签】查询用户标签
        /// <summary>
        /// 用户API-【标签】查询用户标签
        /// 根据cid查询用户标签列表
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns>key: cid，value: 标签列表，列表中只会有一个元素，多个以空格隔开</returns>
        public async Task<ApiResultOutDto<Dictionary<string, string[]>>> UserTagQueryAsync(ApiUserTagQueryInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiUserTagQueryInDto, Dictionary<string, string[]>>($"{ApiBaseUrl}{inDto.appId}/user/custom_tag/cid/{inDto.cid}", inDto);
            return result;
        }
        #endregion
        #endregion
    }
}
