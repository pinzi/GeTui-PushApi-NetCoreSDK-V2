## Build status

![Github Build Status](https://img.shields.io/cirrus/github/pinzi/GeTui-PushApi-ServerSDK-V2/publish?style=plastic)
![stars](https://img.shields.io/github/stars/pinzi/GeTui-PushApi-ServerSDK-V2.svg?style=plastic)
![release](https://img.shields.io/github/v/release/pinzi/GeTui-PushApi-ServerSDK-V2?include_prereleases)
![GitHub top language](https://img.shields.io/github/languages/top/pinzi/GeTui-PushApi-ServerSDK-V2?logo=github)
![GitHub License](https://img.shields.io/github/license/pinzi/GeTui-PushApi-ServerSDK-V2?logo=github)
![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.ServerSDK.Core?logo=nuget)
![Nuget](https://img.shields.io/nuget/v/GeTui-PushApi-ServerSDK-V2?logo=nuget)
![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/GeTui-PushApi-ServerSDK-V2?label=dev%20nuget&logo=nuget)



## Packages

与这个 Repository 相关的 nuget 包：

-![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.ServerSDK.Core?logo=nuget) [GeTuiPushApiV2.ServerSDK.Core](https://www.nuget.org/packages/GeTuiPushApiV2.ServerSDK.Core) 核心服务
- ![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.ServerSDK.Core?logo=nuget)[GeTuiPushApiV2.ServerSDK.Core.Api](https://www.nuget.org/packages/GeTuiPushApiV2.ServerSDK.Core.Api/)  GeTui消息推送V2接口封装
- ![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.ServerSDK.Core?logo=nuget)[GeTuiPushApiV2.ServerSDK.Core.IOC](https://www.nuget.org/packages/GeTuiPushApiV2.ServerSDK.Core.IOC/)  使用IOC容器
- ![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.ServerSDK.Core?logo=nuget)[GeTuiPushApiV2.ServerSDK.Core.MemoryCache](https://www.nuget.org/packages/GeTuiPushApiV2.ServerSDK.Core.MemoryCache) 使用内存存储数据
- ![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.ServerSDK.Core?logo=nuget)[GeTuiPushApiV2.ServerSDK.Core.Storage](https://www.nuget.org/packages/GeTuiPushApiV2.ServerSDK.Core.Storaget) 存储封装
- ![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.ServerSDK.Core?logo=nuget)[GeTuiPushApiV2.ServerSDK.Core.Utility](https://www.nuget.org/packages/GeTuiPushApiV2.ServerSDK.Core.Utility) 公共方法封装
- ![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.ServerSDK.Core?logo=nuget)[GeTuiPushApiV2.ServerSDK.Core.Redis](https://www.nuget.org/packages/GeTuiPushApiV2.ServerSDK.Core.Redis) 使用Redis存储数据

## 简介

`个推PUSH RestAPI V2 SDK For .NetCore`的主要目标是提升开发者在**服务端**集成个推推送服务的开发效率。
开发者不需要进行复杂编程即可使用个推推送服务的各项常用功能，SDK可以自动帮您满足调用过程中所需的鉴权、组装参数、发送HTTP请求等非功能性要求。
目前SDK仅实现了单推，批量推，群推三种方式的推送服务。

【注意】个推推送通道无法实时接收离线推送消息，如需实时接收离线推送消息，则需要接入厂家通道。


## 环境要求

1. 支持.NET CORE 6.0，7.0。

2. 使用`个推PUSH RestAPI V2 SDK For .NetCore`前，您需要先前往[个推开发者中心](https://dev.getui.com) 完成开发者接入的一些准备工作，创建应用。详细见[操作步骤](https://docs.getui.com/getui/start/devcenter/#1)

3. 准备工作完成后，前往[个推开发者中心](https://dev.getui.com)获取应用配置，后续将作为使用SDK的输入。详细见[操作步骤](https://docs.getui.com/getui/start/devcenter/#11)


## 安装依赖
```
Install-Package GeTuiPushApiV2.ServerSDK.Core
```

## 快速开始
本SDK支持3种调用方式，请根据自己的业务情况进行选择。

### 1.直接调用个推RestAPI V2的接口方法
这种方式需要自己对接口的请求参数及响应进行处理，对鉴权token，CID进行缓存等。
##### 使用示例
###### 1.**获取鉴权token**
```C#
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

var result = await GeTuiPushV2Api.HttpPostGeTuiApiAsync<ApiAuthInDto, ApiAuthOutDto>($"https://restapi.getui.com/v2/{AppID}/auth", indto);
string token=result.data.token;
```
###### 2.**根据cid进行单推**
```C#
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
apiInDto.token = token;
apiInDto.appId = AppID;
await HttpPostGeTuiApiAsync<ApiPushToSingleInDto, ApiPushToSingleOutDto>($"https://restapi.getui.com/v2/{AppID}/push/single/cid", apiInDto);
```


### 2.使用已封装好的统一发起及响应处理方法
这种方式是在第1种方式上进行了一层封装，统一对接口请求，响应进行了处理，但仍然需要对鉴权token，CID进行缓存等。

##### 使用示例

###### 1.**获取鉴权token**

```C#
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

GeTuiPushV2Api api = new GeTuiPushV2Api();
var result = await api.AuthAsync(indto);
string token=result.data.token;
```

###### 2.**根据cid进行单推**

```C#
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
apiInDto.token = token;
apiInDto.appId = AppID;
await api.PushToSingleAsync(apiInDto);
```

### 3.使用已封装好的个推推送服务（推荐）
这种方式下，仅需要准备推送服务所需参数，即可进行推送。无需手动选择推送接口来决定使用单推，群推，批量推，程序会根据参数自动选择推送方式。
该方式又支持普通调用和IOC调用两种方式，推荐使用IOC调用方式。

#### 3.1 普通调用
##### 使用示例
```C#
IStorage iStorage = new RedisStorage(new StackExchangeRedis(new RedisOptions()
{
    Host = "127.0.0.1",
    Port = 6379,
    DbNum = 10
}));
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
```
#### 3.2 IOC调用（推荐）

IOC调用方式需要在appsettings.json中配置所需参数

```json
{
  "RedisOptions": {
    "host": "localhost", //主机地址
    "port": 6379, //主机端口号
    "pass": "", //redis访问密码
    "dbNum": 1 //redis数据库编号
  },
  "GeTuiPushOptions": {
    "AppID": "Ny3b4Umv7882X0UheVwCU4", //应用ID
    "AppKey": "dY1BXGSHys8TPKeCqU3ilA", //应用key
    "MasterSecret": "GAZTCU0hyO69XjC9u5pSb2" //主密钥
  }
}
```

安装依赖包

```
Install-Package GeTuiPushApiV2.ServerSDK.Core.IOC
```

默认使用Redis存储鉴权token，CID等关键数据，也支持使用MemoryCache。

```c#
services.UseGeTuiPushApiV2ServerSDKCore(StorageType.MemoryCache);
```
如果需要使用其他方式存储数据，可自定义实现IStorage接口，并在初始化时通过StorageType参数进行指定。

如果实现方式未在StorageType中列出，请选择StorageType.Custom。

当你选择Redis进行存储时，本SDK默认使用StackExchange.Redis进行Redis的读写操作。你也可以选择使用其他Redis客户端库，只需要实现IRedis接口进行IOC注册即可。

```c#
/// <summary>
///  使用NewLife.Redis客户端操作Redis
/// </summary>
public class NewLifeRedis : IRedis
{
    public string Get(string key)
    {
        throw new NotImplementedException();
    }

    public void Remove(string key)
    {
        throw new NotImplementedException();
    }

    public void Set(string key, string value, TimeSpan? expireTime = null)
    {
        throw new NotImplementedException();
    }
}

public static class RedisServiceCollectionExtensions
{
    /// <summary>
    /// 注入使用NewLife.Redis操作Redis
    /// </summary>
    /// <param name="services">IOC容器对象</param>
    public static void AddNewLifeRedis(this IServiceCollection services)
    {
        services.AddSingleton<IRedis, NewLifeRedis>();
    }
}
```

在初始化时进行IOC注册，注意代码顺序，自定义的Redis客户端必须在推送服务注入完成之后再进行注入。

```c#
IServiceCollection services = new ServiceCollection();
//注入推送服务
services.UseGeTuiPushApiV2ServerSDKCore();
//注入自定义的Redis客户端
services.AddNewLifeRedis();
```

注入完成，即可通过IOC容器获取服务实例，并进行消息推送。

##### 使用示例
```C#
IServiceCollection services = new ServiceCollection();
//注入推送服务
services.UseIOC();
var provider = services.BuildServiceProvider();
//开始消息推送
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
```



## 已支持的API列表
以下是消息推送功能与推送API的对应关系

| API类别 | 功能                                                         |
| ------- | ------------------------------------------------------------ |
| 鉴权API | [鉴权](https://docs.getui.com/getui/server/rest_v2/token/#0) |
| 推送API | [cid单推](https://docs.getui.com/getui/server/rest_v2/push/#1) |
| 推送API | [tolist创建消息](https://docs.getui.com/getui/server/rest_v2/push/#5) |
| 推送API | [cid批量推](https://docs.getui.com/getui/server/rest_v2/push/#6) |
| 推送API | [群推](https://docs.getui.com/getui/server/rest_v2/push/#8)  |

> 注：更多API持续更新中，敬请期待。



## 其他链接

[个推服务端SDK RestAPI V2文档中心](https://docs.getui.com/getui/server/rest_v2/service_sdk/)
