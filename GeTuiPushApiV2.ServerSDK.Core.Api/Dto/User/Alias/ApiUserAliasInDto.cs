namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 用户-【别名】绑定别名传入参数
    /// </summary>
    public class ApiUserAliasInDto : ApiInDto
    {
        /// <summary>
        /// 别名数据列表，数组长度不大于1000
        /// </summary>
        public data_listDto[] data_list { get; set; }
    }

    /// <summary>
    /// 别名数据列表
    /// </summary>
    public class data_listDto
    {
        /// <summary>
        /// 必填项，cid，用户标识
        /// </summary>
        public string alias { get; set; }
        /// <summary>
        /// 必填项，别名，有效的别名组成：
        /// 字母（区分大小写）、数字、下划线、汉字;
        /// 长度<40;
        /// 一个别名最多允许绑定10个cid。
        /// </summary>
        public string cid { get; set; }
    }
}
