﻿using GeTuiPushApiV2.ServerSDK.Core.Redis;
using GeTuiPushApiV2.ServerSDK.Core.Service;
using GeTuiPushApiV2.ServerSDK.Core.Utility;
using Newtonsoft.Json;

namespace GeTuiPushApiV2.ServerSDK.Core.Test
{
    /// <summary>
    /// 普通方式
    /// </summary>
    public class CommTest
    {
        public async Task Run()
        {
            string AppID = "Ny3b4Umv7882X0UheVwCU4";//应用ID
            string AppKey = "dY1BXGSHys8TPKeCqU3ilA"; //应用key
            string MasterSecret = "GAZTCU0hyO69XjC9u5pSb2"; //主密钥

            long _timestamp = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
            var indto = new ApiAuthInDto()
            {
                appkey = AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(AppKey + _timestamp + MasterSecret),
                appId = AppID
            };

            //1.使用封装好的HTTP请求方法，需要自己实现Token的缓存，CID的保存及查询逻辑
            {
                var result = await GeTuiPushV2Api.HttpPostGeTuiApiAsync<ApiAuthInDto, ApiAuthOutDto>($"https://restapi.getui.com/v2/{AppID}/auth", indto);
                Console.WriteLine(result.msg);
                var apiInDto = new ApiPushToSingleInDto()
                {
                    request_id = Guid.NewGuid().ToString(),
                    audience = new audience_cidDto()
                    {
                        cid = new string[] { "123456789" }
                    },
                    push_message = new push_messageDto()
                };
                //通知消息
                apiInDto.push_message.notification = new notificationDto()
                {
                    title = "停机警告",
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
                apiInDto.appId = AppID;
                await GeTuiPushV2Api.HttpPostGeTuiApiAsync<ApiPushToSingleInDto, ApiPushToSingleOutDto>($"https://restapi.getui.com/v2/{AppID}/push/single/cid", apiInDto);
            }
            Console.WriteLine("*********************************************************************************************************************");

            //2.使用自定义的HTTP请求方法，需要自己实现Token的缓存，CID的保存及查询逻辑
            {
                GeTuiPushV2Api api = new GeTuiPushV2Api();
                var result = await api.AuthAsync(indto);
                var apiInDto = new ApiPushToSingleInDto()
                {
                    request_id = Guid.NewGuid().ToString(),
                    audience = new audience_cidDto()
                    {
                        cid = new string[] { "123456789" }
                    },
                    push_message = new push_messageDto()
                };
                //通知消息
                apiInDto.push_message.notification = new notificationDto()
                {
                    title = "停机警告",
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
                apiInDto.appId = AppID;
                await api.PushToSingleAsync(apiInDto);
                Console.WriteLine(result.msg);
            }

            Console.WriteLine("*********************************************************************************************************************");

            //3.使用自定义的接口封装方法
            {
                IStorage iStorage = new RedisStorage(new StackExchangeRedis(new RedisOptions()
                {
                    Host = "127.0.0.1",
                    Port = 6379,
                    DbNum = 10
                }));
                iStorage.AddCID("123456789", Guid.NewGuid().ToStr());
                var options = new GeTuiPushOptions()
                {
                    AppID = AppID,
                    AppKey = AppKey,
                    MasterSecret = MasterSecret
                };
                GeTuiPushV2Api api = new GeTuiPushV2Api();
                GeTuiPushService service = new GeTuiPushService(iStorage, options, api);
                try
                {
                    await service.PushMessageAsync(new PushMessageInDto()
                    {
                        title = "停机警告",
                        body = "已停机，请及时处理",
                        payload = JsonConvert.SerializeObject(new
                        {
                            msgId = new string[] { Guid.NewGuid().ToStr() },
                            text = $"停机时间：{DateTime.Now}"
                        }),
                        isall = false,
                        uid = new string[] { "123456789" }
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
