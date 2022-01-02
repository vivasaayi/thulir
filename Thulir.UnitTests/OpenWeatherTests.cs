using System.IO;
using System.Text.Json;
using NUnit.Framework;
using Thulir.Weather.Models;
using Thulir.Weather.Models.OpenWeather;

namespace Thulir.UnitTests
{
    public class Tests
    {
        private string oneCallAPIResponseDataStr = "";
        private string currentWeatherInfoDataStr = "";
        private string hourlyForcastWeatherInfoDataStr = "";
        private string dailyForcastWeatherInfoDataStr = "";
        
        [SetUp]
        public void Setup()
        {
            string oneCallApiResponseDataPath = Path.Join(TestContext.CurrentContext.TestDirectory, "TestData", "onecallapiresponse.json");
            oneCallAPIResponseDataStr = File.ReadAllText( oneCallApiResponseDataPath);
            
            string currentWeatherInfoPath = Path.Join(TestContext.CurrentContext.TestDirectory, "TestData", "current_weatherinfo.json");
            currentWeatherInfoDataStr = File.ReadAllText( currentWeatherInfoPath);
            
            string hourlyForcastWeatherInfoPath = Path.Join(TestContext.CurrentContext.TestDirectory, "TestData", "hourly_forecast_weather_info.json");
            hourlyForcastWeatherInfoDataStr = File.ReadAllText( hourlyForcastWeatherInfoPath);
            
            string dailyForcastWeatherInfoPath = Path.Join(TestContext.CurrentContext.TestDirectory, "TestData", "daily_forecast_weather_info.json");
            dailyForcastWeatherInfoDataStr = File.ReadAllText( dailyForcastWeatherInfoPath);
        }

        [Test]
        public void Test_Parse_WeatherInfo()
        {
            OpenWeatherInfo currentWeatherInfo = JsonSerializer.Deserialize<OpenWeatherInfo>(currentWeatherInfoDataStr);
            
            Assert.AreEqual(currentWeatherInfo.TimeStamp, 1640978589);
            Assert.AreEqual(currentWeatherInfo.Sunrise, 1640999087);
            Assert.AreEqual(currentWeatherInfo.Sunset, 1641040902);
            Assert.AreEqual(currentWeatherInfo.Temperature, 23.19);
            Assert.AreEqual(currentWeatherInfo.FeelsLike, 23.86);
            Assert.AreEqual(currentWeatherInfo.Pressure, 1015);
            Assert.AreEqual(currentWeatherInfo.Humidity, 88);
            Assert.AreEqual(currentWeatherInfo.DewPoint, 21.09);
            Assert.AreEqual(currentWeatherInfo.UVI, 0);
            Assert.AreEqual(currentWeatherInfo.Clouds, 66);
            Assert.AreEqual(currentWeatherInfo.Visibility, 10000);
            Assert.AreEqual(currentWeatherInfo.WindSpeed, 3.21);
            Assert.AreEqual(currentWeatherInfo.WindDegree, 23);
            Assert.AreEqual(currentWeatherInfo.WindGust, 8.71);
            Assert.AreEqual(currentWeatherInfo.Pop, 0);
            
            Assert.NotNull(currentWeatherInfo.Weather);
            Assert.AreEqual(currentWeatherInfo.Weather.Length, 1);
            
            Assert.AreEqual(currentWeatherInfo.Weather[0].Id, 803);
            Assert.AreEqual(currentWeatherInfo.Weather[0].Main, "Clouds");
            Assert.AreEqual(currentWeatherInfo.Weather[0].Description, "broken clouds");
            Assert.AreEqual(currentWeatherInfo.Weather[0].Icon, "04n");
        }
        
