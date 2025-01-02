USE [SoftUni]
GO

-- 01. Employees with Salary Above 35000
CREATE PROCEDURE [usp_GetEmployeesSalaryAbove35000] AS
(
	SELECT [e].[FirstName], [e].[LastName]
	  FROM [Employees] AS [e]
	 WHERE [e].[Salary] > 35000
)

-- 02. Employees with Salary Above Number
CREATE PROCEDURE [usp_GetEmployeesSalaryAboveNumber](@number DECIMAL(18,4)) AS
(
	SELECT [e].[FirstName], [e].[LastName]
	  FROM [Employees] AS [e]
	 WHERE [e].[Salary] >= @number
)

-- 03. Town Names Starting With
CREATE PROCEDURE [usp_GetTownsStartingWith](@word VARCHAR(20)) AS
(
	SELECT [t].[Name]
	  FROM [Towns] AS [t]
	 WHERE [t].[Name] LIKE CONCAT(@word, '%')
)

-- 04. Employees from Town
CREATE PROCEDURE [usp_GetEmployeesFromTown](@townName VARCHAR(20)) AS
(
	SELECT [e].[FirstName], [e].[LastName]
	  FROM [Employees] AS [e]
	  LEFT JOIN [Addresses] AS [a] ON [e].[AddressID] = [a].[AddressID]
	  LEFT JOIN [Towns] AS [t] ON [a].[TownID] = [t].[TownID]
	 WHERE [t].[Name] LIKE @townName
)

-- 05. Salary Level Function
 CREATE FUNCTION [udf_GetSalaryLevel](@salary DECIMAL(18,4)) 
RETURNS VARCHAR(10) AS
  BEGIN
		DECLARE @result VARCHAR(10)

		IF(@salary < 30000)
			SET @result = 'Low'

		ELSE IF(@salary <= 50000)
			SET @result = 'Average'

		ELSE
			SET @result = 'High'
		RETURN @result
	END 

-- 06. Employees by Salary Level
CREATE PROCEDURE [usp_EmployeesBySalaryLevel](@salaryLevel VARCHAR(10)) AS
(
	SELECT [e].[FirstName], [e].[LastName]
	  FROM [Employees] AS [e]
	 WHERE [dbo].[udf_GetSalaryLevel]([e].[Salary]) = @salaryLevel
)

-- 07. Define Function
 CREATE FUNCTION [udf_IsWordComprised](@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT AS
  BEGIN
		DECLARE @wordLength INT = LEN(@word)
		DECLARE @iteartor INT = 1
		  WHILE(@iteartor <= @wordLength)
				BEGIN	
				IF(CHARINDEX(SUBSTRING(@word, @iteartor, 1), @setOfLetters) = 0)
					RETURN 0
				SET @iteartor +=1
				END
		 RETURN 1
    END

-- 08. *Delete Employees and Departments
CREATE PROCEDURE [usp_DeleteEmployeesFromDepartment](@departmentId INT) AS
 BEGIN
 BEGIN ROLLBACK TRANSACTION
	   DECLARE @deletedEmployees TABLE(Id INT)
		-- Make a helper table
	    INSERT INTO @deletedEmployees
	    SELECT [e].[EmployeeID]
	      FROM [Employees] AS [e]
	     WHERE @departmentId = [e].[DepartmentID]

	    -- Nullify ManagerID in Departments
	     ALTER TABLE  [Departments]
	     ALTER COLUMN [ManagerID] INT NULL

		UPDATE [Departments]
		   SET [ManagerID] = NULL
		 WHERE [ManagerID] IN 
		 (
			SELECT [Id]
			  FROM @deletedEmployees
		 )

		-- Delete from all tables
		 DELETE
		   FROM [EmployeesProjects]
		  WHERE [EmployeeID] IN
		  (
				SELECT [Id]
				  FROM @deletedEmployees
		  )

		 UPDATE [Employees]
		    SET [ManagerID] = NULL
		  WHERE [EmployeeID] IN 
		  (
				SELECT [Id]
				  FROM @deletedEmployees
		  )

		 DELETE
		   FROM [Employees]
		  WHERE @departmentId = [DepartmentID]

		 DELETE
		   FROM [Departments]
		  WHERE @departmentId = [DepartmentID]

		-- Return the employees from the given department

		 SELECT COUNT(*)
		   FROM [Employees] AS [e]
		  WHERE @departmentId = [e].[DepartmentID]
   END ROLLBACK TRANSACTION
   END 

--------------------
USE [Bank]
GO
-- 09. Find Full Name
CREATE PROCEDURE [usp_GetHoldersFullName] AS
(
	SELECT [Full Name] = 
				CONCAT_WS(' ', [a].[FirstName], [a].[LastName])
	  FROM [AccountHolders] AS [a]
)

-- 10. People with Balance Higher Than
CREATE PROCEDURE [usp_GetHoldersWithBalanceHigherThan](@number MONEY) AS
 BEGIN
	   SELECT [ah].[FirstName], [ah].[LastName]
	     FROM [AccountHolders] AS [ah]
	     JOIN [Accounts] AS [acc] ON [ah].[Id] = [acc].[AccountHolderId]
	 GROUP BY [ah].[FirstName], [ah].[LastName]
	   HAVING SUM([acc].[Balance]) > @number
	 ORDER BY [ah].[FirstName], [ah].[LastName]
   END

-- 11. Future Value Function
CREATE FUNCTION [udf_CalculateFutureValue](@sum DECIMAL(10,4), @interestRate FLOAT, @years INT)
RETURNS DECIMAL(10,4) AS
 BEGIN
	   DECLARE @futureValue DECIMAL(10,4)
	       SET @futureValue = @sum * (POWER((1 + @interestRate), @years))
	    RETURN @futureValue
   END

-- 12. Calculating Interest
CREATE PROCEDURE [usp_CalculateFutureValueForAccount](@accountId INT, @interestRate FLOAT) AS
 BEGIN
	   DECLARE @years INT = 5	

	   SELECT [ah].[Id] AS [Account Id],
			  [ah].[FirstName] AS [First Name],
			  [ah].[LastName] AS [Last Name],
			  [acc].[Balance] AS [Current Balance],
			  [Balance in 5 years] =
					[dbo].[udf_CalculateFutureValue]([acc].[Balance], @interestRate, @years)
	     FROM [AccountHolders] AS [ah]
		 JOIN [Accounts] AS [acc] ON [ah].[Id] = [acc].[AccountHolderId]
		WHERE @accountId = [acc].[Id]
   END

--------------------
USE [Diablo]
GO

-- 13. *Cash in User Games Odd Rows
 CREATE FUNCTION [udf_CashInUsersGames](@gameName VARCHAR(MAX))
RETURNS TABLE AS
 RETURN
 (
	WITH [cte_GamesCash] AS
	(
		SELECT [g].[Id],
			   [g].[Name],
			   [ug].[Cash],
		       [RowRank] = 
				    ROW_NUMBER() OVER (ORDER BY [ug].[Cash] DESC)
	      FROM [Games] AS [g]
	      JOIN [UsersGames] AS [ug] ON [g].[Id] = [ug].[GameId]
	     WHERE [g].[Name] = @gameName
	)

	SELECT [SumCash] =
				SUM([cte].[Cash])
	  FROM [cte_GamesCash] AS [cte]
	 WHERE [cte].[RowRank] % 2 = 1
 )