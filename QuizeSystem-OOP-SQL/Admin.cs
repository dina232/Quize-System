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
    public enum AdminPreveleges
    {
        AddCourse,
        ViewAllCourses,
        ViewAllTeachers,
        ViewAllStudents,
        LogOut
    }
    internal class Admin : Person
    {

        public Admin(string name, string email, string passward): base(name, email, passward) { }
       
        internal void AddCourse() 
        {
            CourseCategory category;
            int numberOfLessons;
            float courseMounthDuration;
            string name;
            Console.WriteLine();
            Console.WriteLine();
            while (true)
            {
                Console.Write("Enter Course Name :");
                name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) break;
                Console.WriteLine("Invalid Name!");
            }

            Console.WriteLine("Available Course Categories : Programming\nCoumputerScience\nBusiness\nLanguage\nNaturalScience\nMath");
            while (true)
            {
                Console.Write("Course Category :", ConsoleColor.Red);
                var courseStringCategory = Console.ReadLine();
                if(Enum.TryParse<CourseCategory>(courseStringCategory,true,out category))
                {
                    break;
                }
                Console.WriteLine("Invalid category! enter a valid one ");
            }
            while (true)
            {
                Console.Write("number of lessons :");
                var numberOfLessonsString = Console.ReadLine();
                if(int.TryParse(numberOfLessonsString,out numberOfLessons) && numberOfLessons > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid number! Enter a valid one");
            }
            while (true)
            {
                Console.Write("course mounth duration :");
                var courseMounthDurationString = Console.ReadLine();
                if (float.TryParse(courseMounthDurationString, out courseMounthDuration) && courseMounthDuration > 0) break;
                Console.WriteLine("Invalid Duration!");

            }
                
            Console.WriteLine("-------------------------------------");
            Course course = new Course(name, category, numberOfLessons, courseMounthDuration);
            Data.Courses[course.CourseID] = course;
        }

        internal void AddCourseForInitialData(string name , CourseCategory category, int numberOfLessons , float mounthDuration)
        {
            Course course = new Course(name, category, numberOfLessons, mounthDuration);
            Data.Courses[course.CourseID] = course;
        }
        internal void ViewAllCourses() { 
            Console.WriteLine();
            Console.WriteLine();

            string unAssignedCourse = "No Teacher Assigned yet";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var course in Data.Courses)
            {
                Console.WriteLine();
                Course c = course.Value;
                c.ViewDetails();
                Console.WriteLine($"Number of Students : {c.Students.Count}");
                Console.WriteLine("*********************************");
                Console.WriteLine($"Students :");
                for (int i = 0; i < c.Students.Count; i++)
                    Console.WriteLine($"{i+1}. {c.Students[i].Name}");

               Console.WriteLine("*********************************");
                Console.WriteLine($"Quizes");
                for (int i = 0; i < c.Quizes.Count; i++)
                    Console.WriteLine($"{i + 1}. {c.Quizes[i].QuizName}");

                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("-----------------------------------------------");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal void ViewAllStudents() 
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("All Students :");
            foreach (var student in Data.Students)
            {
                int studentCourses = student.Courses.Count;
                int studentQuizes = student.QuizeStudentAnswersAndScores.Count;
                Console.WriteLine();
                Console.WriteLine($"Student Id: {student.Id}");
                Console.WriteLine($"Name : {student.Name}");
                Console.WriteLine($"Email : {student.Email}");
                Console.WriteLine($"Grade : {(student.GetStudentGrade() is null? "Did not finish any course yet" : student.GetStudentGrade())} ",ConsoleColor.Red);
                Console.WriteLine($"Number of Courses  : {studentCourses}");
                
                Console.WriteLine($"Number of Quizzes : {studentQuizes}");
                Console.WriteLine("*********************************");
                Console.WriteLine($"Courses :");
                for (int i = 0; i < studentCourses; i++)
                    Console.WriteLine($"{i + 1}. {student.Courses[i].CourseName}");
                Console.WriteLine("*********************************");
                Console.WriteLine($"Quizes");
                for (int i = 0; i < studentQuizes; i++)
                    Console.WriteLine($"{i + 1}. {student.QuizeStudentAnswersAndScores[i].quiz.QuizName}");

                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("-----------------------------------------------");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal void ViewAllTeachers() 
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("All Teachers :");
            foreach (var teacher in Data.Teachers)
            {
                int CoursesNumber = teacher.Courses.Count;
                int QuizesNumber = 0;
                for (int i = 0; i < CoursesNumber; i++) 
                    QuizesNumber += teacher.Courses[i].Quizes.Count;

                Console.WriteLine($"Teacher id : {teacher.Id}");
                Console.WriteLine($"Name : {teacher.Name}");
                Console.WriteLine($"Email : {teacher.Email}");
                Console.WriteLine($"Title : {teacher.Title} ", ConsoleColor.Red);
                Console.WriteLine($"Number of Courses  : {CoursesNumber}");

                Console.WriteLine($"Number of Quizzes : {QuizesNumber}");

                Console.WriteLine("*********************************");
                Console.WriteLine($"Courses :");
                for (int i = 0; i < CoursesNumber; i++)
                {
                    Console.WriteLine($"Course {i + 1}. ");
                    Console.WriteLine($"Name : {teacher.Courses[i].CourseName}");
                    Console.WriteLine($"Category : {teacher.Courses[i].CourseCategory}");

                }
                Console.WriteLine("*********************************");
                Console.WriteLine($"Quizes");
                int quizeNumber = 1;
                for (int i = 0; i < teacher.Courses.Count; i++)
                {
                    for (int j = 0; j < teacher.Courses[i].Quizes.Count; j++)
                    {
                        Console.WriteLine($"{quizeNumber}. {teacher.Courses[i].Quizes[j].QuizName}");
                        quizeNumber++;
                    }
                }

                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("-----------------------------------------------");
            }
            
        }
    }
}
