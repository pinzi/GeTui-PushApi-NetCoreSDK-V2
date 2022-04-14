using Microsoft.Extensions.DependencyInjection;

namespace GeTuiPushApiV2.ServerSDK.Core.Redis
{
    /// <summary>
    ///  使用NewLife.Redis客户端操作Redis
    /// </summary>
    public class NewLifeRedis : IRedis
    {
        public string Get(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, string value, TimeSpan? expireTime = null)
        {
            throw new NotImplementedException();
        }
    }

    public static class RedisServiceCollectionExtensions
    {
        /// <summary>
        /// 注入使用NewLife.Redis操作Redis
        /// </summary>
        /// <param name="services">IOC容器对象</param>
        public static void AddNewLifeRedis(this IServiceCollection services)
        {
            services.AddSingleton<IRedis, NewLifeRedis>();
        }
    }
}
