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
            get
            {
                return Question;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    Question = value;
                }
            }
        }
        internal string CorrectAnswer
        {
            get
            {
                return CorrectAnswer;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    CorrectAnswer = value;
                }
            }
        }

        internal Quize Quize;

        internal string[]? MultipleChoicesQuizeChoices;

        internal QuizeQuestion(Quize quize, string question, string answer, float questionScore)
        {
            if (quize.QuizeType == QuizeType.MultipleChoice) throw new Exception("Choices must be provided in MultiChoice Quizes");
            Quize = quize;
            Question = question;
            CorrectAnswer = answer;
            QuestionScore = questionScore;


        }

        internal QuizeQuestion(Quize quize, string question, string answer, float questionScore, string[] choices)
        {
            if (quize.QuizeType != QuizeType.MultipleChoice) throw new Exception("Choices must be provided in MultiChoice Quizes only");

            if (CheckCorrectAnswerExistaceInChoices(answer, choices))
            {
                Quize = quize;
                Question = question;
                CorrectAnswer = answer;
                QuestionScore = questionScore;
                MultipleChoicesQuizeChoices = choices;
            }
            else
            {
                throw new ArgumentException("Correct answer must be one of the choices.");
            }
        }

        internal bool CheckCorrectAnswerExistaceInChoices(string correctAnswer, string[] choices)
        {
            foreach (string choice in choices)
            {
                if (choice.Equals(correctAnswer)) return true;
            }
            return false;

        }
    }
}
