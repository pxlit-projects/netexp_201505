using System.IO;
using System.Net;
using System.Text;

namespace BruPark.Tools.RestClient
{
    public class HttpUtils
    {
        private static string Execute(HttpWebRequest request)
        {
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static string HttpGet(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            return Execute(request);
        }

        public static string HttpPost(string url, byte[] payload)
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

        public static string HttpPost(string url, string payload)
        {
            return HttpPost(url, Encoding.UTF8.GetBytes(payload));
        }
    }
}
