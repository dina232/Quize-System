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
        public float Score { get; set; }
        public List<string> Answers { get; set; }

        public QuizeStudentAnswersAndScores(Quize quize,float score, List<string> answers) 
        {
            if (score > quize.TotalScore || score < 0) throw new Exception("Invalid Score!");
            if(quize is null) throw new NullReferenceException("quize");
            if (answers is null) score = 0;
            this.quize = quize;
            Score = score;
            Answers = answers;
        
        }
    }
}
