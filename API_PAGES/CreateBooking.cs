using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpDemo.Util;
using System;
using System.Collections.Generic;

namespace RestSharpDemo.API_PAGES
{
    public class CreateBooking
    {
        public static (int ResponseBookingId, string Firstname, string Lastname, string AdditionalNeeds, int ResponseCode) 
            CreateNewBooking(string BaseUrl, string Firstname, string Lastname, string AdditionalNeeds)
        {
            var BodyDynamicValues = new Dictionary<string, string>
            {
                { "firstname", Firstname },
                { "lastname", Lastname },
                { "additionalneeds", AdditionalNeeds },
            };
            var Headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                {"Accept", "application/json"}
            };

            string requestBody = JsonFactory.ReplaceDynamicValues("D:/RestSharp_API/RestSharpDemo/Resources/APIsJSONs/CreateBooking.json", BodyDynamicValues);

            var response = APIFactory.PostRequest(BaseUrl, "booking", requestBody, Headers);

            Assert.That(response.IsSuccessful, Is.True, "Failed to create booking.");

            dynamic jsonResponse = null!;
            if (!string.IsNullOrEmpty(response.Content))
            {
                jsonResponse = JObject.Parse(response.Content);
            }

            int ResponseBookingId = jsonResponse?.bookingid ?? -1;
            string firstName = jsonResponse?.booking?.firstname?.ToString() ?? string.Empty;
            string lastName = jsonResponse?.booking?.lastname?.ToString() ?? string.Empty;
            string additionalNeeds = jsonResponse?.booking?.additionalneeds?.ToString() ?? string.Empty;

            Console.WriteLine("Booking Created Successful: " + ResponseBookingId);

            return (ResponseBookingId, firstName, lastName, additionalNeeds, (int)response.StatusCode);
        }
    }
}
