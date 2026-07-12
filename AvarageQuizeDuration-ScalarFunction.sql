
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION AvarageQuizeDuration
(
	
)
RETURNS numeric
AS
BEGIN
	declare @AvarageDuration numeric;
	select @AvarageDuration = AVG(Duration) from Quizes;
	return @AvarageDuration;
END
GO

