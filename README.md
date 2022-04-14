欢迎使用[个推**PUSH** SDK For .NetCore](https://docs.getui.com/getui/server/rest_v2/introduction/)。

`个推PUSH SDK For .NetCore`的主要目标是提升开发者在**服务端**集成个推推送服务的开发效率。
开发者不需要进行复杂编程即可使用个推推送服务的各项常用功能，SDK可以自动帮您满足调用过程中所需的鉴权、组装参数、发送HTTP请求等非功能性要求。
目前SDK仅实现了单推，批量推，群推三种方式的推送服务。


## 环境要求
1. 支持.NET CORE 6.0，7.0。

2. 使用`个推PUSH SDK For .NetCore`前，您需要先前往[个推开发者中心](https://dev.getui.com) 完成开发者接入的一些准备工作，创建应用。详细见[操作步骤](https://docs.getui.com/getui/start/devcenter/#1)

3. 准备工作完成后，前往[个推开发者中心](https://dev.getui.com)获取应用配置，后续将作为使用SDK的输入。详细见[操作步骤](https://docs.getui.com/getui/start/devcenter/#11)


## 安装依赖
```SH
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

### 3.使用已封装好的个推推送服务（推荐）
这种方式下，仅需要准备推送服务所需参数，即可进行推送。无需手动选择推送接口来决定使用单推，群推，批量推，程序会根据参数自动选择推送方式。

### 普通调用





##### 使用示例：**创建API**

```C#

```

##### 使用示例：**推送API**_根据cid进行单推

```C#

```



## 已支持的API列表
以下是消息推送功能与推送API的对应关系

| API类别      |      功能       | 调用的API名称                                              |
|-----------|-----------------|-----------------------------------------------------------|
| 鉴权API | [鉴权](https://docs.getui.com/getui/server/rest_v2/token/#0)              | com.getui.push.v2.sdk.api.AuthApi.auth                                  |
| 推送API | [cid单推](https://docs.getui.com/getui/server/rest_v2/push/#1)            | com.getui.push.v2.sdk.api.PushApi.pushToSingleByCid                     |
| 推送API | [tolist创建消息](https://docs.getui.com/getui/server/rest_v2/push/#5)      | com.getui.push.v2.sdk.api.PushApi.createMsg                             |
| 推送API | [cid批量推](https://docs.getui.com/getui/server/rest_v2/push/#6)           | com.getui.push.v2.sdk.api.PushApi.pushListByCid                         |
| 推送API | [群推](https://docs.getui.com/getui/server/rest_v2/push/#8)                | com.getui.push.v2.sdk.api.PushApi.pushAll                               |

> 注：更多API持续更新中，敬请期待。


## 新API接口开发指南
1. 新建api接口类，使用类注解`com.getui.push.v2.sdk.anno.GtApi`标记为个推接口类

2. 接口，使用`com.getui.push.v2.sdk.anno.method`包下的方法注解`GtGet`/`GtPost`/`GtPut`/`GtDelete`标记请求方式，分别代表`GET`、`POST`、`PUT`、`DELETE`四种HTTP请求方式

3. 参数，使用`com.getui.push.v2.sdk.anno.param`包下的参数注解`GtPathParam`/`GtHeaderParam`/`GtQueryParam`/`GtBodyParam`标记参数类型，分别表示HTTP请求中的四种参数： 路径参数/header参数/query参数/body参数

## 其他链接
[个推服务端SDK RestAPI V2文档中心](https://docs.getui.com/getui/server/rest_v2/service_sdk/)