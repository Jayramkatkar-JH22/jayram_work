CREATE PROCEDURE [dbo].DeleteEmployee10
	@EmpNo int
	
AS
	delete from Employees where EmpNo=@EmpNo;
RETURN 0