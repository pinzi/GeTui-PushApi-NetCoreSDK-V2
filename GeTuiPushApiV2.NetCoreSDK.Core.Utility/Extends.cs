namespace GeTuiPushApiV2.NetCoreSDK.Core.Utility
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class Extends
    {
        /// <summary>
        /// object转string的扩展方法
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToStr(this object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            return obj.ToString()!;
        }
    }
}
