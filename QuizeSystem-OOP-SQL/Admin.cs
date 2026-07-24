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
        Add_Course,
        View_All_Course,
        View_All_Teachers,
        View_All_Students
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
            while (true)
            {
                Console.Write("Enter Course Name :");
                name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) break;
                Console.WriteLine("Invalid Name!");
            }

            Console.WriteLine("Available Course Categories : Programming\nCoumputerScience\nBusiness\nLanguage\nNaturalScience,");
            while (true)
            {
                Console.Write("Course Category :", ConsoleColor.Red);
                var courseStringCategory = Console.ReadLine();
                if(Enum.TryParse(courseStringCategory,true,out category))
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
                
            
            Course course = new Course(name, category, numberOfLessons, courseMounthDuration);
            Menu.Courses[course.CourseID] = course;
        }

        internal void AddCourseForInitialData(string name , CourseCategory category, int numberOfLessons , float mounthDuration)
        {
            Course course = new Course(name, category, numberOfLessons, mounthDuration);
            Menu.Courses[course.CourseID] = course;
        }
        internal void ViewAllCourses() {
            int courseIndex = 0;
            string unAssignedCourse = "No Teacher Assigned yet";
            foreach (var course in Menu.Courses)
            {
                Course c = course.Value;
                Console.WriteLine($"Course {courseIndex} : {c.CourseName}");
                Console.WriteLine($"Teacher : {(c.Teacher is null ? unAssignedCourse : c.Teacher.Name)}");
                Console.WriteLine($"Course Duration : {c.CourseMonthDuration} Month");
                Console.WriteLine($"Number of Lessons : {c.NumberOfLessons}");
                Console.WriteLine($"Category {c.CourseCategory}");
                Console.WriteLine($"Number of Students : {c.Students.Count}");
                Console.WriteLine($"Number of Quizzes : {c.Quizes.Count}");
                Console.WriteLine($"Students :");
                for (int i = 0; i < c.Students.Count; i++)
                    Console.WriteLine($"{i+1}. {c.Students[i].Name}");

                Console.WriteLine($"Quizes");
                for (int i = 0; i < c.Quizes.Count; i++)
                    Console.WriteLine($"{i + 1}. {c.Quizes[i].QuizeName}");

                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("-----------------------------------------------");
                courseIndex++;
            }
        }
        internal void ViewAllStudents() {
            int studentIndex = 0;
            foreach (var student in Menu.Students)
            {
                int studentCourses = student.Courses.Count;
                int studentQuizes = student.QuizeStudentAnswersAndScores.Count;
                Console.WriteLine($"Student {studentIndex}");
                Console.WriteLine($"Name : {student.Name}");
                Console.WriteLine($"Email : {student.Email}");
                Console.WriteLine($"Grade : {student.Grade} ",ConsoleColor.Red);
                Console.WriteLine($"Number of Courses  : {studentCourses}");
                
                Console.WriteLine($"Number of Quizzes : {studentQuizes}");
                Console.WriteLine($"Courses :");
                for (int i = 0; i < studentCourses; i++)
                    Console.WriteLine($"{i + 1}. {student.Courses[i].CourseName}");

                Console.WriteLine($"Quizes");
                for (int i = 0; i < studentQuizes; i++)
                    Console.WriteLine($"{i + 1}. {student.QuizeStudentAnswersAndScores[i].quize.QuizeName}");

                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("-----------------------------------------------");
                studentIndex++;
            }
            //Student Name
            //Student Email
            //Grade
            //Number of Courses
            //Number of Quizzes Taken
            //List of Course Names
            //List of Quiz Names
        }

        internal void ViewAllTeachers() {
            int teacherIndex = 0;
            foreach (var teacher in Menu.Teachers)
            {
                int CoursesNumber = teacher.Courses.Count;
                int QuizesNumber = 0;
                for (int i = 0; i < CoursesNumber; i++) 
                    QuizesNumber += teacher.Courses[i].Quizes.Count;

                Console.WriteLine($"Teacher {teacherIndex}");
                Console.WriteLine($"Name : {teacher.Name}");
                Console.WriteLine($"Email : {teacher.Email}");
                Console.WriteLine($"Title : {teacher.Title} ", ConsoleColor.Red);
                Console.WriteLine($"Number of Courses  : {CoursesNumber}");

                Console.WriteLine($"Number of Quizzes : {QuizesNumber}");
                Console.WriteLine($"Courses :");
                for (int i = 0; i < CoursesNumber; i++)
                {
                    Console.WriteLine($"Course {i + 1}. ");
                    Console.WriteLine($"Name : {teacher.Courses[i].CourseName}");
                    Console.WriteLine($"Category : {teacher.Courses[i].CourseCategory}");

                }

                Console.WriteLine($"Quizes");
                int quizeNumber = 1;
                for (int i = 0; i < teacher.Courses.Count; i++)
                {
                    for (int j = 0; j < teacher.Courses[i].Quizes.Count; j++)
                    {
                        Console.WriteLine($"{quizeNumber}. {teacher.Courses[i].Quizes[j].QuizeName}");
                        quizeNumber++;
                    }
                }

                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("-----------------------------------------------");
                teacherIndex++;
            }
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
