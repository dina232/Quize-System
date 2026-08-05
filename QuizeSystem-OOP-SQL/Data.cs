using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    internal static class Data
    {
        public static Dictionary<int, Course> Courses = new Dictionary<int, Course>();
        public static List<Student> Students = new List<Student>();
        public static List<Admin> Admins = new List<Admin>();
        public static List<Teacher> Teachers = new List<Teacher>();

        public static Dictionary<string, Person> SystemPersons = new Dictionary<string, Person>();
        internal static void InitializeData()
        {

            // Admins Info
            Random random = new Random();
            for (int i = 1; i <= 3; i++)
            {
                // generate random password from 7 digits
                string email = "admin" + i + "@gmail.com";
                Admin admin = new Admin("admin" + i, email, "admin"+i+i+i+"admin");
                Admins.Add(admin);
                SystemPersons[email] = admin;
            }

            Admins[0].AddCourseForInitialData("Operating Systems", CourseCategory.CoumputerScience, 9, 3);
            Admins[1].AddCourseForInitialData("English", CourseCategory.Language, 12, 4);
            Admins[2].AddCourseForInitialData("Analysis and Design of Algorithms", CourseCategory.CoumputerScience, 15, 5);
            Admins[1].AddCourseForInitialData("Physics", CourseCategory.NaturalScience, 18, 6);

            Teacher teacher1 = new Teacher("Ahmed Salah", "ahmed753@gmail.com", "456iop753", TeacherTitle.Professor);
            SystemPersons["ahmed753@gmail.com"] = teacher1;
            Teacher teacher2 = new Teacher("Salsabil Amin", "salsabil7453@gmail.com", "456ioqwerty", TeacherTitle.Instructor);
            SystemPersons["salsabil7453@gmail.com"] = teacher2;
            Teacher teacher3 = new Teacher("Taha Ragab", "TahaRagab@gmail.com", "uiopop853", TeacherTitle.ProfessorAssistant);
            SystemPersons["TahaRagab@gmail.com"] = teacher3;
            teacher1.AssignToACourse(Courses[1]);
            teacher2.AssignToACourse(Courses[4]);
            teacher3.AssignToACourse(Courses[2]);

            Teachers.Add(teacher1);
            Teachers.Add(teacher2);
            Teachers.Add(teacher3);

            var quiz1= Courses[1].CreateQuize("Analysis of normal code", QuizType.ShortAnswer, 8,5, 5, true);
            quiz1.AddQuestion("Counting # steps that the algorithm takes as a function in the input size is Defenetion of :", "Running Time");
            quiz1.AddQuestion("Max dominant factor in the running time without any constants :", "Order");
            quiz1.AddQuestion("Loops Order :", "Number of iterations × body order");
            quiz1.AddQuestion("A situation (i.e. input) that leads the algorithm to behave at its worst time :", "Worst Case");
            quiz1.AddQuestion("Worst case of Linear search for an item in the array :", "O(N)");

            var quiz2 = Courses[2].CreateQuize("Grammer Quiz 1", QuizType.MultipleChoice,10,10, 5, true);
            var options1 = new string[] { "goes", "go", "going", "gone" };
            quiz2.AddQuestion("She ____ to school every day", options1,0);

            var options2 = new string[] { "play", "plays", "are playing", "played" };
            quiz2.AddQuestion("Look! The children ____ in the garden.", options2,2);

            var options3 = new string[] { "watch", "watched", "watches", "watching" };
            quiz2.AddQuestion("They ____ the movie yesterday.",options3,1);

            var options4 = new string[] {"will rain","rains", "is raining", "rain" };
            quiz2.AddQuestion("I think it ____ tomorrow.",options4,0);

            var options5 = new string[] { "an", "a", "the", "no article" };
            quiz2.AddQuestion("She is ____ honest person.",options5,0);

            var options6 = new string[] { "in", "on", "at", "to" };
            quiz2.AddQuestion("The cat is sitting ____ the table.",options6,1);

            var options7 = new string[] { "has", "have", "had", "having" };
            quiz2.AddQuestion("He ____ a lot of friends.",options7,0);

            var options8 = new string[] { "is", "are", "was", "were" }; 
            quiz2.AddQuestion("The children ____ playing in the park.",options8,1);

            var options9 = new string[] { "in", "on", "at", "by" };
            quiz2.AddQuestion("The meeting starts ____ 10 o'clock.",options9,2);

            var options10 = new string[] { "to", "for", "with", "about" };
            quiz2.AddQuestion("She is interested ____ learning new languages.",options10,0);


            var quiz3 = Courses[4].CreateQuize("Physics Basics Quiz", QuizType.TrueOrFalse,14,7, 6, true);
            quiz3.AddQuestion("Sound cannot travel through a vacuum.", "true");
            quiz3.AddQuestion("The SI unit of force is the Newton.", "true");
            quiz3.AddQuestion("The Earth is the center of the Solar System.", "false");
            quiz3.AddQuestion("Light travels faster than sound.", "true");
            quiz3.AddQuestion("An object at rest has kinetic energy.", "false");
            quiz3.AddQuestion("Gravity pulls objects toward the Earth.", "true");
            quiz3.AddQuestion("The unit of electric current is the Volt.", "false");




            // add 2 other quizes
            // add 3 students answers

            Student student1 = new Student("Mohamed wessim", "moo4562@gmail.com", "qwertyuu");
            SystemPersons["moo4562@gmail.com"] = student1;
            Student student2 = new Student("Dalia salim", "Dalia@gmail.com", "qsdfcvjb");
            SystemPersons["Dalia@gmail.com"] = student2;

            Student student3 = new Student("Ali Mohamed", "alimo2@gmail.com", "qwertytyu");
            SystemPersons["alimo2@gmail.com"] = student3;

            Student student4 = new Student("Nour", "nour4562@gmail.com", "q1234wer5tyu");
            SystemPersons["nour4562@gmail.com"] = student4;


            student1.EnrollInACourse(Courses[1]);
            student2.EnrollInACourse(Courses[1]);
            student3.EnrollInACourse(Courses[4]);
            student4.EnrollInACourse(Courses[2]);
            student1.EnrollInACourse(Courses[4]);
            student1.EnrollInACourse(Courses[2]);

            Students.Add(student1);
            Students.Add(student2);
            Students.Add(student3);
            Students.Add(student4);

            // students answers for quiz1
            var student_choices = new List<string> { "Running Time", "Order", "Number of iterations × body order", "Worst Case", "O(N2)" };
            float totalScore = 6.5f;
            var student1Quize1Details = new QuizeStudentAnswersAndScores(quiz1, totalScore, student_choices);
            student1.QuizeStudentAnswersAndScores.Add(student1Quize1Details);
            student1.Grades[0] += totalScore;

            var student2_choices = new List<string> { "Running Time", "Order", "Number of iterations × body order", "Worst Case", "O(N)" };
            totalScore = 8f;
            var student2Quize1Details = new QuizeStudentAnswersAndScores(quiz1, totalScore, student2_choices);
            student2.QuizeStudentAnswersAndScores.Add(student2Quize1Details);
            student2.Grades[0] += totalScore;

            var student1EnglishQuizchoices = new List<string> { "goes", "are playing", "watched", "will rain", "a","at","has","were","at","to"};
            totalScore = 7f;
            var student1Quize2Details = new QuizeStudentAnswersAndScores(quiz2, totalScore, student_choices);
            student1.QuizeStudentAnswersAndScores.Add(student1Quize2Details);
            student1.Grades[2] += totalScore;



        }

    }
}
