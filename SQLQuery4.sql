CREATE PROCEDURE [dbo].UpdateEmployee10
	@EmpNo int,
	@Name varchar(50),
	@Basic decimal(18,2),
	@DeptNo int
AS
	update Employees set Name=@Name, Basic=@Basic,DeptNo=@DeptNo where EmpNo=@EmpNo;
RETURN 0