using SWAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SWAPI.Services
{
    public class SwaAPI
    {
        readonly string _api_base_url = "https://swapi.co/api";

        public async Task<List<Root>> GetAllCategoriesAsync()
        {
            //grab json from server
            var json = await GetJsonData($"{_api_base_url}/people");

            json = "[" + json + "]";
            //Deserialize json
            var items = JsonConvert.DeserializeObject<List<Root>>(json);

            return items;

        }
        public async Task<List<Root>> GetRandomJokeByCategoyAsync()
        {
            //grab json from server
            var json = await GetJsonData($"{_api_base_url}/people");

            json = "[" + json + "]";
            //Deserialize json
            var items = JsonConvert.DeserializeObject<List<Root>>(json);

            return items;
        }
        public async Task<Movies> GetMovieByPersonAsync(string url)
        {
            //grab json from server
            var json = await GetJsonData($"{url}");

            //Deserialize json
            var movieInfo = JsonConvert.DeserializeObject<Movies>(json);

            return movieInfo;
        }



        async Task<string> GetJsonData(string url)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return json;
            }
        }
    }
}
