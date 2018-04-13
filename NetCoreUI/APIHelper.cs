using NetCoreHelp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreUI
{
    public class APIHelper
    {
        private static readonly HttpClient _httpClient;
        static APIHelper()
        {
            _httpClient = new HttpClient();

            ////帮HttpClient热身
            //_httpClient.SendAsync(new HttpRequestMessage
            //{
            //    Method = new HttpMethod("HEAD"),
            //    RequestUri = new Uri("/Login/PreLoad" + "/")
            //})
            //    .Result.EnsureSuccessStatusCode();
        }
        #region Get请求
        /// <summary>
        /// 发起Get请求，返回json字符串
        /// </summary>
        /// <param name="url">路径</param>
        /// <param name="RequestParames">请求参数</param>
        /// <returns></returns>
        public async Task<string> JsonHttpGet(string url, string RequestParames = "")
        {
            //_httpClient.Timeout = TimeSpan.FromMinutes(2);
            //HttpContent httpContent = new StringContent("");
            //httpContent.Headers.ContentType.CharSet = "utf-8";
            var response = await _httpClient.GetAsync(url + RequestParames).ContinueWith(x => x.Result.Content.ReadAsStringAsync().Result);
            return response;
        }
        /// <summary>
        /// 发起Get请求，返回对象实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">路径</param>
        /// <param name="RequestParames">请求参数</param>
        /// <returns></returns>
        public async Task<T> ModelHttpGet<T>(string url, string RequestParames = "") where T : class
        {
            var response = await _httpClient.GetAsync(url + RequestParames).ContinueWith(x => x.Result.Content.ReadAsStringAsync());
            if (response.IsCompletedSuccessfully)
            {
                var res = JsonHelper.DeserializeJsonToObject<T>(response.Result, out T t) == true ? t : null; ;
                return res;
            }
            return null;

        }
        /// <summary>
        /// 发起Get请求，返回对象实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="RequestParames"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> ModelListHttpGet<T>(string url, string RequestParames = "") where T : class
        {
            var response = await _httpClient.GetAsync(url + RequestParames).ContinueWith(x => x.Result.Content.ReadAsStringAsync());
            if (response.IsCompletedSuccessfully)
            {
                var result = JsonHelper.DeserializeJsonToList<T>(response.Result);              
                return result;
            }
            return null;

        }
        [Obsolete("This class is obsolete;")]
        public async Task<T> HttpGet1<T>(HttpClient client, string url) where T : class
        {
            //Uri newurl = new Uri(url);
            //向Person发送GET请求
            //return await await client.GetAsync(url)
            //                         //获取返回Body，并根据返回的Content-Type自动匹配格式化器反序列化Body内容为对象
            //                         .ContinueWith(x => x.Result.Content.ReadAsAsync<T>(
            //        new List<MediaTypeFormatter>() {new JsonMediaTypeFormatter()/*这是Json的格式化器*/
            //                                       ,new XmlMediaTypeFormatter()/*这是XML的格式化器*/}));
            //获取当前联系人列表
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url).ContinueWith(x => x.Result.Content.ReadAsStringAsync().Result);



            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(response);
            object o = serializer.Deserialize(new JsonTextReader(sr));


            T t = null;
            var result = JsonHelper.DeserializeAnonymousType<T>(response, t);
            //var result= JsonHelper.DeserializeJsonToList<T>(response);
            return result;
            //  T t = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            //Console.WriteLine("当前联系人列表：");
            // ListContacts(contacts);
        }
        #endregion
        #region Post请求
        public async Task<IEnumerable<T>> ModelListHttpPost<T>(string url, string RequestParames = "") where T : class
        {
            HttpContent httpContent = new StringContent(RequestParames, Encoding.UTF8);
            //httpContent.Headers.ContentType.CharSet = "utf-8";
            //new FormUrlEncodedContent(parameters)
            var response= await _httpClient.PostAsync(url,httpContent).ContinueWith(x => x.Result.Content.ReadAsStringAsync());
            if (response.IsCompletedSuccessfully)
            {
                var result = JsonHelper.DeserializeJsonToList<T>(response.Result);
                return result;
            }
            return null;
        }
        #endregion


    }
}
