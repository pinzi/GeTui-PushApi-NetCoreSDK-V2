using GeTuiPushApiV2.NetCoreSDK.Core.Utility;
using Newtonsoft.Json;

namespace GeTuiPushApiV2.NetCoreSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口
    /// </summary>
    public partial class GeTuiPushV2Api
    {
        /// <summary>
        /// 个推开放平台接口前缀
        /// </summary>
        internal const string ApiBaseUrl = "https://restapi.getui.com/v2/";

        #region HTTP请求
        #region 发起Post请求
        /// <summary>
        /// 发起Post请求
        /// </summary>
        /// <typeparam name="T1">请求参数类型</typeparam>
        /// <typeparam name="T2">响应参数data类型</typeparam>
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
                try
                {
                    return JsonConvert.DeserializeObject<ApiResultOutDto<T2>>(ex.Message)!;
                }
                catch
                {
                    return new ApiResultOutDto<T2>() { code = -1, msg = ex.Message };
                }
            }
        }
        #endregion

        #region 发起Post请求（无data）
        /// <summary>
        /// 发起Post请求（无data）
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
                try
                {
                    return JsonConvert.DeserializeObject<ApiResultOutDto>(ex.Message)!;
                }
                catch
                {
                    return new ApiResultOutDto() { code = -1, msg = ex.Message };
                }
            }
        }
        #endregion

        #region 发起Get请求
        /// <summary>
        /// 发起Get请求
        /// </summary>
        /// <typeparam name="T1">请求参数类型</typeparam>
        /// <typeparam name="T2">响应参数data类型</typeparam>
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
                try
                {
                    return JsonConvert.DeserializeObject<ApiResultOutDto<T2>>(ex.Message)!;
                }
                catch
                {
                    return new ApiResultOutDto<T2>() { code = -1, msg = ex.Message };
                }
            }
        }
        #endregion

        #region 发起Get请求（无data）
        /// <summary>
        /// 发起Get请求（无data）
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
                try
                {
                    return JsonConvert.DeserializeObject<ApiResultOutDto>(ex.Message)!;
                }
                catch
                {
                    return new ApiResultOutDto() { code = -1, msg = ex.Message };
                }
            }
        }
        #endregion

        #region 发起Put请求
        /// <summary>
        /// 发起Put请求
        /// </summary>
        /// <typeparam name="T1">请求参数类型</typeparam>
        /// <typeparam name="T2">响应参数data类型</typeparam>
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
                try
                {
                    return JsonConvert.DeserializeObject<ApiResultOutDto<T2>>(ex.Message)!;
                }
                catch
                {
                    return new ApiResultOutDto<T2>() { code = -1, msg = ex.Message };
                }
            }
        }
        #endregion

        #region 发起Put请求（无data）
        /// <summary>
        /// 发起Put请求（无data）
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
                try
                {
                    return JsonConvert.DeserializeObject<ApiResultOutDto>(ex.Message)!;
                }
                catch
                {
                    return new ApiResultOutDto() { code = -1, msg = ex.Message };
                }
            }
        }
        #endregion

        #region 发起Delete请求
        /// <summary>
        /// 发起Delete请求
        /// </summary>
        /// <typeparam name="T1">请求参数类型</typeparam>
        /// <typeparam name="T2">响应参数data类型</typeparam>
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
                try
                {
                    return JsonConvert.DeserializeObject<ApiResultOutDto<T2>>(ex.Message)!;
                }
                catch
                {
                    return new ApiResultOutDto<T2>() { code = -1, msg = ex.Message };
                }
            }
        }
        #endregion

        #region 发起Delete请求（无data）
        /// <summary>
        /// 发起Delete请求（无data）
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
                try
                {
                    return JsonConvert.DeserializeObject<ApiResultOutDto>(ex.Message)!;
                }
                catch
                {
                    return new ApiResultOutDto() { code = -1, msg = ex.Message };
                }
            }
        }
        #endregion
        #endregion    
    }
}
