namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-【toList】执行cid批量推输入参数
    /// </summary>
    public class ApiPushToListCIDInDto : ApiInDto
    {
        /// <summary>
        /// 必填项，推送目标用户该接口audience 对应值为all，表示推送所有用户
        /// </summary>
        public audience_listcidDto audience { get; set; }
        /// <summary>
        ///  false	是否异步推送，true是异步，false同步。异步推送不会返回data详情
        /// </summary>
        public bool is_async { get; set; }
        /// <summary>
        /// 必填项，使用创建消息接口返回的taskId，可以多次使用
        /// </summary>
        public string taskid { get; set; }
    }

    /// <summary>
    /// 推送目标用户
    /// </summary>
    public class audience_listcidDto
    {
        /// <summary>
        /// 必填项，cid数组，数组长度不大于1000
        /// </summary>
        public string[] cid { get; set; }
    }
}
