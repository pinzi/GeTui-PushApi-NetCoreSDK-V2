using GeTuiPushApiV2.ServerSDK.Core.Redis;
using Microsoft.Extensions.DependencyInjection;

namespace GeTuiPushApiV2.ServerSDK.Core.Test
{
    public class StorageTest
    {
        public void Run(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var redis = provider.GetRequiredService<IRedis>();
            //单键值
            redis.Set("k1", "永不过期");
            Console.WriteLine(redis.Get("k1"));
            redis.Set("k2", "3s后过期", TimeSpan.FromSeconds(3));
            Console.WriteLine(redis.Get("k2"));
            Thread.Sleep(3000);
            Console.WriteLine(redis.Get("k2"));
            //Set集合键值
            List<string> list = new List<string>()
            {
                "hello","world","hi","yeah"
            };
            redis.SetAdd("s1", list);
            redis.GetList("s1").ForEach(f =>
            {
                Console.WriteLine(f);
            });
            Console.WriteLine("---------------------------------------------");
            redis.SetRemove("s1", "hi");
            redis.GetList("s1").ForEach(f =>
            {
                Console.WriteLine(f);
            });
            Console.WriteLine("---------------------------------------------");
            redis.Remove("s1");
            redis.GetList("s1").ForEach(f =>
            {
                Console.WriteLine(f);
            });
            Console.WriteLine("---------------------------------------------");
        }
    }
}
