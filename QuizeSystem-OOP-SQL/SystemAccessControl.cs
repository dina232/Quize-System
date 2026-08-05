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
        internal static Person ShowLoginMenu()
        {
            Console.Write("Email : ");
            var email = Console.ReadLine();
            if (email == null || !Helpers.CheckEmailExiestance(email))
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
                            return ShowRegisterMenu();
                        else
                            return ShowLoginMenu();
                    }
                    else
                        Console.Write("Invalid input. Please enter 'Login' or 'Register' : ");
                }
            }
            while (true)
            {
                Console.Write("Password : ");
                var password = Console.ReadLine();
                if (Helpers.CheckPassword(email, password))
                    return Data.SystemPersons[email];
                Console.WriteLine("Wrong Password!Do you want to Try write it Again ? [y/n]");
                while (true)
                {
                    var answer = Console.ReadLine();
                    if (string.Equals(answer, "y", StringComparison.OrdinalIgnoreCase))
                        break;
                    else if (string.Equals(answer, "n", StringComparison.OrdinalIgnoreCase))
                        OperatingClass.Starting();
                    else
                        Console.WriteLine("Please enter a valid answer!");
                }
                    
            }
        }
        
        internal static Person ShowRegisterMenu()
        {
            Console.WriteLine("1. Register as a Student");
            Console.WriteLine("2. Register as a Teacher");
            
            Role role;
            string email , password , name ;
            while (true)
            {
                Console.Write("Please select an option (student or teacher ): ");
                var roleInput = Console.ReadLine();
                if (Enum.TryParse<Role>(roleInput, true, out role))
                {
                    Helpers.TakeRegestrationBasicInfo(out email, out password, out name);
                    if (role == Role.Student)
                    {
                        Student student = new Student(name, email, password);
                        Data.Students.Add(student);
                        Data.SystemPersons[email] = student;
                        Console.WriteLine("Registered Successfully!");
                        Privileges.StudentPrivileges(student);
                        return student;
                    }
                    else if (role == Role.Teacher)
                    {
                        TeacherTitle title;
                        while (true)
                        {
                            Console.Write("Your Title (Professor, ProfessorAssistant or Instructor): ");
                            var titleString = Console.ReadLine();
                            if (Enum.TryParse<TeacherTitle>(titleString, true, out title))
                            {
                                break;
                            }
                            Console.WriteLine("Invalid title. Please enter a valid title.");
                            
                        }
                        Teacher teacher = new Teacher(name, email, password, title);
                        Data.Teachers.Add(teacher);
                        Data.SystemPersons[email] = teacher;
                        Console.WriteLine("Registered Successfully!");
                        Privileges.TeacherPrivileges(teacher);
                        return teacher;
                    }

                }
                Console.WriteLine("Please Enter A valid Role!");
            }
        }
    }
}
