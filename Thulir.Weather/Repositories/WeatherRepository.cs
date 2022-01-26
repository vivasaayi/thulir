using System;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using NpgsqlTypes;
using Thulir.Core.Dals;
using Thulir.Weather.Models.OpenWeather;

namespace Thulir.Weather.Repositories
{
    public class OneCallAPIResponseHandler : SqlMapper.TypeHandler<OneCallAPIResponse>
    {
        public OneCallAPIResponseHandler() { }
        public static JObjectHandler Instance { get; } = new JObjectHandler();
        public override OneCallAPIResponse Parse(object value)
        {
            var json = value.ToString();
            return json == null ? null : JsonSerializer.Deserialize<OneCallAPIResponse>(value?.ToString());
        }
        
        public override void SetValue(IDbDataParameter parameter, OneCallAPIResponse value)
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
            SqlMapper.AddTypeHandler(new OneCallAPIResponseHandler());
        }
        
        public async Task SaveCurrentWeather(OneCallAPIResponse oneCallApiResponse)
        {   
            
            string command = @"insert into latestweather(city, updatedtime, currentweather, forecast, rawdata) 
                               values (@city, @updatedtime, @currentweather, @forecast, @rawdata)";
            
            var result = await _dal.ExecuteQuery<OneCallAPIResponse>(command, new 
            {
                city = "abc",
                updatedtime = new DateTime(),
                currentweather = oneCallApiResponse,
                forecast = oneCallApiResponse,
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