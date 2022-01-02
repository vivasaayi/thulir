namespace Thulir.Weather.Models.OpenWeather
{
    public class OpenWeatherCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public double Longitude { get; set; }
        public double Lattitude { get; set; }
    }
}