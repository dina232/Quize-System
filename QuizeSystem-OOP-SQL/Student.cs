using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    internal class Student : Person 
    {
        public Student(string name, string email, string passward) : base(name, email, passward) { }

        internal List<Course> courses;
        internal List<QuizeStudentAnswersAndScores> quizeStudentAnswersAndScores;
        internal void EnrollInACourse(Course course) { }
        internal void ViewEnrolledCoursesDetailsAndQuizes() { }
        internal void TakeQuize(Quize quize) { }

        internal void ViewAllCourses() { }

        
    }
}
