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
            var course = Helpers.ChooseCourse(Data.Courses.Where(a => a.Value.Teacher != null && !a.Value.Students.Contains(student)).Select(a => a.Value).ToList());
            if (course is null) return;
            student.EnrollInACourse(course);
            Console.WriteLine($"You have been enrolled in {course.CourseName} successfully!");
        }
    }
}
