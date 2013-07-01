using System;
using System.Net;

namespace RealWorldStocks.Core.Http
{
    //TODO: might not need this
    public class HttpRequestMessage
    {
        public HttpContent Content { get; set; }
        public WebHeaderCollection Headers { get; set; }
        public string Method { get; set; }
        public Uri RequestUri { get; set; }

        public HttpRequestMessage() { }

        public HttpRequestMessage(HttpWebRequest request)
        {
            RequestUri = request.RequestUri;
            Method = request.Method;
            Headers = request.Headers;
        }
    }
}
