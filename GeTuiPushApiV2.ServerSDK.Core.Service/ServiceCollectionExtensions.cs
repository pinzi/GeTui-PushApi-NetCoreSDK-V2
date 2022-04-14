using Microsoft.Extensions.DependencyInjection;

namespace GeTuiPushApiV2.ServerSDK.Core.Service
{
    /// <summary>
    /// 服务注册扩展类
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注入个推消息推送服务
        /// </summary>
        /// <param name="services">IOC容器对象</param>
        public static void AddGeTuiPushService(this IServiceCollection services)
        {
            services.AddSingleton<GeTuiPushService>();
        }
    }
}