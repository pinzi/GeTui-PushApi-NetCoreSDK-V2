# GeTui Push API V2 SDK for .NET Core

[![Build Status](https://img.shields.io/github/stars/pinzi/GeTui-PushApi-NetCoreSDK-V2.svg?style=flat-square)](https://github.com/pinzi/GeTui-PushApi-NetCoreSDK-V2)
[![Release](https://img.shields.io/github/v/release/pinzi/GeTui-PushApi-NetCoreSDK-V2?include_prereleases&style=flat-square)](https://github.com/pinzi/GeTui-PushApi-NetCoreSDK-V2/releases)
[![License](https://img.shields.io/github/license/pinzi/GeTui-PushApi-NetCoreSDK-V2?style=flat-square)](LICENSE)
[![NuGet Downloads](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core?style=flat-square)](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core)
[![NuGet Version](https://img.shields.io/nuget/v/GeTuiPushApiV2.NetCoreSDK.Core?style=flat-square)](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core)
[![Pre-release](https://img.shields.io/nuget/vpre/GeTuiPushApiV2.NetCoreSDK.Core?label=dev&style=flat-square)](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core/absoluteLatest)

---

## 📦 NuGet Packages

| Package | Description | Downloads |
|:--------|:------------|:---------:|
| [GeTuiPushApiV2.NetCoreSDK.Core](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core) | 核心推送服务库 | [![NuGet](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core?style=flat-square)](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core) |
| [GeTuiPushApiV2.NetCoreSDK.Core.Api](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.Api) | 个推 API 接口封装库 | [![NuGet](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core.Api?style=flat-square)](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.Api) |
| [GeTuiPushApiV2.NetCoreSDK.Core.IOC](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.IOC) | IOC 容器集成扩展库 | [![NuGet](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core.IOC?style=flat-square)](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.IOC) |
| [GeTuiPushApiV2.NetCoreSDK.Core.Storage](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.Storage) | 存储接口定义库 | [![NuGet](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core.Storage?style=flat-square)](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.Storage) |
| [GeTuiPushApiV2.NetCoreSDK.Core.MemoryCache](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.MemoryCache) | 内存缓存存储实现 | [![NuGet](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core.MemoryCache?style=flat-square)](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.MemoryCache) |
| [GeTuiPushApiV2.NetCoreSDK.Core.Redis](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.Redis) | Redis 存储实现 | [![NuGet](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core.Redis?style=flat-square)](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.Redis) |
| [GeTuiPushApiV2.NetCoreSDK.Core.Utility](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.Utility) | 工具类库（HTTP、SHA256 等） | [![NuGet](https://img.shields.io/nuget/dt/GeTuiPushApiV2.NetCoreSDK.Core.Utility?style=flat-square)](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core.Utility) |

---

## 📖 简介

**个推 PUSH RestAPI V2 SDK For .NET Core** 旨在帮助开发者高效集成个推推送服务到服务端应用中。

本 SDK 封装了个推推送服务的核心功能，自动处理鉴权、参数组装、HTTP 请求等底层细节，让开发者能够专注于业务逻辑的实现。

### ✨ 核心特性

- 🔐 **自动鉴权**：Token 自动获取与缓存刷新
- 📦 **灵活存储**：支持 Redis、MemoryCache 等多种 Token/CID 存储方式
- 🚀 **多种推送**：支持单推、批量推、群推等多种推送方式
- 🔧 **IOC 集成**：完美支持 .NET Core 依赖注入
- 📊 **丰富 API**：涵盖推送、用户管理、报表查询等完整 API

> **当前支持功能**：单推、批量推、群推三种推送方式。

⚠️ **注意**：新增 API 已实现但尚未完成全部测试，生产环境使用请谨慎验证。

---

## 🚀 快速开始

### 1. 安装 NuGet 包

#### 方式一：使用 .NET CLI
```bash
dotnet add package GeTuiPushApiV2.NetCoreSDK.Core
dotnet add package GeTuiPushApiV2.NetCoreSDK.Core.IOC
dotnet add package GeTuiPushApiV2.NetCoreSDK.Core.Redis  # 或使用 MemoryCache
```

#### 方式二：使用 Package Manager Console
```powershell
Install-Package GeTuiPushApiV2.NetCoreSDK.Core
Install-Package GeTuiPushApiV2.NetCoreSDK.Core.IOC
Install-Package GeTuiPushApiV2.NetCoreSDK.Core.Redis
```

### 2. 配置应用设置

在 `appsettings.json` 中添加个推配置和 Redis 配置：

```json
{
  "RedisOptions": {
    "host": "localhost",
    "port": 6379,
    "pass": "",
    "dbNum": 1
  },
  "GeTuiPushOptions": {
    "AppID": "YOUR_APP_ID_HERE",
    "AppKey": "YOUR_APP_KEY_HERE",
    "MasterSecret": "YOUR_MASTER_SECRET_HERE"
  }
}
```

### 3. 注册服务（IOC 方式）

在 `Program.cs` 或 `Startup.cs` 中注册服务：

```csharp
using GeTuiPushApiV2.NetCoreSDK.Core.IOC;

// .NET 6+ 最小托管模型
builder.Services.UseGeTuiPushApiV2NetCoreSDKCore(StorageType.Redis);
// 或使用内存缓存
// builder.Services.UseGeTuiPushApiV2NetCoreSDKCore(StorageType.MemoryCache);
```

### 4. 使用推送服务

#### 方式一：IOC 依赖注入（推荐）

```csharp
public class PushService
{
    private readonly GeTuiPushService _pushService;
    
    public PushService(GeTuiPushService pushService)
    {
        _pushService = pushService;
    }
    
    public async Task SendNotificationAsync()
    {
        await _pushService.QuickPushMessageAsync(new PushMessageInDto
        {
            title = "通知标题",
            body = "通知内容",
            payload = "{\"msgId\":\"123\",\"text\":\"自定义数据\"}",
            filter = TargetUserFilter.uid,
            filterCondition = new[] { "user_id_123" }
        });
    }
}
```

#### 方式二：普通方式调用

```csharp
using GeTuiPushApiV2.NetCoreSDK.Core;
using GeTuiPushApiV2.NetCoreSDK.Core.Redis;
using GeTuiPushApiV2.NetCoreSDK.Storage;

// 初始化存储
IStorage storage = new RedisStorage(
    new StackExchangeRedis(new RedisOptions 
    { 
        Host = "localhost", 
        Port = 6379, 
        DbNum = 1 
    }),
    new GeTuiPushOptions
    {
        AppID = "your_app_id",
        AppKey = "your_app_key",
        MasterSecret = "your_master_secret"
    }
);

// 创建 API 实例和服务
var api = new GeTuiPushV2Api();
var options = new GeTuiPushOptions 
{ 
    AppID = "your_app_id",
    AppKey = "your_app_key",
    MasterSecret = "your_master_secret"
};
var service = new GeTuiPushService(storage, options, api);

// 发送推送
await service.QuickPushMessageAsync(new PushMessageInDto
{
    title = "通知标题",
    body = "通知内容",
    filter = TargetUserFilter.cid,
    filterCondition = new[] { "cid_value" }
});
```

---

## 📋 三种调用方式对比

| 方式 | 描述 | Token 缓存 | CID 管理 | 推荐场景 |
|:----:|:-----|:----------:|:--------:|:---------|
| **方式一** | 直接调用 HTTP 请求方法 | ❌ 需自行实现 | ❌ 需自行实现 | 学习 SDK 底层原理 |
| **方式二** | 使用封装的 API 方法 | ❌ 需自行实现 | ❌ 需自行实现 | 需要精细控制请求过程 |
| **方式三** | 使用 GeTuiPushService 服务 | ✅ 自动处理 | ✅ 自动处理 | ⭐ **生产环境推荐** |

---

## 🔧 存储方式选择

SDK 支持多种 Token 和 CID 存储方式，通过 `StorageType` 枚举指定：

```csharp
services.UseGeTuiPushApiV2NetCoreSDKCore(StorageType.Redis);      // Redis（推荐）
services.UseGeTuiPushApiV2NetCoreSDKCore(StorageType.MemoryCache); // 内存缓存
```

| 存储类型 | 适用场景 | 优点 | 注意事项 |
|:--------|:---------|:-----|:---------|
| **Redis** | 生产环境、分布式部署 | 持久化、多实例共享 | 需要 Redis 服务 |
| **MemoryCache** | 开发测试、单实例 | 无需额外依赖 | 重启后数据丢失、多实例不共享 |
| **Custom** | 特殊需求 | 可自定义数据库存储 | 需实现 `IStorage` 接口 |

---

## 📚 API 列表

### 认证 API (Auth)

| API 方法 | 描述 | 状态 |
|:---------|:-----|:----:|
| `AuthAsync(ApiAuthInDto)` | 获取推送权限 Token | ✅ |

### 推送 API (Push)

#### 单推 (toSingle)

| API 方法 | 描述 | 状态 |
|:---------|:-----|:----:|
| `PushToSingleCIDAsync(ApiPushToSingleCIDInDto)` | 按 CID 单推 | ✅ |
| `PushToSingleAliasAsync(ApiPushToSingleAliasInDto)` | 按别名单推 | ✅ |
| `PushToSingleBatchCIDAsync(ApiPushToSingleBatchCIDInDto)` | CID 批量单推 | ✅ |
| `PushToSingleBatchAliasAsync(ApiPushToSingleBatchAliasInDto)` | 别名批量单推 | ✅ |

#### 群推 (toList)

| API 方法 | 描述 | 状态 |
|:---------|:-----|:----:|
| `PushToListCIDAsync(ApiPushToListCIDInDto)` | 按 CID 群推 | 🔄 |
| `PushToListAliasAsync(ApiPushToListAliasInDto)` | 按别名群推 | 🔄 |
| `PushToListTagAsync(ApiPushToListTagInDto)` | 按标签群推 | 🔄 |

#### 全推 (toApp)

| API 方法 | 描述 | 状态 |
|:---------|:-----|:----:|
| `PushToAppCIDAsync(ApiPushToAppCIDInDto)` | 全量推送 | 🔄 |
| `PushToAppTagAsync(ApiPushToAppTagInDto)` | 按标签全推 | 🔄 |
| `PushToAppFastCustomTagAsync(ApiPushToAppFastCustomTagInDto)` | 快速自定义标签全推 | 🔄 |

#### 任务管理 (task)

| API 方法 | 描述 | 状态 |
|:---------|:-----|:----:|
| `TaskDetailAsync(TaskDetailInDto)` | 查询任务详情 | 🔄 |
| `TaskStopAsync(TaskStopInDto)` | 停止推送任务 | 🔄 |
| `TaskDeleteAsync(TaskDeleteInDto)` | 删除推送任务 | 🔄 |

### 用户 API (User)

| API 模块 | 功能 | 状态 |
|:--------|:-----|:----:|
| **Alias** | 别名绑定/解绑/查询 | 🔄 |
| **Tag** | 标签绑定/解绑/查询 | 🔄 |
| **User** | 用户关系管理 | 🔄 |

### 报表 API (Report)

| API 模块 | 功能 | 状态 |
|:--------|:-----|:----:|
| **Push** | 推送数据查询 | 🔄 |
| **User** | 用户数据查询 | 🔄 |

> **图例说明**：✅ 已测试 | 🔄 已实现待完整测试 | ⏳ 计划中

更多 API 详细文档请参考 [个推官方文档](https://docs.getui.com/)

---

## 🛠️ 开发环境

- **.NET**: .NET 6.0 / .NET 7.0+
- **语言**: C# 10.0+
- **依赖**: 
  - Newtonsoft.Json
  - Microsoft.Extensions.DependencyInjection
  - StackExchange.Redis (可选)

---

## 📝 示例项目

本仓库包含完整的示例项目：

- `GeTuiPushApiV2.NetCoreSDK.Core.Sample.Net6` - .NET 6 示例
- `GeTuiPushApiV2.NetCoreSDK.Core.Sample.Net7` - .NET 7 示例
- `GeTuiPushApiV2.NetCoreSDK.Core.Test` - 功能测试项目
- `GeTuiPushApiV2.NetCoreSDK.Core.UnitTest` - 单元测试项目

运行示例：

```bash
cd GeTuiPushApiV2.NetCoreSDK.Core.Sample.Net6
# 修改 appsettings.json 中的配置
dotnet run
```

---

## 🤝 贡献

欢迎提交 Issue 和 Pull Request！

1. Fork 本仓库
2. 创建特性分支 (`git checkout -b feature/AmazingFeature`)
3. 提交更改 (`git commit -m 'Add some AmazingFeature'`)
4. 推送到分支 (`git push origin feature/AmazingFeature`)
5. 开启 Pull Request

---

## 📄 许可证

本项目采用 MIT 许可证 - 查看 [LICENSE](LICENSE) 文件了解详情。

---

## 🔗 相关链接

- [个推官方网站](https://www.getui.com/)
- [个推开发者文档](https://docs.getui.com/)
- [NuGet 包主页](https://www.nuget.org/packages/GeTuiPushApiV2.NetCoreSDK.Core)
- [GitHub 仓库](https://github.com/pinzi/GeTui-PushApi-NetCoreSDK-V2)

---

<div align="center">

**如果这个项目对你有帮助，请给一个 ⭐ Star 支持一下！**

Made with ❤️ by the .NET Community

</div>
