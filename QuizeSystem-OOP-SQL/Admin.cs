using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuizeSystem_OOP_SQL
{
    internal class Admin : Person
    {

        public Admin(string name, string email, string passward): base(name, email, passward) { }
       
        internal void AddCourse(string courseName,string course_category,int numberOf_lessons , float course_mounth_duration) {
            
        }
        internal void ViewAllCourses() {
            //Course Name
            //Teacher Name
            //Duration
            //Number of Lessons
            //Category
            //Number of Students
            //Number of Quizzes
            //List of Quiz Names
            //List of Student Names
        }
        internal void ViewAllStudents() {
            //Student Name
            //Student Email
            //Grade
            //Number of Courses
            //Number of Quizzes Taken
            //List of Course Names
            //List of Quiz Names
        }

        internal void ViewAllTeachers() {
            //Display the following details for each teacher:
                //Teacher Name
                //Email
                //Title
                //Number of Courses
                //Number of Quizzes Created
                //List of Course Names with their Categories
                //List of Quiz Names
        }
    }
}
