using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    internal class Teacher : Person 
    {
        internal List<Course> Courses;
        public Teacher(string name, string email, string passward) : base(name, email, passward) {
            Courses = new List<Course>();
        }

        internal void AssignToACourse(Course course) 
        {
            if (course is not null)
            {
                course.Teacher = this;
                Courses.Add(course);
            }
            else
                throw new ArgumentNullException("course");
        }
        internal void ViewAssignedCoursesDetails() 
        {
            if (Courses is null || Courses.Count == 0) 
            {
                Console.WriteLine("No Assigned Quizes yet!");
                return;
            }
            for (int i = 0; i < Courses.Count; i++)
            {
                Console.WriteLine($"Course {i+1}");
                Console.WriteLine($"Name : {Courses[i].CourseName}");
                Console.WriteLine($"Category : {Courses[i].CourseCategory}");
                Console.WriteLine($"Number Of Lessons : {Courses[i].NumberOfLessons}");
                Console.WriteLine($"Duration : {Courses[i].CourseMonthDuration} months");
                Console.WriteLine($"Current Quizes number : {Courses[i].Quizes.Count}");

            }

        }
        internal bool CheckCourseExistanceInTeacherCourses(Course course)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (course.CourseID == Courses[i].CourseID)
                    return true;
            }
            return false;
        }
        internal void ViewUnAssignedCourses() 
        {
            int course_number = 1;
            for(int i = 0;i < Menu.Courses.Count; i++)
            {
                if (!CheckCourseExistanceInTeacherCourses(Menu.Courses[i]))
                {
                    Console.WriteLine($"Course {course_number}");
                    Console.WriteLine($"Name : {Menu.Courses[i].CourseName}");
                    Console.WriteLine($"Category : {Menu.Courses[i].CourseCategory}");
                    Console.WriteLine($"Duration : {Menu.Courses[i].CourseMonthDuration} months");
                    course_number++;
                }
            }

        
        }
        internal void ReleaseCourse(Course course)
        { 
            if (course.Students is null || course.Students.Count == 0)
            {

            }
        
        }



    }
}
