using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spaetzel.RpxDA
{
    public static class Config
    {
        private static string _apiKey;

        internal static string ApiKey
        {
            get { return Config._apiKey; }

        }
        private static string _baseUrl;

        internal static string BaseUrl
        {
            get { return Config._baseUrl; }
 
        }

        public static void SetConfigurations(string apiKey, string baseUrl)
        {
            _apiKey = apiKey;

            _baseUrl = baseUrl;

            while (_baseUrl.EndsWith("/"))
                _baseUrl = _baseUrl.Substring(0, _baseUrl.Length - 1);

            
        }


    }
}
