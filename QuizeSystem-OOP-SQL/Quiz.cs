using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace QuizeSystem_OOP_SQL
{
    public enum QuizType
    {
        MultipleChoice,
        TrueOrFalse,
        ShortAnswer,
    }
    public enum EditOperation
    {
        AddQuestion,
        RemoveQuestion
    }

    public enum QuestionAddingState
    {
        InitialCreation,
        Editing
    }

    public class Quiz : IViewable
    {
        public int QuizId { get;}
        private static int _quizIdCounter = 1;
        public string QuizName { get;}
        public QuizType QuizType { get;}

        public float TotalScore { get; private set; }

        public int QuestionsNumber { get; private set; }
        public int DurationInMinutes { get; private set; }

        public List<QuizQuestion> QuizQuestions;

        public Course Course;

        public List<Student> Students;

        public bool IsEqualInQuestionsScores { get; private set; }

        public Quiz(Course course, string quizName, QuizType quizType, float totalScore,int questionsNumber, int durationInMinutes , bool isEqualInQuestionsScores)
        {
            QuizId = _quizIdCounter;
            _quizIdCounter++;
            Course = course;
            QuizName = quizName;
            QuizType = quizType;

            TotalScore = totalScore;
            QuestionsNumber = questionsNumber;
            DurationInMinutes = durationInMinutes;
            Students = new List<Student>();
            QuizQuestions = new List<QuizQuestion>();
            IsEqualInQuestionsScores = isEqualInQuestionsScores;
            IsEqualInQuestionsScores = isEqualInQuestionsScores;
        }

        public void ViewDetails()
        {
            Console.WriteLine($"Quize: {QuizName}");
            Console.WriteLine($"Duration : {DurationInMinutes} minutes");
            Console.WriteLine($"Total Score : {TotalScore} ");
            Console.WriteLine($"Quiz Id : {QuizId}");
        }
        public void PrintQuizeDetails()
        {
            ViewDetails();
            ShowQuizQuestions();


        }

        public void ShowQuizQuestions()
        {
            for (int j = 0; j < QuizQuestions.Count; j++)
            {
                Console.WriteLine($"Question {j + 1} : {QuizQuestions[j]}");
                Console.WriteLine($"Correct answer : {QuizQuestions[j].CorrectAnswer}", ConsoleColor.Green);
                if (QuizType == QuizType.MultipleChoice)
                {
                    Console.WriteLine("Available Choices");
                    for (int i = 0; i < 4; i++)
                    {
                        var choice = QuizQuestions[j].MultipleChoicesQuizeChoices[i];
                        if (choice != null)
                        {
                            Console.Write($"{i + 1}.{choice}  ");
                        }
                    }
                }
            }
        }

        public void AddQuestion(string questionText, string[] options, int correctOptionIndex,float score)
        {
            QuizQuestion question = new QuizQuestion(this, questionText, options, correctOptionIndex, score);
            this.QuizQuestions.Add(question);
        }
        public void AddQuestion(string questionText, string correctAnswer, float score)
        {
            QuizQuestion question = new QuizQuestion(this, questionText, correctAnswer, score);
            this.QuizQuestions.Add(question);
        }
        public void AddQuestion(string questionText, string[] options, int correctOptionIndex)
        {
            QuizQuestion question = new QuizQuestion(this, questionText, options, correctOptionIndex);
            this.QuizQuestions.Add(question);
        }
        public void AddQuestion(string questionText, string correctAnswer)
        {
            QuizQuestion question = new QuizQuestion(this, questionText, correctAnswer);
            this.QuizQuestions.Add(question);
        }

        public void RedistributeQuestionScores(EditOperation operation)
        {
            if (IsEqualInQuestionsScores)
            {
                float questionScore;
                if (operation == EditOperation.AddQuestion)
                {
                    questionScore = TotalScore / QuizQuestions.Count();
                    for (int i = 0; i < QuizQuestions.Count; i++)
                    {
                        QuizQuestions[i].QuestionScore = questionScore;
                    }
                    
                }
                else if (operation == EditOperation.RemoveQuestion)
                {
                    questionScore = TotalScore / QuizQuestions.Count();
                    for (int i = 0; i < QuizQuestions.Count; i++)
                    {
                        QuizQuestions[i].QuestionScore = questionScore;
                    }
                }
            }
            else
                throw new ArgumentException("ReAssignQuestionsMarksAfterEditing is for equal scored quizes only!");


        }
       
    }
}
