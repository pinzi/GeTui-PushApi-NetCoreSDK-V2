using GeTuiPushApiV2.ServerSDK.Core.Utility;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GeTuiPushApiV2.ServerSDK.Core.Test
{
    /// <summary>
    /// IOC方式
    /// </summary>
    public class IocUserTagTest
    {
        public async Task Run(IServiceCollection services)
        {
            Console.WriteLine("*************************************************IOC方式*************************************************");

            var provider = services.BuildServiceProvider();
            //获取身份Token
            GeTuiPushOptions geTuiPushOptions = provider.GetRequiredService<GeTuiPushOptions>();
            GeTuiPushService service = provider.GetRequiredService<GeTuiPushService>();
            string token = await service.GetTokenAsync(geTuiPushOptions.AppID);
            Console.WriteLine(token);
            long _timestamp = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;

            //1.直接调用API HTTP请求方法，自行处理cid别名的存储
            {
                //一个用户绑定一批标签
                var indto = new ApiUserTagBindInDto()
                {
                    token = token,
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    cid = "2bfd19ad80d679853a690ceb72c7c041",
                    custom_tag = new string[] { "新用户", "中奖用户" }
                };
                var result = await GeTuiPushV2Api.HttpPostGeTuiApiAsync<ApiUserTagBindInDto, ApiUserTagBindOutDto>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/user/custom_tag/cid/{indto.cid}", indto);
                Console.WriteLine(result.msg);
                Thread.Sleep(1000);
                //一批用户绑定一个标签
                var indto2 = new ApiUserTagBatchBindInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = token,
                    cid = new string[] { "2bfd19ad80d679853a690ceb72c7c041" },
                    custom_tag = "VIP客户"
                };
                var result2 = await GeTuiPushV2Api.HttpPutGeTuiApiAsync<ApiUserTagBatchBindInDto, ApiUserTagBatchBindOutDto>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/user/custom_tag/batch/{indto2.custom_tag}", indto2);
                Console.WriteLine(result2.msg);
                Thread.Sleep(1000);
                //查询用户标签
                var indto3 = new ApiUserTagQueryInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = token,
                    cid = "2bfd19ad80d679853a690ceb72c7c041"
                };
                var result3 = await GeTuiPushV2Api.HttpGetGeTuiApiAsync<ApiUserTagQueryInDto, Dictionary<string, string[]>>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/user/custom_tag/cid/{indto3.cid}", indto3);
                foreach (string key in result3.data.Keys)
                {
                    Console.WriteLine($"{key}:{string.Join(",", result3.data[key])}");
                }
                Thread.Sleep(1000);
                //一批用户解绑一个标签
                var indto4 = new ApiUserTagBatchUnBindInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = token,
                    custom_tag = "VIP客户",
                    cid = new string[] { "2bfd19ad80d679853a690ceb72c7c041" }
                };
                var result4 = await GeTuiPushV2Api.HttpDeleteGeTuiApiAsync<ApiUserTagBatchUnBindInDto, Dictionary<string, bool>>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/user/custom_tag/batch/{indto4.custom_tag}", indto4);
                foreach (string key in result4.data.Keys)
                {
                    Console.WriteLine($"{key}:{string.Join(",", result4.data[key])}");
                }
                Thread.Sleep(1000);
                //查询用户标签
                var indto5 = new ApiUserTagQueryInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = token,
                    cid = "2bfd19ad80d679853a690ceb72c7c041"
                };
                var result5 = await GeTuiPushV2Api.HttpGetGeTuiApiAsync<ApiUserTagQueryInDto, Dictionary<string, string[]>>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/user/custom_tag/cid/{indto5.cid}", indto5);
                foreach (string key in result5.data.Keys)
                {
                    Console.WriteLine($"{key}:{string.Join(",", result5.data[key])}");
                }
            }
            Console.WriteLine("*********************************************************************************************************************");
            Thread.Sleep(1000);

            //2.使用封装好的API调用方法，自行处理cid别名的存储
            {
                GeTuiPushV2Api api = provider.GetRequiredService<GeTuiPushV2Api>();

                //一个用户绑定一批标签
                var indto = new ApiUserTagBindInDto()
                {
                    token = token,
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    cid = "2bfd19ad80d679853a690ceb72c7c041",
                    custom_tag = new string[] { "新用户", "中奖用户" }
                };
                var result = await api.UserTagBindAsync(indto);
                Console.WriteLine(result.msg);
                Thread.Sleep(1000);
                //一批用户绑定一个标签
                var indto2 = new ApiUserTagBatchBindInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = token,
                    cid = new string[] { "2bfd19ad80d679853a690ceb72c7c041" },
                    custom_tag = "VIP客户"
                };
                var result2 = await api.UserTagBatchBindAsync(indto2);
                Console.WriteLine(result2.msg);
                Thread.Sleep(1000);
                //查询用户标签
                var indto3 = new ApiUserTagQueryInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = token,
                    cid = "2bfd19ad80d679853a690ceb72c7c041"
                };
                var result3 = await api.UserTagQueryAsync(indto3);
                foreach (string key in result3.data.Keys)
                {
                    Console.WriteLine($"{key}:{string.Join(",", result3.data[key])}");
                }
                Thread.Sleep(1000);
                //一批用户解绑一个标签
                var indto4 = new ApiUserTagBatchUnBindInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = token,
                    custom_tag = "VIP客户",
                    cid = new string[] { "2bfd19ad80d679853a690ceb72c7c041" }
                };
                var result4 = await api.UserTagBatchUnBindAsync(indto4);
                foreach (string key in result4.data.Keys)
                {
                    Console.WriteLine($"{key}:{string.Join(",", result4.data[key])}");
                }
                Thread.Sleep(1000);
                //查询用户标签
                var indto5 = new ApiUserTagQueryInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = token,
                    cid = "2bfd19ad80d679853a690ceb72c7c041"
                };
                var result5 = await api.UserTagQueryAsync(indto5);
                foreach (string key in result5.data.Keys)
                {
                    Console.WriteLine($"{key}:{string.Join(",", result5.data[key])}");
                }
            }
            Console.WriteLine("*********************************************************************************************************************");
            Thread.Sleep(1000);

            //3.使用封装好的个推API服务
            {
                //一个用户绑定一批标签
                var indto = new UserTagBindInDto()
                {
                    cid = "2bfd19ad80d679853a690ceb72c7c041",
                    custom_tag = new string[] { "新用户", "中奖用户" }
                };
                var result = await service.UserTagBindAsync(indto);
                Console.WriteLine(result.msg);
                Thread.Sleep(1000);
                //一批用户绑定一个标签
                var indto2 = new UserTagBatchBindInDto()
                {
                    cid = new string[] { "2bfd19ad80d679853a690ceb72c7c041" },
                    custom_tag = "VIP客户"
                };
                var result2 = await service.UserTagBatchBindAsync(indto2);
                Console.WriteLine(result2.msg);
                Thread.Sleep(1000);
                //查询用户标签
                var indto3 = new UserTagQueryInDto()
                {
                    cid = "2bfd19ad80d679853a690ceb72c7c041"
                };
                var result3 = await service.UserTagQueryAsync(indto3);
                foreach (string key in result3.data.Keys)
                {
                    Console.WriteLine($"{key}:{string.Join(",", result3.data[key])}");
                }
                Thread.Sleep(1000);
                //一批用户解绑一个标签
                var indto4 = new UserTagBatchUnBindInDto()
                {
                    custom_tag = "VIP客户",
                    cid = new string[] { "2bfd19ad80d679853a690ceb72c7c041" }
                };
                var result4 = await service.UserTagBatchUnBindAsync(indto4);
                foreach (string key in result4.data.Keys)
                {
                    Console.WriteLine($"{key}:{string.Join(",", result4.data[key])}");
                }
                Thread.Sleep(1000);
                //查询用户标签
                var indto5 = new UserTagQueryInDto()
                {
                    cid = "2bfd19ad80d679853a690ceb72c7c041"
                };
                var result5 = await service.UserTagQueryAsync(indto5);
                foreach (string key in result5.data.Keys)
                {
                    Console.WriteLine($"{key}:{string.Join(",", result5.data[key])}");
                }
            }
            Console.WriteLine("*************************************************IOC方式*************************************************");
        }
    }
}
