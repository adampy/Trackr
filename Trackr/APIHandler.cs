using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Trackr {
    public static class APIHandler {
        public static void SetAuthorizationHeader(string credentials) {
            /// <summary>
            /// Subroutine that sets the Authorization header of the WebRequestHandler.
            /// </summary>
            WebRequestHandler.SetAuthorizationHeader(credentials);
        }

        #region Students
        async public static Task<Student> GetStudent(int id = 0, string username = null) {
            /// <summary>
            /// Gets all the students from the API, either using `id`, `username`. The first element from the query is returned.
            /// </summary>
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
        async public static Task<Student[]> GetAllStudents() {
            /// <summary>
            /// Gets all the students from the API.
            /// </summary>
            HttpResponseMessage response = await WebRequestHandler.GET("/student/");
            Student[] students = Student.CreateFromJsonString(await response.Content.ReadAsStringAsync());
            return students;
        }
        #endregion

        #region Teachers
        async public static Task<Teacher> GetTeacher(int id = 0, string username = null) {
            /// <summary>
            /// Gets all the teachers from the API, either using `id`, `username`. The first element from the query is returned.
            /// </summary>
            string extension = "";
            if (id != 0) {
                extension = "/teacher/" + id.ToString();
            } else if (username != null) {
                extension = "/teacher/" + username + "?username=True";
            } else {
                return null;
            }

            HttpResponseMessage response = await WebRequestHandler.GET(extension);
            Teacher teacher = Teacher.CreateFromJsonString(await response.Content.ReadAsStringAsync())[0]; // Get the first teacher
            return teacher;
        }
        async public static Task<Teacher[]> GetAllTeachers() {
            /// <summary>
            /// Gets all the teachers from the API.
            /// </summary>
            HttpResponseMessage response = await WebRequestHandler.GET("teacher/");
            Teacher[] teachers = Teacher.CreateFromJsonString(await response.Content.ReadAsStringAsync());
            return teachers;
        }
        async public static Task<Teacher> MakeTeacher(string forename, string surname, string username, string password, string title, string adminCode = null) {
            /// <summary>
            /// Makes a new teacher by sending POST /teacher to the API. `adminCode` is neccessary unless Authorization header is set to a teacher.
            /// </summary>

            Dictionary<string, string> formData = new Dictionary<string, string> {
                {"forename", forename },
                {"surname", surname },
                {"username", username },
                {"password", password },
                {"title", title }
            };

            if (adminCode != null) {
                formData["admin"] = adminCode;
            }

            HttpResponseMessage response = await WebRequestHandler.POST("/teacher/", formData);
            return Teacher.CreateFromJsonString(await response.Content.ReadAsStringAsync())[0];
        }
        async public static Task<bool> IsTeacherUsernameTaken(string username, string adminCode) {
            /// <summary>
            /// Returns true if the username is taken, else returns false.
            /// </summary>

            Dictionary<string, string> formData = new Dictionary<string, string> {
                {"admin", adminCode }
            };

            HttpResponseMessage response = await WebRequestHandler.POST("/teacher/username/" + username, formData);
            dynamic json = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
            return json.data[0];
        }
        #endregion
    }
}
