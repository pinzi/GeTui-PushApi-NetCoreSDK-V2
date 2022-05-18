using GeTuiPushApiV2.ServerSDK.Core.IOC;
using GeTuiPushApiV2.ServerSDK.Core.Test;
using Microsoft.Extensions.DependencyInjection;


IServiceCollection services = new ServiceCollection();
services.UseGeTuiPushApiV2ServerSDKCore();

#region 鉴权API
{
    //IOC方式
    //await new IocAuthTest().Run(services);
}
#endregion

#region 推送API
{
    ////普通方式
    //await new CommPushTest().Run();
    ////IOC方式
    //await new IocPushTest().Run(services);
}
#endregion

#region 鉴权API
{
    //IOC方式
    await new IocAliasTest().Run(services);
}
#endregion

Console.WriteLine("ok");
Console.ReadKey();