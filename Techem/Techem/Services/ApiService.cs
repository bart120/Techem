using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Techem.Services
{
    public static class ApiService
    {
        public async static Task<dynamic> GetDataFromServiceAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response != null)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    dynamic data = JsonConvert.DeserializeObject(json);
                    return data;
                }
                return null;
            }
        }
    }
}
