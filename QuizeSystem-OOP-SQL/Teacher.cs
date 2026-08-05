using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    public enum TeacherPreveleges
    {
        AssignYourselfToACourse,
        ViewAssignedCoursesDetails,
        ReleaseCourse,
        ViewUnAssignedCourses,
        CreateQuize,
        AddQuestionToQuize,
        RemoveQuestionFromQuize,
        LogOut
    }
    public enum TeacherTitle
    {
        Professor,
        ProfessorAssistant,
        Instructor
    }
    public class Teacher : Person 
    {
        internal TeacherTitle Title;
        internal List<Course> Courses;
        public Teacher(string name, string email, string passward , TeacherTitle title) : base(name, email, passward) {
            Courses = new List<Course>();
            Title = title;
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
                Console.WriteLine("No Assigned Courses yet!");
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
        internal List<int> ViewUnAssignedCourses() 
        {
            int course_number = 1;
            var ids = new List<int>();
            for(int i = 0;i < Data.Courses.Count; i++)
            {
                if (!CheckCourseExistanceInTeacherCourses(Data.Courses[i]))
                {
                    Console.WriteLine($"Id : {Data.Courses[i].CourseID}");
                    Console.WriteLine($"Course {course_number}");
                    Console.WriteLine($"Name : {Data.Courses[i].CourseName}");
                    Console.WriteLine($"Category : {Data.Courses[i].CourseCategory}");
                    Console.WriteLine($"Duration : {Data.Courses[i].CourseMonthDuration} months");
                    ids.Add( i );
                    course_number++;
                }
            }

            return ids;
        }
        
        internal void ReleaseCourse(Course course)
        {
            if (course.Students is null) throw new ArgumentNullException("course");
            if(course.Students.Count == 0)
            {
                course.Teacher = null;
                Courses.Remove(course);
                Console.WriteLine("Course released successfully!");
                return;
            }
            Console.WriteLine("Can not release a course that has students enrolled in it!");
        }
    }
}
