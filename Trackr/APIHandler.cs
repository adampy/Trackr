using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Trackr {

    public static class APIHandler {
        private static Dictionary<int, Group> groupCache = new Dictionary<int, Group>();
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
        async public static Task<Teacher> GetTeacher(int id = 0, string username = null, string hateoasLink = null) {
            /// <summary>
            /// Gets all the teachers from the API, either using `id`, `username`. The first element from the query is returned.
            /// </summary>
            string extension = "";
            if (id != 0) {
                extension = "/teacher/" + id.ToString();
            } else if (username != null) {
                extension = "/teacher/" + username + "?username=True";
            } else if (hateoasLink != null) {
                extension = hateoasLink;
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
            HttpResponseMessage response = await WebRequestHandler.GET("/teacher/");
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
            if (response.StatusCode == System.Net.HttpStatusCode.Created) {
                return Teacher.CreateFromJsonString(await response.Content.ReadAsStringAsync())[0];
            } else {
                throw new HttpStatusUnauthorized();
            }
        }
        async public static Task<bool> IsTeacherUsernameTaken(string username, string adminCode) {
            /// <summary>
            /// Returns true if the username is taken, else returns false.
            /// </summary>

            Dictionary<string, string> formData = new Dictionary<string, string> {
                {"admin", adminCode },
                {"username", username }
            };

            HttpResponseMessage response = await WebRequestHandler.POST("/teacher/username", formData);

            dynamic json = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
            return json.data[0];
        }
        #endregion

        #region Tasks
        async public static Task<Homework[]> GetHomework(Student student, bool groupHardRefresh = false) {
            HttpResponseMessage response = await WebRequestHandler.GET("/task/?is_completed=True");
            Homework[] tasks = Homework.CreateFromJsonString(await response.Content.ReadAsStringAsync(), student, groupHardRefresh: groupHardRefresh);
            return tasks;
        }
        async public static void UpdateHomeworkStatus(Homework homework) {
            Dictionary<string, string> formData = new Dictionary<string, string> {
                {"completed", homework.hasCompleted.ToString().ToLower() }
            };
            HttpResponseMessage response = await WebRequestHandler.POST("/task/" + homework.id.ToString() + "/status", formData);
        }
        #endregion

        #region Groups
        async public static Task<Group> GetGroup(string hateoasLink, bool hardRefresh = false) {
            Group group;
            int id = hateoasLink[hateoasLink.Length - 1];
            bool exists = groupCache.TryGetValue(id, out group);

            // Search cache first
            if (exists) {
                if (!hardRefresh) {
                    return group;
                } else {
                    groupCache.Remove(id);
                }
            }

            // Otherwise, or if no cache wanted, send request
            HttpResponseMessage response = await WebRequestHandler.GET(hateoasLink);
            group = Group.CreateFromJsonString(await response.Content.ReadAsStringAsync())[0];
            // Add to cache
            groupCache.Add(id, group);
            return group;
        }
        #endregion

        #region Feedback
        async public static Task<Feedback> GetFeedback(Homework task) {
            /// <summary>
            /// Static method that gets feedback for the given `task` and the student stored in the Authorization header.
            /// As `Feedback` is a struct, there is no static constructor like there is with other objects, therefore JSON needs to be processed here.
            /// This may return an empty feedback structure (feedback = "None", score = "None") if feedback is not avaliable.
            /// </summary>
            HttpResponseMessage response = await WebRequestHandler.GET("/task/" + task.id.ToString() + "/status");
            string responseContent = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(responseContent);

            string feedbackString = json.data[0].feedback;
            int score = 0;
            if (json.data[0].score != null) {
                score = json.data[0].score;
            }
            Feedback feedback = new Feedback(task, feedbackString, score);
            return feedback;
        }
        #endregion
    }
}
