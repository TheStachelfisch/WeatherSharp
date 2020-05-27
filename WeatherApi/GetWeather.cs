using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherSharp.WeatherApi
{
    public class GetWeather
    {
        public bool FromCache { get; set; }

        [JsonProperty("coord")]
        public Coord Coord { get; private set; }

        [JsonProperty("weather")]
        public List<Weather> Weather { get; private set; }

        [JsonProperty("base")]
        public string Base { get; private set; }

        [JsonProperty("main")]
        public Main Main { get; private set; }

        [JsonProperty("visibility")]
        public long Visibility { get; private set; }

        [JsonProperty("wind")]
        public Wind Wind { get; private set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; private set; }

        [JsonProperty("dt")]
        public long Dt { get; private set; }

        [JsonProperty("sys")]
        public Sys Sys { get; private set; }

        [JsonProperty("timezone")]
        public long Timezone { get; private set; }

        [JsonProperty("id")]
        public long Id { get; private set; }

        [JsonProperty("name")]
        public string CityName { get; private set; }

        [JsonProperty("cod")]
        public int Cod { get; private set; }

        [JsonProperty("message")]
        public string ErrorMessage { get; private set; }
    }

    public class Coord
    {
        [JsonProperty("long")]
        public double Longitude { get; private set; }

        [JsonProperty("lat")]
        public double Latitude { get; private set; }
    }

    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("main")]
        public string MainWeather { get; private set; }

        [JsonProperty("description")]
        public string WeatherDescription { get; private set; }

        [JsonProperty("icon")]
        public string Icon { get; private set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; private set; }

        [JsonProperty("feels_like")]
        public double FeelsLikeTemperature { get; private set; }

        [JsonProperty("temp_min")]
        public double TemperatureMinimum { get; private set; }

        [JsonProperty("temp_max")]
        public double TemperatureMaximum { get; private set; }

        [JsonProperty("pressure")]
        public int Pressure { get; private set; }

        [JsonProperty("humidity")]
        public int Humidity { get; private set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double WindSpeed { get; private set; }

        [JsonProperty("deg")]
        public double Deg { get; private set; }
    }

    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; private set; }
    }

    public class Sys
    {
        [JsonProperty("type")]
        public int Type { get; private set; }

        [JsonProperty("id")]
        public long Id { get; private set; }

        [JsonProperty("country")]
        public string Country { get; private set; }

        [JsonProperty("sunrise")]
        public long Sunrise { get; private set; }

        [JsonProperty("sunset")]
        public long Sunset { get; private set; }
    }
}