using GeTuiPushApiV2.ServerSDK.Storage;

namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推消息推送服务
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

        #region 获取时间戳
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns>时间戳</returns>
        private long GetTimeStamp()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }
        #endregion
        #endregion

        #region 推送消息-根据用户标识cid
        /// <summary>
        /// 推送消息-根据用户标识cid
        /// </summary>
        /// <param name="inDto">消息推送-根据用户标识cid输入参数</param>
        /// <returns></returns>
        public async Task PushMessageAsync(PushMessageInDto inDto)
        {
            inDto.cid = await GetUserCIDAsync(inDto.uid);
            string[] cids = inDto.cid;
            if (inDto.isall)
            {
                #region 群推
                var dto = new PushToAppInDto()
                {
                    title = inDto.title,
                    body = inDto.body,
                    payload = inDto.payload,
                    istransmsg = inDto.istransmsg,
                    isall = inDto.isall,
                    cid = inDto.cid
                };
                var result = await PushToAppAsync(dto);
                if (!result.code.Equals(0))
                {
                    throw new Exception(result.msg);
                }
                #endregion
            }
            else if (cids.Length.Equals(1))
            {
                #region 单推
                var dto = new PushToSingleInDto()
                {
                    title = inDto.title,
                    body = inDto.body,
                    payload = inDto.payload,
                    istransmsg = inDto.istransmsg,
                    isall = inDto.isall,
                    cid = inDto.cid
                };
                var result = await PushToSingleAsync(dto);
                if (!result.code.Equals(0))
                {
                    throw new Exception(result.msg);
                }
                #endregion
            }
            else if (cids.Length > 1)
            {
                #region 批量推
                var dto = new PushToListInDto()
                {
                    title = inDto.title,
                    body = inDto.body,
                    payload = inDto.payload,
                    istransmsg = inDto.istransmsg,
                    isall = inDto.isall,
                    cid = inDto.cid,
                    is_async = false,
                    taskid = await CreateListMessageAsync(inDto)//创建消息
                };
                //执行cid批量推
                var result = await PushToListAsync(dto);
                if (!result.code.Equals(0))
                {
                    throw new Exception(result.msg);
                }
                #endregion
            }
            else
            {
                throw new Exception("未指定接收人设备cid");
            }
        }
        #endregion
    }
}
