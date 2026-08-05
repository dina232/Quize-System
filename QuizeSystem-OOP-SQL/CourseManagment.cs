using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    public static class CourseManagment
    {
        public static void EnrollInCourse(Student student)
        {
            if(student == null) throw new NullReferenceException("student object in EnrollInCourse method");
            Console.ForegroundColor = ConsoleColor.Yellow;
            List<Course> courses = Data.Courses.Select(a => a.Value).ToList();
            Console.WriteLine();
            Console.WriteLine("Available Courses : ");
            var course = CourseManagment.ChooseCourse(Data.Courses.Where(a => a.Value.Teacher != null && !a.Value.Students.Contains(student)).Select(a => a.Value).ToList());
            if (course is null) return;
            student.EnrollInACourse(course);
            Console.WriteLine($"You have been enrolled in {course.CourseName} successfully!");
        }
        public static Course ChooseCourse(List<Course> courses)
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses available.");
                return null;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║          Available Courses           ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var course in courses)
            {
                course.ViewDetails();
                Console.WriteLine("-------------------------------");
            }
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Enter the Course ID you want to choose: ");
                var courseIdString = Console.ReadLine();
                if (int.TryParse(courseIdString, out int courseId) && courses.Any(a => a.CourseID == courseId))
                {
                    Console.ResetColor();
                    return courses.First(a => a.CourseID == courseId);
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Course ID! Please enter a valid one.");
            }


        }

        public static void ReleaseCourse(Teacher teacher)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("you can only release a course that has no students enrolled in it");
            Console.WriteLine();
            var course = CourseManagment.ChooseCourse(teacher.Courses.Where(c => c.Students.Count() == 0).ToList());
            if (course == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No course available to release");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            teacher.ReleaseCourseBasicFunc(course);
            return;
        }
    }
}
