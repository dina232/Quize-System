
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE UpdateAdminPhone 
	@Email varchar(250),
	@Password varchar(20),
	@Phone varchar(14)
AS
BEGIN
	update Admins
	set Phone = @Phone
	where Email = @Email and Password = @Password;

	select * from Admins where  Email = @Email and Password = @Password;
END
GO
