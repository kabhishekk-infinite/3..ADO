-- DB
CREATE DATABASE EmployeeDB_A1;
GO

--Use DB
USE EmployeeDB_A1;
GO

CREATE TABLE Employees
		(
			EmployeeID INT PRIMARY KEY,
			FirstName  VARCHAR(50),
			LastName   VARCHAR(50),
			Title      VARCHAR(50),
			DOB        DATE,
			DOJ        DATE,
			City       VARCHAR(50)
		);
GO						

SELECT * FROM Employees;


INSERT INTO Employees (EmployeeID, FirstName, LastName, Title, DOB, DOJ, City)
	VALUES
		(1001, 'Malcolm', 'Daruwalla', 'Manager'    , '1984-11-16', '2011-06-08', 'Mumbai'),
		(1002, 'Asdin'  , 'Dhalla'   , 'AsstManager', '1984-08-20', '2012-07-07', 'Mumbai'),
		(1003, 'Madhavi', 'Oza'      , 'Consultant' , '1987-11-14', '2015-04-12', 'Pune'),
		(1004, 'Saba'   , 'Shaikh'   , 'SE'         , '1990-06-03', '2016-02-02', 'Pune'),
		(1005, 'Nazia'  , 'Shaikh'   , 'SE'         , '1991-03-08', '2016-02-02', 'Mumbai'),
		(1006, 'Amit'   , 'Pathak'   , 'Consultant' , '1989-11-07', '2014-08-08', 'Chennai'),
		(1007, 'Vijay'  , 'Natrajan' , 'Consultant' , '1989-12-02', '2015-06-01', 'Mumbai'),
		(1008, 'Rahul'  , 'Dubey'    , 'Associate'  , '1993-11-11', '2014-11-06', 'Chennai'),
		(1009, 'Suresh' , 'Mistry'   , 'Associate'  , '1992-08-12', '2014-12-03', 'Chennai'),
		(1010, 'Sumit'  , 'Shah'     , 'Manager'    , '1991-04-12', '2016-01-02', 'Pune');
GO

SELECT * FROM Employees;
