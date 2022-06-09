﻿using GeTuiPushApiV2.NetCoreSDK.Core;
using GeTuiPushApiV2.NetCoreSDK.Core.Utility;
using GeTuiPushApiV2.NetCoreSDK.Storage;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace GeTuiPushApiV2.NetCoreSDK.Core.Sample
{
    /// <summary>
    /// IOC方式
    /// </summary>
    public class IocPushTest
    {
        public async Task Run(IServiceCollection services)
        {
            Console.WriteLine("*************************************************IOC方式*************************************************");

            var provider = services.BuildServiceProvider();

            //准备CID
            var redis = provider.GetRequiredService<IStorage>();
            redis.SaveCID("123456789", "2bfd19ad80d679853a690ceb72c7c041");

            //获取推送身份Token
            GeTuiPushOptions geTuiPushOptions = provider.GetRequiredService<GeTuiPushOptions>();
            long _timestamp = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
            var indto = new ApiAuthInDto()
            {
                appkey = geTuiPushOptions.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                appId = geTuiPushOptions.AppID
            };

            //1.直接调用API HTTP请求方法，需要自己实现Token的缓存，CID的保存及查询逻辑
            {
                var result = await GeTuiPushV2Api.HttpPostGeTuiApiAsync<ApiAuthInDto, ApiAuthOutDto>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/auth", indto);
                Console.WriteLine(result.data.token);
                var apiInDto = new ApiPushToSingleCIDInDto()
                {
                    request_id = Guid.NewGuid().ToString(),
                    audience = new audience_cidDto()
                    {
                        cid = new string[] { "2bfd19ad80d679853a690ceb72c7c041" }
                    },
                    push_message = new push_messageDto()
                };
                //通知消息
                apiInDto.push_message.notification = new notificationDto()
                {
                    title = "停机警告-IOC-1",
                    body = "已停机，请及时处理",
                    click_type = "payload",
                    payload = JsonConvert.SerializeObject(new
                    {
                        msgId = new string[] { Guid.NewGuid().ToStr() },
                        text = $"停机时间：{DateTime.Now}"
                    }),
                    badge_add_num = 1,
                    channel_id = "Push",
                    channel_name = "Push",
                    channel_level = 4
                };
                apiInDto.token = result.data.token;
                apiInDto.appId = geTuiPushOptions.AppID;
                var result2 = await GeTuiPushV2Api.HttpPostGeTuiApiNoDataAsync<ApiPushToSingleCIDInDto>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/push/single/cid", apiInDto);
                Console.WriteLine($"IOC-1=>{result2.msg}");
            }

            Console.WriteLine("*********************************************************************************************************************");
            Thread.Sleep(1000);
            //2.使用封装好的API调用方法，需要自己实现Token的缓存，CID的保存及查询逻辑
            {
                GeTuiPushV2Api api = provider.GetRequiredService<GeTuiPushV2Api>();
                var result = await api.AuthAsync(indto);
                Console.WriteLine(result.data.token);
                var apiInDto = new ApiPushToSingleCIDInDto()
                {
                    request_id = Guid.NewGuid().ToString(),
                    audience = new audience_cidDto()
                    {
                        cid = new string[] { "2bfd19ad80d679853a690ceb72c7c041" }
                    },
                    push_message = new push_messageDto()
                };
                //通知消息
                apiInDto.push_message.notification = new notificationDto()
                {
                    title = "停机警告-IOC-2",
                    body = "已停机，请及时处理",
                    click_type = "payload",
                    payload = JsonConvert.SerializeObject(new
                    {
                        msgId = new string[] { Guid.NewGuid().ToStr() },
                        text = $"停机时间：{DateTime.Now}"
                    }),
                    badge_add_num = 1,
                    channel_id = "Push",
                    channel_name = "Push",
                    channel_level = 4
                };
                apiInDto.token = result.data.token;
                apiInDto.appId = geTuiPushOptions.AppID;
                var result2 = await api.PushToSingleCIDAsync(apiInDto);
                Console.WriteLine($"IOC-2=>{result2.msg}");
            }

            Console.WriteLine("*********************************************************************************************************************");
            Thread.Sleep(1000);
            //3.使用封装好的个推API服务
            {
                GeTuiPushService service = provider.GetRequiredService<GeTuiPushService>();
                try
                {
                    await service.QuickPushMessageAsync(new PushMessageInDto()
                    {
                        title = "停机警告-IOC-3",
                        body = $"已停机，请及时处理",
                        payload = JsonConvert.SerializeObject(new
                        {
                            msgId = new string[] { Guid.NewGuid().ToStr() },
                            text = $"停机时间：{DateTime.Now}"
                        }),
                        filter = TargetUserFilter.uid,
                        filterCondition = new string[] { "123456789" }
                    });
                    Console.WriteLine("IOC-3=>推送成功");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"IOC-3=>{ex.Message}");
                }
            }

            Console.WriteLine("*************************************************IOC方式*************************************************");
        }
    }
}
