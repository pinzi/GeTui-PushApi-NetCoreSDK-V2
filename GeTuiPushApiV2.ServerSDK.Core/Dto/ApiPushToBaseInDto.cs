using Newtonsoft.Json;

namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 推送
    /// </summary>
    public class ApiPushToBaseInDto : ApiInDto
    {
        /// <summary>
        /// 必填项，请求唯一标识号，10-32位之间；如果request_id重复，会导致消息丢失
        /// </summary>
        public string request_id { get; set; }
        /// <summary>
        /// 任务组名
        /// </summary>
        public string group_name { get; set; }
        /// <summary>
        /// 必填项，推送目标用户该接口audience 对应值为all，表示推送所有用户
        /// </summary>
        public dynamic audience { get; set; }
        /// <summary>
        /// 推送条件设置
        /// </summary>
        public settingsDto settings { get; set; }
        /// <summary>
        /// 必填项，个推推送消息参数
        /// </summary>
        public push_messageDto push_message { get; set; }
        /// <summary>
        /// 厂商推送消息参数，包含ios消息参数，android厂商消息参数
        /// </summary>
        public push_channelDto push_channel { get; set; }
    }

    /// <summary>
    /// 推送条件
    /// </summary>
    public class tagDto
    {
        /// <summary>
        ///  必填项，查询条件(phone_type 手机类型; region 省市; custom_tag 用户标签; portrait，个推用户画像使用编码，点击下载文件portrait.data。设置用户标签(custom_tag)请见接口)
        /// </summary>
        public string key { get; set; }
        ///必填项，查询条件值列表，其中手机型号使用如下参数android和ios；省市使用编号，点击下载文件region_code.data；
        public string[] values { get; set; }
        /// <summary>
        /// 必填项，or(或),and(与),not(非)，values间的交并补操作
        /// </summary>
        public string opt_type { get; set; }
    }

    /// <summary>
    /// 推送条件设置
    /// </summary>
    public class settingsDto
    {
        /// <summary>
        /// 默认值1小时，	消息离线时间设置，单位毫秒，-1表示不设离线，-1 ～ 3 * 24 * 3600 * 1000(3天)之间
        /// </summary>
        public long ttl { get; set; }
        /// <summary>
        /// 默认值{"strategy":{"default":1}}，厂商通道策略
        /// default	 Number	否	1	默认所有通道的策略选择1-4
        /// 1: 表示该消息在用户在线时推送个推通道，用户离线时推送厂商通道;
        /// 2: 表示该消息只通过厂商通道策略下发，不考虑用户是否在线;
        /// 3: 表示该消息只通过个推通道下发，不考虑用户是否在线；
        /// 4: 表示该消息优先从厂商通道下发，若消息内容在厂商通道代发失败后会从个推通道下发。
        /// 其中名称可填写: ios、st、hw、xm、vv、mz、op，如有疑问请点击右侧“技术咨询”了解详情。
        /// ios Number  否 无   ios通道策略1-4，表示含义同上，要推送ios通道，需要在个推开发者中心上传ios证书，建议填写2或4，否则可能会有消息不展示的问题
        /// st  Number 否   无 通道策略1-4，表示含义同上，需要开通st厂商使用该通道推送消息
        /// ...Number 否   无 通道策略1-4，表示含义同上
        /// {
        ///"settings": {
        ///"strategy":{
        /// "default":1,
        ///"ios":4,
        ///"st":1
        /// }
        /// }
        /// }
        /// </summary>
        public string strategy { get; set; }
        /// <summary>
        /// 默认值0，	定速推送，例如100，个推控制下发速度在100条/秒左右，0表示不限速
        /// </summary>
        public int speed { get; set; }
        /// <summary>
        /// 定时推送时间，必须是7天内的时间，格式：毫秒时间戳，此功能需要开通VIP，如需开通请点击右侧“技术咨询”了解详情
        /// </summary>
        public long schedule_time { get; set; }
    }

    /// <summary>
    /// 个推通道消息内容，通知消息(notification)，仅支持安卓系统，iOS系统不展示个推通道下发的通知消息
    /// </summary>
    public class push_messageDto
    {
        /// <summary>
        /// 手机端通知展示时间段，格式为毫秒时间戳段，两个时间的时间差必须大于10分钟，例如："1590547347000-1590633747000"
        /// </summary>
        public string duration { get; set; }
        /// <summary>
        /// 通知消息内容，仅支持安卓系统，iOS系统不展示个推通知消息，与transmission、revoke三选一，都填写时报错
        /// </summary>
        public notificationDto notification { get; set; }
        /// <summary>
        /// 纯透传消息内容，安卓和iOS均支持，与notification、revoke 三选一，都填写时报错，长度 ≤ 3072
        /// </summary>
        public string transmission { get; set; }
        /// <summary>
        /// 撤回消息时使用(仅撤回个推通道消息)，与notification、transmission三选一，都填写时报错(消息撤回请勿填写策略参数)
        /// </summary>
        public revokeDto revoke { get; set; }
    }

    /// <summary>
    /// 通知消息内容，仅支持安卓系统，iOS系统不展示个推通知消息，与transmission、revoke三选一，都填写时报错
    /// </summary>
    public class notificationDto
    {
        /// <summary>
        /// 必填项，通知消息标题，长度 ≤ 50
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 必填项，通知消息内容，长度 ≤ 256
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// 长文本消息内容，通知消息+长文本样式，与big_image二选一，两个都填写时报错，长度 ≤ 512
        /// </summary>
        public string big_text { get; set; }
        /// <summary>
        /// 大图的URL地址，通知消息+大图样式， 与big_text二选一，两个都填写时报错，长度 ≤ 1024
        /// </summary>
        public string big_image { get; set; }
        /// <summary>
        /// 通知的图标名称，包含后缀名（需要在客户端开发时嵌入），如“push.png”，长度 ≤ 64
        /// </summary>
        public string logo { get; set; }
        /// <summary>
        /// 通知图标URL地址，长度 ≤ 256
        /// </summary>
        public string logo_url { get; set; }
        /// <summary>
        /// 默认值Default 通知渠道id，长度 ≤ 64
        /// </summary>
        public string channel_id { get; set; }
        /// <summary>
        /// 默认值Default 通知渠道名称，长度 ≤ 64
        /// </summary>
        public string channel_name { get; set; }
        /// <summary>
        /// 设置通知渠道重要性（可以控制响铃，震动，浮动，闪灯等等）
        /// android8.0以下
        /// 0，1，2:无声音，无振动，不浮动
        /// 3:有声音，无振动，不浮动
        /// 4:有声音，有振动，有浮动
        /// android8.0以上
        /// 0：无声音，无振动，不显示；
        /// 1：无声音，无振动，锁屏不显示，通知栏中被折叠显示，导航栏无logo;
        /// 2：无声音，无振动，锁屏和通知栏中都显示，通知不唤醒屏幕;
        /// 3：有声音，无振动，锁屏和通知栏中都显示，通知唤醒屏幕;
        /// 4：有声音，有振动，亮屏下通知悬浮展示，锁屏通知以默认形式展示且唤醒屏幕;
        /// 默认值3
        /// </summary>
        public int channel_level { get; set; }
        /// <summary>
        /// 必填项，点击通知后续动作，
        /// 目前支持以下后续动作，
        /// intent：打开应用内特定页面，
        /// url：打开网页地址，
        /// payload：自定义消息内容启动应用，
        /// payload_custom：自定义消息内容不启动应用，
        /// startapp：打开应用首页，
        /// none：纯通知，无后续动作
        /// </summary>
        public string click_type { get; set; }
        /// <summary>
        /// click_type为intent时必填
        /// 点击通知打开应用特定页面，长度 ≤ 4096;
        /// 示例：intent://com.getui.push/detail?#Intent;scheme=gtpushscheme;launchFlags=0x4000000;package=com.getui.demo;component=com.getui.demo/com.getui.demo.DemoActivity;S.payload=payloadStr;end 
        /// </summary>
        public string intent { get; set; }
        /// <summary>
        /// click_type为url时必填，点击通知打开链接，长度 ≤ 1024
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// click_type为payload/payload_custom时必填，点击通知时，附加自定义透传消息，长度 ≤ 3072
        /// </summary>
        public string payload { get; set; }
        /// <summary>
        /// 覆盖任务时会使用到该字段，两条消息的notify_id相同，新的消息会覆盖老的消息，范围：0-2147483647
        /// </summary>
        public int notify_id { get; set; }
        /// <summary>
        /// 自定义铃声，请填写文件名，不包含后缀名(需要在客户端开发时嵌入)，个推通道下发有效        
        /// 客户端SDK最低要求 2.14.0.0
        /// </summary>
        public string ring_name { get; set; }
        /// <summary>
        /// 角标, 必须大于0, 个推通道下发有效
        /// 此属性目前仅针对华为 EMUI 4.1 及以上设备有效
        /// 角标数字数据会和之前角标数字进行叠加；
        /// 举例：角标数字配置1，应用之前角标数为2，发送此角标消息后，应用角标数显示为3。
        /// 客户端SDK最低要求 2.14.0.0
        /// </summary>
        public int badge_add_num { get; set; }
        /// <summary>
        /// 消息折叠分组，设置成相同thread_id的消息会被折叠（仅支持个推渠道下发的安卓消息）。目前与iOS的thread_id设置无关，安卓和iOS需要分别设置。
        /// </summary>
        public string thread_id { get; set; }
    }

    /// <summary>
    /// 撤回消息时使用(仅撤回个推通道消息)，与notification、transmission三选一，都填写时报错(消息撤回请勿填写策略参数)
    /// </summary>
    public class revokeDto
    {
        /// <summary>
        /// 必填项，需要撤回的taskId
        /// </summary>
        public string old_task_id { get; set; }
        /// <summary>
        /// 在没有找到对应的taskId，是否把对应appId下所有的通知都撤回
        /// </summary>
        public bool force { get; set; }
    }

    /// <summary>
    /// 厂商通道消息内容
    /// </summary>
    public class push_channelDto
    {
        /// <summary>
        /// ios通道推送消息内容
        /// </summary>
        public iosDto ios { get; set; }
        /// <summary>
        /// android通道推送消息内容
        /// </summary>
        public androidDto android { get; set; }
    }

    /// <summary>
    /// ios通道推送消息内容
    /// </summary>
    public class iosDto
    {
        /// <summary>
        /// 默认值notify，voip：voip语音推送，notify：apns通知消息
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 推送通知消息内容
        /// </summary>
        public apsDto aps { get; set; }
        /// <summary>
        ///  用于计算icon上显示的数字，还可以实现显示数字的自动增减，如“+1”、 “-1”、 “1” 等，计算结果将覆盖badge
        /// </summary>
        public string auto_badge { get; set; }
        /// <summary>
        /// 增加自定义的数据
        /// </summary>
        public string payload { get; set; }
        /// <summary>
        /// 多媒体设置，最多可设置3个子项
        /// </summary>
        public multimediaDto[] multimedia { get; set; }
        /// <summary>
        /// 使用相同的apns-collapse-id可以覆盖之前的消息
        /// </summary>
        [JsonProperty("apns-collapse-id")]
        public string apnscollapseid { get; set; }
    }

    /// <summary>
    /// android通道推送消息内容
    /// </summary>
    public class androidDto
    {
        /// <summary>
        /// android厂商通道推送消息内容
        /// </summary>
        public upsDto ups { get; set; }
    }

    /// <summary>
    /// android厂商通道推送消息内容
    /// </summary>
    public class upsDto
    {
        /// <summary>
        /// 通知消息内容，与transmission、revoke三选一，都填写时报错。若希望客户端离线时，直接在系统通知栏中展示通知栏消息，推荐使用此参数。
        /// </summary>
        public notificationDto notification { get; set; }
        /// <summary>
        /// 透传消息内容，与notification、revoke 三选一，都填写时报错，长度 ≤ 3072
        /// </summary>
        public string transmission { get; set; }
        /// <summary>
        /// 撤回消息时使用(仅撤回厂商通道消息，支持的厂商有小米、VIVO)，与notification、transmission三选一，都填写时报错(消息撤回请勿填写策略参数)
        /// </summary>
        public upsrevokeDto revoke { get; set; }
        /// <summary>
        /// 第三方厂商扩展内容
        /// </summary>
        public optionsDto options { get; set; }
    }

    /// <summary>
    /// 撤回消息时使用
    /// </summary>
    public class upsrevokeDto
    {
        /// <summary>
        /// 需要撤回的taskId
        /// </summary>
        public string old_task_id { get; set; }
    }

    /// <summary>
    /// 第三方厂商扩展内容
    /// </summary>
    public class optionsDto
    {
        /// <summary>
        /// 扩展内容对应厂商通道设置如：ALL,HW,XM,VV,OP,MZ,UPS(UPS的参数会影响UPS下面的所有机型，比如ST, SN等等)
        /// </summary>
        public string constraint { get; set; }
        /// <summary>
        /// 厂商内容扩展字段
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 具体数据类型 value的设置根据key值决定
        /// </summary>
        public dynamic value { get; set; }
    }

    /// <summary>
    /// 推送通知消息内容
    /// </summary>
    public class apsDto
    {
        /// <summary>
        /// 通知消息
        /// </summary>
        public alertDto alert { get; set; }
        /// <summary>
        ///   否	0	0表示普通通知消息(默认为0)；
        ///   1表示静默推送(无通知栏消息)，静默推送时不需要填写其他参数。
        ///   苹果建议1小时最多推送3条静默消息
        /// </summary>
        [JsonProperty("content-available")]
        public int contentavailable { get; set; }
        /// <summary>
        /// 通知铃声文件名，如果铃声文件未找到，响铃为系统默认铃声。
        /// 无声设置为“com.gexin.ios.silence”或不填
        /// </summary>
        public string sound { get; set; }
        /// <summary>
        /// 在客户端通知栏触发特定的action和button显示
        /// </summary>
        public string category { get; set; }
        /// <summary>
        /// ios的远程通知通过该属性对通知进行分组，仅支持iOS 12.0以上版本
        /// </summary>
        [JsonProperty("thread-id")]
        public string threadid { get; set; }
    }

    /// <summary>
    /// 通知消息
    /// </summary>
    public class alertDto
    {
        /// <summary>
        /// 通知消息标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 通知消息内容
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// （用于多语言支持）指定执行按钮所使用的Localizable.strings
        /// </summary>
        [JsonProperty("action-loc-key")]
        public string actionlockey { get; set; }
        //（用于多语言支持）指定Localizable.strings文件中相应的key
        [JsonProperty("loc-key")]
        public string lockey { get; set; }
        //如果loc-key中使用了占位符，则在loc-args中指定各参数
        [JsonProperty("loc-args")]
        public string[] locargs { get; set; }
        //指定启动界面图片名
        [JsonProperty("launch-image")]
        public string launchimage { get; set; }
        //(用于多语言支持）对于标题指定执行按钮所使用的Localizable.strings, 仅支持iOS8.2以上版本
        [JsonProperty("title-loc-key")]
        public string titlelockey { get; set; }
        //对于标题, 如果loc-key中使用的占位符，则在loc-args中指定各参数, 仅支持iOS8.2以上版本
        [JsonProperty("title-loc-args")]
        public string[] titlelocargs { get; set; }
        /// <summary>
        /// 通知子标题, 仅支持iOS8.2以上版本
        /// </summary>
        public string subtitle { get; set; }
        /// <summary>
        /// 当前本地化文件中的子标题字符串的关键字, 仅支持iOS8.2以上版本
        /// </summary>
        [JsonProperty("subtitle-loc-key")]
        public string subtitlelockey { get; set; }
        /// <summary>
        /// 当前本地化子标题内容中需要置换的变量参数, 仅支持iOS8.2以上版本
        /// </summary>
        [JsonProperty("subtitle-loc-args")]
        public string[] subtitlelocargs { get; set; }
    }

    /// <summary>
    /// 多媒体设置
    /// </summary>
    public class multimediaDto
    {
        /// <summary>
        /// 多媒体资源地址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 资源类型（1.图片，2.音频，3.视频）
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 是否只在wifi环境下加载，如果设置成true,但未使用wifi时，会展示成普通通知
        /// </summary>
        public bool only_wifi { get; set; }
    }
}
