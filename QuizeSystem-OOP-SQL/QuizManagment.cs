using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    public static class QuizManagment
    {
        public static Quiz ChooseQuiz(List<Quiz> quizes)
        {

            if (quizes is null || quizes.Count == 0)
            {
                Console.WriteLine("No Available Quizes");
                return null;
            }
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║          Available Quizes            ║");
            Console.WriteLine("╚══════════════════════════════════════╝"); 
            foreach (var quiz in quizes)
            {
                quiz.ViewDetails();
                Console.WriteLine();
                Console.WriteLine("──────────────────────────────────────");
                Console.WriteLine("──────────────────────────────────────");
                Console.WriteLine();
            }
            while (true)
            {
                Console.Write("Enter the Quize ID you want to choose: ");
                var quizeIdString = Console.ReadLine();
                if (int.TryParse(quizeIdString, out int quizeId))
                {
                    Quiz? quiz = quizes.FirstOrDefault(q => q.QuizId == quizeId);
                    if (quiz != null)
                    {
                        return quiz;
                    }
                }
                Console.WriteLine("Invalid Quize ID! Please enter a valid one.");
            }
        }


        public static Quiz CreateAQuize(Course course)
        {
            if (course.Teacher is null) throw new Exception("Can not create quiz for this course! No one teaches it!");
            string name;
            QuizType quizType;
            int totalScore;
            int quizDurationminutes;
            int questionsNumber;
            name = Helpers.ValidateUserStringAnswer("Quiz Name : ");
            Console.WriteLine("Available Quiz Types : TrueOrFalse , ShortAnswer or MultipleChoice");
            while (true)
            {
                Console.Write("Quize Type :", ConsoleColor.Red);
                var QuizStringType = Console.ReadLine();
                if (Enum.TryParse<QuizType>(QuizStringType, true, out quizType))
                {
                    break;
                }
                Console.WriteLine("Invalid category! enter a valid one ");
            }
            while (true)
            {
                Console.Write("Total Score :");
                var totalScoreString = Console.ReadLine();
                if (int.TryParse(totalScoreString, out totalScore) && totalScore > 0
                    && totalScore < 100 && totalScore + course.Quizes.Sum(a => a.TotalScore) <= 100)
                {
                    break;
                }
                Console.WriteLine("Invalid number! Enter a valid one , total score must be between 1 and 100");
            }
            while (true)
            {
                Console.Write("Quiz Duration with minutes :");
                var quizDurationminutesString = Console.ReadLine();
                if (int.TryParse(quizDurationminutesString, out quizDurationminutes) && quizDurationminutes > 0 && quizDurationminutes < 30) break;
                Console.WriteLine("Invalid Duration!");

            }
            while (true)
            {
                Console.Write("Quiz Questions Number :");
                var questionsNumberString = Console.ReadLine();
                if (int.TryParse(questionsNumberString, out questionsNumber) && quizDurationminutes > 0 ) break;
                Console.WriteLine("Invalid Number!");

            }
            bool isEqualInScores = AreQuizQuestionsEqualInMarks();
            return course.CreateQuize(name, quizType, totalScore, questionsNumber, quizDurationminutes, isEqualInScores);

        }

        private static bool AreQuizQuestionsEqualInMarks()
        {
            bool areEqualInScore;
            while (true)
            {
                Console.WriteLine("Quiz Marks Distribution Type :");
                Console.WriteLine("If the Questions are not equal in score , Editing Quiz Won't be Allowed!", ConsoleColor.Red);
                Console.Write("Do you want the Quiz Questions to be Equal in Marks?[y/n] : ");
                var answer = Console.ReadLine();
                if (answer.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    areEqualInScore = true;
                    break;
                }
                else if (answer.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    areEqualInScore = false;
                    break;
                }
                Console.WriteLine("Please Enter A valid answer!");
            }
            return areEqualInScore;
        }
    }
}

    