        [Test]
        public void Test_Parse_HourlyForecast()
        {
            OpenWeatherInfo hourlyForecastWeatherInfo =  JsonSerializer.Deserialize<OpenWeatherInfo>(hourlyForcastWeatherInfoDataStr);

            Assert.AreEqual(hourlyForecastWeatherInfo.TimeStamp, 1641088800);
            Assert.AreEqual(hourlyForecastWeatherInfo.Sunrise, 0); // This value is not available for Hourly Forecast
            Assert.AreEqual(hourlyForecastWeatherInfo.Sunset, 0); // This value is not available for Hourly Forecast
            Assert.AreEqual(hourlyForecastWeatherInfo.Temperature, 26.55);
            Assert.AreEqual(hourlyForecastWeatherInfo.FeelsLike, 26.55);
            Assert.AreEqual(hourlyForecastWeatherInfo.Pressure, 1016);
            Assert.AreEqual(hourlyForecastWeatherInfo.Humidity, 82);
            Assert.AreEqual(hourlyForecastWeatherInfo.DewPoint, 23.22);
            Assert.AreEqual(hourlyForecastWeatherInfo.UVI, 0.47);
            Assert.AreEqual(hourlyForecastWeatherInfo.Clouds, 97);
            Assert.AreEqual(hourlyForecastWeatherInfo.Visibility, 10000);
            Assert.AreEqual(hourlyForecastWeatherInfo.WindSpeed, 0.66);
            Assert.AreEqual(hourlyForecastWeatherInfo.WindDegree, 164);
            Assert.AreEqual(hourlyForecastWeatherInfo.WindGust, 3.84);
            Assert.AreEqual(hourlyForecastWeatherInfo.Pop, 0.06);
            
            Assert.NotNull(hourlyForecastWeatherInfo.Weather);
            Assert.AreEqual(hourlyForecastWeatherInfo.Weather.Length, 1);
            
            Assert.AreEqual(hourlyForecastWeatherInfo.Weather[0].Id, 804);
            Assert.AreEqual(hourlyForecastWeatherInfo.Weather[0].Main, "Clouds");
            Assert.AreEqual(hourlyForecastWeatherInfo.Weather[0].Description, "overcast clouds");
            Assert.AreEqual(hourlyForecastWeatherInfo.Weather[0].Icon, "04d");
        }
        
