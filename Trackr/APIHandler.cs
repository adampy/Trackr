using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Trackr {
    public static class APIHandler {
        public static void SetAuthorizationHeader(string credentials) { // TODO: Give <summary> to all methods
            WebRequestHandler.SetAuthorizationHeader(credentials);
        }

        async public static Task<Student> GetStudent(int id = 0, string username = null) {
            string extension = "";
            if (id != 0) {
                extension = "/student/" + id.ToString();
            } else if (username != null) {
                extension = "/student/" + username + "?username=True";
            } else {
                return null;
            }

            HttpResponseMessage response = await WebRequestHandler.GET(extension);
            Student student = Student.CreateFromJsonString(await response.Content.ReadAsStringAsync())[0]; // Get the first student from the students
            return student;
        }
    }
}
