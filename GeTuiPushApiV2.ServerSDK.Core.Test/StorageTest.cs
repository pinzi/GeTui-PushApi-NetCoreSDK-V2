using GeTuiPushApiV2.ServerSDK.Core.MemoryCache;
using GeTuiPushApiV2.ServerSDK.Core.Redis;
using GeTuiPushApiV2.ServerSDK.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace GeTuiPushApiV2.ServerSDK.Core.Test
{
    public class StorageTest
    {
        public void Run(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();

            #region IRedis
            {
                //var redis = provider.GetRequiredService<IRedis>();
                ////单键值
                //redis.Set("k1", "永不过期");
                //Console.WriteLine(redis.Get("k1"));
                //redis.Set("k2", "3s后过期", TimeSpan.FromSeconds(3));
                //Console.WriteLine(redis.Get("k2"));
                //Thread.Sleep(3000);
                //Console.WriteLine(redis.Get("k2"));
                ////Set集合键值
                //redis.SetAdd("A", "a");
                //redis.SetAdd("A", "b");
                //redis.SetAdd("A", "c");
                //redis.SetAdd("A", "b");
                //redis.GetList("A").ForEach(f =>
                //{
                //    Console.WriteLine(f);
                //});
                //Console.WriteLine("---------------------------------------------");
                //List<string> list = new List<string>()
                //{
                //    "hello","world", "hi","a","yeah"
                //};
                //redis.SetAdd("A", list);
                //redis.GetList("A").ForEach(f =>
                //{
                //    Console.WriteLine(f);
                //});
                //Console.WriteLine("---------------------------------------------");
                //redis.SetRemove("s1", "hi");
                //redis.GetList("s1").ForEach(f =>
                //{
                //    Console.WriteLine(f);
                //});
                //Console.WriteLine("---------------------------------------------");
                //redis.Remove("s1");
                //redis.GetList("s1").ForEach(f =>
                //{
                //    Console.WriteLine(f);
                //});
                //Console.WriteLine("---------------------------------------------");
            }
            #endregion

            #region MemoryManager
            {
                var memory = provider.GetRequiredService<MemoryManager>();
                ////单键值
                //redis.Set("k1", "永不过期");
                //Console.WriteLine(redis.Get("k1"));
                //redis.Set("k2", "3s后过期", TimeSpan.FromSeconds(3));
                //Console.WriteLine(redis.Get("k2"));
                //Thread.Sleep(3000);
                //Console.WriteLine(redis.Get("k2"));
                //Set集合键值
                memory.SetList_NotExpire("A", "a");
                memory.SetList_NotExpire("A", "b");
                memory.SetList_NotExpire("A", "c");
                memory.SetList_NotExpire("A", "b");
                memory.Get<List<string>>("A")?.ForEach(f =>
                {
                    Console.WriteLine(f);
                });
                Console.WriteLine("---------------------------------------------");
                List<string> list = new List<string>(){
                    "hello","world", "hi","a","yeah"
                };
                memory.SetList_NotExpire("A", list);
                memory.Get<List<string>>("A")?.ForEach(f =>
                {
                    Console.WriteLine(f);
                });
                Console.WriteLine("---------------------------------------------");
                memory.SetRemove("A", "hi");
                memory.Get<List<string>>("A")?.ForEach(f =>
                {
                    Console.WriteLine(f);
                });
                Console.WriteLine("---------------------------------------------");
                memory.Remove("A");
                memory.Get<List<string>>("A")?.ForEach(f =>
                {
                    Console.WriteLine(f);
                });
                Console.WriteLine("---------------------------------------------");
                return;
            }
            #endregion

            #region IStorage
            var iStorage = provider.GetRequiredService<IStorage>();
            {
                //Console.WriteLine("-------------------------------【CID】-------------------------------");
                //iStorage.SaveCID("1", "A");
                //var list1 = iStorage.GetCID("1");
                //foreach (var item in list1)
                //{
                //    Console.WriteLine($"1=>{item}");
                //}
                //Console.WriteLine("---------------------------------------------");
                //iStorage.SaveCID("1", "B");
                //iStorage.SaveCID("1", "C");
                //var list2 = iStorage.GetCID("1");
                //foreach (var item in list2)
                //{
                //    Console.WriteLine($"1=>{item}");
                //}
                //Console.WriteLine("---------------------------------------------");
                //iStorage.DeleteCID("1", "B");
                //var list3 = iStorage.GetCID("1");
                //foreach (var item in list3)
                //{
                //    Console.WriteLine($"1=>{item}");
                //}
                //Console.WriteLine("---------------------------------------------");
                //Console.WriteLine("-------------------------------【CID】-------------------------------");
            }

            Console.WriteLine("\r\n\r\n");

            {
                Console.WriteLine("-------------------------------【别名】-------------------------------");
                iStorage.SaveAlias("2", "A");
                var list1 = iStorage.GetAlias("2");
                foreach (var item in list1)
                {
                    Console.WriteLine($"2=>{item}");
                }
                Console.WriteLine("---------------------------------------------");
                iStorage.SaveAlias("2", "B");
                iStorage.SaveAlias("2", new List<string>() { "C" });
                iStorage.SaveAlias("2", new List<string>() { "D" });
                var list2 = iStorage.GetAlias("2");
                foreach (var item in list2)
                {
                    Console.WriteLine($"2=>{item}");
                }
                Console.WriteLine("---------------------------------------------");
                iStorage.DeleteAlias("2", "B");
                var list3 = iStorage.GetAlias("2");
                foreach (var item in list3)
                {
                    Console.WriteLine($"2=>{item}");
                }
                Console.WriteLine("---------------------------------------------");
                iStorage.DeleteAlias("2", new List<string>() { "C", "D" });
                var list4 = iStorage.GetAlias("2");
                foreach (var item in list4)
                {
                    Console.WriteLine($"2=>{item}");
                }
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("-------------------------------【别名】-------------------------------");
            }
            #endregion
        }
    }
}
