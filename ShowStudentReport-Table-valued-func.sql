
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION ShowStudentRecord 
(	
	@StudentId int
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT S.Name as studentName , C.Name as CourseName , Q.Name as QuizeName , Q.totalScore , 
	case
		when QSS.StudentScore >= 0.5*Q.totalScore then 'pass'
		else 'fail'
	end as Result
	from Courses C join Quizes Q
	on C.Id = Q.CourseId
	join QuizeStudentsAndScores QSS
	on Q.Id = QSS.QuizeId
	join Students S
	on S.Id = QSS.studentId and S.Id = @StudentId
)
GO
