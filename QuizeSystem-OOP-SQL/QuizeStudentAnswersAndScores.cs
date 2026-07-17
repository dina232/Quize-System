using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    internal class QuizeStudentAnswersAndScores
    {
        public Quize quize;
        public int Score { get; set; }
        public List<string> Answers { get; set; }
    }
}