        [Test]
        public void Test_Parse_DailyForecast()
        {
            OWDailyWeatherInfo dailyForecaseWeatherInfo =  JsonSerializer.Deserialize<OWDailyWeatherInfo>(dailyForcastWeatherInfoDataStr);

            Assert.AreEqual(dailyForecaseWeatherInfo.TimeStamp, 1641537000);
            Assert.AreEqual(dailyForecaseWeatherInfo.Sunrise, 1641517621); // This value is not available for Hourly Forecast
            Assert.AreEqual(dailyForecaseWeatherInfo.Sunset, 1641559488); // This value is not available for Hourly Forecast
            // Assert.AreEqual(dailyForecaseWeatherInfo.Temperature, 26.55);
            // Assert.AreEqual(dailyForecaseWeatherInfo.FeelsLike, 26.55);
            Assert.AreEqual(dailyForecaseWeatherInfo.Pressure, 1016);
            Assert.AreEqual(dailyForecaseWeatherInfo.Humidity, 55);
            Assert.AreEqual(dailyForecaseWeatherInfo.DewPoint, 17.04);
            Assert.AreEqual(dailyForecaseWeatherInfo.UVI, 11);
            Assert.AreEqual(dailyForecaseWeatherInfo.Clouds, 48);
            Assert.AreEqual(dailyForecaseWeatherInfo.Visibility, 0); // This value is not available for Daily Forecast
            Assert.AreEqual(dailyForecaseWeatherInfo.WindSpeed, 3.53);
            Assert.AreEqual(dailyForecaseWeatherInfo.WindDegree, 33);
            Assert.AreEqual(dailyForecaseWeatherInfo.WindGust, 5.04);
            Assert.AreEqual(dailyForecaseWeatherInfo.Pop, 0);
            
            Assert.NotNull(dailyForecaseWeatherInfo.Weather);
            Assert.AreEqual(dailyForecaseWeatherInfo.Weather.Length, 1);
            
            Assert.AreEqual(dailyForecaseWeatherInfo.Weather[0].Id, 802);
            Assert.AreEqual(dailyForecaseWeatherInfo.Weather[0].Main, "Clouds");
            Assert.AreEqual(dailyForecaseWeatherInfo.Weather[0].Description, "scattered clouds");
            Assert.AreEqual(dailyForecaseWeatherInfo.Weather[0].Icon, "03d");
        }

        
        [Test]
        public void Test_Parse_OneCallAPIResponse()
        {
            OneCallAPIResponse oneCallApiResponse =  JsonSerializer.Deserialize<OneCallAPIResponse>(oneCallAPIResponseDataStr);

            Assert.NotNull(oneCallApiResponse);
            Assert.NotNull(oneCallApiResponse.Current);
            Assert.NotNull(oneCallApiResponse.Hourly);
            Assert.NotNull(oneCallApiResponse.Minutely);
            
            Assert.AreEqual(oneCallApiResponse.Lattitude, 8.8667);
            Assert.AreEqual(oneCallApiResponse.Longitude, 77.5);
            Assert.AreEqual(oneCallApiResponse.TimeZone, "Asia/Kolkata");
            Assert.AreEqual(oneCallApiResponse.TimeZoneOffset, 19800);
            
            Assert.AreEqual(oneCallApiResponse.Current.TimeStamp, 1640978589);
            Assert.AreEqual(oneCallApiResponse.Current.Sunrise, 1640999087);
            Assert.AreEqual(oneCallApiResponse.Current.Sunset, 1641040902);
            Assert.AreEqual(oneCallApiResponse.Current.Temperature, 23.19);
            Assert.AreEqual(oneCallApiResponse.Current.FeelsLike, 23.86);
            Assert.AreEqual(oneCallApiResponse.Current.Pressure, 1015);
            Assert.AreEqual(oneCallApiResponse.Current.Humidity, 88);
            Assert.AreEqual(oneCallApiResponse.Current.DewPoint, 21.09);
            Assert.AreEqual(oneCallApiResponse.Current.UVI, 0);
            Assert.AreEqual(oneCallApiResponse.Current.Clouds, 66);
            Assert.AreEqual(oneCallApiResponse.Current.Visibility, 10000);
            Assert.AreEqual(oneCallApiResponse.Current.WindSpeed, 3.21);
            Assert.AreEqual(oneCallApiResponse.Current.WindDegree, 23);
            Assert.AreEqual(oneCallApiResponse.Current.WindGust, 8.71);
            Assert.AreEqual(oneCallApiResponse.Current.Pop, 0);
            
            Assert.NotNull(oneCallApiResponse.Current.Weather);
            Assert.AreEqual(oneCallApiResponse.Current.Weather.Length, 1);
            
            Assert.AreEqual(oneCallApiResponse.Current.Weather[0].Id, 803);
            Assert.AreEqual(oneCallApiResponse.Current.Weather[0].Main, "Clouds");
            Assert.AreEqual(oneCallApiResponse.Current.Weather[0].Description, "broken clouds");
            Assert.AreEqual(oneCallApiResponse.Current.Weather[0].Icon, "04n");
            
            
            Assert.AreEqual(oneCallApiResponse.Hourly[1].TimeStamp, 1640980800);
            Assert.AreEqual(oneCallApiResponse.Hourly[1].Sunrise, 0); // This value is not available for Hourly Forecast
            Assert.AreEqual(oneCallApiResponse.Hourly[1].Sunset, 0); // This value is not available for Hourly Forecast
            Assert.AreEqual(oneCallApiResponse.Hourly[1].Temperature, 23.11);
            Assert.AreEqual(oneCallApiResponse.Hourly[1].FeelsLike, 23.8);
            Assert.AreEqual(oneCallApiResponse.Hourly[1].Pressure, 1015);
            Assert.AreEqual(oneCallApiResponse.Hourly[1].Humidity, 89);
            Assert.AreEqual(oneCallApiResponse.Hourly[1].DewPoint, 21.2);
            Assert.AreEqual(oneCallApiResponse.Hourly[1].UVI, 0);
            Assert.AreEqual(oneCallApiResponse.Hourly[1].Clouds, 63);
            Assert.AreEqual(oneCallApiResponse.Hourly[1].Visibility, 10000);
            Assert.AreEqual(oneCallApiResponse.Hourly[1].WindSpeed, 2.02);
            Assert.AreEqual(oneCallApiResponse.Hourly[1].WindDegree, 12);
            Assert.AreEqual(oneCallApiResponse.Hourly[1].WindGust, 6.59);
            Assert.AreEqual(oneCallApiResponse.Hourly[1].Pop, 0.3);
            
            Assert.NotNull(oneCallApiResponse.Hourly[1].Weather);
            Assert.AreEqual(oneCallApiResponse.Hourly[1].Weather.Length, 1);
            
            Assert.AreEqual(oneCallApiResponse.Hourly[1].Weather[0].Id, 803);
            Assert.AreEqual(oneCallApiResponse.Hourly[1].Weather[0].Main, "Clouds");
            Assert.AreEqual(oneCallApiResponse.Hourly[1].Weather[0].Description, "broken clouds");
            Assert.AreEqual(oneCallApiResponse.Hourly[1].Weather[0].Icon, "04n");
            
            Assert.AreEqual(oneCallApiResponse.Minutely[2].TimeStamp, 1640978760);
            Assert.AreEqual(oneCallApiResponse.Minutely[2].Precipitation, 0);
            
            Assert.AreEqual(oneCallApiResponse.Daily[3].TimeStamp, 1641277800);
            Assert.AreEqual(oneCallApiResponse.Daily[3].Sunrise, 1641258357); // This value is not available for Hourly Forecast
            Assert.AreEqual(oneCallApiResponse.Daily[3].Sunset, 1641300195); // This value is not available for Hourly Forecast
            // Assert.AreEqual(oneCallApiResponse.Daily[3].Temperature, 26.55);
            // Assert.AreEqual(oneCallApiResponse.Daily[3].FeelsLike, 26.55);
            Assert.AreEqual(oneCallApiResponse.Daily[3].Pressure, 1015);
            Assert.AreEqual(oneCallApiResponse.Daily[3].Humidity, 61);
            Assert.AreEqual(oneCallApiResponse.Daily[3].DewPoint, 19.36);
            Assert.AreEqual(oneCallApiResponse.Daily[3].UVI, 10.72);
            Assert.AreEqual(oneCallApiResponse.Daily[3].Clouds, 87);
            Assert.AreEqual(oneCallApiResponse.Daily[3].Visibility, 0); // This value is not available for Daily Forecast
            Assert.AreEqual(oneCallApiResponse.Daily[3].WindSpeed, 3.51);
            Assert.AreEqual(oneCallApiResponse.Daily[3].WindDegree, 28);
            Assert.AreEqual(oneCallApiResponse.Daily[3].WindGust,  5.09);
            Assert.AreEqual(oneCallApiResponse.Daily[3].Pop, 0);
            
            Assert.NotNull(oneCallApiResponse.Daily[3].Weather);
            Assert.AreEqual(oneCallApiResponse.Daily[3].Weather.Length, 1);
            
            Assert.AreEqual(oneCallApiResponse.Daily[3].Weather[0].Id, 804);
            Assert.AreEqual(oneCallApiResponse.Daily[3].Weather[0].Main, "Clouds");
            Assert.AreEqual(oneCallApiResponse.Daily[3].Weather[0].Description, "overcast clouds");
            Assert.AreEqual(oneCallApiResponse.Daily[3].Weather[0].Icon, "04d");
        }
    }
}