using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    internal static class Data
    {
        internal static void InitializeData()
        {
            // Admins Info
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                // generate random password from 7 digits
                string email = "admin" + i + "@gmail.com";
                Admin admin = new Admin("admin" + i, email, random.Next(11111, 111111).ToString());
                Menu.Admins.Add(admin);
                Menu.SystemPersons[email] = admin;
            }

            Menu.Admins[0].AddCourseForInitialData("Operating Systems", CourseCategory.CoumputerScience, 9, 3);
            Menu.Admins[1].AddCourseForInitialData("English", CourseCategory.Language, 12, 4);
            Menu.Admins[2].AddCourseForInitialData("Analysis and Design of Algorithms", CourseCategory.CoumputerScience, 15, 5);
            Menu.Admins[1].AddCourseForInitialData("Physics", CourseCategory.NaturalScience, 18, 6);

            Teacher teacher1 = new Teacher("Ahmed Salah", "ahmed753@gmail.com", "456iop753", TeacherTitle.Professor);
            Menu.SystemPersons["ahmed753@gmail.com"] = teacher1;
            Teacher teacher2 = new Teacher("Salsabil Amin", "salsabil7453@gmail.com", "456ioqwerty", TeacherTitle.Instructor);
            Menu.SystemPersons["salsabil7453@gmail.com"] = teacher2;
            Teacher teacher3 = new Teacher("Taha Ragab", "TahaRagab@gmail.com", "uiopop853", TeacherTitle.ProfessorAssistant);
            Menu.SystemPersons["TahaRagab@gmail.com"] = teacher3;
            teacher1.AssignToACourse(Menu.Courses[0]);
            teacher2.AssignToACourse(Menu.Courses[3]);
            teacher3.AssignToACourse(Menu.Courses[1]);

            Menu.Teachers.Add(teacher1);
            Menu.Teachers.Add(teacher2);
            Menu.Teachers.Add(teacher3);

            Student student1 = new Student("Mohamed wessim", "moo4562@gmail.com", "qwertyu");
            Menu.SystemPersons["moo4562@gmail.com"] = student1;
            Student student2 = new Student("Dalia salim", "Dalia@gmail.com", "qsdfcvb");
            Menu.SystemPersons["Dalia@gmail.com"] = student2;

            Student student3 = new Student("Ali Mohamed", "alimo2@gmail.com", "qwertyu");
            Menu.SystemPersons["alimo2@gmail.com"] = student3;

            Student student4 = new Student("Nour", "nour4562@gmail.com", "q12345tyu");
            Menu.SystemPersons["nour4562@gmail.com"] = student4;


            student1.EnrollInACourse(Menu.Courses[0]);
            student2.EnrollInACourse(Menu.Courses[0]);
            student3.EnrollInACourse(Menu.Courses[3]);
            student4.EnrollInACourse(Menu.Courses[1]);
            student1.EnrollInACourse(Menu.Courses[3]);
            student1.EnrollInACourse(Menu.Courses[1]);

            Menu.Students.Add(student1);
            Menu.Students.Add(student2);
            Menu.Students.Add(student3);
            Menu.Students.Add(student4);

        }

    }
}
