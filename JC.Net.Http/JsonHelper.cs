using Newtonsoft.Json;
using System.Collections.Generic;

namespace JC.Net.Http
{
    public static class JsonHelper
    {
        public static string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static IDictionary<string, string> ObjectToDictionary(object obj)
        {
            if (obj is IDictionary<string, string>)
            {
                return obj as IDictionary<string, string>;
            }

            var json = ToJson(obj);

            return ToObject<Dictionary<string, string>>(json);
        }

        public static IDictionary<string, object> ToDictionary(string json)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        }

        public static IDictionary<string, string> ToStringDictionary(string json)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
    }
}
