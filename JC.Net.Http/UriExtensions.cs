using System;

namespace JC.Net.Http
{
    public static class UriExtensions
    {
        public static Uri Combine(this Uri baseAddress, string relativeUrl)
        {
            return UriHelper.Combine(baseAddress, relativeUrl);
        }

        public static string CombineAsString(this Uri baseAddress, string relativeUrl)
        {
            return baseAddress.Combine(relativeUrl).ToString();
        }
    }
}
