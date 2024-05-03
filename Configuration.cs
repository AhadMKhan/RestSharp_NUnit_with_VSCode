using Newtonsoft.Json;
using System;
using System.IO;

namespace RestSharpDemo
{
    public class Configuration
    {
        private const int DefaultSuccessResponseCode = 200;
        private const int DefaultCreatedResponseCode = 201;

        public string BaseUrl { get; set; } = string.Empty; // Provide default value
        public string Username { get; set; } = string.Empty; // Provide default value
        public string Password { get; set; } = string.Empty; // Provide default value
        public int SuccessResponseCode { get; set; } = DefaultSuccessResponseCode; // Provide default value
        public int CreatedResponseCode { get; set; } = DefaultCreatedResponseCode; // Provide default value

        private static readonly string AppSettingsPath = "D:/RestSharp_API/RestSharpDemo/appsettings.json";

        public static Configuration Load()
        {
            if (File.Exists(AppSettingsPath))
            {
                try
                {
                    string json = File.ReadAllText(AppSettingsPath);
                    return JsonConvert.DeserializeObject<Configuration>(json) ?? new Configuration();
                }
                catch (Exception ex)
                {
                    throw new JsonSerializationException($"Error deserializing configuration file: {ex.Message}", ex);
                }
            }
            else
            {
                throw new FileNotFoundException($"Configuration file not found at path: {AppSettingsPath}");
            }
        }
    }
}
