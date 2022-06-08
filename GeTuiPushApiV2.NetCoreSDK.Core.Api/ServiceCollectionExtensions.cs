using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 服务注册扩展类
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注入个推消息推送V2接口
        /// </summary>
        /// <param name="services">IOC容器对象</param>
        public static void AddGeTuiPushApiV2(this IServiceCollection services)
        {
            services.AddSingleton<GeTuiPushV2Api>();
        }
        /// <summary>
        /// 注入个推消息推送配置信息
        /// </summary>
        /// <param name="services">IOC容器对象</param>
        public static void AddGeTuiPushOptions(this IServiceCollection services)
        {
            var jsonServices = JObject.Parse(File.ReadAllText("appSettings.json"))["GeTuiPushOptions"];
            if (jsonServices != null)
            {
                var requiredServices = JsonConvert.DeserializeObject<GeTuiPushOptions>(jsonServices.ToString());
                if (requiredServices != null)
                {
                    services.AddSingleton(requiredServices);
                }
            }
        }
    }
}