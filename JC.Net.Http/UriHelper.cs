using System;
using System.Collections.Generic;

namespace JC.Net.Http
{
    public static class UriHelper
    {
        public const string QUERY_SEPARATOR = "?";
        public const string QUERY_STRING_SEPARATOR = "&";
        public const string NAME_VALUE_SEPARATOR = "=";

        public static readonly char PathSeparator = '/';

        public static string Combine(string baseAddress, string relativeUrl)
        {
            var baseUri = new Uri(baseAddress);

            return Combine(baseUri, relativeUrl).AbsoluteUri;
        }

        public static Uri Combine(Uri baseAddress, string relativeUrl)
        {
            var baseUrl = baseAddress.AbsoluteUri;
            var fillSeparator = String.Empty;

            if (baseUrl[baseUrl.Length - 1] != PathSeparator)
            {
                fillSeparator = PathSeparator.ToString();
            }

            return new Uri(String.Concat(baseUrl, fillSeparator, relativeUrl));
        }

        public static string Combine(string url, IDictionary<string, string> queryPairs)
        {
            var uri = new Uri(url);

            return Combine(uri, queryPairs).AbsoluteUri;
        }

        public static Uri Combine(Uri uri, IDictionary<string, string> queryPairs)
        {
            var queryString = queryPairs.ToEncodedQueryString();
            var separator = QUERY_STRING_SEPARATOR;

            if (String.IsNullOrWhiteSpace(uri.Query))
            {
                separator = QUERY_SEPARATOR;
            }

            return new Uri(uri.AbsoluteUri + separator + queryString);
        }
    }
}
