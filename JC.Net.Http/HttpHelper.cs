using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace JC.Net.Http
{
    public static class HttpHelper
    {
        private static readonly char DomainSeparator = '\\';

        public static string CredentialsToBase64String(ICredentials credentials)
        {
            var credentialsAsString = CredentialsToString(credentials);

            return credentialsAsString != null ? Convert.ToBase64String(Encoding.UTF8.GetBytes(credentialsAsString)) : null;
        }

        public static string CredentialsToString(ICredentials credentials)
        {
            var credential = credentials as NetworkCredential;

            return credential != null ? String.Format("{0}{1}:{2}", FormatDomain(credential.Domain), credential.UserName, credential.Password) : null;
        }

        private static string FormatDomain(string domain)
        {
            return String.IsNullOrWhiteSpace(domain) ? String.Empty : domain + DomainSeparator;
        }

        public static HttpContent CreateJsonContent(object data)
        {
            var json = JsonHelper.ToJson(data);

            return new StringContent(json, Encoding.UTF8, HttpContentType.Json);
        }
    }
}
