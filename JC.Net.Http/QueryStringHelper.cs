namespace JC.Net.Http
{
    public static class QueryStringHelper
    {
        public static string ToQueryString(object obj)
        {
            var map = JsonHelper.ObjectToDictionary(obj);

            return map.ToNameValueCollection().ToEncodedQueryString();
        }
    }
}
