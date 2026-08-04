using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    public class QuizeStudentAnswersAndScores
    {
        public Quiz quiz;
        public float Score { get; set; }
        public List<string> Answers { get; set; }

        public QuizeStudentAnswersAndScores(Quiz quiz,float score, List<string> answers) 
        {
            if (score > quiz.TotalScore || score < 0) throw new Exception("Invalid Score!");
            if(quiz is null) throw new NullReferenceException("quiz");
            if (answers is null) score = 0;
            this.quiz = quiz;
            Score = score;
            Answers = answers;
        
        }
    }
}
