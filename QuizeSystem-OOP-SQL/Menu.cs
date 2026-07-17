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
        public static List<Course> Courses;
        public static List<Student> Students;
        public static List<Admin> Admins;
        public static List<Teacher> Teachers;

        public static Dictionary<string, Person> SystemPersons;

        internal static void ShowLoginMenu()
        {
            Console.WriteLine("Email : ");
            var email = Console.ReadLine();
            if(!CheckEmailExiestance(email))
            {
                Console.WriteLine("Invalid Email! , Please enter valid one or Sign up");
                Console.Write("Do you want to Register ? Login or Register ?");
                string answer = Console.ReadLine();
                EnteringState enum_answer;
                if(Enum.TryParse(answer,true, out enum_answer))
                {
                    if (enum_answer == EnteringState.Register)
                    {
                        ShowRegisterMenu();
                    }
                    else
                        ShowLoginMenu();

                }
                return;
            }
            Console.Write("Password : ");
            var password = Console.ReadLine();
            CheckPassword(email, password);
        }
        internal static bool CheckPassword(string email, string password)
        {
            if (SystemPersons[email].Passward == password)
                return true;
            return false;
        }

        internal static bool CheckEmailExiestance(string email)
        {
            if(SystemPersons.ContainsKey(email))
                return true;
            return false;
        }

        internal static void ShowRegisterMenu()
        {
            Console.WriteLine("Welcome to the Quiz System!");
            Console.WriteLine("1. Register as a Student");
            Console.WriteLine("2. Register as a Teacher");
            Console.WriteLine("3. Exit");
            Console.Write("Please select an option: ");
        }
        internal static void InitializeData()
        {
            // Admins Info
            for (int i = 0; i < 3; i++) {
                // generate random password from 7 digits
                Admin admin = new Admin("admin" +i, "admin"+i+"@gmail.com",);
                
            
            }


        }
        
    }
}
