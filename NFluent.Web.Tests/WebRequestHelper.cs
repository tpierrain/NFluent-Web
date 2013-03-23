namespace NFluent.Web.Tests
{
    using System.Net;

    public static class WebRequestHelper
    {
        internal static HttpWebRequest CreateGoogleHttpRequest()
        {
            return CreateHttpRequest("http://www.google.ca");
        }

        internal static HttpWebRequest CreateHttpRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 5000;
            request.UserAgent = "Mozilla/5.0 compatible";
            
            return request;
        }
    }
}