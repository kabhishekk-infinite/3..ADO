--DB
CREATE DATABASE EmployeeManagement;
GO

--USE DB
USE EmployeeManagement;
GO

--Create Table
CREATE TABLE Employee_Details
	(
		Empno INT PRIMARY KEY IDENTITY(1,1),
		EmpName VARCHAR(50) NOT NULL,
		Empsal NUMERIC(10,2) CHECK (Empsal >= 25000),
		Emptype CHAR(1) CHECK (Emptype IN ('F', 'P'))
	);

SELECT * FROM Employee_Details;

--Create the Stored Procedure
CREATE PROCEDURE AddEmployee
    @EmpName VARCHAR(50),
    @Empsal NUMERIC(10,2),
    @Emptype CHAR(1)
AS
BEGIN
    INSERT INTO Employee_Details (EmpName, Empsal, Emptype)
    VALUES (@EmpName, @Empsal, @Emptype);
END;

--Check the procedure
EXEC AddEmployee @EmpName = 'Abhishek Kumar', @Empsal = 50000, @Emptype = 'F';

--Check the procedure one more time
EXEC AddEmployee @EmpName = 'Reshma Singh', @Empsal = 45000, @Emptype = 'P';

--Check
SELECT * FROM Employee_Details;
