namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 统计API-【推送】获取推送实时结果输出参数
    /// </summary>
    public class ApiReportPushTaskDetailOutDto : ReportPushDataOutDto
    {
        /// <summary>
        /// 消息折损详情
        /// </summary>
        public failed_detailOutDto failed_detail { get; set; }
    }

    /// <summary>
    /// 消息折损详情
    /// </summary>
    public class failed_detailOutDto
    {
        /// <summary>
        /// 请求-可下发阶段折损数据
        /// </summary>
        public tsrssffdOutDto ts { get; set; }
        /// <summary>
        /// 可下发-下发成功阶段折损数据
        /// </summary>
        public tsrssffdOutDto rs { get; set; }
        /// <summary>
        /// 下发成功-到达阶段折损数据
        /// </summary>
        public tsrssffdOutDto sf { get; set; }
        /// <summary>
        /// 到达-展示阶段折损数据
        /// </summary>
        public tsrssffdOutDto fd { get; set; }
    }

    /// <summary>
    /// 通道折损数据
    /// </summary>
    public class tsrssffdOutDto
    {
        /// <summary>
        /// 个推通道
        /// </summary>
        public failchannelOutDto gt { get; set; }
        /// <summary>
        /// APN通道
        /// </summary>
        public failchannelOutDto ios { get; set; }
        /// <summary>
        /// 坚果通道
        /// </summary>
        public failchannelOutDto st { get; set; }
        /// <summary>
        /// 华为通道
        /// </summary>
        public failchannelOutDto hw { get; set; }
        /// <summary>
        /// 小米通道
        /// </summary>
        public failchannelOutDto xm { get; set; }
        /// <summary>
        /// vivo通道
        /// </summary>
        public failchannelOutDto vv { get; set; }
        /// <summary>
        /// 魅族通道
        /// </summary>
        public failchannelOutDto mz { get; set; }
        /// <summary>
        /// OPPO通道
        /// </summary>
        public failchannelOutDto op { get; set; }
    }

    /// <summary>
    /// 折损大类
    /// </summary>
    public class failchannelOutDto
    {
        /// <summary>
        /// 参数无效
        /// </summary>
        public Dictionary<string, int> d2 { get; set; }
        /// <summary>
        /// app鉴权信息错误
        /// </summary>
        public Dictionary<string, int> d3 { get; set; }
        /// <summary>
        /// 敏感词过滤
        /// </summary>
        public Dictionary<string, int> d4 { get; set; }
        /// <summary>
        /// 设备/应用无效（卸载）
        /// </summary>
        public Dictionary<string, int> d5 { get; set; }
        /// <summary>
        /// 推送数量超限
        /// </summary>
        public Dictionary<string, int> d6 { get; set; }
        /// <summary>
        /// 参数超限
        /// </summary>
        public Dictionary<string, int> d7 { get; set; }
        /// <summary>
        /// 无相关权限
        /// </summary>
        public Dictionary<string, int> d8 { get; set; }
        /// <summary>
        /// 关闭通知
        /// </summary>
        public Dictionary<string, int> d10 { get; set; }
        /// <summary>
        /// 其他厂商原因
        /// </summary>
        public Dictionary<string, int> d11 { get; set; }
        /// <summary>
        /// 消息有效期内离线
        /// </summary>
        public Dictionary<string, int> d12 { get; set; }
        /// <summary>
        /// 无效用户
        /// </summary>
        public Dictionary<string, int> d13 { get; set; }
        /// <summary>
        /// 其它
        /// </summary>
        public Dictionary<string, int> d14 { get; set; }
    }
}
