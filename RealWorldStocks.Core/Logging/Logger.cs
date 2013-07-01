using System;
using System.Diagnostics;
using System.Net;

namespace RealWorldStocks.Core.Logging
{
    public static class Logger
    {
        public static bool IsUrlLoggingEnabled { get; set; }
        public static bool IsVerboseLoggingEnabled { get; set; }

        static Logger()
        {
            IsUrlLoggingEnabled = true;
            IsVerboseLoggingEnabled = true;
        }

        [Conditional("DEBUG")]
        public static void Log(string message, params object[] args)
        {
#if USE_CONSOLE
            Console.WriteLine(message, args);
#else
            Debug.WriteLine(message, args);
#endif
        }

        [Conditional("DEBUG")]
        public static void Log(Exception ex)
        {
            Log("Exception {0} {1}: {2}", ex.GetType().Name, (ex.InnerException != null ? "has inner exception" : "with no inner exception"), ex.Message);
            Log(ex.StackTrace);
            if (ex.InnerException != null)
                Log(ex.InnerException);
        }

        [Conditional("DEBUG")]
        public static void LogVerbose(string message, params object[] args)
        {
            if (IsVerboseLoggingEnabled)
            {
                Log(message, args);
            }
        }


        [Conditional("DEBUG")]
        public static void LogWebRequest(HttpWebRequest request, string description = null)
        {
            if (IsUrlLoggingEnabled)
            {
                Log(String.Format("WebRequest {0}\r\n-Url: {1}\r\n-Method: {2}\r\n-Headers: {3}\r\n",
                    description, request.RequestUri.OriginalString, request.Method,
                    request.Headers != null ? request.Headers.ToString() : String.Empty));
            }
        }

        [Conditional("DEBUG")]
        public static void LogWebResponse(WebResponse response, string description = null)
        {

            if (IsUrlLoggingEnabled)
            {
                var httpWebResponse = response as HttpWebResponse;
                Log(String.Format("WebResponse {0}\r\n-Url: {1}\r\n-HttpStatus: {2} {3}\r\n-ContentLength: {4:0.00 KB}\r\n", description, response.ResponseUri.OriginalString,
                    (int)httpWebResponse.StatusCode, httpWebResponse.StatusDescription, (Convert.ToDecimal(Convert.ToDouble(response.ContentLength) / 1024))));
            }
        }
    }
}
