using GeTuiPushApiV2.ServerSDK.Core.TestMethod;
using GeTuiPushApiV2.ServerSDK.IOC;
using Microsoft.Extensions.DependencyInjection;

//普通方式
await new CommTest().Run();
Thread.Sleep(3000);
//IOC方式
IServiceCollection services = new ServiceCollection();
services.UseIOC();
await new IocTest().Run(services);

Console.WriteLine("ok");
Console.ReadKey();