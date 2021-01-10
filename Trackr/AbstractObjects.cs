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
        public string fullName { get; set; }

        public User(int id, string forename, string surname, string username) {
            /// <summary>
            /// Constructor for the base class, `User`. Sub-classes are `Student` and `Teacher`.
            /// </summary>
            this.id = id;
            this.forename = forename;
            this.surname = surname;
            this.username = username;
            this.fullName = forename + " " + surname;
        }
        public virtual string DisplayName() { // Virtual means this method can be overriden 
            /// <summary>
            /// Returns the display name, which consists of the forename plus the first letter of the surname.
            /// </summary>
            return (forename + " " + surname[0]);
        }
        public int GetId() {
            /// <summary>
            /// Method used to encapsulate the `id` attribute.
            /// </summary>
            return id;
        }
        public string GetUsername() {
            /// <summary>
            /// Method used to encapsulate the private `username` attribute.
            /// </summary>
            return username;
        }
        public string GetFullName() {
            return this.fullName;
        }
        public string GetForename() {
            return this.forename;
        }
        public string GetSurname() {
            return this.surname;
        }
        public void SetUsername(string username) {
            /// <summary>
            /// Encapsulation method that ONLY sets the username of this user object, NO API CALLS HAPPEN IN THIS METHOD.
            /// </summary>
            this.username = username;
        }
        public static bool IsPasswordValid(string password) {
            /// <summary>
            /// Returns `true` if `password` is strong enough (passes the criteria), else returns false.
            /// Criteria:
            ///     length of 8 or more
            ///     1 or more uppercase
            ///     1 or more lowercase
            ///     1 or more digits
            /// </summary>
            if (password.Length < 8) {
                return false;
            }

            bool uppercase = false;
            bool lowercase = false;
            bool digit = false;
            bool colon = false;
            foreach (char letter in password) {
                int ascii = (int)letter; // Get the ASCII representation of the character
                if (ascii >= 97 && ascii <= 122) {
                    lowercase = true;
                } else if (ascii >= 65 && ascii <= 90) {
                    uppercase = true;
                } else if (ascii >= 48 && ascii <= 57) {
                    digit = true;
                } else if (ascii == 58) { // Ensure there is no colon present as this will affect the Authorization header formatting (username:password)
                    colon = true;
                }
            }
            return (uppercase && lowercase && digit && !colon);
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
        public string GetAlpsString() {
            /// <summary>
            /// Returns an ALPs string for the students ALPs grade
            /// </summary>
            if (this.alps <= 47) {
                return "D";
            } else if (this.alps <= 52) {
                return "C/D";
            } else if (this.alps <= 58) {
                return "C";
            } else if (this.alps <= 64) {
                return "B/C";
            } else if (this.alps <= 70) {
                return "B";
            } else if (this.alps <= 75) {
                return "A";
            } else {
                return "A*/A";
            }
        }
        public int GetAlps() {
            return this.alps;
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
        /// <summary>
        ///  Implements ITask, this is the student version of a Task object.
        /// </summary>
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

    public class Assignment : ITask {
        public int id { get; set; }
        public Group group { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int maxScore { get; set; }
        public DateTime dateDue { get; set; }
        public DateTime dateSet { get; set; }
        public Assignment(int id, Group group, string title, string description, int maxScore, DateTime dateDue, DateTime dateSet) {
            this.id = id;
            this.group = group;
            this.title = title; // TODO: make these public and access them in the TaskControl class
            this.description = description;
            this.maxScore = maxScore;
            this.dateDue = dateDue;
            this.dateSet = dateSet;
        }
        public static Assignment[] CreateFromJsonString(string json) {
            /// <summary>
            /// Static method that creates an array of `TaskObj` from an API response
            /// </summary>
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            Assignment[] assignments = new Assignment[jsonObj.data.Count];
            for (int i = 0; i < jsonObj.data.Count; i++) {
                dynamic homeworkObj = jsonObj.data[i];
                int id = homeworkObj.id;

                string temp = homeworkObj.group.reference.link;

                Group group = Task.Run<Group>(async () => await APIHandler.GetGroup(hateoasLink: temp)).Result;
                int maxScore = homeworkObj.max_score;
                string title = homeworkObj.title;
                string description = homeworkObj.description;
                DateTime dateDue = homeworkObj.date_due;
                DateTime dateSet = homeworkObj.date_set;

                assignments[i] = new Assignment(id, group, title, description, maxScore, dateDue, dateSet);
            }
            return assignments;
        }
    }

    public class Group {
        private int id;
        private Teacher teacher;
        public string name { get; set; } // This needs a getter and setter because of the teacher/create task/assigned to combobox
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
        
        public int GetId() {
            return this.id;
        }
    }

    public class Feedback {
        private string feedback { get; set; }
        private int score { get; set; }
        public ITask task { get; set; }
        public Feedback(ITask task, string feedback = null, int score = 0) {
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

    public class AbstractMark {
        private bool hasMarked = false;
        private string feedback;
        private int score;

        // Oject not needed because it will cause unnecessary API calls. Only the ID is required. Student and task objects will be added afterwards.
        private int studentId;
        private int taskId;
        public Student student { get; set; }
        public ITask task { get; set; }

        public AbstractMark(int studentId, int taskId, string feedback = null, int score = 0, bool hasMarked = false){
            this.studentId = studentId;
            this.taskId = taskId;
            this.feedback = feedback;
            this.score = score;
            this.hasMarked = hasMarked;
        }
        public static AbstractMark[] CreateFromJsonString(string json) {
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            AbstractMark[] marks = new AbstractMark[jsonObj.data.Count]; // The provided JSON may be an array of marks
            
            for (int i = 0; i < jsonObj.data.Count; i++) {
                dynamic markObj = jsonObj.data[i]; // Get the mark
                bool hasMarked = markObj.has_marked;
                string feedback = markObj.feedback;
                int score = markObj.score;

                int studentId = markObj.student.reference.id;
                int taskId = markObj.task.reference.id;

                marks[i] = new AbstractMark(studentId, taskId, feedback, score, hasMarked);
            }
            return marks;
        }
        public int GetStudentId() {
            return this.studentId;
        }
        public int GetTaskId() {
            return this.taskId;
        }
        public string GetScoreString() {
            /// <summary>
            /// Returns a string for the score. If the task has not been marked then return "Not completed".
            /// </summary>
            if (this.hasMarked) {
                return this.score.ToString();
            } else {
                return "Not completed";
            }
        }
        public string GetFeedback() {
            return this.feedback;
        }
        public bool HasMarked() {
            return this.hasMarked;
        }
        public int GetScore() {
            return this.score;
        }
    }
}
