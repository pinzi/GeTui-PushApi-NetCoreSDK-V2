using Microsoft.Extensions.DependencyInjection;
using GeTuiPushApiV2.NetCoreSDK.Storage;

namespace GeTuiPushApiV2.NetCoreSDK.Core.MemoryCache
{
    /// <summary>
    /// 服务注册扩展类
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注入使用内存存储
        /// </summary>
        /// <param name="services">IOC容器对象</param>
        public static void AddMemoryCacheStorage(this IServiceCollection services)
        {
            services.AddSingleton<MemoryManager>();
            services.AddSingleton<IStorage, MemoryCacheStorage>();
        }
    }
}