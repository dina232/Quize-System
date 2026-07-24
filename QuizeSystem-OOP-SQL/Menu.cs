using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    public enum EnteringState
    {
        Login,
        Register
    }


    internal static class Menu
    {
        public static Dictionary<int, Course> Courses;
        public static List<Student> Students;
        public static List<Admin> Admins;
        public static List<Teacher> Teachers;

        public static Dictionary<string, Person> SystemPersons;

        internal static void Starting()
        {
            Console.WriteLine("Welcome to the Quiz System!");
            Console.WriteLine("Have an account? or will you get one ?");
            Console.ForegroundColor = ConsoleColor.Red;
            while (true)
            {
                Console.Write("Login or Register ? Write one : ");
                var answer = Console.ReadLine();
                if (Enum.TryParse<EnteringState>(answer, true, out EnteringState state))
                {
                    if (state == EnteringState.Login)
                    {
                        SystemAccessControl.ShowLoginMenu();
                    }
                    else if (state == EnteringState.Register)
                    {
                        SystemAccessControl.ShowRegisterMenu();
                    }
                    break;
                }
                else
                    Console.WriteLine("Please enter a correct choice");
            }
        }

        internal static void AdminPrivileges(Admin admin)
        {
            Console.WriteLine($"Welcome {admin.Name}", ConsoleColor.Red);
            Console.WriteLine("What do you need to do now ?");
            Console.WriteLine("1.Add Course (Add_Course)");
            Console.WriteLine("2.View All Course (View_All_Course) ");
            Console.WriteLine("3.View All Teachers (View_All_Teachers)");
            Console.WriteLine("4.View All Students (View_All_Students)");

            var answer = Console.ReadLine();
            if (Enum.TryParse<AdminPreveleges>(answer, false, out AdminPreveleges desire))
            {
                switch (desire)
                {
                    case (AdminPreveleges.Add_Course):
                        admin.AddCourse();
                        break;
                    case (AdminPreveleges.View_All_Course):
                        admin.ViewAllCourses();
                        break;
                    case (AdminPreveleges.View_All_Students):
                        admin.ViewAllStudents();
                        break;
                    case (AdminPreveleges.View_All_Teachers):
                        admin.ViewAllTeachers();
                        break;
                }
            }




        }
    }
}
