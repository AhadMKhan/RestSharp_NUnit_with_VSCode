using System;
using System.Collections.Generic;

namespace RestSharpDemo.Util
{
    public class JsonFactory
    {
        public static string? LoadJsonRequestBody(string jsonFilePath)
        {
            try
            {
                return System.IO.File.ReadAllText(jsonFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON file: {ex.Message}");
                return null;
            }
        }

        public static string ReplaceDynamicValues(string jsonFilePath, Dictionary<string, string> dynamicValues)
        {
            string? requestBody = LoadJsonRequestBody(jsonFilePath);
            if (requestBody != null)
            {
                foreach (var kvp in dynamicValues)
                {
                    requestBody = requestBody.Replace($"{{{kvp.Key}}}", kvp.Value);
                }
            }
            return requestBody ?? string.Empty; 
        }
    }
}
