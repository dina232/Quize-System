using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    public enum QuizeType
    {
        MultipleChoice,
        TrueFalse,
        ShortAnswer,
    }
    internal class Quize
    {

        internal string QuizeName { get; private set; }
        internal QuizeType QuizeType { get; private set; }

        internal int TotalScore { get; private set; }

        internal int DurationInMinutes { get; private set; }

        internal List<QuizeQuestion> QuizeQuestions;

        internal Quize(string quizeName, QuizeType quizeType, int totalScore, int durationInMinutes)
        {
            QuizeName = quizeName;
            QuizeType = quizeType;
            TotalScore = totalScore;
            DurationInMinutes = durationInMinutes;
        }


    }
}
