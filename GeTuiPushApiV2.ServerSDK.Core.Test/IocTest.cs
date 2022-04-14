using GeTuiPushApiV2.ServerSDK.Core.Service;
using GeTuiPushApiV2.ServerSDK.Core.Utility;
using Microsoft.Extensions.DependencyInjection;
using GeTuiPushApiV2.ServerSDK.Storage;
using Newtonsoft.Json;

namespace GeTuiPushApiV2.ServerSDK.Core.Test
{
    /// <summary>
    /// IOC方式
    /// </summary>
    public class IocTest
    {
        public async Task Run(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();

            //准备CID
            var redis = provider.GetRequiredService<IStorage>();
            redis.AddCID("123456789", Guid.NewGuid().ToStr());

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

            //1.使用封装好的HTTP请求方法，需要自己实现Token的缓存，CID的保存及查询逻辑
            {
                var result = await GeTuiPushV2Api.HttpPostGeTuiApiAsync<ApiAuthInDto, ApiAuthOutDto>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/auth", indto);
                Console.WriteLine(result.msg);
            }

            Console.WriteLine("*********************************************************************************************************************");

            //2.使用自定义的HTTP请求方法，需要自己实现Token的缓存，CID的保存及查询逻辑
            {
                GeTuiPushV2Api api = provider.GetRequiredService<GeTuiPushV2Api>();
                var result = await api.AuthAsync(indto);
                Console.WriteLine(result.msg);
            }

            Console.WriteLine("*********************************************************************************************************************");

            //3.使用自定义的接口封装方法
            {
                GeTuiPushService service = provider.GetRequiredService<GeTuiPushService>();
                try
                {
                    await service.PushMessageAsync(new PushMessageInDto()
                    {
                        title = "停机警告",
                        body = $"已停机，请及时处理",
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
