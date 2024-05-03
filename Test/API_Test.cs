using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json.Linq;
using Microsoft.VisualBasic;
using RestSharpDemo.Util;

namespace RestSharpDemo.Test
{
    [TestFixture]
    public class API_Test
    {

        private Configuration _config = null!;
        private string _baseUrl = string.Empty;
        private string _username = string.Empty;
        private string _password = string.Empty;
        private int _successResponseCode;
        private int _createdResponseCode;
        
        [SetUp]
        public void Setup()
        {
            try
            {
                _config = Configuration.Load();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            _baseUrl = _config.BaseUrl;
            _username = _config.Username;
            _password = _config.Password;
            _successResponseCode = _config.SuccessResponseCode;
            _createdResponseCode = _config.CreatedResponseCode;
        }

        [Test]
        [Order(1)]
        public void Verify_Auth_Token_Is_Not_Null()
        {
            (TestVariables.DynamicAuthToken, TestVariables.DynamicResponseCode) = API_PAGES.GenerateAuthToken.GetAuthToken(_baseUrl, _username, _password);
            
            Assertions.AssertNotNull(TestVariables.DynamicAuthToken);
            Assertions.ResponseCodeAssert(TestVariables.DynamicResponseCode, _successResponseCode);
        }

        [Test]
        [Order(2)]
        public void Create_Booking_And_Verify_BookingID_Is_Not_Null()
        {
            (TestVariables.DynamicBookingId, TestVariables.DynamicFirstName, TestVariables.DynamicLastName, TestVariables.DynamicAdditionalNeeds, TestVariables.DynamicResponseCode) 
            = API_PAGES.CreateBooking.CreateNewBooking(_baseUrl, TestVariables.DefaultFirstname, TestVariables.DefaultLastname, TestVariables.DefaultAdditionalneeds);
            Assert.That(TestVariables.DynamicBookingId, Is.GreaterThan(0), "Failed to create booking.");
            Assertions.ResponseCodeAssert(_successResponseCode, TestVariables.DynamicResponseCode);
            Assertions.ResponseBodyAssert(TestVariables.DefaultFirstname, TestVariables.DynamicFirstName);
            Assertions.ResponseBodyAssert(TestVariables.DefaultLastname, TestVariables.DynamicLastName);
            Assertions.ResponseBodyAssert(TestVariables.DefaultAdditionalneeds, TestVariables.DynamicAdditionalNeeds);

        }

        [Test]
        [Order(3)]
        public void Get_Booking_Details_And_Verify_API_Success()
        {
            (TestVariables.DynamicFirstName, TestVariables.DynamicLastName, TestVariables.DynamicAdditionalNeeds, TestVariables.DynamicResponseCode) 
            = API_PAGES.GetBooking.GetBookingDetails(_baseUrl, TestVariables.DynamicBookingId);
            Assertions.ResponseCodeAssert(_successResponseCode, TestVariables.DynamicResponseCode);
            Assertions.ResponseBodyAssert(TestVariables.DefaultFirstname, TestVariables.DynamicFirstName);
            Assertions.ResponseBodyAssert(TestVariables.DefaultLastname, TestVariables.DynamicLastName);
            Assertions.ResponseBodyAssert(TestVariables.DefaultAdditionalneeds, TestVariables.DynamicAdditionalNeeds);
        }

        [Test]
        [Order(4)]
        public void TestUpdateBooking()
        {
            (TestVariables.DynamicFirstName, TestVariables.DynamicLastName, TestVariables.DynamicAdditionalNeeds, TestVariables.DynamicResponseCode) 
            = API_PAGES.UpdateBooking.UpdateBookingDetails(_baseUrl, TestVariables.DynamicAuthToken, TestVariables.DynamicBookingId, 
                                                                        TestVariables.UpdateFirstname, TestVariables.UpdateLastname, 
                                                                        TestVariables.UpdateAdditionalneeds);
            Assertions.ResponseCodeAssert(_successResponseCode, TestVariables.DynamicResponseCode);
            Assertions.ResponseBodyAssert(TestVariables.UpdateFirstname, TestVariables.DynamicFirstName);
            Assertions.ResponseBodyAssert(TestVariables.UpdateLastname, TestVariables.DynamicLastName);
            Assertions.ResponseBodyAssert(TestVariables.UpdateAdditionalneeds, TestVariables.DynamicAdditionalNeeds);
        }

        [Test]
        [Order(5)]
        public void Get_Update_Booking_Details_And_Verify_API_Success()
        {
            (TestVariables.DynamicFirstName, TestVariables.DynamicLastName, TestVariables.DynamicAdditionalNeeds, TestVariables.DynamicResponseCode) 
            = API_PAGES.GetBooking.GetBookingDetails(_baseUrl, TestVariables.DynamicBookingId);
            Assertions.ResponseCodeAssert(_successResponseCode, TestVariables.DynamicResponseCode);
            Assertions.ResponseBodyAssert(TestVariables.UpdateFirstname, TestVariables.DynamicFirstName);
            Assertions.ResponseBodyAssert(TestVariables.UpdateLastname, TestVariables.DynamicLastName);
            Assertions.ResponseBodyAssert(TestVariables.UpdateAdditionalneeds, TestVariables.DynamicAdditionalNeeds);
        }

        [Test]
        [Order(6)]
        public void TestDeleteBooking()
        {
            TestVariables.DynamicResponseCode = API_PAGES.DeleteBooking.DeleteBookingDetails(_baseUrl, TestVariables.DynamicAuthToken, TestVariables.DynamicBookingId);
            Assertions.ResponseCodeAssert( _createdResponseCode, TestVariables.DynamicResponseCode);
        }
    }
}
