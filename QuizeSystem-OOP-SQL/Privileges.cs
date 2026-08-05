using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizeSystem_OOP_SQL
{
    internal class Privileges
    {
        internal static void AdminPrivileges(Admin admin)
        {
            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine($"       Welcome Admin : {admin.Name}    ");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.WriteLine();

            Console.WriteLine($"Welcome Admin : {admin.Name}");
            Console.WriteLine("What do you need to do now ?");
            Console.WriteLine("1.Add Course (AddCourse)");
            Console.WriteLine("2.View All Course (ViewAllCourses) ");
            Console.WriteLine("3.View All Teachers (ViewAllTeachers)");
            Console.WriteLine("4.View All Students (ViewAllStudents)");
            Console.WriteLine("8.Log out (LogOut)");


            while (true)
            {
                Console.Write("Please Enter the Word between parenthies in your option : ");
                var answer = Console.ReadLine();
                if (Enum.TryParse<AdminPreveleges>(answer, true, out AdminPreveleges desire))
                {
                    switch (desire)
                    {
                        case (AdminPreveleges.AddCourse):
                            admin.AddCourse();
                            break;
                        case (AdminPreveleges.ViewAllCourses):
                            admin.ViewAllCourses();
                            break;
                        case (AdminPreveleges.ViewAllStudents):
                            admin.ViewAllStudents();
                            break;
                        case (AdminPreveleges.ViewAllTeachers):
                            admin.ViewAllTeachers();
                            break;
                        case (AdminPreveleges.LogOut):
                            Console.WriteLine("Logging out...");
                            OperatingClass.Starting();
                            break;
                    }
                    break;
                }
            }
        }

        internal static void StudentPrivileges(Student student)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine($"        Welcome {student.Name}         ");
            Console.WriteLine("╚══════════════════════════════════════╝"); 
            Console.WriteLine();

            Console.WriteLine("What do you need to do now ?");
            Console.WriteLine("1. Enroll in a Course (EnrollInACourse)");
            Console.WriteLine("2. Take a quize (TakeQuize)");

            Console.WriteLine("3. View All Course (ViewAllCourses) ");
            Console.WriteLine("4. View All Student Quizes (ViewAllStudentQuizes)");
            Console.WriteLine("5. View Enrolled Courses Details And Quizes (ViewEnrolledCoursesDetailsAndQuizes)");
            Console.WriteLine("8.Log out (LogOut)");


            while (true)
            {
                Console.Write("Please Enter the Word between parenthies in your option : ");
                var answer = Console.ReadLine();
                if (Enum.TryParse<StudentPrivilege>(answer, true, out StudentPrivilege desire))
                {
                    switch (desire)
                    {
                        case (StudentPrivilege.EnrollInACourse):
                            CourseManagment.EnrollInCourse(student);
                            break;
                        case (StudentPrivilege.TakeQuize):
                            List<Quiz> studentQuizes = student.QuizeStudentAnswersAndScores.Select(a => a.quiz).ToList();
                            var quizes = student.Courses.SelectMany(a => a.Quizes).Where(a => !studentQuizes.Contains(a)).ToList();
                            var quiz = QuizManagment.ChooseQuiz(quizes);
                            student.TakeQuize(quiz);
                            break;
                        case (StudentPrivilege.ViewAllCourses):
                            student.ViewAllCourses();
                            break;
                        case (StudentPrivilege.ViewAllStudentQuizes):
                            student.ViewAllStudentQuizes();
                            break;
                        case (StudentPrivilege.ViewEnrolledCoursesDetailsAndQuizes):
                            student.ViewEnrolledCoursesDetailsAndQuizes();
                            break;
                        case (StudentPrivilege.LogOut):
                            Console.WriteLine("Logging out...");
                            OperatingClass.Starting();
                            break;
                    }
                    break;
                }
            }
        }

        internal static void TeacherPrivileges(Teacher teacher)
        {

            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine($"Welcome {teacher.Title}\\{teacher.Name}");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine($"Welcome ");
            Console.WriteLine("What do you need to do now ?");
            Console.WriteLine("1.Assign Yourself To A Course (AssignYourselfToACourse)");
            Console.WriteLine("2.View Assigned Courses Details (ViewAssignedCoursesDetails)");

            Console.WriteLine("3.Release Course (ReleaseCourse) ");
            Console.WriteLine("4.View UnAssigned Courses (ViewUnAssignedCourses)");
            Console.WriteLine("5.Create a Quize (CreateQuize)");
            Console.WriteLine("6.Add Question To Quize (AddQuestionToQuize)");
            Console.WriteLine("7.Remove Question From Quize (RemoveQuestionFromQuize)");
            Console.WriteLine("8.Log out (LogOut)");

            while (true)
            {
                Console.Write("Please Enter the Word between parenthies in your option : ");
                var answer = Console.ReadLine();
                if (Enum.TryParse<TeacherPreveleges>(answer, true, out TeacherPreveleges desire))
                {
                    switch (desire)
                    {
                        case (TeacherPreveleges.AssignYourselfToACourse):
                            Course course =CourseManagment.ChooseCourse(Data.Courses.Where(a => a.Value.Teacher == null).Select(d => d.Value).ToList());
                            teacher.AssignToACourse(course);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"You have been assigned to the course {course.CourseName}");
                            break;
                        case (TeacherPreveleges.ViewAssignedCoursesDetails):
                            teacher.ViewAssignedCoursesDetails();
                            break;
                        case (TeacherPreveleges.ReleaseCourse):
                            CourseManagment.ReleaseCourse(teacher);
                            break;
                        case (TeacherPreveleges.ViewUnAssignedCourses):
                            teacher.ViewUnAssignedCourses();
                            break;
                        case (TeacherPreveleges.CreateQuize):
                            Quiz quiz = QuizManagment.CreateAQuize(CourseManagment.ChooseCourse(teacher.Courses));
                            QuizQuestionsManagment.TakeQuestionsFromTeacher(quiz);
                            break;

                        case (TeacherPreveleges.AddQuestionToQuize):
                            QuizQuestionsManagment.EditAQuiz(teacher, EditOperation.AddQuestion);

                            break;
                        case (TeacherPreveleges.RemoveQuestionFromQuize):
                            QuizQuestionsManagment.EditAQuiz(teacher, EditOperation.RemoveQuestion);
                            break;

                        case (TeacherPreveleges.LogOut):
                            Console.WriteLine("Logging out...");
                            OperatingClass.Starting();
                            break;
                    }
                    break;
                }
            }
        }

    }
}
