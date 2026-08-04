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

        }

    }
}
