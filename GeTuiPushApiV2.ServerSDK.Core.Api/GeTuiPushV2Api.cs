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
        public async Task<ApiResultOutDto<ApiAuthDeleteOutDto>> AuthDeleteAsync(ApiInDto inDto)
        {
            var result = await HttpDeleteGeTuiApiAsync<ApiInDto, ApiAuthDeleteOutDto>($"{ApiBaseUrl}{inDto.appId}/auth/{inDto.token}", inDto);
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

        #region 推送-【toSingle】执行别名单推
        /// <summary>
        ///  推送-【toSingle】执行别名单推
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushToSingleAliasOutDto>> PushToSingleAliasAsync(ApiPushToSingleAliasInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiPushToSingleAliasInDto, ApiPushToSingleAliasOutDto>($"{ApiBaseUrl}{inDto.appId}/push/single/alias", inDto);
            return result;
        }
        #endregion

        #region 推送-【toList】创建消息
        /// <summary>
        ///  推送-【toList】创建消息
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiPushCreateListMessageOutDto>> CreateListMessageAsync(ApiPushCreateListMessageInDto inDto)
        {
            var result = await HttpPostGeTuiApiAsync<ApiPushCreateListMessageInDto, ApiPushCreateListMessageOutDto>($"{ApiBaseUrl}{inDto.appId}/push/list/message", inDto);
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

        #region 用户API
        #region 用户-【别名】绑定别名
        /// <summary>
        /// 用户-【别名】绑定别名
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserAliasOutDto>> UserAliasAsync(ApiUserAliasInDto inDto)
        {
            if (inDto.data_list == null || inDto.data_list.Length == 0)
            {
                return new ApiResultOutDto<ApiUserAliasOutDto>() { code = -1, msg = "data_list不能为空" };
            }
            if (inDto.data_list.Length > 1000)
            {
                return new ApiResultOutDto<ApiUserAliasOutDto>() { code = -1, msg = "data_list长度不能超过1000" };
            }
            var result = await HttpPostGeTuiApiAsync<ApiUserAliasInDto, ApiUserAliasOutDto>($"{ApiBaseUrl}{inDto.appId}/user/alias", inDto);
            return result;
        }
        #endregion

        #region 用户-【别名】根据cid查询别名
        /// <summary>
        /// 用户-【别名】根据cid查询别名
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserAliasCidOutDto>> UserAliasCidAsync(ApiUserAliasCidInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiUserAliasCidInDto, ApiUserAliasCidOutDto>($"{ApiBaseUrl}{inDto.appId}/user/alias/cid/{inDto.cid}", inDto);
            return result;
        }
        #endregion

        #region 用户-【别名】根据别名查询cid
        /// <summary>
        /// 用户-【别名】根据别名查询cid
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserCidAliasOutDto>> UserCidAliasAsync(ApiUserCidAliasInDto inDto)
        {
            var result = await HttpGetGeTuiApiAsync<ApiUserCidAliasInDto, ApiUserCidAliasOutDto>($"{ApiBaseUrl}{inDto.appId}/user/cid/alias/{inDto.alias}", inDto);
            return result;
        }
        #endregion

        #region 用户-【别名】批量解绑别名
        /// <summary>
        /// 用户-【别名】批量解绑别名
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserAliasBatchUnBoundOutDto>> UserAliasBatchUnBoundAsync(ApiUserAliasBatchUnBoundInDto inDto)
        {
            if (inDto.data_list == null || inDto.data_list.Length == 0)
            {
                return new ApiResultOutDto<ApiUserAliasBatchUnBoundOutDto>() { code = -1, msg = "data_list不能为空" };
            }
            if (inDto.data_list.Length > 1000)
            {
                return new ApiResultOutDto<ApiUserAliasBatchUnBoundOutDto>() { code = -1, msg = "data_list长度不能超过1000" };
            }
            var result = await HttpDeleteGeTuiApiAsync<ApiUserAliasBatchUnBoundInDto, ApiUserAliasBatchUnBoundOutDto>($"{ApiBaseUrl}{inDto.appId}/user/alias", inDto);
            return result;
        }
        #endregion

        #region 用户-【别名】解绑所有别名
        /// <summary>
        /// 用户-【别名】解绑所有别名
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns></returns>
        public async Task<ApiResultOutDto<ApiUserAliasUnBoundOutDto>> UserAliasUnBoundAsync(ApiUserAliasUnBoundInDto inDto)
        {
            var result = await HttpDeleteGeTuiApiAsync<ApiUserAliasUnBoundInDto, ApiUserAliasUnBoundOutDto>($"{ApiBaseUrl}{inDto.appId}/user/alias/{inDto.alias}", inDto);
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
        #endregion    
    }
}
