using System.Collections.Generic;
using System.Collections.Specialized;

namespace JC.Net.Http
{
    public static class IDictionaryExtensions
    {
        public static NameValueCollection ToNameValueCollection(this IDictionary<string, string> source)
        {
            var map = new NameValueCollection();

            foreach (var pair in source)
            {
                map.Add(pair.Key, pair.Value);
            }

            return map;
        }

        public static string ToEncodedQueryString(this IDictionary<string, string> source)
        {
            return source.ToNameValueCollection().ToEncodedQueryString();
        }

        public static IDictionary<TKey, TValue> Concat<TKey, TValue>(this IDictionary<TKey, TValue> source, IDictionary<TKey, TValue> collection)
        {
            foreach (var pair in collection)
            {
                source.Add(pair.Key, pair.Value);
            }

            return source;
        }
    }
}
