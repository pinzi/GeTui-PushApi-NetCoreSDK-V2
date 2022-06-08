namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 个推推送服务-推送
    /// </summary>
    public partial class GeTuiPushService
    {
        #region 获取消息推送结果
        /// <summary>
        /// 获取消息推送结果
        /// 单推消息或同步批量单推消息结果
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private List<PushMessageOutDto> GetPushResultData(Dictionary<string, Dictionary<string, string>> result)
        {
            List<PushMessageOutDto> list = new List<PushMessageOutDto>();
            foreach (string taskid in result.Keys)
            {
                foreach (string cid in result[taskid].Keys)
                {
                    list.Add(new PushMessageOutDto()
                    {
                        taskid = taskid,
                        cid = cid,
                        status = result[taskid][cid]
                    });
                }
            }
            return list;
        }
        #endregion    
    }
}
