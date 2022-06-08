using GeTuiPushApiV2.NetCoreSDK.Storage;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeTuiPushApiV2.NetCoreSDK.Core.Redis
{
    /// <summary>
    /// 服务注册扩展类
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注入使用Redis存储
        /// </summary>
        /// <param name="services">IOC容器对象</param>
        public static void AddRedisStorage(this IServiceCollection services)
        {
            services.AddSingleton<IStorage, RedisStorage>();
        }
        /// <summary>
        /// 注入使用StackExchange.Redis操作Redis
        /// </summary>
        /// <param name="services">IOC容器对象</param>
        public static void AddStackExchangeRedis(this IServiceCollection services)
        {
            services.AddSingleton<IRedis, StackExchangeRedis>();
        }
        /// <summary>
        /// 注入Redis配置信息
        /// </summary>
        /// <param name="services">IOC容器对象</param>
        public static void AddRedisOptions(this IServiceCollection services)
        {
            var jsonServices = JObject.Parse(File.ReadAllText("appSettings.json"))["RedisOptions"];
            if (jsonServices != null)
            {
                var requiredServices = JsonConvert.DeserializeObject<RedisOptions>(jsonServices.ToString());
                if (requiredServices != null)
                {
                    services.AddSingleton(requiredServices);
                }
            }
        }
    }
}