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

        async static public Task<HttpResponseMessage> GET(string extension) {
            HttpResponseMessage response = await client.GetAsync(apiRoot + extension);
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
        async static public Task<HttpResponseMessage> POST(string extension) {
            HttpResponseMessage response = await client.PostAsync(apiRoot + extension, new StringContent(""));
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

        static public string ConvertToBase64(string utf8) {
            /// <summary>
            /// Converts a string, `utf8`, into Base64 ready for internet transfer.
            /// </summary>

            var bytes = Encoding.UTF8.GetBytes(utf8);
            return Convert.ToBase64String(bytes);
        }

    }
}
