using Thulir.Weather.Models.OpenWeather;

namespace Thulir.Weather.Crawler.crawlers
{
    public class OpenWeatherConstants
    {
        public static OpenWeatherCity[] OpenWeatherCities = new[]
        {
            new OpenWeatherCity
            {
                Id = 1279058,
                Name = "Alangulam",
                Longitude = 77.5,
                Lattitude = 8.86667
            },
            new OpenWeatherCity
            {
                Id = 1254744,
                Name = "Thenkasi",
                Longitude = 77.300003,
                Lattitude = 8.96667
            },
            new OpenWeatherCity
            {
                Id = 1265403,
                Name = "Kutralam",
                Longitude = 77.283333,
                Lattitude = 8.91667
            },
        };

        public static OpenWeatherCondition[] OpenWeatherConditions = new[]
        {
            new OpenWeatherCondition
            {
                Id = 200,
                Main = "Thunderstorm",
                Description = "thunderstorm with light rain",
                Icon = "11d"
            },
            new OpenWeatherCondition
            {
                Id = 201,
                Main = "Thunderstorm",
                Description = "thunderstorm with rain",
                Icon = "11d"
            },
            new OpenWeatherCondition
            {
                Id = 202,
                Main = "Thunderstorm",
                Description = "thunderstorm with heavy rain",
                Icon = "11d"
            },
            new OpenWeatherCondition
            {
                Id = 210,
                Main = "Thunderstorm",
                Description = "light thunderstorm",
                Icon = "11d"
            },
            new OpenWeatherCondition
            {
                Id = 211,
                Main = "Thunderstorm",
                Description = "thunderstorm",
                Icon = "11d"
            },
            new OpenWeatherCondition
            {
                Id = 212,
                Main = "Thunderstorm",
                Description = "heavy thunderstorm",
                Icon = "11d"
            },
            new OpenWeatherCondition
            {
                Id = 221,
                Main = "Thunderstorm",
                Description = "ragged thunderstorm",
                Icon = "11d"
            },
            new OpenWeatherCondition
            {
                Id = 230,
                Main = "Thunderstorm",
                Description = "thunderstorm with light drizzle",
                Icon = "11d"
            },
            new OpenWeatherCondition
            {
                Id = 231,
                Main = "Thunderstorm",
                Description = "thunderstorm with drizzle",
                Icon = "11d"
            },
            new OpenWeatherCondition
            {
                Id = 232,
                Main = "Thunderstorm",
                Description = "thunderstorm with heavy drizzle",
                Icon = "11d"
            },
            
            new OpenWeatherCondition
            {
                Id = 300,
                Main = "Drizzle",
                Description = "light intensity drizzle",
                Icon = "09d"
            },
            new OpenWeatherCondition
            {
                Id = 301,
                Main = "Drizzle",
                Description = "drizzle",
                Icon = "09d"
            },
            new OpenWeatherCondition
            {
                Id = 302,
                Main = "Drizzle",
                Description = "heavy intensity drizzle",
                Icon = "09d"
            },
            new OpenWeatherCondition
            {
                Id = 310,
                Main = "Drizzle",
                Description = "light intensity drizzle rain",
                Icon = "09d"
            },
            new OpenWeatherCondition
            {
                Id = 311,
                Main = "Drizzle",
                Description = "drizzle rain",
                Icon = "09d"
            },
            new OpenWeatherCondition
            {
                Id = 312,
                Main = "Drizzle",
                Description = "heavy intensity drizzle rain",
                Icon = "09d"
            },
            new OpenWeatherCondition
            {
                Id = 313,
                Main = "Drizzle",
                Description = "shower rain and drizzle",
                Icon = "09d"
            },
            new OpenWeatherCondition
            {
                Id = 314,
                Main = "Drizzle",
                Description = "heavy shower rain and drizzle",
                Icon = "09d"
            },
            new OpenWeatherCondition
            {
                Id = 321,
                Main = "Drizzle",
                Description = "shower drizzle",
                Icon = "09d"
            },
            
            
            
            new OpenWeatherCondition
            {
                Id = 500,
                Main = "Rain",
                Description = "light rain",
                Icon = "10d"
            },
            new OpenWeatherCondition
            {
                Id = 501,
                Main = "Rain",
                Description = "moderate rain",
                Icon = "10d"
            },
            new OpenWeatherCondition
            {
                Id = 502,
                Main = "Rain",
                Description = "heavy intensity rain",
                Icon = "10d"
            },
            new OpenWeatherCondition
            {
                Id = 503,
                Main = "Rain",
                Description = "very heavy rain",
                Icon = "10d"
            },
            new OpenWeatherCondition
            {
                Id = 504,
                Main = "Rain",
                Description = "extreme rain",
                Icon = "10d"
            },
            new OpenWeatherCondition
            {
                Id = 511,
                Main = "Rain",
                Description = "freezing rain",
                Icon = "13d"
            },
            new OpenWeatherCondition
            {
                Id = 520,
                Main = "Rain",
                Description = "light intensity shower rain",
                Icon = "09d"
            },
            new OpenWeatherCondition
            {
                Id = 521,
                Main = "Rain",
                Description = "shower rain",
                Icon = "09d"
            },
            new OpenWeatherCondition
            {
                Id = 522,
                Main = "Rain",
                Description = "heavy intensity shower rain",
                Icon = "09d"
            },
            new OpenWeatherCondition
            {
                Id = 531,
                Main = "Rain",
                Description = "ragged shower rain",
                Icon = "09d"
            },
            
            new OpenWeatherCondition
            {
                Id = 600,
                Main = "Snow",
                Description = "light snow",
                Icon = "13d"
            },
            new OpenWeatherCondition
            {
                Id = 601,
                Main = "Snow",
                Description = "Snow",
                Icon = "13d"
            },
            new OpenWeatherCondition
            {
                Id = 602,
                Main = "Snow",
                Description = "Heavy snow",
                Icon = "13d"
            },
            new OpenWeatherCondition
            {
                Id = 611,
                Main = "Snow",
                Description = "Sleet",
                Icon = "13d"
            },
            new OpenWeatherCondition
            {
                Id = 612,
                Main = "Snow",
                Description = "Light shower sleet",
                Icon = "13d"
            },
            new OpenWeatherCondition
            {
                Id = 613,
                Main = "Snow",
                Description = "Shower sleet",
                Icon = "13d"
            },
            
            new OpenWeatherCondition
            {
                Id = 615,
                Main = "Snow",
                Description = "Light rain and snow",
                Icon = "13d"
            },
            new OpenWeatherCondition
            {
                Id = 616,
                Main = "Snow",
                Description = "Rain and snow",
                Icon = "13d"
            },
            new OpenWeatherCondition
            {
                Id = 620,
                Main = "Snow",
                Description = "Light shower snow",
                Icon = "13d"
            },
            new OpenWeatherCondition
            {
                Id = 621,
                Main = "Snow",
                Description = "Shower snow",
                Icon = "13d"
            },
            new OpenWeatherCondition
            {
                Id = 622,
                Main = "Snow",
                Description = "Heavy shower snow",
                Icon = "13d"
            },
            
            
            new OpenWeatherCondition
            {
                Id = 701,
                Main = "Mist",
                Description = "mist",
                Icon = "50d"
            },
            new OpenWeatherCondition
            {
                Id = 711,
                Main = "Smoke",
                Description = "Smoke",
                Icon = "50d"
            },
            new OpenWeatherCondition
            {
                Id = 721,
                Main = "Haze",
                Description = "Haze",
                Icon = "50d"
            },
            new OpenWeatherCondition
            {
                Id = 731,
                Main = "Dust",
                Description = "sand/ dust whirls",
                Icon = "50d"
            },
            new OpenWeatherCondition
            {
                Id = 741,
                Main = "Fog",
                Description = "Fog",
                Icon = "50d"
            },
            new OpenWeatherCondition
            {
                Id = 751,
                Main = "Sand",
                Description = "sand",
                Icon = "50d"
            },
            new OpenWeatherCondition
            {
                Id = 761,
                Main = "Dust",
                Description = "dust",
                Icon = "50d"
            },
            new OpenWeatherCondition
            {
                Id = 762,
                Main = "Ash",
                Description = "volcanic",
                Icon = "50d"
            },
            new OpenWeatherCondition
            {
                Id = 771,
                Main = "Squall",
                Description = "squalls",
                Icon = "50d"
            },
            new OpenWeatherCondition
            {
                Id = 781,
                Main = "Tornado",
                Description = "tornado",
                Icon = "50d"
            },
            new OpenWeatherCondition
            {
                Id = 800,
                Main = "Clear",
                Description = "clear sky",
                Icon = "01d, 01n"
            },
            
            new OpenWeatherCondition
            {
                Id = 801,
                Main = "Clouds",
                Description = "few clouds: 11-25%",
                Icon = "02d, 02n"
            },
            new OpenWeatherCondition
            {
                Id = 802,
                Main = "Clouds",
                Description = "scattered clouds: 25-50%",
                Icon = "03d, 03n"
            },
            new OpenWeatherCondition
            {
                Id = 803,
                Main = "Clouds",
                Description = "broken clouds: 51-84%",
                Icon = "04d, 04n"
            },
            new OpenWeatherCondition
            {
                Id = 804,
                Main = "Clouds",
                Description = "overcast clouds: 85-100%",
                Icon = "04d, 04n"
            },
        };
    }
}