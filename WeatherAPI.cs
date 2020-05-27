using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Timers;
using Newtonsoft.Json;
using RestSharp;
using WeatherApiWrapper.WeatherApi;

namespace WeatherApiWrapper
{
    public class WeatherAPI
    {
        private readonly string _appId;
        private readonly int _CacheTime;
        private static readonly MemoryCache apiMemoryCache = MemoryCache.Default;

        private static string _baseUrl = "http://api.openweathermap.org/data/2.5/";

        public WeatherAPI(string AppId, int CacheTimeInMinutes)
        {
            _appId = AppId;
            _CacheTime = CacheTimeInMinutes;
        }

        private void AddItemToCache(string Type, string ApiResponse)
        {
            var CacheItemPolicy = new CacheItemPolicy()
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(_CacheTime),
            };

            apiMemoryCache.Add(Type, ApiResponse, CacheItemPolicy);
        }

        public async Task<GetWeather> GetWeatherByCity(string city)
        {
            var cityCache = city.Replace(" ", "") + "Weather";

            if (apiMemoryCache.Contains(cityCache))
            {
                var getCacheItem = apiMemoryCache.GetCacheItem(cityCache);

                if (getCacheItem != null)
                {
                    var deserializedResponseCache = JsonConvert.DeserializeObject<GetWeather>(getCacheItem.Value.ToString());
                    deserializedResponseCache.FromCache = true;
                    return deserializedResponseCache;
                }
            }

            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"weather?q={city}&appid={_appId}", Method.GET);

            var response = await client.ExecuteAsync(request);
            var responseDeserialized = await Task.Run(() => JsonConvert.DeserializeObject<GetWeather>(response.Content));

            if (responseDeserialized.Cod == 200)
            {
                AddItemToCache(cityCache, response.Content);
                responseDeserialized.FromCache = false;
                return responseDeserialized;
            }

