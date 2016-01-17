using System.IO;
using System.Net;

namespace BruPark.Tools.RestClient
{
    public class HttpUtils
    {
        public static string Request(string url)
        {
            WebRequest request = WebRequest.Create(url);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
