using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Services
{
    public class Service : IService
    {
        public async Task<int> GetJokeCount()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://dad-jokes.p.rapidapi.com/joke/count"),
                Headers =
            {
                { "X-RapidAPI-Key", "28d9bb0fbamsh064f07798950e47p14c9bejsn0c4be9eefd8a" },
                { "X-RapidAPI-Host", "dad-jokes.p.rapidapi.com" },
            },
            };
            int count = 0;
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var getdata = JsonConvert.DeserializeObject<jsonDataCount>(body);
                count = getdata.body;
            }

            return count;
        }

        public async Task<RandomJokes> GetRandomJokes()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://dad-jokes.p.rapidapi.com/random/joke"),
                Headers =
            {
                { "X-RapidAPI-Key", "28d9bb0fbamsh064f07798950e47p14c9bejsn0c4be9eefd8a" },
                { "X-RapidAPI-Host", "dad-jokes.p.rapidapi.com" },
            },
            };
            RandomJokes randomJokes;
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var getdata = JsonConvert.DeserializeObject<jsonData>(body);
                randomJokes = new RandomJokes() { 
                 Id = getdata.body[0]._id,
                 Jokes = getdata.body[0].setup,
                 punchline = getdata.body[0].punchline,
                 type = getdata.body[0].type,
                };
            }

            return randomJokes;
        }
    }
}
