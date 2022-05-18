using GeTuiPushApiV2.ServerSDK.Core.IOC;
using GeTuiPushApiV2.ServerSDK.Core.Test;
using Microsoft.Extensions.DependencyInjection;

#region 鉴权API
{
    //IOC方式
    IServiceCollection services = new ServiceCollection();
    services.UseGeTuiPushApiV2ServerSDKCore();
    await new IocAuthTest().Run(services);
}
#endregion

#region 推送API
{
    ////普通方式
    //await new CommPushTest().Run();
    ////IOC方式
    //IServiceCollection services = new ServiceCollection();
    //services.UseGeTuiPushApiV2ServerSDKCore();
    //await new IocPushTest().Run(services);
}
#endregion


Console.WriteLine("ok");
Console.ReadKey();