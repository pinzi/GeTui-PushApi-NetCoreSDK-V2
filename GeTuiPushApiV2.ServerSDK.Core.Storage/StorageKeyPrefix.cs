using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeTuiPushApiV2.ServerSDK.Core.Storage
{
    /// <summary>
    /// 缓存key前缀
    /// </summary>
    public class StorageKeyPrefix
    {
        #region 鉴权
        /// <summary>
        /// 鉴权token
        /// </summary>
        public static string AUTH_TOKEN = "GeTui:AuthToken";
        #endregion

        #region 别名

        #endregion

        #region 标签

        #endregion

        #region 用户
        /// <summary>
        /// 个推用户唯一标识CID
        /// </summary>
        public static string AUTH_CID = "GeTui:CID:";
        #endregion

        #region 黑名单
        /// <summary>
        /// 用户黑名单
        /// </summary>
        public static string USER_BLACK = "GeTui:BlackList:";
        #endregion
    }
}
