using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruPark.Tools.RestClient
{
    public class RestClient
    {
        public static T Request<T>(string url)
        {
            string json = HttpUtils.Request(url);
            Debug.WriteLine(json);

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
    }
}
