namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 统计API-【推送】获取推送结果（不含自定义事件）输出参数
    /// 统计API-【推送】获取推送结果（含自定义事件）输出参数
    /// 统计API-【推送】任务组名查报表输出参数
    /// </summary>
    public class ReportPushDataOutDto
    {
        /// <summary>
        /// 总的统计数据
        /// </summary>
        public totalOutDto total { get; set; }
        /// <summary>
        /// 个推通道
        /// </summary>
        public channelOutDto gt { get; set; }
        /// <summary>
        /// APN通道
        /// </summary>
        public channelOutDto ios { get; set; }
        /// <summary>
        /// 坚果通道
        /// </summary>
        public channelOutDto st { get; set; }
        /// <summary>
        /// 华为通道
        /// </summary>
        public channelOutDto hw { get; set; }
        /// <summary>
        /// 小米通道
        /// </summary>
        public channelOutDto xm { get; set; }
        /// <summary>
        /// vivo通道
        /// </summary>
        public channelOutDto vv { get; set; }
        /// <summary>
        /// 魅族通道
        /// </summary>
        public channelOutDto mz { get; set; }
        /// <summary>
        /// OPPO通道
        /// </summary>
        public channelOutDto op { get; set; }
        /// <summary>
        /// 自定义事件统计数据
        /// $actionId为自定义事件id，对应的值表示对应的统计数据(由开发者打点统计)
        /// </summary>
        public Dictionary<string, int> actionCntMap { get; set; }
    }

    /// <summary>
    /// 总的统计数据
    /// </summary>
    public class totalOutDto
    {
        /// <summary>
        /// 消息可下发数
        /// </summary>
        public int msg_num { get; set; }
        /// <summary>
        /// 消息下发数
        /// </summary>
        public int target_num { get; set; }
        /// <summary>
        /// 消息接收数
        /// </summary>
        public int receive_num { get; set; }
        /// <summary>
        /// 消息展示数
        /// </summary>
        public int display_num { get; set; }
        /// <summary>
        /// 消息点击数
        /// </summary>
        public int click_num { get; set; }
    }

    /// <summary>
    /// key表示厂商通道，value表示该通道的统计数据。其中 gt: 个推通道; ios: APN;st: 坚果; key还可以是hw、xm、vv、mz、op。
    /// </summary>
    public class channelOutDto
    {
        /// <summary>
        /// 消息下发数
        /// </summary>
        public int target_num { get; set; }
        /// <summary>
        /// 消息接收数
        /// </summary>
        public int receive_num { get; set; }
        /// <summary>
        /// 消息展示数
        /// </summary>
        public int display_num { get; set; }
        /// <summary>
        /// 消息点击数
        /// </summary>
        public int click_num { get; set; }
    }
}
