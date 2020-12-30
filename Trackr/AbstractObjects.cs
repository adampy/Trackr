using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Trackr {

    public class User {
        protected int id;
        protected string forename;
        protected string surname; // Protected attributes such that User's children can access them - Student and Teacher
        protected string username;

        public User(int id, string forename, string surname, string username) {
            /// <summary>
            /// Constructor for the base class, `User`. Sub-classes are `Student` and `Teacher`.
            /// </summary>
            this.id = id;
            this.forename = forename;
            this.surname = surname;
            this.username = username;
        }
        public virtual string DisplayName() { // Virtual means this method can be overriden 
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
        public int GetId() {
            /// <summary>
            /// Method used to encapsulate the `id` attribute.
            /// </summary>
            return id;
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
        public Student(int id, string forename, string surname, string username, int alps) : base(id, forename, surname, username) {
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

        public override string DisplayName() {
            /// <summary>
            /// Returns Title + Surname
            /// </summary>
            return this.title + " " + this.surname;
        }
    }

    public interface ITask {
        public int id { get; set; }
        public Group group { get; set; } // This field is the group ref object
        public string title { get; set; }
        public string description { get; set; }
        public int maxScore { get; set; }
        public DateTime dateDue { get; set; }
        public DateTime dateSet { get; set; }
    }

    public class Homework : ITask {
        public int id { get; set; }
        public Group group { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int maxScore { get; set; }
        public DateTime dateDue { get; set; }
        public DateTime dateSet { get; set; }
        public Student student { get; set; }
        public bool hasCompleted { get; set; }
        public Feedback feedback { get; set; }
        public Homework(int id, Group group, string title, string description, int maxScore, DateTime dateDue, DateTime dateSet, bool hasCompleted = false, Student student = null) {
            this.id = id;
            this.student = student;
            this.group = group;
            this.title = title; // make these public and access them in the TaskControl class
            this.description = description;
            this.maxScore = maxScore;
            this.dateDue = dateDue;
            this.dateSet = dateSet;
            this.hasCompleted = hasCompleted;
            this.student = student;
        }
        public static Homework[] CreateFromJsonString(string json, Student student, bool groupHardRefresh = false) {
            /// <summary>
            /// Static method that creates an array of `TaskObj` from an API response
            /// </summary>
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            Homework[] homeworks = new Homework[jsonObj.data.Count];
            for (int i = 0; i < jsonObj.data.Count; i++) {
                dynamic homeworkObj = jsonObj.data[i];
                int id = homeworkObj.id;

                string temp = homeworkObj.group.reference.link;

                Group group = Task.Run<Group>(async () => await APIHandler.GetGroup(hateoasLink: temp, hardRefresh: groupHardRefresh)).Result;
                int maxScore = homeworkObj.max_score;
                string title = homeworkObj.title;
                string description = homeworkObj.description;
                DateTime dateDue = homeworkObj.date_due;
                DateTime dateSet = homeworkObj.date_set;

                bool hasCompleted = false;
                if (homeworkObj.has_completed != null) {
                    hasCompleted = homeworkObj.has_completed;
                }

                homeworks[i] = new Homework(id, group, title, description, maxScore, dateDue, dateSet, hasCompleted: hasCompleted, student: student);
            }
            return homeworks;
        }
        public void UpdateHomeworkStatus(bool newStatus) {
            this.hasCompleted = newStatus;
            APIHandler.UpdateHomeworkStatus(this);
        }

    }

    public class Group {
        private int id;
        private Teacher teacher;
        private string name;
        private string subject;

        public Group(int id, Teacher teacher, string name, string subject) {
            this.id = id;
            this.teacher = teacher;
            this.name = name;
            this.subject = subject;
        }

        public Teacher GetTeacher() {
            return this.teacher; // TODO: Make all private attributes accessible by funcitons (encapsulation)
        }

        public static Group[] CreateFromJsonString(string json) {
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            Group[] allGroups = new Group[jsonObj.data.Count]; // The provided JSON may be an array of groups
            for (int i = 0; i < jsonObj.data.Count; i++) {
                dynamic groupObj = jsonObj.data[i]; // Get the group
                int id = groupObj.id;
                string name = groupObj.name;
                string subject = groupObj.subject;

                string hateoasLink = groupObj.teacher.reference.link;
                Task<Teacher> task = Task.Run<Teacher>(async () => await APIHandler.GetTeacher(hateoasLink: hateoasLink));
                Teacher teacher = task.Result;

                allGroups[i] = new Group(id, teacher, name, subject);
            }
            return allGroups;
        }

        public string GetName() {
            return this.name;
        }

        public string GetSubject() {
            return this.subject;
        }
    }

    public class Feedback {
        private string feedback { get; set; }
        private int score { get; set; }
        public Homework task { get; set; }
        public Feedback(Homework task, string feedback = null, int score = 0) {
            this.feedback = feedback;
            this.score = score;
            this.task = task;
        }
        public bool Exists() {
            return (this.feedback != null);
        }
        public string GetFeedback() {
            return this.feedback;
        }
        public int GetScore() {
            return this.score;
        }
    }
}
