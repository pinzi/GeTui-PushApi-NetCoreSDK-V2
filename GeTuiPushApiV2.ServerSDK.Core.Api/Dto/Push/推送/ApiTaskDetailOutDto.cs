using Newtonsoft.Json;

namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 推送API-【推送】查询消息明细输出参数
    /// </summary>
    public class ApiTaskDetailOutDto
    {
        /// <summary>
        /// 请求返回详细数据
        /// </summary>
        public DetailOutDto[] deatil { get; set; }
    }

    /// <summary>
    /// 请求返回详细数据
    /// </summary>
    public class DetailOutDto
    {
        /// <summary>
        /// 时间，格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime? time { get; set; }
        /// <summary>
        /// 事件
        /// </summary>
        [JsonProperty("event")]
        public string Event { get; set; }
    }
}
