using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CPVPAAppDes
{
    public class RestClient
    {
        public async Task <T> Get<T>(string url)
        {
          
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);
                if (response.StatusCode==System.Net.HttpStatusCode.OK)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();
                    //var array = JsonConvert.DeserializeObject<T>(jsonstring);
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonstring);
                    //return array;
                }
           }
            catch {

            }
            return default(T);
        }

    }
}
