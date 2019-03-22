using System;
using System.IO;
using System.Net.Http;

namespace JC.Net.Http
{
    public static class HttpResponseMessageExtensions
    {
        public static Stream GetContentAsStream(this HttpResponseMessage response)
        {
            return response.Content.ReadAsStreamAsync().Result;
        }

        public static T GetContentAsObject<T>(this HttpResponseMessage response)
        {
            var responseText = response.Content.ReadAsStringAsync().Result;

            return String.IsNullOrEmpty(responseText) ? default(T) : JsonHelper.ToObject<T>(responseText);
        }

        public static string GetContentAsString(this HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
