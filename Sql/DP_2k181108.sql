GO
CREATE PROCEDURE GetAllUsers
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *  from AspNetUsers
END

GO
CREATE PROCEDURE GetUsersById
	@paramId nvarchar(450)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *  from AspNetUsers where Id = @paramId
END

GO
CREATE PROCEDURE DeleteUser
	@paramId nvarchar(450)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete AspNetUsers where Id = @paramId
END

GO
CREATE PROCEDURE UpdateUser
	@paramId nvarchar(450),
	@paramUserName nvarchar(256),
	@paramEmail nvarchar(256),
	@paramPhone nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [dbo].[AspNetUsers]
	   SET [UserName] = @paramUserName		 
		  ,[Email] = @paramEmail	 		  
		  ,[PhoneNumber] = @paramPhone		
	 WHERE Id = @paramId
END

GO
CREATE PROCEDURE InsertUsersByProjectId
	@paramProjectId int,
	@paramUserId	nvarchar(450)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Project_Users (ProjectID, UserId) values (@paramProjectId,@paramUserId);
END