            var weatherException = new ApplicationException($"{responseDeserialized.ErrorMessage}", response.ErrorException);
            throw weatherException;
        }

        public async Task<GetWeather> GetWeatherByCity(string city, string stateCode)
        {
            var cityCache = city.Replace(" ", "") + "Weather";

            if (apiMemoryCache.Contains(cityCache))
            {
                var getCacheItem = apiMemoryCache.GetCacheItem(cityCache);

                if (getCacheItem != null)
                {
                    var deserializedResponseCache = JsonConvert.DeserializeObject<GetWeather>(getCacheItem.Value.ToString());
                    deserializedResponseCache.FromCache = true;
                    return deserializedResponseCache;
                }
            }

            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"weather?q={city},{stateCode}&appid={_appId}", Method.GET);

            var response = await client.ExecuteAsync(request);
            var responseDeserialized = await Task.Run(() => JsonConvert.DeserializeObject<GetWeather>(response.Content));

            if (responseDeserialized.Cod == 200)
            {
                AddItemToCache(cityCache, response.Content);
                responseDeserialized.FromCache = false;
                return responseDeserialized;
            }

            var weatherException = new ApplicationException($"{responseDeserialized.ErrorMessage}", response.ErrorException);
            throw weatherException;
        }

        public async Task<GetWeather> GetWeatherByCity(string city, string stateCode, string countryCode)
        {
            string cityStringFixed = city.Replace(" ", "");

            var cityCache = cityStringFixed + "Weather";

            if (apiMemoryCache.Contains(cityCache))
            {
                var getCacheItem = apiMemoryCache.GetCacheItem(cityCache);

                if (getCacheItem != null)
                {
                    var deserializedResponseCache = JsonConvert.DeserializeObject<GetWeather>(getCacheItem.Value.ToString());
                    deserializedResponseCache.FromCache = true;
                    return deserializedResponseCache;
                }
            }

            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"weather?q={city},{stateCode},{countryCode}&appid={_appId}", Method.GET);

            var response = await client.ExecuteAsync(request);
            var responseDeserialized = await Task.Run(() => JsonConvert.DeserializeObject<GetWeather>(response.Content));

            if (responseDeserialized.Cod == 200)
            {
                AddItemToCache(cityCache, response.Content);
                responseDeserialized.FromCache = false;
                return responseDeserialized;
            }

            var weatherException = new ApplicationException($"{responseDeserialized.ErrorMessage}", response.ErrorException);
            throw weatherException;
        }

        public async Task<GetWeather> GetWeatherByLongitudeAndLatitude(long latitude, long longitude)
        {
            var WeatherCache = longitude + latitude + "Weather";

            if (apiMemoryCache.Contains(WeatherCache))
            {
                var getCacheItem = apiMemoryCache.GetCacheItem(WeatherCache);

                if (getCacheItem != null)
                {
                    var deserializedResponseCache = JsonConvert.DeserializeObject<GetWeather>(getCacheItem.Value.ToString());
                    deserializedResponseCache.FromCache = true;
                    return deserializedResponseCache;
                }
            }

            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"weather?lat={latitude}&lon={longitude}&appid={_appId}", Method.GET);

            var response = await client.ExecuteAsync(request);
            var responseDeserialized = await Task.Run(() => JsonConvert.DeserializeObject<GetWeather>(response.Content));

            if (responseDeserialized.Cod == 200)
            {
                AddItemToCache(WeatherCache, response.Content);
                responseDeserialized.FromCache = false;
                return responseDeserialized;
            }

            var weatherException = new ApplicationException($"{responseDeserialized.ErrorMessage}", response.ErrorException);
            throw weatherException;
        }

        public async Task<GetWeather> GetWeatherByCityId(long cityId)
        {
            var WeatherCache = cityId + "Weather";

            if (apiMemoryCache.Contains(WeatherCache))
            {
                var getCacheItem = apiMemoryCache.GetCacheItem(WeatherCache);

                if (getCacheItem != null)
                {
                    var deserializedResponseCache = JsonConvert.DeserializeObject<GetWeather>(getCacheItem.Value.ToString());
                    deserializedResponseCache.FromCache = true;
                    return deserializedResponseCache;
                }
            }

            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"weather?id={cityId}&appid={_appId}", Method.GET);

            var response = await client.ExecuteAsync(request);
            var responseDeserialized = await Task.Run(() => JsonConvert.DeserializeObject<GetWeather>(response.Content));

            if (responseDeserialized.Cod == 200)
            {
                AddItemToCache(WeatherCache, response.Content);
                responseDeserialized.FromCache = false;
                return responseDeserialized;
            }

            var weatherException = new ApplicationException($"{responseDeserialized.ErrorMessage}", response.ErrorException);
            throw weatherException;
        }

        public async Task<GetWeather> GetWeatherByZipCode(long zipCode, string countryCode)
        {
            var WeatherCache = zipCode + "Weather";

            if (apiMemoryCache.Contains(WeatherCache))
            {
                var getCacheItem = apiMemoryCache.GetCacheItem(WeatherCache);

                if (getCacheItem != null)
                {
                    var deserializedResponseCache = JsonConvert.DeserializeObject<GetWeather>(getCacheItem.Value.ToString());
                    deserializedResponseCache.FromCache = true;
                    return deserializedResponseCache;
                }
            }

            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"weather?zip={zipCode},{countryCode}&appid={_appId}", Method.GET);

            var response = await client.ExecuteAsync(request);
            var responseDeserialized = await Task.Run(() => JsonConvert.DeserializeObject<GetWeather>(response.Content));

            if (responseDeserialized.Cod == 200)
            {
                AddItemToCache(WeatherCache, response.Content);
                responseDeserialized.FromCache = false;
                return responseDeserialized;
            }

            var weatherException = new ApplicationException($"{responseDeserialized.ErrorMessage}", response.ErrorException);
            throw weatherException;
        }
    }
}
