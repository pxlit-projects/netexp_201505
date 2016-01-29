using Newtonsoft.Json;
using System.Diagnostics;

namespace BruPark.Tools.RestClient
{
    public class RestClient
    {
        public static T Get<T>(string url)
        {
            string json = HttpUtils.HttpGet(url);
            Debug.WriteLine(json);

            return Parse<T>(json);
        }

        private static T Parse<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (JsonReaderException e)
            {
                Debug.WriteLine("Error while parsing JSON:  " + e.Message);
                return default(T);
            }
        }

        public static T Post<T>(string url, object payload)
        {
            string input = JsonConvert.SerializeObject(payload);
            Debug.WriteLine("INPUT:  " + input);

            string output = HttpUtils.HttpPost(url, input);
            Debug.WriteLine("OUTPUT:  " + output);

            return Parse<T>(output);
        }
    }
}
