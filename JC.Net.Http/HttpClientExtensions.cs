using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JC.Net.Http
{
    public static class HttpClientExtensions
    {
        public static HttpResponseMessage Get(this HttpClient httpClient, Uri requestUri)
        {
            return httpClient.GetAsync(requestUri).Result;
        }

        public static HttpResponseMessage PostJson<T>(this HttpClient httpClient, Uri requestUri, T model)
            where T : class
        {
            return PostJsonAsync<T>(httpClient, requestUri, model).Result;
        }

        public static Task<HttpResponseMessage> PostJsonAsync<T>(this HttpClient httpClient, Uri requestUri, T model)
            where T : class
        {
            var content = HttpHelper.CreateJsonContent(model);

            return httpClient.PostAsync(requestUri, content);
        }

        public static HttpResponseMessage PostMultipartFormData(this HttpClient httpClient, Uri requestUri, Action<MultipartFormDataContent> initContent)
        {
            return PostMultipartFormDataAsync(httpClient, requestUri, initContent).Result;
        }

        public static Task<HttpResponseMessage> PostMultipartFormDataAsync(this HttpClient httpClient, Uri requestUri, Action<MultipartFormDataContent> initContent)
        {
            var content = new MultipartFormDataContent();
            initContent(content);

            return httpClient.PostAsync(requestUri, content);
        }

        public static HttpResponseMessage PostFormUrlEncoded(this HttpClient httpClient, Uri requestUri, Func<FormUrlEncodedContent> createContent)
        {
            return PostFormUrlEncodedAsync(httpClient, requestUri, createContent).Result;
        }

        public static Task<HttpResponseMessage> PostFormUrlEncodedAsync(this HttpClient httpClient, Uri requestUri, Func<FormUrlEncodedContent> createContent)
        {
            var content = createContent();

            return httpClient.PostAsync(requestUri, content);
        }
    }
}
