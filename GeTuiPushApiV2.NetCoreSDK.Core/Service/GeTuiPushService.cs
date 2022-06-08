using GeTuiPushApiV2.NetCoreSDK.Storage;

namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 个推消息推送服务-推送API
    /// </summary>
    public partial class GeTuiPushService
    {
        #region 字段
        /// <summary>
        /// 存储方式
        /// </summary>
        private readonly IStorage _iStorage;
        /// <summary>
        /// 个推消息推送V2接口
        /// </summary>
        private readonly GeTuiPushV2Api _api;
        /// <summary>
        /// 个推消息推送配置信息
        /// </summary>
        private readonly GeTuiPushOptions _options;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="cacheManager">存储方式</param>
        /// <param name="option">个推消息推送配置信息</param>
        /// <param name="api">个推消息推送V2接口</param>
        public GeTuiPushService(IStorage iStorage, GeTuiPushOptions options, GeTuiPushV2Api api)
        {
            _iStorage = iStorage;
            _api = api;
            _options = options;
        }
        #endregion

        #region 公共
        #region 获取用户的CID
        /// <summary>
        /// 获取用户的CID
        /// </summary>
        /// <param name="UIDs">用户ID</param>
        /// <returns></returns>
        public async Task<string[]> GetUserCIDAsync(string[] UIDs)
        {
            List<string> CIDs = new List<string>();
            foreach (string uid in UIDs)
            {
                //从redis读取token缓存信息
                CIDs.AddRange(_iStorage.GetCID(uid));
            }
            return await Task.FromResult(CIDs.ToArray());
        }
        #endregion

        #region 获取当前时间的毫秒时间戳
        /// <summary>
        /// 获取当前时间的毫秒时间戳
        /// </summary>
        /// <returns>当前时间的毫秒时间戳</returns>
        private long GetTimeStamp()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }
        #endregion
        #endregion

        #region 快速统一推送消息
        /// <summary>
        /// 快速统一推送消息
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<List<PushMessageOutDto>> QuickPushMessageAsync(PushMessageInDto inDto)
        {
            List<PushMessageOutDto> list = new List<PushMessageOutDto>();
            switch (inDto.filter)
            {
                case TargetUserFilter.all:
                    {
                        #region 群推
                        var dto = new PushToAppInDto()
                        {
                            title = inDto.title,
                            body = inDto.body,
                            payload = inDto.payload,
                            istransmsg = inDto.istransmsg,
                            filterCondition = inDto.filterCondition
                        };
                        list.Add(new PushMessageOutDto() { taskid = await PushToAppAsync(dto) });
                        #endregion
                    }
                    break;
                case TargetUserFilter.cid:
                    {
                        #region cid
                        if (inDto.filterCondition.Length.Equals(0))
                        {
                            throw new Exception("至少需要提供一个推送目标用户的CID");
                        }
                        if (inDto.filterCondition.Length.Equals(1))
                        {
                            #region 单推
                            var dto = new PushToSingleInDto()
                            {
                                title = inDto.title,
                                body = inDto.body,
                                payload = inDto.payload,
                                istransmsg = inDto.istransmsg,
                                filterCondition = inDto.filterCondition,
                                is_async = inDto.is_async
                            };
                            list = await PushToSingleCIDAsync(dto);
                            #endregion
                        }
                        else
                        {
                            #region 批量推
                            List<string> cids = new List<string>();
                            for (int i = 0; i < inDto.filterCondition.Length; i++)
                            {
                                cids.Add(inDto.filterCondition[i]);
                                if (i % 1000 == 0)
                                {
                                    //每1000组推送一次
                                    var dto = new PushToListCIDInDto()
                                    {
                                        title = inDto.title,
                                        body = inDto.body,
                                        payload = inDto.payload,
                                        istransmsg = inDto.istransmsg,
                                        filterCondition = cids.ToArray(),
                                        is_async = inDto.is_async,
                                        taskid = await CreateListMessageAsync(inDto)//创建消息
                                    };
                                    //执行cid批量推
                                    list.AddRange(await PushToListAsync(dto));
                                    cids.Clear();
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    break;
                case TargetUserFilter.uid:
                    {
                        #region uid
                        //获取用户cid数组
                        inDto.filterCondition = await GetUserCIDAsync(inDto.filterCondition);
                        //使用cid方式推送消息
                        goto case TargetUserFilter.cid;
                        #endregion
                    }
                case TargetUserFilter.alias:
                    {
                        #region 别名
                        if (inDto.filterCondition.Length.Equals(0))
                        {
                            throw new Exception("至少需要提供一个推送目标用户的别名");
                        }
                        if (inDto.filterCondition.Length.Equals(1))
                        {
                            #region 单推
                            var dto = new PushToSingleAliasInDto()
                            {
                                title = inDto.title,
                                body = inDto.body,
                                payload = inDto.payload,
                                istransmsg = inDto.istransmsg,
                                filterCondition = inDto.filterCondition,
                                is_async = inDto.is_async
                            };
                            list = await PushToSingleAliasAsync(dto);
                            #endregion
                        }
                        else
                        {
                            #region 批量推
                            List<string> alias = new List<string>();
                            for (int i = 0; i < inDto.filterCondition.Length; i++)
                            {
                                alias.Add(inDto.filterCondition[i]);
                                if (i % 1000 == 0)
                                {
                                    //每1000组推送一次
                                    var dto = new PushToListAliasInDto()
                                    {
                                        title = inDto.title,
                                        body = inDto.body,
                                        payload = inDto.payload,
                                        istransmsg = inDto.istransmsg,
                                        filterCondition = alias.ToArray(),
                                        is_async = inDto.is_async
                                    };
                                    list.AddRange(await PushToListAliasAsync(dto));
                                    alias.Clear();
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    break;
                case TargetUserFilter.tag:
                    {
                        #region 标签
                        #region 快速推
                        if (!inDto.filterCondition.Length.Equals(0))
                        {
                            throw new Exception("只能提供一个推送目标用户的标签");
                        }
                        var dto = new PushToAppTagInDto()
                        {
                            title = inDto.title,
                            body = inDto.body,
                            payload = inDto.payload,
                            istransmsg = inDto.istransmsg,
                            filterCondition = inDto.filterCondition,
                            is_async = inDto.is_async
                        };
                        list.Add(new PushMessageOutDto() { taskid = await PushToAppTagAsync(dto) });
                        #endregion
                        #endregion
                    }
                    break;
                default:
                    goto case TargetUserFilter.cid;
            }
            return list;
        }
        #endregion
    }
}
