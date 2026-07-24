using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuizeSystem_OOP_SQL
{
    public enum Role
    {
        Student,
        Teacher
    }
    internal static class SystemAccessControl
    {
        internal static void ShowLoginMenu()
        {
            Console.Write("Email : ");
            var email = Console.ReadLine();
            if (!CheckEmailExiestance(email))
            {
                Console.WriteLine("Invalid Email! , Please enter valid one or Sign up");
                Console.Write("Do you want to Register ? Login or Register ?");
                while (true)
                {
                    string answer = Console.ReadLine();
                    EnteringState enum_answer;
                    if (Enum.TryParse(answer, true, out enum_answer ))
                    {
                        if (enum_answer == EnteringState.Register)
                        {
                            ShowRegisterMenu();
                        }
                        else
                            ShowLoginMenu();
                        break;
                    }
                    else
                        Console.Write("Invalid input. Please enter 'Login' or 'Register' : ");
                }
                return;
            }
            Console.Write("Password : ");
            var password = Console.ReadLine();
            CheckPassword(email, password);
        }
        internal static bool CheckPassword(string email, string password)
        {
            if (Menu.SystemPersons[email].Passward == password)
                return true;
            return false;
        }

        internal static bool CheckEmailExiestance(string email)
        {
            if (Menu.SystemPersons.ContainsKey(email))
                return true;
            return false;
        }

        internal static void  TakeRegestrationBasicInfo(out string email , out string password , out string name)
        {
            while (true)
            {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();
                if (name.Length < 2 || name == null)
                {
                    Console.WriteLine("Invalid. Please enter a valid name.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Enter your email: ");
                email = Console.ReadLine();
                if (email.Length < 7 || email == null || !email.Contains('@')) 
                {
                    Console.WriteLine("Invalid. Please enter a valid email.");
                    continue;
                }
                if(Menu.SystemPersons.ContainsKey(email))
                {
                    Console.WriteLine("This Email Already Exists. Please enter a different email.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Enter your password: ");
                password = Console.ReadLine();
                if (password.Length < 8 || password == null)
                {
                    Console.WriteLine("passward must be at least 8 charachter length. Please enter a valid email.");
                    continue;
                }
                break;
            }   
        }
        internal static void ShowRegisterMenu()
        {
            Console.WriteLine("1. Register as a Student");
            Console.WriteLine("2. Register as a Teacher");
            Console.Write("Please select an option (student or teacher ): ");
            var roleInput = Console.ReadLine();
            Role role;
            string email , password , name ;
            if (Enum.TryParse(roleInput,true,out role)) 
            {
                if (role == Role.Student)
                {
                    TakeRegestrationBasicInfo(out email, out password, out name);
                    Student student = new Student(name, email, password);
                    Menu.Students.Add(student); 
                    Menu.SystemPersons[email] = student;
                }
                else if (role == Role.Teacher)
                {
                    TakeRegestrationBasicInfo(out email, out password, out name);
                    TeacherTitle title;
                    while (true)
                    {
                        Console.Write("Your Title (Professor, ProfessorAssistant or Instructor): ");
                        var titleString = Console.ReadLine();
                        if (Enum.TryParse(titleString, true, out title))
                        {
                            Console.WriteLine("Invalid title. Please enter a valid title.");
                            continue ;
                        }
                        break;
                    }
                    Teacher teacher = new Teacher(name, email, password,title);
                    Menu.Teachers.Add(teacher);
                    Menu.SystemPersons[email] = teacher;
                }
            }

        }
    }
}
