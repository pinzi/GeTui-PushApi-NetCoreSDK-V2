using GeTuiPushApiV2.ServerSDK.Core.Utility;
using GeTuiPushApiV2.ServerSDK.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace GeTuiPushApiV2.ServerSDK.Core.Test
{
    /// <summary>
    /// IOC方式
    /// </summary>
    public class IocAuthTest
    {
        public async Task Run(IServiceCollection services)
        {
            Console.WriteLine("*************************************************IOC方式*************************************************");

            var provider = services.BuildServiceProvider();
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

            //1.直接调用API HTTP请求方法，自行处理token的存储
            {
                var result = await GeTuiPushV2Api.HttpPostGeTuiApiAsync<ApiAuthInDto, ApiAuthOutDto>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/auth", indto);
                Console.WriteLine(result.data.token);
                indto.token = result.data.token;
                var result2 = await GeTuiPushV2Api.HttpDeleteGeTuiApiAsync<ApiInDto, ApiAuthDeleteOutDto>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/auth/{indto.token}", indto);
                Console.WriteLine(result2.msg);
            }
            Console.WriteLine("*********************************************************************************************************************");
            Thread.Sleep(1000);

            //2.使用封装好的API调用方法，自行处理token的存储
            {
                GeTuiPushV2Api api = provider.GetRequiredService<GeTuiPushV2Api>();
                var result = await api.AuthAsync(indto);
                Console.WriteLine(result.data.token);
                var result2 = await api.AuthDeleteAsync(new ApiInDto()
                {
                    appId = geTuiPushOptions.AppID,
                    token = result.data.token
                });
                Console.WriteLine(result2.msg);
            }
            Console.WriteLine("*********************************************************************************************************************");
            Thread.Sleep(1000);

            //3.使用封装好的个推API服务
            {
                GeTuiPushService service = provider.GetRequiredService<GeTuiPushService>();
                var result = await service.AuthAsync();
                Console.WriteLine(result.data.token);
                IStorage iStorage = provider.GetRequiredService<IStorage>();
                Console.WriteLine($"删除前token={iStorage.GetToken(geTuiPushOptions.AppID)}");
                var result2 = await service.AuthDeleteAsync();
                Console.WriteLine(result2.msg);
                Console.WriteLine($"删除后token={iStorage.GetToken(geTuiPushOptions.AppID)}");
            }
            Console.WriteLine("*************************************************IOC方式*************************************************");
        }
    }
}
