using GeTuiPushApiV2.ServerSDK.Core.IOC;
using GeTuiPushApiV2.ServerSDK.Core.Sample.Net7;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;

Console.WriteLine(RuntimeInformation.FrameworkDescription);
//普通方式
await new CommTest().Run();
//IOC方式
IServiceCollection services = new ServiceCollection();
services.UseGeTuiPushApiV2ServerSDKCore();
await new IocTest().Run(services);

Console.WriteLine("ok");
Console.ReadKey();