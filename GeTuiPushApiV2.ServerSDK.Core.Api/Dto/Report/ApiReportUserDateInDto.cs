namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 统计API-【用户】获取单日用户数据接口输入参数
    /// </summary>
    public class ApiReportUserDateInDto : ApiInDto
    {
        /// <summary>
        /// 必填项，日期，格式: yyyy-MM-dd
        /// </summary>
        public DateTime date { get; set; }
    }
}
