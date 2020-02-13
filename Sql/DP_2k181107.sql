Go 
CREATE TABLE Project_Users (
    ProjectID int FOREIGN KEY REFERENCES Project (Id) ,
    UserId nvarchar(450) FOREIGN KEY REFERENCES AspNetUsers(Id)
);

GO

CREATE PROCEDURE GetUsersByProjectId
	@projectId int
AS
BEGIN
	select u.* from Project_Users pu
	inner join AspNetUsers u on u.Id = pu.UserId
	inner join Project p on p.Id = pu.ProjectID
	where pu.ProjectID = @projectId;

END