CREATE TABLE Employee
(
	EmployeeId BIGINT IDENTITY(1,1),
	Name VARCHAR(25),
	Gender VARCHAR(1),
	Salary FLOAT,
	Rating INT,
	Department VARCHAR(10)
)
GO

CREATE PROCEDURE AddEmployee
	@Name VARCHAR(25),
	@Gender VARCHAR(1),
	@Salary FLOAT,
	@Rating INT,
	@Department VARCHAR(10)

AS
BEGIN
	INSERT INTO Employee
	(
		Name,
		Gender,
		Salary,
		Rating,
		Department
	)
	VALUES
	(
		@Name,
		@Gender,
		@Salary,
		@Rating,
		@Department
	)
END
GO

CREATE PROCEDURE GetEmployees
AS
BEGIN
	SELECT * FROM Employee
END
GO