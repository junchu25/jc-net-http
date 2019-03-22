using System;
using System.Net;
using System.Net.Http;

namespace JC.Net.Http
{
    public class HttpClientProtocol
    {
        public HttpClientProtocol()
        {
            this.Timeout = TimeSpan.FromMinutes(1);
        }

        public Uri BaseAddress { get; set; }

        public TimeSpan Timeout { get; set; }

        public ICredentials Credentials { get; set; }

        protected virtual HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = this.BaseAddress;
            httpClient.Timeout = this.Timeout;
            InitHttpClient(httpClient);

            return httpClient;
        }

        protected virtual void InitHttpClient(HttpClient httpClient)
        {
        }

        public TResult Request<TResult>(string requestUrl, Func<HttpClient, Uri, TResult> body)
        {
            using (var httpClient = CreateHttpClient())
            {
                var requestUri = new Uri(requestUrl);

                return body(httpClient, requestUri);
            }
        }
    }
}
