using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    internal class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Passward { get; set; }

        public Person(string name, string email, string passward) 
        {
            if(name == null || name.Length < 2) throw new ArgumentException("enter a valid name");
            if(email == null || email.Length < 7 || !email.Contains("@")) throw new ArgumentException("enter a valid email");
            if (passward == null || passward.Length < 8) throw new ArgumentNullException("enter a valid passward");
            Name = name;
            Email = email;
            Passward = passward;
        }


    }
}
