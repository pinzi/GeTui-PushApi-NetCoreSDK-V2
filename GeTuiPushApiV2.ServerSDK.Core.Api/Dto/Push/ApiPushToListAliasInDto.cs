namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 推送-【toList】执行别名批量推输入参数
    /// </summary>
    public class ApiPushToListAliasInDto : ApiInDto
    {
        /// <summary>
        /// 必填项，推送目标用户
        /// </summary>
        public audience_listaliasDto audience { get; set; }
        /// <summary>
        ///  false	是否异步推送，true是异步，false同步。异步推送不会返回data详情
        /// </summary>
        public bool is_async { get; set; }
        /// <summary>
        /// 必填项，使用创建消息接口返回的taskId，可以多次使用
        /// </summary>
        public string taskid { get; set; }
        /// <summary>
        /// 是否返回别名详情,返回别名详情的前提：is_async=false
        /// </summary>
        public bool need_alias_detail { get; set; }
    }

    /// <summary>
    /// 推送目标用户
    /// </summary>
    public class audience_listaliasDto
    {
        /// <summary>
        /// 必填项，alias数组，数组长度不大于1000；绑定别名请参考接口
        /// </summary>
        public string[] alias { get; set; }
    }
}
