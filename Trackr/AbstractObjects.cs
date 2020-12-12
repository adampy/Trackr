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

        public User(int id, string forename, string surname) {
            this.id = id;
            this.forename = forename;
            this.surname = surname;
        }
    }

    public class Student : User {
        private int alps;

        public static Student[] CreateFromJsonString(string json) {
            /// <summary>
            /// Returns an array of student objects from a JSON string.
            /// </summary>
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            Student[] toReturn = new Student[jsonObj.data.Count];

            for (int i = 0; i < jsonObj.data.Count; i++) { // Place all students that have been returned into an array of students
                dynamic studentObj = jsonObj.data[i];
                int id = Convert.ToInt32(studentObj.id);
                string forename = studentObj.forename;
                string surname = studentObj.surname;
                int alps = studentObj.alps;
                Student student = new Student(id, forename, surname, alps);
                toReturn[i] = student;
            }
            return toReturn;
        }

        public Student(int id, string forename, string surname, int alps) : base(id, forename, surname){
            this.alps = alps;
        }
    }
}
