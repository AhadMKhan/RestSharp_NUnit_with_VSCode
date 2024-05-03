using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpDemo.Util;

namespace RestSharpDemo.API_PAGES
{
    public class DeleteBooking
    {
        public static int DeleteBookingDetails(string BaseUrl, string AuthToken, int BookingId)
        {
            var Headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                {"Cookie", $"token={AuthToken}"}
            };

            var response = APIFactory.DeleteRequest(BaseUrl, $"booking/{BookingId}", Headers);

            int responseCode = (int)response.StatusCode;
            Console.WriteLine("Booking is Deleted");

            return responseCode;
        }
    }
}
