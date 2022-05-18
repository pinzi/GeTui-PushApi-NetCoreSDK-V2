using GeTuiPushApiV2.ServerSDK.Core.Utility;
using Microsoft.Extensions.DependencyInjection;

namespace GeTuiPushApiV2.ServerSDK.Core.Test
{
    /// <summary>
    /// IOC方式
    /// </summary>
    public class IocAliasTest
    {
        public async Task Run(IServiceCollection services)
        {
            Console.WriteLine("*************************************************IOC方式*************************************************");

            var provider = services.BuildServiceProvider();
            //获取推送身份Token
            GeTuiPushOptions geTuiPushOptions = provider.GetRequiredService<GeTuiPushOptions>();
            GeTuiPushService service = provider.GetRequiredService<GeTuiPushService>();
            string token = await service.GetTokenAsync(geTuiPushOptions.AppID);
            Console.WriteLine(token);
            var data_list = new data_listDto[]
                {
                    new data_listDto(){cid="2bfd19ad80d679853a690ceb72c7c041",alias="新用户"},
                    new data_listDto(){cid="2bfd19ad80d679853a690ceb72c7c042",alias="新用户"},
                    new data_listDto(){cid="2bfd19ad80d679853a690ceb72c7c043",alias="新用户"},
                    new data_listDto(){cid="2bfd19ad80d679853a690ceb72c7c044",alias="中奖用户"},
                    new data_listDto(){cid="2bfd19ad80d679853a690ceb72c7c045",alias="中奖用户"}

                };
            long _timestamp = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
            var indto = new ApiAliasInDto()
            {
                token = token,
                appkey = geTuiPushOptions.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                appId = geTuiPushOptions.AppID,
                data_list = data_list
            };

            //1.直接调用API HTTP请求方法，自行处理cid别名的存储
            {
                var result = await GeTuiPushV2Api.HttpPostGeTuiApiAsync<ApiAliasInDto, ApiAliasOutDto>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/user/alias", indto);
                Console.WriteLine(result.msg);
                var indto2 = new ApiAliasCidInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = indto.token,
                    cid = "2bfd19ad80d679853a690ceb72c7c041"
                };
                var result2 = await GeTuiPushV2Api.HttpGetGeTuiApiAsync<ApiAliasCidInDto, ApiAliasCidOutDto>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/user/alias/cid/{indto2.cid}", indto2);
                Console.WriteLine(result2.data.alias);
            }
            Console.WriteLine("*********************************************************************************************************************");
            Thread.Sleep(1000);

            //2.使用封装好的API调用方法，自行处理cid别名的存储
            {
                GeTuiPushV2Api api = provider.GetRequiredService<GeTuiPushV2Api>();
                var result = await api.AliasAsync(indto);
                Console.WriteLine(result.msg);
                var result2 = await api.AliasCidAsync(new ApiAliasCidInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = indto.token,
                    cid = "2bfd19ad80d679853a690ceb72c7c041"
                });
                Console.WriteLine(result2.data.alias);
            }
            Console.WriteLine("*********************************************************************************************************************");
            Thread.Sleep(1000);

            //3.使用封装好的个推API服务
            {
                var result = await service.AliasAsync(new ApiAliasInDto()
                {
                    data_list = data_list
                });
                Console.WriteLine(result.msg);
                var result2 = await service.AliasCidAsync(new ApiAliasCidInDto()
                {
                    cid = "2bfd19ad80d679853a690ceb72c7c041"
                });
                Console.WriteLine(result2.data.alias);
            }
            Console.WriteLine("*************************************************IOC方式*************************************************");
        }
    }
}
