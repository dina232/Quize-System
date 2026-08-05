using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    public enum StudentPrivilege
    {
        ViewAllCourses,
        ViewAllStudentQuizes,
        EnrollInACourse,
        ViewEnrolledCoursesDetailsAndQuizes,
        TakeQuize,
        LogOut
    }
    public class Student : Person 
    {
        public char Grade { get; set; }
        public List<float> Grades;
        public List<Course> Courses;
        public List<QuizeStudentAnswersAndScores> QuizeStudentAnswersAndScores;
        public Student(string name, string email, string passward) : base(name, email, passward) 
        {
            Courses = new List<Course>();
            Grades = new List<float>();
            QuizeStudentAnswersAndScores = new List<QuizeStudentAnswersAndScores>();
        }


        public void EnrollInACourse(Course course) 
        {
            if (course is not null && course.Teacher is not null)
            {
                course.Students.Add(this);
                Courses.Add(course);
                Grades.Add(0f);
            }
            else throw new NullReferenceException();
        }

        public Char? GetStudentGrade()
        {
            float gradsSum = 0f;
            float totalGrads = 0f;
            bool didFinishedCourse = false;
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].IsFinished)
                {
                    gradsSum += Grades[i];
                    totalGrads += 100;
                    didFinishedCourse = true;
                }
            }
            if (!didFinishedCourse)
                return null;
            
            float percentage = gradsSum / totalGrads * 100;
            if (percentage < 60)
                return 'F';
            else if (percentage < 70) return 'D';
            else if ((percentage < 80)) return 'C';
            else if (((percentage < 90))) return 'B';
            return 'A';
        }
        public void ViewEnrolledCoursesDetailsAndQuizes() 
        {
            ViewAllCourses();
            int enrolledQuizes = QuizeStudentAnswersAndScores.Count;
            Console.WriteLine($"Token quizes : {enrolledQuizes}");
            for (int j = 0; j < enrolledQuizes; j++) 
            {
                Console.WriteLine($"{j + 1}-{QuizeStudentAnswersAndScores[j].quiz.QuizName}");
                Console.WriteLine($"Your Score : {QuizeStudentAnswersAndScores[j].Score} ");
                Console.WriteLine($"Total Score : {QuizeStudentAnswersAndScores[j].quiz.TotalScore} ");

            }
        }


        public QuizeStudentAnswersAndScores passQuizeAnswersObject(Quiz quiz)
        {
            for (int i = 0; i < QuizeStudentAnswersAndScores.Count; i++) 
            {
                if (QuizeStudentAnswersAndScores[i].quiz ==  quiz)
                    return QuizeStudentAnswersAndScores[i];
            }
            return null;
        }


        public void ViewQuizesDetails(Course course)
        {
            if (!Courses.Contains(course) || course is null)
            {
                Console.WriteLine("No Information Available");
                return;
            }
            for (int i = 0; i < course.Quizes.Count; i++) 
            {
                Console.WriteLine($"Quize {i + 1} : {course.Quizes[i].QuizName}");
                Console.WriteLine($"Duration : {course.Quizes[i].DurationInMinutes} minutes");
                Console.WriteLine($"Total Score : {course.Quizes[i].TotalScore} ");
                QuizeStudentAnswersAndScores answers = passQuizeAnswersObject(course.Quizes[i]);
                if (answers is null) continue;
                for (int j = 0; j < answers.Answers.Count; j++)
                {
                    Console.WriteLine($"Question {j+1} : {answers.quiz.QuizQuestions[j].Question}");
                    Console.WriteLine($"Your answer : {answers.Answers[j]}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Correct answer : {answers.quiz.QuizQuestions[j].CorrectAnswer}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Your Score : {answers.Score} ");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("──────────────────────────────────────");
                Console.WriteLine("──────────────────────────────────────");

            }
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("═══════════════════════════════════════");


        }
        public void ViewAllStudentQuizes()
        {
            foreach (Course course in Courses)
            {
                Console.WriteLine(" ╔══════════════════════════════════════╗");
                Console.WriteLine($"           {course.CourseName}          ");
                Console.WriteLine(" ╚══════════════════════════════════════╝");
                ViewQuizesDetails(course);
                Console.WriteLine();
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine();
            }
        }



        public void TakeQuize(Quiz quize) 
        {
            int courseIndex = CheckEnrollementInCourse(quize.Course);
            if (courseIndex < 0) throw new Exception("unavailable quize for this student");

            DateTime end = DateTime.Now.AddMinutes(quize.DurationInMinutes);
            var student_choices = new List<string>();
            int question_counter = 1;
            Console.WriteLine(" ╔══════════════════════════════════════╗");
            Console.WriteLine($"║{quize.QuizName} : {quize.QuizType}   ║");
            Console.WriteLine(" ╚══════════════════════════════════════╝");
            float total_score = 0f;

            string? answer = null;
            do
            {
                var question = quize.QuizQuestions[question_counter-1];
                float question_score = 0;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Remaining Time : {end.Minute-DateTime.Now.Minute} M");
                Console.ResetColor();
                Console.WriteLine($"Question {question_counter} (Marks : {question.QuestionScore}) :");
                Console.WriteLine(question.Question);
                string? chosen_answer = null;

                if (quize.QuizType == QuizType.MultipleChoice)
                {
                    for (int i = 0; i < 4; i++) Console.Write($"{i+1}.{question.MultipleChoicesQuizeChoices[i]}  ");
                    while (true)
                    {
                        Console.Write("Your Answer (enter choice number):");
                        answer = Console.ReadLine();
                        int answer_number;
                        if (int.TryParse(answer, out answer_number) && answer_number > 0 && answer_number < 5)
                        {
                            chosen_answer = question.MultipleChoicesQuizeChoices[answer_number - 1];
                            student_choices.Add(chosen_answer);
                            break;
                        }
                        Console.WriteLine("Please enter choice Number!");
                        
                    }
                }
                else
                {
                    
                    
                    if (quize.QuizType == QuizType.TrueOrFalse)
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
                if (question_counter == quize.QuizQuestions.Count) break;
                question_counter++;
                Console.WriteLine("──────────────────────────────────────");
                Console.WriteLine("──────────────────────────────────────");
            } while (end > DateTime.Now);

            var quize_details = new QuizeStudentAnswersAndScores(quize, total_score, student_choices);
            QuizeStudentAnswersAndScores.Add(quize_details);
            Grades[courseIndex] += total_score;
            PrintQuizeResult(quize, quize_details);
        }

        private void EvaluateQuestion(QuizQuestion question , string answer , ref float questionMarks)
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

        private void PrintQuizeResult(Quiz quize, QuizeStudentAnswersAndScores studentAnswersAndScore)
        {
            var studentAnswers = studentAnswersAndScore.Answers;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Your Score : {studentAnswersAndScore.Score}/{quize.TotalScore}");
            Console.ResetColor();
            for (int i = 0; i < quize.QuizQuestions.Count; i++)
            {
                Console.WriteLine($"Question {i+1}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Correct Answer : {quize.QuizQuestions[i].CorrectAnswer}");
                Console.ResetColor();

                if (i < studentAnswers.Count)
                {
                    if (string.Equals(quize.QuizQuestions[i].CorrectAnswer, studentAnswers[i],StringComparison.OrdinalIgnoreCase)) Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"your answer : {studentAnswers[i]}");
                    Console.ResetColor();
                }
                else
                    Console.WriteLine("No Answer");

                Console.WriteLine();
                Console.WriteLine("──────────────────────────────────────");
                Console.WriteLine();

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



        public void ViewAllCourses()
        {
            var courses = Data.Courses.Select(a => a.Value).ToList();
            if (Courses is null || courses.Count == 0)
            {
                Console.WriteLine("No Enrolled Courses yet!");
                return;
            }
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine();
                courses[i].ViewDetails();
                bool amItakeThisCourse = Courses.Contains(courses[i]);
                Console.WriteLine($"your Status : {(amItakeThisCourse ? "Enrolled In":"Not Enrolled In This Course")}");
                Console.WriteLine();
                var courseQuizesNumber = courses[i].Quizes.Count();
                Console.WriteLine($"Course Quizes :{courseQuizesNumber}");
                if (courseQuizesNumber == 0)
                    Console.WriteLine("No Quizes yet for this course!");
                else
                {
                    for (int k = 0; k < courseQuizesNumber; k++)
                    {
                        courses[i].Quizes[k].ViewDetails();
                        var myAnswers = passQuizeAnswersObject(courses[i].Quizes[k]);
                        if (myAnswers is null && amItakeThisCourse)
                            Console.WriteLine("Status : Not Token");
                        else if (myAnswers != null)
                        {
                            Console.WriteLine("Status : Token");
                            Console.WriteLine($"your score {myAnswers.Score}/{courses[i].Quizes[k].TotalScore}");
                        }
                        Console.WriteLine("---------------------------------");
                    }
                }
                Console.WriteLine("---------------------------------");
                Console.WriteLine("---------------------------------");

            }

        }
    }
}
