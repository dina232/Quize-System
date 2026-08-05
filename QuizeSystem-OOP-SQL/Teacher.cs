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
            if (Courses.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Assigned Courses yet!");
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║            Your Courses              ║");
                Console.WriteLine("╚══════════════════════════════════════╝");

                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int i = 0; i < Courses.Count; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Course {i + 1}");
                    Console.WriteLine($"Name : {Courses[i].CourseName}");
                    Console.WriteLine($"Category : {Courses[i].CourseCategory}");
                    Console.WriteLine($"Number Of Lessons : {Courses[i].NumberOfLessons}");
                    Console.WriteLine($"Duration : {Courses[i].CourseMonthDuration} months");
                    Console.WriteLine($"Current Quizes number : {Courses[i].Quizes.Count}");
                    Console.WriteLine();
                    Console.WriteLine("──────────────────────────────────────");
                    Console.WriteLine("──────────────────────────────────────");

                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
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
            var courses = Data.Courses.Where(a => !Courses.Contains(a.Value)).Select(a => a.Value).ToList();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║           UnAssigned Courses         ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var course in courses) 
            {
                    Console.WriteLine($"Course {course_number}");
                    Console.WriteLine($"Name : {course.CourseName}");
                    Console.WriteLine($"Id : {course.CourseID}");
                    Console.WriteLine($"Category : {course.CourseCategory}");
                    Console.WriteLine($"Duration : {course.CourseMonthDuration} months");
                    course_number++;
                    Console.WriteLine();
                    Console.WriteLine("──────────────────────────────────────");
                    Console.WriteLine("──────────────────────────────────────");
                    Console.WriteLine();

            }
            Console.ForegroundColor = ConsoleColor.Green;

        }

        internal void ReleaseCourseBasicFunc(Course course)
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
