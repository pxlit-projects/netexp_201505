﻿using System.IO;
using System.Net;
using System.Text;

namespace BruPark.Tools.RestClient
{
    public class HttpUtils
    {
        private static Response<string> Execute(HttpWebRequest request)
        {
            try {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        return new Response<string>(response.StatusCode, reader.ReadToEnd());
                    }
                }
            }
            catch (WebException e)
            {
                Response<string> response = new Response<string>(HttpStatusCode.ServiceUnavailable);

                response.Error = e.Message;

                switch (e.Status)
                {
                    case WebExceptionStatus.Timeout:
                        response.StatusCode = HttpStatusCode.RequestTimeout;
                        break;
                }

                return response;
            }
        }

        public static Response<string> HttpGet(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            return Execute(request);
        }

        public static Response<string> HttpPost(string url, byte[] payload)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.ContentType = "application/json";
            request.Method = "POST";
            
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(payload, 0, payload.Length);
                stream.Flush();
                stream.Close();
            }

            return Execute(request);
        }

        public static Response<string> HttpPost(string url, string payload)
        {
            return HttpPost(url, Encoding.UTF8.GetBytes(payload));
        }
    }
}
