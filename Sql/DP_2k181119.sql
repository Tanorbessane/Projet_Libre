
GO

CREATE TABLE Project_Files
(
	ProjectId int FOREIGN KEY REFERENCES Project (Id),
	FileId int FOREIGN KEY REFERENCES Files(Id)
)

GO

CREATE PROCEDURE InsertFilesByProjectId
	@paramProjectId	int,
	@paramfileId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Project_Files (ProjectID, FileId) values (@paramProjectId,@paramfileId);
END

GO

CREATE PROCEDURE GetFilesByProjectId
	@paramProjectId	int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

      -- Insert statements for procedure here
	SELECT f.* FROM Project_Files pf
	INNER JOIN Files f ON  f.Id = pf.FileId
	WHERE pf.projectID = @paramProjectId;
END

GO

CREATE PROCEDURE DeleteFile
	@paramProjectId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE Files WHERE Id = @paramProjectId;
END

GO

CREATE PROCEDURE  DeleteUsersByProjectId
	@paramProjectId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE Project_Users WHERE ProjectID = @paramProjectId;
END

GO

CREATE PROCEDURE  DeleteFilesByProjectId
	@paramProjectId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE Project_Files WHERE ProjectID = @paramProjectId;
END

GO

CREATE PROCEDURE GetUsersByGroupId
	@paramGroupId int,
	@paramUserId	nvarchar(450)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Group_Users(GroupId, UserId) values (@paramGroupId,@paramUserId);
END
