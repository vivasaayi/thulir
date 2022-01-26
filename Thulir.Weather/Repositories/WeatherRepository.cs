using System;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using NpgsqlTypes;
using Thulir.Core.Dals;
using Thulir.Weather.Models;
using Thulir.Weather.Models.OpenWeather;

namespace Thulir.Weather.Repositories
{
    public class GenericTypeHandler<T> : SqlMapper.TypeHandler<T>
    {
        public GenericTypeHandler() { }
        public static JObjectHandler Instance { get; } = new JObjectHandler();
        public override T Parse(object value)
        {
            var json = value.ToString();
            return json == null ? JsonSerializer.Deserialize<T>("") : JsonSerializer.Deserialize<T>(value?.ToString());
        }
        
        public override void SetValue(IDbDataParameter parameter, T value)
        {	
            parameter.Value = JsonSerializer.Serialize(value);
            ((NpgsqlParameter)parameter).NpgsqlDbType = NpgsqlDbType.Jsonb;
        }
    }
    public class WeatherRepository : IWeatherRepository
    {
        private PostgresDal _dal;
        public WeatherRepository(PostgresDal dal)
        {
            _dal = dal;
            SqlMapper.AddTypeHandler(new GenericTypeHandler<OneCallAPIResponse>());
            SqlMapper.AddTypeHandler(new GenericTypeHandler<OWCurrentWeatherInfo>());
            SqlMapper.AddTypeHandler(new GenericTypeHandler<OWDailyWeatherForecast>());
        }
        
        public async Task SaveCurrentWeather(OneCallAPIResponse oneCallApiResponse)
        {   
            
            string command = @"UPDATE latestweather SET 
                                    city = @city, 
                                    updatedtime = @updatedtime, 
                                    currentweather = @currentweather,
                                    forecast = @forecast, 
                                    rawdata = @rawdata
                               WHERE city=@city";
            
            var result = await _dal.ExecuteQuery<OneCallAPIResponse>(command, new 
            {
                city = "abc",
                updatedtime = new DateTime(),
                currentweather = oneCallApiResponse.Current,
                forecast = oneCallApiResponse.Daily,
                rawdata = oneCallApiResponse
            });

            Console.WriteLine("Query Executed");
        }

        public async Task<OneCallAPIResponse> GetCurrentWeather(string city)
        {
            string command = "select * from latestweather where city=@city";

            var result = await _dal.ExecuteQuery<OneCallAPIResponse>(command, new 
            {
                city = city
            });
            
            return result.FirstOrDefault();
        }
    }
}