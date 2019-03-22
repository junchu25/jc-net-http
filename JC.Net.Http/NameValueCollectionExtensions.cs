using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace JC.Net.Http
{
    public static class NameValueCollectionExtensions
    {
        public static string ToEncodedQueryString(this NameValueCollection collection)
        {
            return String.Join
                (
                    UriHelper.QUERY_STRING_SEPARATOR,
                    (from string name in collection select ToEncodedQueryString(collection, name)).ToArray()
                );
        }

        private static string ToEncodedQueryString(NameValueCollection collection, string name)
        {
            return String.Concat(name, UriHelper.NAME_VALUE_SEPARATOR, Encode(collection[name]));
        }

        private static string Encode(string value)
        {
            return HttpUtility.UrlEncode(value);
        }
    }
}
