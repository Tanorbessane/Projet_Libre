Go 

CREATE TABLE Tasks 
(Id            INT NOT NULL IDENTITY(12485, 1) PRIMARY KEY, 
 Tache           VARCHAR(50) NOT NULL, 
 Description        VARCHAR(50))


GO

CREATE TABLE Project_Tasks
(
	ProjecId int FOREIGN KEY REFERENCES Project (Id),
	TasksId  int FOREIGN KEY REFERENCES Tasks(Id)
)

GO
CREATE PROCEDURE [dbo].[InsertTasksByProjectId]
	@paramProjectId	int,
	@paramTasksId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Project_Tasks (ProjecID, TasksId) values (@paramProjectId,@paramTasksId);
END

GO

CREATE PROCEDURE [dbo].[GetTasksByProjectId]
	@paramProjectId	int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

      -- Insert statements for procedure here
	SELECT t.* FROM Project_Tasks pt
	INNER JOIN Tasks t ON  t.Id = pt.TasksId
	WHERE pt.ProjecId = @paramProjectId;
END

GO

CREATE PROCEDURE DeleteTask
	@paramId	int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

      -- Insert statements for procedure here
	DELETE Tasks WHERE id = @paramId
END

GO

CREATE PROCEDURE DeleteProject
	@paramId	int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

      -- Insert statements for procedure here
	DELETE Project_Tasks WHERE ProjecId = @paramId
	DELETE Project_Files  WHERE ProjectId = @paramId
	DELETE Project_Users WHERE ProjectId = @paramId
	DELETE Project WHERE id = @paramId
END