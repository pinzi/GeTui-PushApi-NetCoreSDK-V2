namespace GeTuiPushApiV2.ServerSDK.Core.Redis
{
    /// <summary>
    /// Redis配置信息
    /// </summary>
    public class RedisOptions
    {
        /// <summary>
        /// 主机地址
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// 主机端口号
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 访问密码
        /// </summary>
        public string Pass { get; set; }
        /// <summary>
        /// 数据库编号
        /// </summary>
        public int DbNum { get; set; } = 0;
    }
}
