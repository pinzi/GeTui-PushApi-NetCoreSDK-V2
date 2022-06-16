## Build status

![stars](https://img.shields.io/github/stars/pinzi/GeTui-PushApi-NetCoreSDK-V2.svg?style=plastic)
![release](https://img.shields.io/github/v/release/pinzi/GeTui-PushApi-NetCoreSDK-V2?include_prereleases)
![GitHub top language](https://img.shields.io/github/languages/top/pinzi/GeTui-PushApi-NetCoreSDK-V2?logo=github)
![GitHub License](https://img.shields.io/github/license/pinzi/GeTui-PushApi-NetCoreSDK-V2?logo=github)
![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core?logo=nuget)
![Nuget](https://img.shields.io/nuget/v/GeTuiPushApiV2.NetCoreSDK.Core?logo=nuget)
![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/GeTuiPushApiV2.NetCoreSDK.Core?label=dev%20nuget&logo=nuget)



## Packages

相关的nuget package：

- ![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core?logo=nuget) [GeTuiPushApiV2.NetCoreSDK.Core](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core) 核心服务
- ![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core.Api?logo=nuget) [GeTuiPushApiV2.NetCoreSDK.Core.Api](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.Api/)  GeTui消息推送V2接口封装
- ![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core.IOC?logo=nuget) [GeTuiPushApiV2.NetCoreSDK.Core.IOC](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.IOC/)  使用IOC容器
- ![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core.MemoryCache?logo=nuget) [GeTuiPushApiV2.NetCoreSDK.Core.MemoryCache](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.MemoryCache) 使用内存存储数据
- ![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core.Storage?logo=nuget) [GeTuiPushApiV2.NetCoreSDK.Core.Storage](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.Storage) 存储封装
- ![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core.Utility?logo=nuget) [GeTuiPushApiV2.NetCoreSDK.Core.Utility](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.Utility) 公共方法封装
- ![Nuget Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core.Redis?logo=nuget) [GeTuiPushApiV2.NetCoreSDK.Core.Redis](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.Redis) 使用Redis存储数据

## 简介

`个推PUSH RestAPI V2 SDK For .NetCore`的主要目标是提升开发者在**服务端**集成个推推送服务的开发效率。
开发者不需要进行复杂编程即可使用个推推送服务的各项常用功能，SDK可以自动帮您满足调用过程中所需的鉴权、组装参数、发送HTTP请求等非功能性要求。
目前SDK仅实现了单推，批量推，群推三种方式的推送服务。

#### `新增API只测试了部分功能，尚未完整测试过。`

## 推送逻辑
首先调用鉴权API获取token，然后根据业务需要选择推送API（单推，群推等等）。因为鉴权API的调用有一定的频率和次数限制，建议对token进行缓存。推送时需要获取用户标识CID，此CID由客户端获取并上传至业务服务器。所以，我们需要对业务系统中的用户uid和用户CID进行关联存储，可以选择存储在数据库中，推荐使用Redis或者内存进行缓存。
调用推送API时，我们可以选择传入业务系统中的用户uid，根据uid获取存储的cid，完成消息推送。如果选择使用推荐的IOC调用方式，则无需关注token，cid和用户uid关系的存储处理。否则，则需要自行对token，cid等数据的存储，获取进行处理。
#### `【注意】个推推送通道无法实时接收离线推送消息，如需实时接收离线推送消息，则需要接入厂家通道。`

## 环境要求

1. 支持.NET CORE 6.0，7.0。

2. 使用`个推PUSH RestAPI V2 SDK For .NetCore`前，您需要先前往[个推开发者中心](https://dev.getui.com) 完成开发者接入的一些准备工作，创建应用。详细见[操作步骤](https://docs.getui.com/getui/start/devcenter/#1)

3. 准备工作完成后，前往[个推开发者中心](https://dev.getui.com)获取应用配置，后续将作为使用SDK的输入。详细见[操作步骤](https://docs.getui.com/getui/start/devcenter/#11)


## 安装依赖
```
Install-Package GeTuiPushApiV2.NetCoreSDK.Core
```

## 快速开始
本SDK支持3种调用方式，请根据自己的业务情况进行选择。

### 1.直接调用API HTTP请求方法
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
var apiInDto = new ApiPushToSingleCIDInDto()
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
await HttpPostGeTuiApiAsync<ApiPushToSingleCIDInDto, Dictionary<string, Dictionary<string, string>>>($"https://restapi.getui.com/v2/{AppID}/push/single/cid", apiInDto);
```


### 2.使用封装好的API调用方法
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
var apiInDto = new ApiPushToSingleCIDInDto()
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
await api.PushToSingleCIDAsync(apiInDto);
```

### 3.使用封装好的个推API服务（推荐）
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
}), new GeTuiPushOptions()
{
    AppID = AppID,
    AppKey = AppKey,
    MasterSecret = MasterSecret
});
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
    await service.QuickPushMessageAsync(new PushMessageInDto()
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
Install-Package GeTuiPushApiV2.NetCoreSDK.Core.IOC
```

默认使用Redis存储鉴权token，CID等关键数据，也支持使用MemoryCache。

```c#
services.UseGeTuiPushApiV2NetCoreSDKCore(StorageType.MemoryCache);
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

        public List<string> GetList(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(List<string> keys)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, string value, TimeSpan? expireTime = null)
        {
            throw new NotImplementedException();
        }

        public void SetAdd(string key, string value)
        {
            throw new NotImplementedException();
        }

        public void SetAdd(string key, List<string> value)
        {
            throw new NotImplementedException();
        }

        public void SetRemove(string key, string value)
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
services.UseGeTuiPushApiV2NetCoreSDKCore();
//注入自定义的Redis客户端
services.AddNewLifeRedis();
```

注入完成，即可通过IOC容器获取服务实例，并进行消息推送。

##### 使用示例
```C#
IServiceCollection services = new ServiceCollection();
//注入推送服务
services.UseGeTuiPushApiV2NetCoreSDKCore();
var provider = services.BuildServiceProvider();
//开始消息推送
GeTuiPushService service = provider.GetRequiredService<GeTuiPushService>();
try
{
    await service.QuickPushMessageAsync(new PushMessageInDto()
     {
         title = "停机警告-IOC-3",
         body = $"已停机，请及时处理",
         payload = JsonConvert.SerializeObject(new
         {
             msgId = new string[] { Guid.NewGuid().ToStr() },
             text = $"停机时间：{DateTime.Now}"
         }),
         filter = TargetUserFilter.uid,
         filterCondition = new string[] { "123456789" }
     });
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```



## 已支持的API列表
以下是消息推送功能与推送API的对应关系

| API类别| 方法名 | 功能 | 测试情况 |
| ------- | ------------- |------------------------------------------------------------ |------- | 
| 鉴权API | AuthAsync |[获取鉴权](https://docs.getui.com/getui/server/rest_v2/token/#0) |已测试 | 
| 鉴权API | AuthDeleteAsync |[删除鉴权](https://docs.getui.com/getui/server/rest_v2/token/#1) |已测试 | 
| 推送API | PushToSingleCIDAsync |[[toSingle]执行cid单推](https://docs.getui.com/getui/server/rest_v2/push/#1) |已测试 | 
| 推送API | PushToSingleAliasAsync |[[toSingle]执行别名单推](https://docs.getui.com/getui/server/rest_v2/push/#2) | | 
| 推送API | PushToSingleBatchCIDAsync |[[toSingle]执行cid批量单推](https://docs.getui.com/getui/server/rest_v2/push/#3) | | 
| 推送API | PushToSingleBatchAliasAsync |[[toSingle]执行别名批量单推](https://docs.getui.com/getui/server/rest_v2/push/#4) | | 
| 推送API | CreateListMessageAsync |[[toList]创建消息](https://docs.getui.com/getui/server/rest_v2/push/#5) |已测试 | 
| 推送API | PushToListAsync |[[toList]执行cid批量推](https://docs.getui.com/getui/server/rest_v2/push/#6) |已测试| 
| 推送API | PushToListAliasAsync |[[toList]执行别名批量推](https://docs.getui.com/getui/server/rest_v2/push/#7) |------- | 
| 推送API | PushToAppAsync |[[toApp]执行群推](https://docs.getui.com/getui/server/rest_v2/push/#8) |已测试 | 
| 推送API | PushToAppTagAsync |[[toApp]根据条件筛选用户推送](https://docs.getui.com/getui/server/rest_v2/push/#9) |------- | 
| 推送API | PushToAppFastCustomTagAsync |[[toApp]使用标签快速推送](https://docs.getui.com/getui/server/rest_v2/push/#10) |------- | 
| 推送API | TaskStopAsync |[[任务]停止任务](https://docs.getui.com/getui/server/rest_v2/push/#11) |------- | 
| 推送API | TaskScheduleAsync |[[任务]查询定时任务](https://docs.getui.com/getui/server/rest_v2/push/#12) |------- | 
| 推送API | TaskDeleteAsync |[[任务]删除定时任务](https://docs.getui.com/getui/server/rest_v2/push/#13) |------- | 
| 推送API | TaskDetailAsync |[[推送]查询消息明细](https://docs.getui.com/getui/server/rest_v2/push/#14) |------- | 
| 统计API | ReportPushTaskAsync | [[推送]获取推送结果（不含自定义事件）](https://docs.getui.com/getui/server/rest_v2/report/#1)  |------- | 
| 统计API | ReportPushTaskActionAsync | [[推送]获取推送结果（含自定义事件）](https://docs.getui.com/getui/server/rest_v2/report/#2)  |------- | 
| 统计API | ReportPushTaskGroupAsync | [[推送]任务组名查报表](https://docs.getui.com/getui/server/rest_v2/report/#3)  |------- | 
|统计API  | ReportPushTaskDetailAsync |[[推送]获取推送实时结果](https://docs.getui.com/getui/server/rest_v2/report/#4)  |------- | 
| ~~统计API~~ ||~~[[推送]获取单日推送数据](https://docs.getui.com/getui/server/rest_v2/report/#5)~~ |------- | 
| ~~统计API~~ ||~~[[推送]查询推送量](https://docs.getui.com/getui/server/rest_v2/report/#6)~~  |------- | 
| 统计API | ReportUserDateAsync |[[用户]获取单日用户数据接口](https://docs.getui.com/getui/server/rest_v2/report/#7)  |------- | 
| 统计API | ReportOnlineUserAsync |[[用户]获取24个小时在线用户数](https://docs.getui.com/getui/server/rest_v2/report/#8)  |------- | 
| 用户API | UserAliasAsync |[[别名]绑定别名](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-1)  |已测试| 
| 用户API | UserAliasCidAsync |[[别名]根据cid查询别名](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-2)  |已测试| 
| 用户API | UserCidAliasAsync |[[别名]根据别名查询cid](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-3)  |------- | 
| 用户API | UserAliasBatchUnBoundAsync |[[别名]批量解绑别名](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-4)  |已测试| 
| 用户API | UserAliasUnBoundAsync |[[别名]解绑所有别名](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-5)  |已测试| 
| 用户API | UserTagBindAsync |[[标签]一个用户绑定一批标签](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-6)  |已测试| 
| 用户API | UserTagBatchBindAsync |[[标签]一批用户绑定一个标签](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-7)  |已测试| 
| 用户API | UserTagBatchUnBindAsync |[[标签]一批用户解绑一个标签](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-8)  |已测试| 
| 用户API | UserTagQueryAsync |[[标签]查询用户标签](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-9)  |已测试| 
| 用户API | UserBlackAddAsync |[[用户]添加黑名单用户](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-10)  |------- | 
| 用户API | UserBlackRemoveAsync |[[用户]移除黑名单用户](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-11)  |------- | 
| 用户API | UserStatusAsync |[[用户]查询用户状态](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-12)  |------- | 
| 用户API | UserDeviceStatusAsync |[[用户]查询设备状态](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-13)  |------- | 
| 用户API | UserDetailAsync |[[用户]查询用户信息](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-14)  |------- | 
| 用户API | UserBadgeAsync |[[用户]设置角标(仅支持IOS)](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-15)  |------- | 
| 用户API | UserCountAsync |[[用户]查询用户总量](https://docs.getui.com/getui/server/rest_v2/user/#doc-title-16)  |------- | 



## 其他链接

[个推服务端SDK RestAPI V2文档中心](https://docs.getui.com/getui/server/rest_v2/service_sdk/)
