-- ================================================
-- Template generated from Template Explorer using:
-- Create Multi-Statement Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION CourseStudents
(
	-- Add the parameters for the function here
	 @CourseId int
)
RETURNS 
TABLE 
(
	-- Add the column definitions for the TABLE variable here
	StudentsNames varchar(250),
	CourseName varchar(250),
)
AS
BEGIN
	-- Fill the table variable with the rows for your result set
	select S.Name
	from Students as S join (select * from Courses where Id = @CourseId
	where Id in ( select StudentId from CourseStudents where CourseId = @CourseId)
	RETURN 
END
GO