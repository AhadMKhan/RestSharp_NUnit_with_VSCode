using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpDemo.Util;
using System;
using System.Collections.Generic;

namespace RestSharpDemo.API_PAGES
{
    public class UpdateBooking
    {
        public static (string Firstname, string Lastname, string AdditionalNeeds, int ResponseCode) 
            UpdateBookingDetails(string BaseUrl, string AuthToken, int BookingId, string Firstname, string Lastname, string Additionalneeds)
        {
            var BodyDynamicValues = new Dictionary<string, string>
            {
                { "firstname", Firstname },
                { "lastname", Lastname },
                { "additionalneeds", Additionalneeds },
            };
            var Headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                {"Accept", "application/json"},
                {"Cookie", $"token={AuthToken}"}
            };

            string requestBody = JsonFactory.ReplaceDynamicValues("D:/RestSharp_API/RestSharpDemo/Resources/APIsJSONs/UpdateBooking.json", BodyDynamicValues);
            var response = APIFactory.PutRequest(BaseUrl, $"booking/{BookingId}", requestBody, Headers);

            Assert.That(response.IsSuccessful, Is.True, "Failed to update booking.");

            dynamic jsonResponse;
            if (!string.IsNullOrEmpty(response.Content))
            {
                jsonResponse = JObject.Parse(response.Content);
            }
            else
            {
                Console.WriteLine("Response content is null or empty.");
                return (string.Empty, string.Empty, string.Empty, (int)response.StatusCode);
            }

            string firstName = jsonResponse?.firstname?.ToString() ?? string.Empty;
            string lastName = jsonResponse?.lastname?.ToString() ?? string.Empty;
            string additionalNeeds = jsonResponse?.additionalneeds?.ToString() ?? string.Empty;


            return (firstName, lastName, additionalNeeds, (int)response.StatusCode);
        }
    }
}
