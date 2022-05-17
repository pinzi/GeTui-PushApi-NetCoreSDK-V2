using GeTuiPushApiV2.ServerSDK.Core.Utility;
using Newtonsoft.Json;

namespace GeTuiPushApiV2.ServerSDK.Core
{
    /// <summary>
    /// 个推消息推送V2接口
    /// </summary>
    public class GeTuiPushV2Api
    {
        /// <summary>
        /// 个推开放平台接口前缀
        /// </summary>
        private const string ApiBaseUrl = "https://restapi.getui.com/v2/";

        #region 鉴权API
        #region 鉴权-获取鉴权token
        /// <summary>
        /// 鉴权-获取鉴权token
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiAuthOutDto>> AuthAsync(ApiAuthInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiAuthInDto, ApiAuthOutDto>($"{ApiBaseUrl}{inDto.appId}/auth", inDto);
            return result;
        }
        #endregion

        #region 鉴权-删除鉴权token
        /// <summary>
        /// 鉴权-删除鉴权token
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiAuthOutDto>> AuthAsync(ApiAuthDeleteInDto inDto)
        {
            var result = await HttpDeleteGeTuiApiAsync<ApiAuthDeleteInDto, ApiAuthOutDto>($"{ApiBaseUrl}{inDto.appId}/auth/{inDto.token}", inDto);
            return result;
        }
        #endregion
        #endregion

        #region 推送API
        #region 推送-【toSingle】执行cid单推
        /// <summary>
        ///  推送-【toSingle】执行cid单推
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToSingleOutDto>> PushToSingleAsync(ApiPushToSingleInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiPushToSingleInDto, ApiPushToSingleOutDto>($"{ApiBaseUrl}{inDto.appId}/push/single/cid", inDto);
            return result;
        }
        #endregion

        #region 推送-【toList】创建消息
        /// <summary>
        ///  推送-【toList】创建消息
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiCreateListMessageOutDto>> CreateListMessageAsync(ApiCreateListMessageInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiCreateListMessageInDto, ApiCreateListMessageOutDto>($"{ApiBaseUrl}{inDto.appId}/push/list/message", inDto);
            return result;
        }
        #endregion

        #region 推送-【toList】执行cid批量推
        /// <summary>
        ///  推送-【toList】执行cid批量推
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToListOutDto>> PushToListAsync(ApiPushToListInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiPushToListInDto, ApiPushToListOutDto>($"{ApiBaseUrl}{inDto.appId}/push/list/cid", inDto);
            return result;
        }
        #endregion

        #region 推送-【toApp】执行群推
        /// <summary>
        ///  推送-【toApp】执行群推
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToAppOutDto>> PushToAppAsync(ApiPushToAppInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiPushToAppInDto, ApiPushToAppOutDto>($"{ApiBaseUrl}{inDto.appId}/push/all", inDto);
            return result;
        }
        #endregion
        #endregion

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

        #region 发起Get请求
        /// <summary>
        /// 发起Get请求
        /// </summary>
        /// <typeparam name="T1">请求参数类型</typeparam>
        /// <typeparam name="T2">响应参数data类型</typeparam>
        /// <param name="ApiUrl">请求地址</param>
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

        #region 发起Delete请求
        /// <summary>
        /// 发起Delete请求
        /// </summary>
        /// <typeparam name="T1">请求参数类型</typeparam>
        /// <typeparam name="T2">响应参数data类型</typeparam>
        /// <param name="ApiUrl">请求地址</param>
        /// <param name="PostData">请求参数</param>
        /// <returns></returns>
        public static async Task<ApiResultOutDto<T2>> HttpDeleteGeTuiApiAsync<T1, T2>(string ApiUrl, T1 PostData) where T1 : ApiInDto
        {
            try
            {
                HttpHelper http = new HttpHelper();
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("token", PostData.token);
                string res = await http.HttpDeleteAsync(ApiUrl, headers);
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
        #endregion    
    }
}
