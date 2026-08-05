using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    public static class Helpers
    {

        public static string GetTrueFalseAnswer()
        {
            while (true)
            {
                Console.Write("Answer (true/false): ");
                string answer = Console.ReadLine();

                if (bool.TryParse(answer, out bool _))
                {
                    return answer;
                }
                Console.WriteLine("Invalid input. Please enter 'true' or 'false'.");
            }
        }

        public static string ValidateUserStringAnswer(string statmentToPrint)
        {
            string answer;
            while (true)
            {
                Console.Write($"{statmentToPrint} : ");
                answer = Console.ReadLine();
                if (!string.IsNullOrEmpty(answer)) break;
                Console.WriteLine("Please enter a valid answer!");
            }
            return answer;
        }
        public static bool CheckPassword(string email, string password)
        {
            if (Data.SystemPersons.ContainsKey(email) && Data.SystemPersons[email].Passward == password)
                return true;
            return false;
        }

        public static bool CheckEmailExiestance(string email)
        {
            if (Data.SystemPersons.ContainsKey(email))
                return true;
            return false;
        }

        public static void TakeRegestrationBasicInfo(out string email, out string password, out string name)
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
                if (CheckEmailExiestance(email))
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
    }
}
