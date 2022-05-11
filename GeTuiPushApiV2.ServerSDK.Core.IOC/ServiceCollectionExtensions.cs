using GeTuiPushApiV2.ServerSDK.Core.MemoryCache;
using GeTuiPushApiV2.ServerSDK.Core.Redis;
using GeTuiPushApiV2.ServerSDK.Core;
using Microsoft.Extensions.DependencyInjection;

namespace GeTuiPushApiV2.ServerSDK.Core.IOC
{
    /// <summary>
    /// 服务注册扩展类
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 使用IOC容器
        /// </summary>
        /// <param name="services">IOC容器对象</param>
        /// <param name="storageType">存储方式，默认使用Redis</param>
        public static void UseGeTuiPushApiV2ServerSDKCore(this IServiceCollection services, StorageType storageType = StorageType.Redis)
        {
            services.AddBaseService();
            switch (storageType)
            {
                case StorageType.MemoryCache:
                    {
                        services.AddMemoryCache();
                        services.AddMemoryCacheStorage();
                    }
                    break;
                case StorageType.Redis:
                    {
                        services.AddRedisStorage();
                        services.AddRedisOptions();
                        services.AddStackExchangeRedis();
                    }
                    break;
                case StorageType.SqlServer:
                    break;
                case StorageType.MySQL:
                    break;
                case StorageType.MongoDB:
                    break;
                case StorageType.Sqlite:
                    break;
                case StorageType.Custom:
                    break;
                default:
                    goto case StorageType.Redis;
            }
            //Console.WriteLine($"存储方式：{storageType.ToString()}");
        }
        /// <summary>
        /// 注入基础服务
        /// </summary>
        /// <param name="services">IOC容器对象</param>
        private static void AddBaseService(this IServiceCollection services)
        {
            services.AddGeTuiPushApiV2();
            services.AddGeTuiPushOptions();
            services.AddGeTuiPushService();
        }
    }
}