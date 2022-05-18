using GeTuiPushApiV2.ServerSDK.Core.Utility;
using Microsoft.Extensions.DependencyInjection;

namespace GeTuiPushApiV2.ServerSDK.Core.Test
{
    /// <summary>
    /// IOC方式
    /// </summary>
    public class IocUserTest
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
            var _data_list = new data_listDto[]
                {
                    new data_listDto(){cid="2bfd19ad80d679853a690ceb72c7c041",alias="新用户"},
                    new data_listDto(){cid="2bfd19ad80d679853a690ceb72c7c042",alias="新用户"},
                    new data_listDto(){cid="2bfd19ad80d679853a690ceb72c7c043",alias="新用户"},
                    new data_listDto(){cid="2bfd19ad80d679853a690ceb72c7c044",alias="中奖用户"},
                    new data_listDto(){cid="2bfd19ad80d679853a690ceb72c7c045",alias="中奖用户"}
                };
            long _timestamp = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
            var indto = new ApiUserAliasInDto()
            {
                token = token,
                appkey = geTuiPushOptions.AppKey,
                timestamp = _timestamp,
                sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                appId = geTuiPushOptions.AppID,
                data_list = _data_list
            };

            //1.直接调用API HTTP请求方法，自行处理cid别名的存储
            {
                //绑定
                var result = await GeTuiPushV2Api.HttpPostGeTuiApiAsync<ApiUserAliasInDto, ApiUserAliasOutDto>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/user/alias", indto);
                Console.WriteLine(result.msg);
                var indto2 = new ApiUserAliasCidInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = indto.token,
                    cid = "2bfd19ad80d679853a690ceb72c7c041"
                };
                //查询
                var result2 = await GeTuiPushV2Api.HttpGetGeTuiApiAsync<ApiUserAliasCidInDto, ApiUserAliasCidOutDto>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/user/alias/cid/{indto2.cid}", indto2);
                Console.WriteLine(result2.data.alias);
                //批量解绑
                var indto3 = new ApiUserAliasBatchUnBoundInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = indto.token,
                    data_list = new data_listDto[]
                    {
                        new data_listDto(){cid="2bfd19ad80d679853a690ceb72c7c041",alias="新用户"},
                        new data_listDto(){cid="2bfd19ad80d679853a690ceb72c7c045",alias="中奖用户"}
                    }
                };
                var result3 = await GeTuiPushV2Api.HttpDeleteGeTuiApiAsync<ApiUserAliasBatchUnBoundInDto, ApiUserAliasBatchUnBoundOutDto>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/user/alias", indto3);
                Console.WriteLine(result3.msg);
                //解绑所有
                var indto4 = new ApiUserAliasUnBoundInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = indto.token,
                    alias = "新用户"
                };
                var result4 = await GeTuiPushV2Api.HttpDeleteGeTuiApiAsync<ApiUserAliasUnBoundInDto, ApiUserAliasUnBoundOutDto>($"https://restapi.getui.com/v2/{geTuiPushOptions.AppID}/user/alias/{indto4.alias}", indto4);
                Console.WriteLine(result4.msg);
            }
            Console.WriteLine("*********************************************************************************************************************");
            Thread.Sleep(1000);

            //2.使用封装好的API调用方法，自行处理cid别名的存储
            {
                GeTuiPushV2Api api = provider.GetRequiredService<GeTuiPushV2Api>();
                //绑定
                var result = await api.UserAliasAsync(indto);
                Console.WriteLine(result.msg);
                //查询
                var result2 = await api.UserAliasCidAsync(new ApiUserAliasCidInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = indto.token,
                    cid = "2bfd19ad80d679853a690ceb72c7c041"
                });
                Console.WriteLine(result2.data.alias);
                //批量解绑
                var result3 = await api.UserAliasBatchUnBoundAsync(new ApiUserAliasBatchUnBoundInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = indto.token,
                    data_list = new data_listDto[]
                    {
                        new data_listDto(){cid="2bfd19ad80d679853a690ceb72c7c041",alias="新用户"},
                        new data_listDto(){cid="2bfd19ad80d679853a690ceb72c7c045",alias="中奖用户"}
                    }
                });
                Console.WriteLine(result3.msg);
                //解绑所有
                var result4 = await api.UserAliasUnBoundAsync(new ApiUserAliasUnBoundInDto()
                {
                    appkey = geTuiPushOptions.AppKey,
                    timestamp = _timestamp,
                    sign = SHA256Helper.SHA256Encrypt(geTuiPushOptions.AppKey + _timestamp + geTuiPushOptions.MasterSecret),
                    appId = geTuiPushOptions.AppID,
                    token = indto.token,
                    alias = "新用户"
                });
                Console.WriteLine(result4.msg);
            }
            Console.WriteLine("*********************************************************************************************************************");
            Thread.Sleep(1000);

            //3.使用封装好的个推API服务
            {
                ////绑定
                //var result = await service.UserAliasAsync(new ApiUserAliasInDto()
                //{
                //    data_list = _data_list
                //});
                //Console.WriteLine(result.msg);
                ////查询
                //var result2 = await service.UserAliasCidAsync(new ApiUserAliasCidInDto()
                //{
                //    cid = "2bfd19ad80d679853a690ceb72c7c041"
                //});
                //Console.WriteLine(result2.data.alias);
                ////批量解绑

                ////解绑所有
            }
            Console.WriteLine("*************************************************IOC方式*************************************************");
        }
    }
}
