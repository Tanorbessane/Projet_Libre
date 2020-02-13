Go
CREATE TABLE [Groups]
(
	Id INT NOT NULL IDENTITY(12485, 1) PRIMARY KEY,
	Nom varchar(50)
)


GO 
CREATE TABLE [Group_Users]
(
	GroupId int FOREIGN KEY REFERENCES [Groups] (Id),
	UserId nvarchar(450) FOREIGN KEY REFERENCES AspNetUsers(Id)
)

Go 
CREATE PROCEDURE InsertUsersByGroupId
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