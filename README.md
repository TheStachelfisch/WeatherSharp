# WeatherSharp
WeatherSharp is a [api.openweathermap.org](api.openweathermap.org) C# Wrapper

Currently there is only Current Weather time, soon Forecast and historical weather data will be added


Example Usage:
```
    public class WeatherExample
    {
        static void main()
        {
            var WeatherApi = new WeatherAPI(YourOpenWeatherApiKey, CacheTimeInMinutes);

            var getWeatherByCity = WeatherApi.GetWeatherByCity("London"); //Optionally: also state code and country code
            Console.WriteLine(getWeatherByCity.Result.Main.Temperature);

            var getWeatherByLongitudeAndLatitude = WeatherApi.GetWeatherByLongitudeAndLatitude(35, 139);
            Console.WriteLine(getWeatherByLongitudeAndLatitude.Result.Weather[0].MainWeather);

            var getWeatherByCityId = WeatherApi.GetWeatherByCityId(2172797);
            Console.WriteLine(getWeatherByCityId.Result.CityName);

            var getWeatherByZipCode = WeatherApi.GetWeatherByZipCode(94040, "us");
            Console.WriteLine(getWeatherByZipCode.Result.Clouds);
        }
    }
```
TODO: Forecast, Block weather, Historical weather
