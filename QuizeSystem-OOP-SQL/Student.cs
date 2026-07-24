using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    internal class Student : Person 
    {
        internal char Grade { get; set; }
        internal List<float> Grades;
        internal List<Course> Courses;
        internal List<QuizeStudentAnswersAndScores> QuizeStudentAnswersAndScores;
        public Student(string name, string email, string passward) : base(name, email, passward) 
        {
            Courses = new List<Course>();
            Grades = new List<float>();
            QuizeStudentAnswersAndScores = new List<QuizeStudentAnswersAndScores>();
        }


        internal void EnrollInACourse(Course course) 
        {
            if (course is not null && course.Teacher is not null)
            {
                course.Students.Add(this);
                Courses.Add(course);
                Grades.Add(0f);
            }
            else throw new NullReferenceException();
        }

        internal void ViewEnrolledCoursesDetailsAndQuizes() 
        {
            ViewAllCourses();
            int enrolledQuizes = QuizeStudentAnswersAndScores.Count;
            Console.WriteLine($"Token quizes : {enrolledQuizes}");
            for (int j = 0; j < enrolledQuizes; j++) 
            {
                Console.WriteLine($"{j + 1}-{QuizeStudentAnswersAndScores[j].quize.QuizeName}");
                Console.WriteLine($"Your Score : {QuizeStudentAnswersAndScores[j].Score} ");
                Console.WriteLine($"Total Score : {QuizeStudentAnswersAndScores[j].quize.TotalScore} ");

            }
        }


        internal QuizeStudentAnswersAndScores passQuizeAnswersObject(Quize quize)
        {
            for (int i = 0; i < QuizeStudentAnswersAndScores.Count; i++) 
            {
                if (QuizeStudentAnswersAndScores[i].quize ==  quize)
                    return QuizeStudentAnswersAndScores[i];
            }
            return null;
        }


        internal void ViewQuizesDetails(Course course)
        {
            if (!Courses.Contains(course) || course is null)
            {
                Console.WriteLine("No Information Available");
                return;
            }
            for (int i = 0; i < course.Quizes.Count; i++) 
            {
                Console.WriteLine($"Quize {i + 1} : {course.Quizes[i].QuizeName}");
                Console.WriteLine($"Duration : {course.Quizes[i].DurationInMinutes} minutes");
                Console.WriteLine($"Total Score : {course.Quizes[i].TotalScore} ");
                QuizeStudentAnswersAndScores answers = passQuizeAnswersObject(course.Quizes[i]);
                if (answers is null) continue;
                for (int j = 0; j < answers.Answers.Count; j++)
                {
                    Console.WriteLine($"Question {j+1} : {answers.quize.QuizeQuestions[j]}");
                    Console.WriteLine($"Your answer : {answers.Answers[j]}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Correct answer : {answers.quize.QuizeQuestions[j].CorrectAnswer}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Your Score : {answers.Score} ");
                Console.ForegroundColor = ConsoleColor.White;

            }

        }



        internal void TakeQuize(Quize quize) 
        {
            int courseIndex = CheckEnrollementInCourse(quize.Course);
            if (courseIndex < 0) throw new Exception("unavailable quize for this student");

            DateTime end = DateTime.Now.AddMinutes(quize.DurationInMinutes);
            var student_choices = new List<string>();
            int question_counter = 0;
            Console.WriteLine($"{quize.QuizeName} : {quize.QuizeType} :");
            float total_score = 0f;

            string? answer = null;
            do
            {
                var question = quize.QuizeQuestions[question_counter];
                float question_score = 0;
                Console.WriteLine($"Question {question_counter} (Marks : {question.QuestionScore}) :");
                Console.WriteLine(question.Question);
                string? chosen_answer = null;

                if (quize.QuizeType == QuizeType.MultipleChoice)
                {
                    for (int i = 0; i < 4; i++) Console.Write($"{i+1}.{question.MultipleChoicesQuizeChoices[i]}  ");
                    Console.Write("Your Answer (enter choice number):");
                    answer = Console.ReadLine();
                    int answer_number;
                    if (int.TryParse(answer, out answer_number) && answer_number > 0 && answer_number < 5)
                    {
                        chosen_answer = question.MultipleChoicesQuizeChoices[answer_number - 1];
                        student_choices.Add(chosen_answer);
                        
                    }
                    else
                        student_choices.Add(null);
                }
                else
                {
                    
                    
                    if (quize.QuizeType == QuizeType.TrueFalse)
                    {
                        chosen_answer = GetTrueFalseAnswer();
                        student_choices.Add(chosen_answer);
                    }
                    else
                    {
                        Console.Write("Your Answer :");
                        chosen_answer = Console.ReadLine();
                        student_choices.Add(chosen_answer);
                    }

                }
                EvaluateQuestion(question, chosen_answer, ref question_score);
                total_score += question_score;
                if (question_counter == quize.QuizeQuestions.Count - 1) break;
                question_counter++;
            } while (end > DateTime.Now);

            var quize_details = new QuizeStudentAnswersAndScores(quize, total_score, student_choices);
            QuizeStudentAnswersAndScores.Add(quize_details);
            Grades[courseIndex] += total_score;
            PrintQuizeResult(quize, quize_details);
        }

        private void EvaluateQuestion(QuizeQuestion question , string answer , ref float questionMarks)
        {
            if (string.Equals(answer, question.CorrectAnswer, StringComparison.OrdinalIgnoreCase))
            {
                questionMarks += question.QuestionScore;
            }
        }
        private string GetTrueFalseAnswer()
        {
            while (true)
            {
                Console.Write("Your Answer (true/false): ");
                string answer = Console.ReadLine();

                if (bool.TryParse(answer, out bool _))
                {
                    return answer;
                }
                Console.WriteLine("Invalid input. Please enter 'true' or 'false'.");
            }
        }

        private void PrintQuizeResult(Quize quize, QuizeStudentAnswersAndScores studentAnswersAndScore)
        {
            var studentAnswers = studentAnswersAndScore.Answers;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Your Score : {studentAnswersAndScore.Score}/{quize.TotalScore}");
            Console.ResetColor();
            for (int i = 0; i < quize.QuizeQuestions.Count; i++)
            {
                Console.WriteLine($"{quize.QuizeQuestions[i]}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Correct Answer : {quize.QuizeQuestions[i].CorrectAnswer}");
                Console.ResetColor();

                if (i < studentAnswers.Count)
                {
                    if (string.Equals(quize.QuizeQuestions[i].CorrectAnswer, studentAnswers[i],StringComparison.OrdinalIgnoreCase)) Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"your answer : {studentAnswers[i]}");
                    Console.ResetColor();
                }
                else
                    Console.WriteLine("No Answer");
            }

        }


        internal int CheckEnrollementInCourse(Course course)
        {
            for(int i = 0; i < Courses.Count; i++)
            {
                if (course.Equals(Courses[i]))
                    return i;
            }
            return -1;
        }



        internal void ViewAllCourses()
        {
            if (Courses is null || Courses.Count == 0)
            {
                Console.WriteLine("No Enrolled Courses yet!");
                return;
            }
            for (int i = 0; i < Courses.Count; i++)
            {
                Console.WriteLine($"Course {i + 1}");
                Console.WriteLine($"Name : {Courses[i].CourseName}");
                Console.WriteLine($"Category : {Courses[i].CourseCategory}");
                Console.WriteLine($"Number Of Lessons : {Courses[i].NumberOfLessons}");
                Console.WriteLine($"Duration : {Courses[i].CourseMonthDuration} months");
                Console.WriteLine($"Current Quizes number : {Courses[i].Quizes.Count}");
                for (int k = 0; k < Courses[i].Quizes.Count; k++)
                {
                    Console.WriteLine($"Quize {k + 1} : {Courses[i].Quizes[k].QuizeName}");
                    Console.WriteLine($"Duration : {Courses[i].Quizes[k].DurationInMinutes} minutes");
                    Console.WriteLine($"Total Score : {Courses[i].Quizes[k].TotalScore} ");

                }
            }

        }
    }
}
