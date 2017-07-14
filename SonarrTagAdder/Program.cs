using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SonarrTagAdder.Sonarr.Data;

namespace SonarrTagAdder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Run(args).GetAwaiter().GetResult();
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Couldn't connect to Sonarr.");
            }
            finally
            {
                // Exit
                Console.WriteLine("Finished.");
                Console.ReadKey();
            }
        }

        private static async Task Run(string[] args)
        {
            // Detect config file.
            var configPath = Path.Combine(Environment.CurrentDirectory, "config.json");

            if (!File.Exists(configPath))
            {
                File.WriteAllText(configPath, JsonConvert.SerializeObject(new Config(), Formatting.Indented));

                Console.WriteLine("A fresh config has been created, please change it.");
                return;
            }

            // Validate config.
            var config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configPath));

            if (string.IsNullOrEmpty(config.ApiKey) ||
                string.IsNullOrEmpty(config.BaseUrl))
            {
                Console.WriteLine("Please fill in the api key and base url.");
                return;
            }

            // Connected to Sonarr.
            var sonarr = new Sonarr.SonarrClient(config.BaseUrl, config.ApiKey);
            var status = await sonarr.GetStatusAsync();

            Console.WriteLine($"Connected to Sonarr v{status.Version}.");

            // Fetch series.
            var tags = await sonarr.GetTagsAsync();
            var tag = tags.FirstOrDefault(x => x.Label == "anime");
            if (tag == null)
            {
                Console.WriteLine("Anime tag not found in Sonarr.");
                return;
            }

            var series = await sonarr.GetSeriesAsync();
            var seriesAnime = series.Where(x => x.SeriesType == "anime").ToArray();

            // Add tags :)
            foreach (var serie in seriesAnime)
            {
                if (serie.Tags.Contains(tag.Id)) continue;

                serie.Tags.Add(tag.Id);

                await sonarr.UpdateSerieAsync(serie);

                Console.WriteLine($"Added '{tag.Label}' tag to '{serie.Title}'.");
            }
        }
    }
}
