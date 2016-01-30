using Newtonsoft.Json;
using System.Diagnostics;

namespace BruPark.Tools.RestClient
{
    public class RestClient
    {
        public static Response<T> Get<T>(string url)
        {
            return Parse<T>(HttpUtils.HttpGet(url));
        }

        private static Response<T> Parse<T>(Response<string> response)
        {
            Response<T> result = new Response<T>(response.StatusCode);

            if (response.Failure)
            {
                result.Error = response.Error;
            }
            else
            {
                string json = response.Body;
                Debug.WriteLine("OUTPUT:  " + json);

                result.Body = Parse<T>(json);
            }

            return result;
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

        public static Response<T> Post<T>(string url, object payload)
        {
            string input = JsonConvert.SerializeObject(payload);
            Debug.WriteLine("INPUT:  " + input);
            
            return Parse<T>(HttpUtils.HttpPost(url, input));
        }
    }
}
