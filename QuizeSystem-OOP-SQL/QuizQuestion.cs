using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    public class QuizQuestion : IViewable
    {
        public float QuestionScore { get; set; }
        public string Question { get; }
        public string CorrectAnswer { get; }

        public Quiz Quiz;

        public string[]? MultipleChoicesQuizeChoices;

        internal QuizQuestion(Quiz quiz, string question, string correctAnswer)
        {
            if (quiz.QuizType == QuizType.MultipleChoice) throw new Exception("Choices must be provided in MultiChoice Quizes");
            if (!quiz.IsEqualInQuestionsScores) throw new Exception("Question Mark must be provided in Inequal scores Quizes!");
            if (string.IsNullOrEmpty(correctAnswer)) throw new Exception("Invalid Answer!");
            if (string.IsNullOrEmpty(question)) throw new Exception("Invalid question!");
            Quiz = quiz;
            CorrectAnswer = correctAnswer;
            Question = question;
            QuestionScore = quiz.TotalScore / quiz.QuestionsNumber;


        }

        public QuizQuestion(Quiz quiz, string question, string[] choices, int correctAnswerIndex)
        {
            if (quiz is null) throw new NullReferenceException("Quiz!");
            if (!quiz.IsEqualInQuestionsScores) throw new Exception("Question Mark must be provided in Inequal scores Quizes!");
            if (quiz.QuizType != QuizType.MultipleChoice) throw new Exception("Choices must be provided in MultiChoice Quizes only");
            if (choices.Length != 4) throw new Exception("Choices number must be 4");
            else if (correctAnswerIndex < 0 || correctAnswerIndex >= 4) throw new Exception("Icorrect index for correct choice");
            if (string.IsNullOrEmpty(question)) throw new Exception("Question is null or empty!");

            Quiz = quiz;
            Question = question;
            CorrectAnswer = choices[correctAnswerIndex];
            QuestionScore = quiz.TotalScore/quiz.QuestionsNumber;
            MultipleChoicesQuizeChoices = choices;
          
            
  
            
        }
        internal QuizQuestion(Quiz quiz, string question, string correctAnswer, float questionScore)
        {
            if (quiz.QuizType == QuizType.MultipleChoice) throw new Exception("Choices must be provided in MultiChoice Quizes");
            if (quiz.IsEqualInQuestionsScores) throw new Exception("Question Mark is automatically computed in equal scores Quizes!");
            if (string.IsNullOrEmpty(correctAnswer)) throw new Exception("Invalid Answer!");
            if (string.IsNullOrEmpty(question)) throw new Exception("Invalid question!");
            if (questionScore>Quiz.TotalScore || questionScore < 0) throw new Exception("Invalid Score!");
            Quiz = quiz;
            CorrectAnswer = correctAnswer;
            Question = question;
            QuestionScore = questionScore;


        }

        public QuizQuestion(Quiz quiz, string question, string[] choices,int correctAnswerIndex, float questionScore)
        {
            if (quiz is null) throw new NullReferenceException("Quiz!");
            if (quiz.QuizType != QuizType.MultipleChoice) throw new Exception("Choices must be provided in MultiChoice Quizes only");
            if (quiz.IsEqualInQuestionsScores) throw new Exception("Question Mark is automatically computed in equal scores Quizes!");
            if (correctAnswerIndex >=0 && correctAnswerIndex < 4 && choices.Length == 4 
                && !string.IsNullOrEmpty(question) && questionScore <= quiz.TotalScore 
                && questionScore+quiz.QuizQuestions.Sum(a=>a.QuestionScore) <= quiz.TotalScore)
            {
                Quiz = quiz;
                Question = question;
                CorrectAnswer = choices[correctAnswerIndex];
                QuestionScore = questionScore;
                MultipleChoicesQuizeChoices = choices;
            }
            else
            {
                if (choices.Length != 4) throw new Exception("Choices number must be 4");
                else if (correctAnswerIndex < 0 || correctAnswerIndex >= 4) throw new Exception("Icorrect index for correct choice");
                if (string.IsNullOrEmpty(question)) throw new Exception("Question is null or empty!");
                if (questionScore > Quiz.TotalScore || questionScore + Quiz.QuizQuestions.Sum(a => a.QuestionScore) > Quiz.TotalScore)
                    throw new Exception(" the score is UnCompatable with this Quiz score!");
            }
        }

        public void ViewDetails()
        {
            Console.WriteLine($"Question : {Question}");
            Console.WriteLine($"Correct Answer : {CorrectAnswer}");
            Console.WriteLine($"Score : {QuestionScore}");
            if (Quiz.QuizType == QuizType.MultipleChoice)
            {
                Console.WriteLine("Available Choices :");
                for (int i = 0; i < 4; i++)
                {
                    var choice = MultipleChoicesQuizeChoices[i];
                    if (choice != null)
                    {
                        Console.Write($"{i + 1}.{choice}  ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
