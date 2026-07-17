using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    internal class QuizeQuestion
    {
        internal float QuestionScore
        {
            get
            {
                return QuestionScore;
            }
            set
            {
                if (value > 0)
                {
                    QuestionScore = value;
                }
            }
        }
        internal string Question 
        { 
            get { 
                return Question;
            }
            set { 
                if(value != null && value.Length > 0)
                {
                    Question = value;
                }
            }  
        }
        internal string Answer
        {
            get
            {
                return Answer;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    Answer = value;
                }
            }
        }

        internal QuizeQuestion(string question, string answer , float questionScore)
        {
            Question = question;
            Answer = answer;
            QuestionScore = questionScore;
        }
    }
}
