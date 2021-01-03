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

        #region Abstract User
        async public static Task<bool> IsUsernameTaken(UserType user, string username, string adminCode = null) {
            /// <summary>
            /// Returns true if the username is taken, else returns false.
            /// </summary>

            if (user == UserType.Teacher && adminCode != null) {
                Dictionary<string, string> formData = new Dictionary<string, string> {
                    {"admin", adminCode },
                    {"username", username }
                };

                HttpResponseMessage response = await WebRequestHandler.POST("/teacher/username", formData);
                dynamic json = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                return json.data[0];
            } else if (user == UserType.Student) {
                Dictionary<string, string> formData = new Dictionary<string, string> {
                    { "username", username }
                };
                HttpResponseMessage response = await WebRequestHandler.POST("/student/username", formData);
                dynamic json = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                return json.data[0];
            } else {
                return false; // If incorrect params entered
            }
        }
        async public static Task<bool> EditAccountCredentials(UserType user, string newUsername = null, string newPassword = null) {
            /// <summary>
            /// Update the student which is from the Authorization header.
            /// </summary>
            Dictionary<string, string> formData = new Dictionary<string, string>();
            if (newUsername != null) {
                formData.Add("username", newUsername);
            }
            if (newPassword != null) {
                formData.Add("password", newPassword);
            }

            string url = "";
            if (user == UserType.Student) {
                url = "/student/";
            } else if (user == UserType.Teacher) {
                url = "/teacher/";
            }
            HttpResponseMessage response = await WebRequestHandler.PATCH(url, formData);

            //Now change the Authorization header
            string header = WebRequestHandler.ConvertFromBase64(WebRequestHandler.GetAuthorizationHeader());
            string[] parts = header.Split(':');
            if (newUsername != null) {
                parts[0] = newUsername;
            }
            if (newPassword != null) {
                parts[1] = newPassword;
            }
            string newHeader = parts[0] + ':' + parts[1];
            WebRequestHandler.SetAuthorizationHeader(WebRequestHandler.ConvertToBase64(newHeader));

            return response.IsSuccessStatusCode;
        }
        #endregion

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
        async public static Task<bool> ResetPassword(string username, string password) {
            Dictionary<string, string> formData = new Dictionary<string, string> {
                {"username", username },
                {"password", password }
            };

            try {
                HttpResponseMessage response = await WebRequestHandler.POST("/student/password_reset", formData);
                return response.IsSuccessStatusCode;
            } catch (HttpStatusNotFound) {
                return false;
            } catch (HttpStatusUnauthorized) {
                return false;
            }

        }
        async public static void UpdateStudent(Student student, Dictionary<string, string> formData) {
            HttpResponseMessage response = await WebRequestHandler.PATCH("/student/" + student.GetId().ToString(), formData);
        }
        async public static void CreateStudent(string forename, string surname, string username, int alps) {
            /// <summary>
            /// APIHandler method that creates a student. This method assumes that the alps is in the correct range and username has not already been taken.
            /// </summary>
            Dictionary<string, string> formData = new Dictionary<string, string> {
                { "forename", forename },
                { "surname", surname },
                { "username", username },
                { "alps", alps.ToString() }
            };
            HttpResponseMessage response = await WebRequestHandler.POST("/student/", formData);
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
        async public static void TeacherEditStudent(Student student, Dictionary<string, string> formData) {
            await WebRequestHandler.PATCH("/student/" + student.GetId().ToString(), formData);
        }
        async public static void TeacherDeleteStudentAccount(Student student) {
            await WebRequestHandler.DELETE("/student/" + student.GetId().ToString());
        }
        #endregion

        #region Tasks
        async public static Task<Homework[]> GetHomework(Student student, bool groupHardRefresh = false) {
            try {
                HttpResponseMessage response = await WebRequestHandler.GET("/task/?is_completed=True");
                Homework[] tasks = Homework.CreateFromJsonString(await response.Content.ReadAsStringAsync(), student, groupHardRefresh: groupHardRefresh);
                return tasks;
            } catch (HttpStatusNotFound) {
                return new Homework[0];
            }
        }
        async public static void UpdateHomeworkStatus(Homework homework) {
            Dictionary<string, string> formData = new Dictionary<string, string> {
                {"completed", homework.hasCompleted.ToString().ToLower() }
            };
            HttpResponseMessage response = await WebRequestHandler.POST("/task/" + homework.id.ToString() + "/status", formData); // TODO: Do I need to account for errors here?
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
        async public static Task<Group[]> TeacherGetGroups() {
            HttpResponseMessage response = await WebRequestHandler.GET("/group/?mine=True");
            Group[] groups = Group.CreateFromJsonString(await response.Content.ReadAsStringAsync());
            return groups;
        }
        async public static void UpdateGroup(Group group, Dictionary<string, string> formData) {
            HttpResponseMessage response = await WebRequestHandler.PATCH("/group/" + group.GetId().ToString(), formData);
        }
        async public static void CreateGroup(Dictionary<string, string> formData) {
            await WebRequestHandler.POST("/group/", formData);
        }
        async public static void DeleteGroup(Group group) {
            await WebRequestHandler.DELETE("/group/" + group.GetId().ToString());
        }
        async public static Task<Student[]> GetGroupStudents(Group group) {
            HttpResponseMessage response = await WebRequestHandler.GET("/group/" + group.GetId().ToString() + "/students"); // TODO: Handle 404 NOT FOUND
            return Student.CreateFromJsonString(await response.Content.ReadAsStringAsync());
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
