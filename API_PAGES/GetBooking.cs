using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpDemo.Util;
using System;
using System.Collections.Generic;

namespace RestSharpDemo.API_PAGES
{
    public class GetBooking
    {
        public static (string FirstName, string LastName, string AdditionalNeeds, int ResponseCode)
         GetBookingDetails(string BaseUrl, int bookingId)
        {

            var Headers = new Dictionary<string, string>
            {
                {"Accept", "application/json"}
            };

            var response = APIFactory.GetRequest(BaseUrl, $"booking/{bookingId}", Headers);

            Assert.That(response.IsSuccessful, Is.True, "Error occurred while fetching booking details.");
            
            dynamic bookingDetails;
            if (!string.IsNullOrEmpty(response.Content))
            {
                bookingDetails = JObject.Parse(response.Content);
            }
            else
            {
                Console.WriteLine("Response content is null or empty.");
                return (string.Empty, string.Empty, string.Empty, (int)response.StatusCode);
            }

            string firstName = bookingDetails?.firstname?.ToString() ?? string.Empty;
            string lastName = bookingDetails?.lastname?.ToString() ?? string.Empty;
            string additionalNeeds = bookingDetails?.additionalneeds?.ToString() ?? string.Empty;

            Console.WriteLine("Verify with Get call: "
            + "\n First name: " + bookingDetails?.firstname?.ToString()
            + "\n Last name: " + bookingDetails?.lastname?.ToString()
            + "\n Additional Needs: " + bookingDetails?.additionalneeds?.ToString());

            return (firstName, lastName, additionalNeeds, (int)response.StatusCode);
        }
    }
}
