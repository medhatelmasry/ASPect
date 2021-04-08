using System;

namespace BlazorClient
{
    public class Constants
    {
        public partial class API
        {
            public static string DEV_URL = "https://localhost:5001/api";
            public static string PRODUCTION_URL = "https://openaspect.azurewebsites.net/api";

            public static bool IS_DEVELOPMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

            public static string API_URL = IS_DEVELOPMENT ? DEV_URL : PRODUCTION_URL;
        }
    }
}