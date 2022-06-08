namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 推送API-【toApp】根据条件筛选用户推送输入参数
    /// </summary>
    public class ApiPushToAppTagInDto : ApiPushToBaseInDto
    {
    }

    /// <summary>
    /// 推送目标用户
    /// </summary>
    public class audienceTagInDto
    {
        /// <summary>
        /// 推送条件，详见下方说明
        /// 不同key之间是交集，同一个key之间是根据opt_type操作
        /// eg.需要发送给城市在A,B,C里面，没有设置tagtest标签，手机型号为android的用户，用条件交并补功能可以实现，city(A|B|C) && !tag(tagtest) && phonetype(android)
        /// </summary>
        public tagInDto[] tag { get; set; }
    }

    /// <summary>
    /// 推送条件，详见下方说明
    /// 不同key之间是交集，同一个key之间是根据opt_type操作
    /// eg.需要发送给城市在A,B,C里面，没有设置tagtest标签，手机型号为android的用户，用条件交并补功能可以实现，city(A|B|C) && !tag(tagtest) && phonetype(android)
    /// </summary>
    public class tagInDto
    {
        /// <summary>
        /// 必填项，查询条件(phone_type 手机类型; region 省市; custom_tag 用户标签; portrait 个推用户画像。设置用户标签(custom_tag)请见接口)
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 必填项，查询条件值列表，其中
        /// 手机型号使用如下参数android和ios；
        /// 省市使用编号，点击下载文件region_code.data；
        /// 个推用户画像使用编码，点击下载文件portrait.data。
        /// </summary>
        public string[] values { get; set; }
        /// <summary>
        /// 必填项，or(或),and(与),not(非)，values间的交并补操作
        /// </summary>
        public string opt_type { get; set; }
    }
}
