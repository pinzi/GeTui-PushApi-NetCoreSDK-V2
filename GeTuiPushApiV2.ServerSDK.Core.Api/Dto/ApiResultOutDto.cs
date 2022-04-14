namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 公共返回参数
    /// </summary>
    public class ApiResultOutDto<T>
    {
        /// <summary>
        /// 成功或失败code码，详细含义见业务返回码说明
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 失败时返回此说明
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 详见接口说明
        /// </summary>
        public T data { get; set; }
    }
}
