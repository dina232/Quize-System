
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION ShowStudentAnswersPerAquize
(	
	@QuizeId int
)
RETURNS TABLE 
AS
RETURN 
(
	select S.Name as StudentName , SQA.StudentAnswer , QQ.correctAnswer , QSS.StudentScore
	from Students S join StudentQuizeAnswers SQA 
	on S.Id = SQA.StudentId 
	join QuizesQuestions QQ 
	on SQA.QuestionId = QQ.QuestionId
	join QuizeStudentsAndScores QSS
	on QQ.QuizeId = QSS.QuizeId
	and QSS.studentId = S.Id
	where SQA.QuizeId = @QuizeId

)
GO
