using System.Net;

namespace RealWorldStocks.Core.Http
{
    public class HttpResponseMessage
    {
        public string Content { get; set; }
        public string ContentType { get; set; }
        public WebHeaderCollection Headers { get; private set; }
        public HttpWebRequest Request { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }

        public bool IsSuccessStatusCode
        {
            get { return (int)StatusCode >= 200 && (int)StatusCode <= 299; }
        }

        public bool IsJsonResponse
        {
            get { return ContentType != null && ContentType.Contains("json"); }
        }

        public HttpResponseMessage() 
        {
            Headers = new WebHeaderCollection();
        }

        public HttpResponseMessage(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public void SetResponseData(HttpWebResponse response)
        {
            StatusCode = response.StatusCode;
            StatusDescription = response.StatusDescription;
            ContentType = response.ContentType;
            Content = response.ReadAsString();

            foreach (var headerName in response.Headers.AllKeys)
                Headers[headerName] = response.Headers[headerName];
        }
    }
}
