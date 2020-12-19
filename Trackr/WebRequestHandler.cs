using System;
using System.Collections.Generic;
using System.Linq; // TODO: Remove unnecessary `using` statements
using System.Text;
using System.Threading.Tasks;
using System.Net.Http; // Necessary library for web requests

namespace Trackr {
    
    public static class WebRequestHandler {
        private readonly static HttpClient client = new HttpClient();
        private readonly static string apiRoot = @"https://homework-tracker-nea.herokuapp.com";

        static public void SetAuthorizationHeader(string credentials) {
            client.DefaultRequestHeaders.Remove("Authorization");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", credentials);
        }
        static public string ConvertToBase64(string utf8) {
            /// <summary>
            /// Converts a string, `utf8`, into Base64 ready for internet transfer.
            /// </summary>

            var bytes = Encoding.UTF8.GetBytes(utf8);
            return Convert.ToBase64String(bytes);
        }
        async static public Task<HttpResponseMessage> GET(string extension) {
            /// <summary>
            /// Sends a GET request to `the API root + extension`.
            /// HttpStatusNotFound or HttpStatusUnauthorized exceptions may be thrown here.
            /// </summary>
            HttpResponseMessage response = await client.GetAsync(apiRoot + extension);
            //return response;
            if (response.IsSuccessStatusCode) {
                return response;
            } else if (response.StatusCode == System.Net.HttpStatusCode.NotFound) {
                throw new HttpStatusNotFound();
            } else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) {
                throw new HttpStatusUnauthorized();
            } else {
                throw new HttpRequestException("Unexpected HTTP error, status code " + response.StatusCode.ToString());
            }
        }
        async static public Task<HttpResponseMessage> POST(string extension, Dictionary<string, string> formData) {
            /// <summary>
            /// Sends a POST request to `the API root + extension`. Form-data may be given as `formData`.
            /// </summary>
            var content = new FormUrlEncodedContent(formData);
            HttpResponseMessage response = await client.PostAsync(apiRoot + extension, content);
            //return response;
            
            if (response.IsSuccessStatusCode) {
                return response;
            } else if (response.StatusCode == System.Net.HttpStatusCode.NotFound) {
                throw new HttpStatusNotFound();
            } else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) {
                throw new HttpStatusUnauthorized();
            } else {
                throw new HttpRequestException("Unexpected HTTP error, status code " + response.StatusCode.ToString());
            }
        }        
    }
}
