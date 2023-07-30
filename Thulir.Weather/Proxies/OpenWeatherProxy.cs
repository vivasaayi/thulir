using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Thulir.Core.Models;
using Thulir.Core.Services;
using Thulir.Weather.Models.OpenWeather;

namespace Thulir.Weather.Proxies
{
    public class OpenWeatherProxy
    {
        private ThulirSecrets _secrets = new ThulirSecrets();
        private static readonly HttpClient client = new HttpClient();

        public OpenWeatherProxy()
        {
        }

        private async Task<string> GetAppKey()
        {
            ImageLabellerGlobals globals = await _secrets.GetThulirGlobals();
            return globals.OpenWeatherAppKey;
        } 
        
        public async Task<OneCallAPIResponse> MakeOneCallApi(double lattitude, double longitude)
        {
            string appId = await GetAppKey();
            
            OneCallAPIResponse response = new OneCallAPIResponse();
            try
            {
                string url =
                    $"https://api.openweathermap.org/data/2.5/onecall?lat={lattitude}&lon={longitude}&appid={appId}&units=metric";

                var streamTask = client.GetStreamAsync(url);
                response = await JsonSerializer.DeserializeAsync<OneCallAPIResponse>(await streamTask);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return response;
        }
    }
}