using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharpDemo.Util;
using System;
using System.Collections.Generic;

namespace RestSharpDemo.API_PAGES
{
    public class GenerateAuthToken
    {
        public static (string authToken, int responseCode) GetAuthToken(string baseUrl, string username, string password)
        {
            var dynamicValues = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };
            string requestBody = JsonFactory.ReplaceDynamicValues("D:/RestSharp_API/RestSharpDemo/Resources/APIsJSONs/AuthTokenBody.json", dynamicValues);

            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" }
            };

            var response = APIFactory.PostRequest(baseUrl, "auth", requestBody, headers);

            if (response.IsSuccessful && response.Content != null)
            {
                var jsonResponse = JObject.Parse(response.Content);

                var authToken = jsonResponse["token"]?.ToString();
                Console.WriteLine("Auth Token: "+authToken);

                return (authToken ?? string.Empty, (int)response.StatusCode); // Ensure authToken is not nullable
            }
            else
            {
                Console.WriteLine("Error occurred while generating auth token.");
                return (string.Empty, response.IsSuccessful ? (int)response.StatusCode : -1); // Provide default values
            }
        }
    }
}
