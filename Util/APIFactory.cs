using RestSharp;
using System;
using System.Collections.Generic;

namespace RestSharpDemo.Util
{
    public class APIFactory
    {
        public static RestResponse PostRequest(string baseUrl, string resourceUrl, string requestBody, Dictionary<string, string> headers)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resourceUrl, Method.Post);

            // Add headers
            foreach (var header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            // Add request body
            request.AddParameter("application/json", requestBody, ParameterType.RequestBody);

            // Execute request
            var response = client.Execute(request);
            return response;
        }

        public static RestResponse GetRequest(string baseUrl, string resourceUrl, Dictionary<string, string> headers)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resourceUrl, Method.Get);

            // Add headers
            foreach (var header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            // Execute request
            var response = client.Execute(request);
            return response;
        }

        public static RestResponse PutRequest(string baseUrl, string resourceUrl, string requestBody, Dictionary<string, string> headers)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resourceUrl, Method.Put);

            // Add headers
            foreach (var header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            // Add request body
            request.AddParameter("application/json", requestBody, ParameterType.RequestBody);

            // Execute request
            var response = client.Execute(request);
            return response;
        }

        public static RestResponse DeleteRequest(string baseUrl, string resourceUrl, Dictionary<string, string> headers)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resourceUrl, Method.Delete);

            // Add headers
            foreach (var header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            // Execute request
            var response = client.Execute(request);
            return response;
        }
    }
}
