using System;
using System.Net.Http;

namespace JC.Net.Http
{
    public static class HttpClientProtocolExtensions
    {
        public static HttpResponseMessage Get(this HttpClientProtocol client, string requestUrl)
        {
            return client.Request(requestUrl, (httpClient, requestUri) => httpClient.Get(requestUri));
        }

        public static HttpResponseMessage PostJson<T>(this HttpClientProtocol client, string requestUrl, T model)
            where T : class
        {
            return client.Request(requestUrl, (httpClient, requestUri) => httpClient.PostJson(requestUri, model));
        }

        public static HttpResponseMessage PostMultipartFormData(this HttpClientProtocol client, string requestUrl, Action<MultipartFormDataContent> initContent)
        {
            return client.Request(requestUrl, (httpClient, requestUri) => httpClient.PostMultipartFormData(requestUri, initContent));
        }

        public static HttpResponseMessage PostFormUrlEncoded<T>(this HttpClientProtocol client, string requestUrl, T model)
            where T : class
        {
            var objectMap = JsonHelper.ObjectToDictionary(model);
            var createContent = new Func<FormUrlEncodedContent>(() => new FormUrlEncodedContent(objectMap));

            return client.Request(requestUrl, (httpClient, requestUri) => httpClient.PostFormUrlEncoded(requestUri, createContent));
        }

        public static HttpResponseMessage PostFormUrlEncoded(this HttpClientProtocol client, string requestUrl, Func<FormUrlEncodedContent> createContent)
        {
            return client.Request(requestUrl, (httpClient, requestUri) => httpClient.PostFormUrlEncoded(requestUri, createContent));
        }
    }
}
