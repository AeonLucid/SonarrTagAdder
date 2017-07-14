using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SonarrTagAdder.Sonarr.Data;

namespace SonarrTagAdder.Sonarr
{
    internal class SonarrClient
    {
        private readonly HttpClient _client;

        public SonarrClient(string url, string apiKey)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri($"{url}/api/", UriKind.Absolute),
                DefaultRequestHeaders =
                {
                    { "X-Api-Key", apiKey }
                }
            };
        }

        public async Task<StatusResponse> GetStatusAsync()
        {
            return JsonConvert.DeserializeObject<StatusResponse>(
                await _client.GetStringAsync("system/status")
            );
        }

        public async Task<TagResponse[]> GetTagsAsync()
        {
            return JsonConvert.DeserializeObject<TagResponse[]>(
                await _client.GetStringAsync("tag")
            );
        }

        public async Task<SerieResponse[]> GetSeriesAsync()
        {
            return JsonConvert.DeserializeObject<SerieResponse[]>(
                await _client.GetStringAsync("series")
            );
        }

        public async Task UpdateSerieAsync(SerieResponse serie)
        {
            await _client.PutAsync("series", new StringContent(JsonConvert.SerializeObject(serie), Encoding.UTF8, "application/json"));
        }
    }
}
