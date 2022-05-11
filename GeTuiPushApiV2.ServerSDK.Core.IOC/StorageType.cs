namespace GeTuiPushApiV2.ServerSDK.Core.IOC
{
    /// <summary>
    /// 存储方式
    /// </summary>
    public enum StorageType
    {
        /// <summary>
        /// 内存
        /// </summary>
        MemoryCache,
        /// <summary>
        /// Redis
        /// </summary>
        Redis,
        /// <summary>
        /// SqlServer
        /// </summary>
        SqlServer,
        /// <summary>
        /// MySQL
        /// </summary>
        MySQL,
        /// <summary>
        /// MongoDB
        /// </summary>
        MongoDB,
        /// <summary>
        /// Sqlite
        /// </summary>
        Sqlite,
        /// <summary>
        /// 自定义
        /// </summary>
        Custom
    }
}
