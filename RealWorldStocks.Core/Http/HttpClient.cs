using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using RealWorldStocks.Core.Logging;

namespace RealWorldStocks.Core.Http
{
    public class HttpClient
    {
        /// <summary>
        /// Gets or sets the number of milliseconds to wait before the request times out.
        /// </summary>
        public TimeSpan Timeout { get; set; }

        /// <summary>
        /// Gets the headers which should be sent with each request.
        /// </summary>
        public WebHeaderCollection DefaultRequestHeaders { get; private set; }

        public HttpClient()
        {
            DefaultRequestHeaders = new WebHeaderCollection();
            DefaultRequestHeaders[HttpRequestHeader.AcceptEncoding] = "gzip";
        }

        public Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return GetAsync(new Uri(requestUri));
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            return ExecuteRequest(HttpVerbs.GET, requestUri);
        }

        public Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
        {
            return GetAsync(requestUri);
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            return GetAsync(requestUri);
        }

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return PostAsync(requestUri, content);
        }

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return PostAsync(requestUri, content);
        }

        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            return PostAsync(new Uri(requestUri), content);
        }

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            return ExecuteRequest(HttpVerbs.POST, requestUri, content);
        }


        private async Task<HttpResponseMessage> ExecuteRequest(HttpVerbs method, Uri requestUri, HttpContent content = null)
        {
            var request = WebRequest.CreateHttp(requestUri);
            var httpResponseMessage = new HttpResponseMessage();

            request.Headers = DefaultRequestHeaders;
            request.Method = method.ToString();
            request.Accept = "*/*";

            httpResponseMessage.Request = request;

            Logger.LogWebRequest(request);
            if (content != null) Logger.LogVerbose(content.ToString());

            try
            {
                if (method == HttpVerbs.POST)
                {
                    request.ContentType = content.ContentType;

                    var requestStreamTask = Task<Stream>.Factory.FromAsync(request.BeginGetRequestStream, request.EndGetRequestStream, null);
                    using (Stream stream = await requestStreamTask.ConfigureAwait(false))
                    {
                        content.WriteToStream(stream);
                    }
                }

                var responseTask = Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null);
                using (var response = await responseTask.ConfigureAwait(false) as HttpWebResponse)
                {
                    httpResponseMessage.SetResponseData(response);
                    Logger.LogWebResponse(response);
                }
            }
            catch (WebException we)
            {
                var response = (HttpWebResponse)we.Response;
                if (response != null)
                    httpResponseMessage.SetResponseData(response);

                Logger.Log(we);
            }
            catch (Exception e)
            {
                Logger.Log(e);
            }

            return httpResponseMessage;
        }
    }

    public static class HttpWebResponseExtensions
    {
        public static string ReadAsString(this HttpWebResponse response)
        {
            string content;
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream == null)
                    return null;

                if (response.Headers["Content-Encoding"] != null &&
                    response.Headers["Content-Encoding"].Contains("gzip"))
                {
                    content = PlatformAdapter.Current.ReadCompressedResponseStream(response);
                }
                else
                {
                    content = new StreamReader(responseStream).ReadToEnd();
                }
            }

            return content;
        }
    }
}
