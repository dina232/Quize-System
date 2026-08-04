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
        Math
    }
    public class Course : IViewable
    {
        private static int _idCounter = 1;
        public int CourseID { get; }
        public string CourseName { get; private set; }
        public CourseCategory CourseCategory { get; private set; }
        public int NumberOfLessons { get; private set; }
        public float CourseMonthDuration { get; private set; }

        public List<Quiz> Quizes;

        public List<Student> Students;

        public Teacher? Teacher;

        public bool IsFinished { get; private set; }

        internal Course(string courseName, CourseCategory courseCategory, int numberOfLessons, float courseMonthDuration)
        {
            CourseID = _idCounter;
            _idCounter++;
            CourseName = courseName;
            CourseCategory = courseCategory;
            NumberOfLessons = numberOfLessons;
            CourseMonthDuration = courseMonthDuration;
            IsFinished = false;
            if (numberOfLessons < 1 || string.IsNullOrEmpty(courseName) || CourseMonthDuration < 0) throw new Exception("Invalid data");
            Students = new List<Student>();
            Quizes = new List<Quiz>();


        }
        internal void ViewGeneralDetails() {
            Console.WriteLine($"Course Name: {CourseName}");
            Console.WriteLine($"Course Category: {CourseCategory}");
            Console.WriteLine($"Course Duration (Months): {CourseMonthDuration}");

        }
        public void ViewDetails()
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

        

        internal void ListQuizesNames()
        {
            if (Quizes != null && Quizes.Count > 0)
            {
                for (int i = 0; i < Quizes.Count; i++)
                {
                    Console.WriteLine($"Quize {i + 1} : {Quizes[i].QuizName}");
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

        internal Quiz CreateQuize(string quizeName, QuizType quizType, int totalScore,int questionsNumber, int durationInMinutes, bool isEqualInScores)
        {
            if (string.IsNullOrEmpty(quizeName)) throw new Exception("Invalid Quiz Name!");
            if (totalScore < 0 || totalScore > 100 || totalScore + Quizes.Sum(a => a.TotalScore) > 100)
                throw new Exception("Invalid Score for Quiz!");
            if(durationInMinutes <0 || durationInMinutes > 120)
                throw new Exception("Invalid duration for A Quiz!");

            Quiz quiz = new Quiz(this, quizeName, quizType, totalScore, questionsNumber, durationInMinutes, isEqualInScores);
            this.Quizes.Add(quiz);
            return quiz;
        }
    }
}
