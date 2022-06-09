﻿using GeTuiPushApiV2.NetCoreSDK.Core.IOC;
using GeTuiPushApiV2.NetCoreSDK.Core.Test;
using Microsoft.Extensions.DependencyInjection;


IServiceCollection services = new ServiceCollection();
services.UseGeTuiPushApiV2NetCoreSDKCore(StorageType.MemoryCache);//

#region 鉴权API
{
    //IOC方式
    //await new IocAuthTest().Run(services);
}
#endregion

#region 推送API
{
    //普通方式
    await new CommPushTest().Run();
    //IOC方式
    await new IocPushTest().Run(services);
}
#endregion

#region 用户API
{
    //IOC方式
    //await new IocUserAliasTest().Run(services);
    //IOC方式
    //await new IocUserTagTest().Run(services);
}
#endregion

#region Storage
{
    //IOC方式
    //new StorageTest().Run(services);
}
#endregion

Newtonsoft.Json.JsonConvert.SerializeObject(new { id = 1, name = "hello" });

Console.WriteLine("ok");
Console.ReadKey();