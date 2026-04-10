using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace GeTuiPushApiV2.NetCoreSDK.Core.Utility
{
    /// <summary>
    /// HTTP 请求工具类
    /// </summary>
    public class HttpHelper
    {
        private static readonly Lazy<HttpClient> _httpClientLazy = new Lazy<HttpClient>(() =>
        {
            var client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        });

        private static HttpClient HttpClient => _httpClientLazy.Value;

        /// <summary>
        /// 异步 get 请求
        /// </summary>
        /// <param name="url">请求地址</param>    
        /// <param name="headers">header 键值对</param>
        /// <returns></returns>
        public async Task<string> HttpGetAsync(string url, Dictionary<string, string> headers)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            AddHeaders(request.Headers, headers);
            using var resp = await HttpClient.SendAsync(request);
            return await resp.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 异步 post 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headers">header 键值对</param>
        /// <param name="formData">表单参数</param>
        /// <returns></returns>
        public async Task<string> HttpPostAsync<T>(string url, Dictionary<string, string> headers, T formData)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, url);
            AddHeaders(request.Headers, headers);
            request.Content = CreateJsonContent(formData);
            using var resp = await HttpClient.SendAsync(request);
            return await resp.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 异步 put 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headers">header 键值对</param>
        /// <param name="formData">表单参数</param>
        /// <returns></returns>
        public async Task<string> HttpPutAsync<T>(string url, Dictionary<string, string> headers, T formData)
        {
            using var request = new HttpRequestMessage(HttpMethod.Put, url);
            AddHeaders(request.Headers, headers);
            request.Content = CreateJsonContent(formData);
            using var resp = await HttpClient.SendAsync(request);
            return await resp.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 异步 Delete 请求
        /// </summary>
        /// <param name="url">请求地址</param>    
        /// <param name="headers">header 键值对</param>
        /// <returns></returns>
        public async Task<string> HttpDeleteAsync(string url, Dictionary<string, string> headers)
        {
            using var request = new HttpRequestMessage(HttpMethod.Delete, url);
            AddHeaders(request.Headers, headers);
            using var resp = await HttpClient.SendAsync(request);
            return await resp.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 异步 Delete 请求
        /// </summary>
        /// <param name="url">请求地址</param>    
        /// <param name="headers">header 键值对</param>
        /// <param name="deleteData">提交的数据</param>
        /// <returns></returns>
        public async Task<string> HttpDeleteAsync<T>(string url, Dictionary<string, string> headers, T deleteData)
        {
            using var request = new HttpRequestMessage(HttpMethod.Delete, url);
            AddHeaders(request.Headers, headers);
            request.Content = CreateJsonContent(deleteData);
            using var resp = await HttpClient.SendAsync(request);
            return await resp.Content.ReadAsStringAsync();
        }

        private static void AddHeaders(HttpRequestHeaders headers, Dictionary<string, string> customHeaders)
        {
            foreach (var kv in customHeaders)
            {
                headers.TryAddWithoutValidation(kv.Key, kv.Value);
            }
        }

        private static StringContent CreateJsonContent<T>(T data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            return content;
        }
    }
}
