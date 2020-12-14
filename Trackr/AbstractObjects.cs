using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Trackr {

    public class User {
        private int id;
        private string forename;
        private string surname;
        private string username;

        public User(int id, string forename, string surname, string username) {
            /// <summary>
            /// Constructor for the base class, `User`. Sub-classes are `Student` and `Teacher`.
            /// </summary>
            this.id = id;
            this.forename = forename;
            this.surname = surname;
            this.username = username;
        }
        public string DisplayName() {
            /// <summary>
            /// Returns the display name, which consists of the forename plus the first letter of the surname.
            /// </summary>
            return (forename + " " + surname[0]);
        }
        public string GetUsername() {
            /// <summary>
            /// Method used to encapsulate the private `username` attribute.
            /// </summary>
            return username;
        }
    }

    public class Student : User {
        private int alps;
        public static Student[] CreateFromJsonString(string json) {
            /// <summary>
            /// Returns an array of student objects from a JSON string.
            /// </summary>
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            Student[] students = new Student[jsonObj.data.Count];

            for (int i = 0; i < jsonObj.data.Count; i++) { // Place all students that have been returned into an array of students
                dynamic studentObj = jsonObj.data[i];
                int id = studentObj.id;
                string forename = studentObj.forename;
                string surname = studentObj.surname;
                string username = studentObj.username;
                int alps = studentObj.alps;
                Student student = new Student(id, forename, surname, username, alps);
                students[i] = student;
            }
            return students;
        }
        public Student(int id, string forename, string surname, string username, int alps) : base(id, forename, surname, username){
            /// <summary>
            /// Constructor for the sub-class, `Student`. Inherits from `User`.
            /// </summary>
            this.alps = alps;
        }
    }

    public class Teacher : User {
        private string title;
        public static Teacher[] CreateFromJsonString(string json) {
            /// <summary>
            /// Returns an array of teachers.
            /// </summary>
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            Teacher[] teachers = new Teacher[jsonObj.data.Count];

            for (int i = 0; i < jsonObj.data.Count; i++) {
                dynamic teacherObj = jsonObj.data[i];
                int id = teacherObj.id;
                string forename = teacherObj.forename;
                string surname = teacherObj.surname;
                string username = teacherObj.username;
                string title = teacherObj.title;
                Teacher teacher = new Teacher(id, forename, surname, username, title);
                teachers[i] = teacher;
            }
            return teachers;
        }
        public Teacher(int id, string forename, string surname, string username, string title) : base(id, forename, surname, username) {
            /// <summary>
            /// Constructor for the sub-class, `Teacher`. Inherits from `User`.
            /// </summary>
            this.title = title;
        }
    }
}
