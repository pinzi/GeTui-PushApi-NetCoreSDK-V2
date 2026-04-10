using GeTuiPushApiV2.NetCoreSDK.Core.Utility;
using Newtonsoft.Json;

namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 个推消息推送 V2 接口
    /// </summary>
    public partial class GeTuiPushV2Api
    {
        /// <summary>
        /// 个推开放平台接口前缀
        /// </summary>
        internal const string ApiBaseUrl = "https://restapi.getui.com/v2/";

        #region HTTP 请求
        #region 发起 Post 请求
        /// <summary>
        /// 发起 Post 请求
        /// </summary>
        /// <typeparam name="T1">请求参数类型</typeparam>
        /// <typeparam name="T2">响应参数 data 类型</typeparam>
        /// <param name="ApiUrl">请求地址</param>
        /// <param name="PostData">请求参数</param>
        /// <returns></returns>
        public static async Task<ApiResultOutDto<T2>> HttpPostGeTuiApiAsync<T1, T2>(string ApiUrl, T1 PostData) where T1 : ApiInDto
        {
            try
            {
                HttpHelper http = new HttpHelper();
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("token", PostData.token);
                string res = await http.HttpPostAsync<T1>(ApiUrl, headers, PostData);
                return JsonConvert.DeserializeObject<ApiResultOutDto<T2>>(res)!;
            }
            catch (Exception ex)
            {
                // 记录异常日志（实际项目中应使用日志框架）
                Console.WriteLine($"[ERROR] HttpPostGeTuiApiAsync failed: {ex.Message}");
                return new ApiResultOutDto<T2>() { code = -1, msg = ex.Message };
            }
        }
        #endregion

        #region 发起 Post 请求（无 data）
        /// <summary>
        /// 发起 Post 请求（无 data）
        /// </summary>
        /// <typeparam name="T">请求参数类型</typeparam>
        /// <param name="ApiUrl">请求地址</param>
        /// <param name="PostData">请求参数</param>
        /// <returns></returns>
        public static async Task<ApiResultOutDto> HttpPostGeTuiApiNoDataAsync<T>(string ApiUrl, T PostData) where T : ApiInDto
        {
            try
            {
                HttpHelper http = new HttpHelper();
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("token", PostData.token);
                string res = await http.HttpPostAsync<T>(ApiUrl, headers, PostData);
                return JsonConvert.DeserializeObject<ApiResultOutDto>(res)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] HttpPostGeTuiApiNoDataAsync failed: {ex.Message}");
                return new ApiResultOutDto() { code = -1, msg = ex.Message };
            }
        }
        #endregion

        #region 发起 Get 请求
        /// <summary>
        /// 发起 Get 请求
        /// </summary>
        /// <typeparam name="T1">请求参数类型</typeparam>
        /// <typeparam name="T2">响应参数 data 类型</typeparam>
        /// <param name="ApiUrl">请求地址</param>
        /// <param name="PostData">请求参数</param>
        /// <returns></returns>
        public static async Task<ApiResultOutDto<T2>> HttpGetGeTuiApiAsync<T1, T2>(string ApiUrl, T1 PostData) where T1 : ApiInDto
        {
            try
            {
                HttpHelper http = new HttpHelper();
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("token", PostData.token);
                string res = await http.HttpGetAsync(ApiUrl, headers);
                return JsonConvert.DeserializeObject<ApiResultOutDto<T2>>(res)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] HttpGetGeTuiApiAsync failed: {ex.Message}");
                return new ApiResultOutDto<T2>() { code = -1, msg = ex.Message };
            }
        }
        #endregion

        #region 发起 Get 请求（无 data）
        /// <summary>
        /// 发起 Get 请求（无 data）
        /// </summary>
        /// <typeparam name="T">请求参数类型</typeparam>
        /// <param name="ApiUrl">请求地址</param>
        /// <param name="PostData">请求参数</param>
        /// <returns></returns>
        public static async Task<ApiResultOutDto> HttpGetGeTuiApiNoDataAsync<T>(string ApiUrl, T PostData) where T : ApiInDto
        {
            try
            {
                HttpHelper http = new HttpHelper();
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("token", PostData.token);
                string res = await http.HttpGetAsync(ApiUrl, headers);
                return JsonConvert.DeserializeObject<ApiResultOutDto>(res)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] HttpGetGeTuiApiNoDataAsync failed: {ex.Message}");
                return new ApiResultOutDto() { code = -1, msg = ex.Message };
            }
        }
        #endregion

        #region 发起 Put 请求
        /// <summary>
        /// 发起 Put 请求
        /// </summary>
        /// <typeparam name="T1">请求参数类型</typeparam>
        /// <typeparam name="T2">响应参数 data 类型</typeparam>
        /// <param name="ApiUrl">请求地址</param>
        /// <param name="PostData">请求参数</param>
        /// <returns></returns>
        public static async Task<ApiResultOutDto<T2>> HttpPutGeTuiApiAsync<T1, T2>(string ApiUrl, T1 PostData) where T1 : ApiInDto
        {
            try
            {
                HttpHelper http = new HttpHelper();
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("token", PostData.token);
                string res = await http.HttpPutAsync<T1>(ApiUrl, headers, PostData);
                return JsonConvert.DeserializeObject<ApiResultOutDto<T2>>(res)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] HttpPutGeTuiApiAsync failed: {ex.Message}");
                return new ApiResultOutDto<T2>() { code = -1, msg = ex.Message };
            }
        }
        #endregion

        #region 发起 Put 请求（无 data）
        /// <summary>
        /// 发起 Put 请求（无 data）
        /// </summary>
        /// <typeparam name="T">请求参数类型</typeparam>
        /// <param name="ApiUrl">请求地址</param>
        /// <param name="PostData">请求参数</param>
        /// <returns></returns>
        public static async Task<ApiResultOutDto> HttpPutGeTuiApiNoDataAsync<T>(string ApiUrl, T PostData) where T : ApiInDto
        {
            try
            {
                HttpHelper http = new HttpHelper();
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("token", PostData.token);
                string res = await http.HttpPutAsync<T>(ApiUrl, headers, PostData);
                return JsonConvert.DeserializeObject<ApiResultOutDto>(res)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] HttpPutGeTuiApiNoDataAsync failed: {ex.Message}");
                return new ApiResultOutDto() { code = -1, msg = ex.Message };
            }
        }
        #endregion

        #region 发起 Delete 请求
        /// <summary>
        /// 发起 Delete 请求
        /// </summary>
        /// <typeparam name="T1">请求参数类型</typeparam>
        /// <typeparam name="T2">响应参数 data 类型</typeparam>
        /// <param name="ApiUrl">请求地址</param>
        /// <param name="deleteData">请求参数</param>
        /// <returns></returns>
        public static async Task<ApiResultOutDto<T2>> HttpDeleteGeTuiApiAsync<T1, T2>(string ApiUrl, T1 deleteData) where T1 : ApiInDto
        {
            try
            {
                HttpHelper http = new HttpHelper();
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("token", deleteData.token);
                string res = await http.HttpDeleteAsync(ApiUrl, headers, deleteData);
                return JsonConvert.DeserializeObject<ApiResultOutDto<T2>>(res)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] HttpDeleteGeTuiApiAsync failed: {ex.Message}");
                return new ApiResultOutDto<T2>() { code = -1, msg = ex.Message };
            }
        }
        #endregion

        #region 发起 Delete 请求（无 data）
        /// <summary>
        /// 发起 Delete 请求（无 data）
        /// </summary>
        /// <typeparam name="T">请求参数类型</typeparam>
        /// <param name="ApiUrl">请求地址</param>
        /// <param name="deleteData">请求参数</param>
        /// <returns></returns>
        public static async Task<ApiResultOutDto> HttpDeleteGeTuiApiNoDataAsync<T>(string ApiUrl, T deleteData) where T : ApiInDto
        {
            try
            {
                HttpHelper http = new HttpHelper();
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("token", deleteData.token);
                string res = await http.HttpDeleteAsync(ApiUrl, headers, deleteData);
                return JsonConvert.DeserializeObject<ApiResultOutDto>(res)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] HttpDeleteGeTuiApiNoDataAsync failed: {ex.Message}");
                return new ApiResultOutDto() { code = -1, msg = ex.Message };
            }
        }
        #endregion
        #endregion    
    }
}
