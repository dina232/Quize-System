using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuizeSystem_OOP_SQL
{
    public enum EnteringState
    {
        Login,
        Register
    }

    internal static class OperatingClass
    {

        internal static Person Starting()
        {
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║        QUIZ MANAGEMENT SYSTEM        ║");
            Console.WriteLine("╚══════════════════════════════════════╝");

            Console.WriteLine("▶ Welcome!");
            Data.InitializeData();
            Person person = null;
            Console.WriteLine("▶ Have an account? or will you get one ?");
            while (true)
            {
                Console.WriteLine("[1] Login");
                Console.WriteLine("[2] Register");
                Console.Write("Write one : ");

                var answer = Console.ReadLine();
                if (Enum.TryParse<EnteringState>(answer, true, out EnteringState state))
                {
                    if (state == EnteringState.Login)
                    {
                        person = SystemAccessControl.ShowLoginMenu();
                    }
                    else if (state == EnteringState.Register)
                    {
                        person = SystemAccessControl.ShowRegisterMenu();
                    }
                    break;
                }
                else
                    Console.WriteLine("Please enter a correct choice");
            }
            return person;
        }

        public static void ShowMenu(Person person)
        {
            if (person is Admin admin) 
                Privileges.AdminPrivileges(admin);
            if (person is Student student)
                Privileges.StudentPrivileges(student);
            if (person is Teacher teacher)
                Privileges.TeacherPrivileges(teacher);
            return;
            
        }
        public static void OperateSystem()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Person person = Starting();

            while (true)
            {
                ShowMenu(person);
                Console.WriteLine("Do you want to continue? (y/n) ");
                var answer = Console.ReadLine();
                if (string.Equals(answer, "y", StringComparison.OrdinalIgnoreCase))
                    continue;
                else if (string.Equals(answer, "n", StringComparison.OrdinalIgnoreCase))
                    return;
                else
                    Console.WriteLine("Please enter a valid answer!");
            }
        }
    }
}