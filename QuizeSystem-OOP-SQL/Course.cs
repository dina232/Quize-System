using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    public enum CourseCategory
    {
        Programming,
        CoumputerScience,
        Business,
        Language,
        NaturalScience,
    }
    internal class Course
    {
        internal static int IdCounter = 0;
        internal int CourseID { get; private set; }
        internal string CourseName { get; private set; }
        internal CourseCategory CourseCategory { get; private set; }
        internal int NumberOfLessons { get; private set; }
        internal float CourseMonthDuration { get; private set; }

        internal List<Quize> Quizes;

        internal List<Student> Students;

        internal Teacher? Teacher;

        internal Course(string courseName, CourseCategory courseCategory, int numberOfLessons, float courseMonthDuration)
        {
            CourseID = IdCounter;
            IdCounter++;
            CourseName = courseName;
            CourseCategory = courseCategory;
            NumberOfLessons = numberOfLessons;
            CourseMonthDuration = courseMonthDuration;

            if (numberOfLessons < 1 || string.IsNullOrEmpty(courseName) || CourseMonthDuration < 0) throw new Exception("Invalid data");
            Students = new List<Student>();
            Quizes = new List<Quize>();


        }
        internal void ViewGeneralDetails() {
            Console.WriteLine($"Course Name: {CourseName}");
            Console.WriteLine($"Course Category: {CourseCategory}");
            Console.WriteLine($"Course Duration (Months): {CourseMonthDuration}");

        }
        internal void ViewAllDetails()
        {
            Console.WriteLine($"Course ID: {CourseID}");
            ViewGeneralDetails();
            Console.WriteLine($"Number of Lessons: {NumberOfLessons}");
            Console.WriteLine($"Number of Quizzes: {Quizes?.Count : 0}");
        }
        internal void ViewCourseStudents()
        {
            if(Students != null && Students.Count > 0)
            {
                for (int i =0;i<Students.Count;i++)
                {
                    Console.WriteLine($"Student {i + 1}: {Students[i].Name}");
                }

            }
            else
                Console.WriteLine("No students enrolled in this course.");
        }

        internal void AddQuize(Quize quize)
        {
            if (Quizes == null)
            {
                Quizes = new List<Quize>();
            }
            Quizes.Add(quize);
        }

        internal void RemoveQuize(Quize quize)
        {
            if (Quizes != null)
            {
                Quizes.Remove(quize);
            }
        }

        internal void ListQuizesNames()
        {
            if (Quizes != null && Quizes.Count > 0)
            {
                for (int i = 0; i < Quizes.Count; i++)
                {
                    Console.WriteLine($"Quize {i + 1} : {Quizes[i].QuizeName}");
                }
            }
            else
                Console.WriteLine("NO Quizes yet for this course!");
        }

        internal void AddStudent(Student student)
        {
            if (Students == null)
            {
                Students = new List<Student>();
            }
            Students.Add(student);
        }


    }
}
