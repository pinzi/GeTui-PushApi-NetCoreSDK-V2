namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 用户-【标签】一批用户绑定一个标签输入参数
    /// </summary>
    public class ApiUserTagBatchBindInDto : ApiInDto
    {
        /// <summary>
        /// 必填项，用户标签，标签中不能包含空格，单个标签最大长度为32字符，如果含有中文字符需要编码(UrlEncode)
        /// </summary>
        public string custom_tag { get; set; }
        /// <summary>
        /// 必填项，要修改标签属性的cid列表，数组长度不大于1000
        /// </summary>
        public string[] cid { get; set; }
    }
}
