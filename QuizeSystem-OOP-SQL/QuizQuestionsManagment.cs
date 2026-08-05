using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    public static class QuizQuestionsManagment
    {
        internal static int ChooseQuestion(Quiz quiz)
        {
            quiz.ShowQuizQuestions();
            while (true)
            {
                Console.Write("Question number : ");
                var answer = Console.ReadLine();
                if (int.TryParse(answer, out int questionIndex) && questionIndex >= 1 && questionIndex <= quiz.QuizQuestions.Count())
                    return questionIndex - 1;
                Console.WriteLine("Please enter a valid question number!");
            }
        }


        internal static void EditAQuiz(Teacher teacher, EditOperation edit)
        {
            var quiz = QuizManagment.ChooseQuiz(teacher.Courses.SelectMany(a => a.Quizes).Where(a => a.IsEqualInQuestionsScores == true && a.Students.Count()==0).ToList());
            if (quiz == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No valid quiz found!");
                Console.WriteLine("You Can Only Edit Quizes That Have Equal Question Scores And No Students Attempted Them!");
                Console.ResetColor();
                return;
            }
            int questionsNumber;
            if (edit == EditOperation.AddQuestion)
            {
                questionsNumber = quiz.QuizQuestions.Count() + 1;
                TakeAQuestionFromTeacher(quiz, questionsNumber, 0);
            }
            if (edit == EditOperation.RemoveQuestion)
            {
                int questionIndex = ChooseQuestion(quiz);
                quiz.QuizQuestions.RemoveAt(questionIndex);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Question Removed Successfully!");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            quiz.RedistributeQuestionScores(edit);
        }
        internal static void TakeAQuestionFromTeacher(Quiz quiz, int questionsNumber, int i)
        {
            if (quiz == null) throw new NullReferenceException("Quiz!");
            bool areEqualInScore = quiz.IsEqualInQuestionsScores;
            string question;
            string correctAnswer = null;

            string[] choices = new string[4];
            int correctChoiceIndex = 0;
            while (true)
            {
                Console.Write($"Question{i + 1} :");
                question = Console.ReadLine();
                if (question != null && question.Length > 7) break;
                Console.WriteLine("Please enter a valid question!(must have more than 7 charachters)");
            }
            if (quiz.QuizType == QuizType.ShortAnswer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                correctAnswer = Helpers.ValidateUserStringAnswer("Correct answer :");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else if (quiz.QuizType == QuizType.TrueOrFalse)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                correctAnswer = Helpers.GetTrueFalseAnswer();
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.WriteLine("Please enter 4 choices :");
                for (int j = 0; j < 4; j++)
                {
                    string choice;
                    choice = Helpers.ValidateUserStringAnswer("Choice" + (j + 1) + ":");
                    choices[j] = choice;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Enter correct choice number : ");
                while (true)
                {
                    var answer = Console.ReadLine();
                    if (int.TryParse(answer, out correctChoiceIndex) && correctChoiceIndex > 0 && correctChoiceIndex < 5) break;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a choice number!");
                }
                Console.ForegroundColor = ConsoleColor.Gray;


            }
            if (areEqualInScore)
            {
                if (quiz.QuizType == QuizType.MultipleChoice)
                    quiz.AddQuestion(question, choices, correctChoiceIndex);
                else
                    quiz.AddQuestion(question, correctAnswer);
            }
            else
            {
                int score = 0;
                while (true)
                {
                    Console.Write("question score : ");
                    var answer = Console.ReadLine();

                    if (int.TryParse(answer, out score) && score < quiz.TotalScore && score + quiz.QuizQuestions.Sum(a => a.QuestionScore) <= quiz.TotalScore)
                    {
                        break;
                    }
                    Console.WriteLine($"Invalid score for question! quiz total score {quiz.TotalScore}" +
                        $"Sum of Questions Scores before this Question {quiz.QuizQuestions.Sum(a => a.QuestionScore)} " +
                        $"Please Enter A Valid Score");
                }
                if (quiz.QuizType == QuizType.MultipleChoice)
                    quiz.AddQuestion(question, choices, correctChoiceIndex, score);
                else
                    quiz.AddQuestion(question, correctAnswer, score);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Question{i + 1} added Successfully!");
            Console.ResetColor();
        }
        internal static void TakeQuestionsFromTeacher(Quiz quiz)
        {
            int questionsNumber = quiz.QuestionsNumber;
            Console.WriteLine("--------------------------");

            Console.ForegroundColor = ConsoleColor.Magenta;

            for (int i = 0; i < questionsNumber; i++)
            {
                TakeAQuestionFromTeacher(quiz, questionsNumber, i);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Quiz Created Successfully!");
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
