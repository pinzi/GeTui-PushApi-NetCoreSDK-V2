﻿namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 用户API-【标签】一批用户绑定一个标签输入参数
    /// </summary>
    public class UserTagBatchBindInDto
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
