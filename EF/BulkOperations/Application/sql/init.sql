CREATE TYPE dbo.PeopleList
AS TABLE
(
  Name nvarchar(max),
  Streer nvarchar(max),
  Number int
);
GO

Create Procedure dbo.AddPeople
	@People as dbo.PeopleList readonly
AS
BEGIN
	select Name from @People;

	Insert into dbo.People(Name)
		select p.Name from @People as p
END
GO