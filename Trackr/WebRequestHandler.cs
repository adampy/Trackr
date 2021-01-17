using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http; // Necessary library for web requests

namespace Trackr {
    
    public static class WebRequestHandler {
        private readonly static HttpClient client = new HttpClient();
        private readonly static string apiRoot = @"https://homework-tracker-nea.herokuapp.com";
        private static string authorizationHeader;

        static public void SetAuthorizationHeader(string credentials) {
            client.DefaultRequestHeaders.Remove("Authorization");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", credentials);
            authorizationHeader = credentials;
        }
        static public string GetAuthorizationHeader() {
            return authorizationHeader;
        }
        static public string ConvertToBase64(string utf8) {
            /// <summary>
            /// Converts a string, `utf8`, into Base64 ready for internet transfer.
            /// </summary>

            var bytes = Encoding.UTF8.GetBytes(utf8);
            return Convert.ToBase64String(bytes);
        }
        static public string ConvertFromBase64(string b64) {
            /// <summary>
            /// Converts a string, `b64`, into UTF8.
            /// </summary>
            var bytes = Convert.FromBase64String(b64);
            return Encoding.UTF8.GetString(bytes);
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

        //https://stackoverflow.com/questions/26218764/patch-async-requests-with-windows-web-http-httpclient-class - used for guidance
        async public static Task<HttpResponseMessage> PATCH(string extension, Dictionary<string, string> formData) {
            
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, apiRoot + extension);
            var content = new FormUrlEncodedContent(formData);
            request.Content = content;
            HttpResponseMessage response = new HttpResponseMessage();
            
            response = await client.SendAsync(request); // TODO: try catch for patch requests
            return response;
        }

        async public static Task<HttpResponseMessage> DELETE(string extension) {
            HttpResponseMessage response = await client.DeleteAsync(apiRoot + extension);
            return response;
        }
    }
}
