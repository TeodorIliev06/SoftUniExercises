USE [Gringotts]
GO

-- 01. Records’ Count
SELECT COUNT(*)
  FROM [WizzardDeposits]

-- 02. Longest Magic Wand
SELECT [LongestMagicWand] = 
			MAX([MagicWandSize])
  FROM [WizzardDeposits]

-- 03. Longest Magic Wand per Deposit Groups
  SELECT [DepositGroup], [LongestMagicWand] = 
   			MAX([MagicWandSize])
    FROM [WizzardDeposits] AS [wd]
GROUP BY [wd].[DepositGroup]

-- 04. Smallest Deposit Group Per Magic Wand Size
WITH [CTE_AvgWandSizePerDepositGroup] AS
(
	SELECT [wd].[DepositGroup],
		   [AverageWandSize] =
				AVG([MagicWandSize])
	  FROM [WizzardDeposits] AS [wd]
	GROUP BY [wd].[DepositGroup]
)

  SELECT TOP(2)[cte].[DepositGroup]
    FROM [CTE_AvgWandSizePerDepositGroup] AS [cte]
ORDER BY [cte].[AverageWandSize], [cte].[DepositGroup]

-- 05. Deposits Sum
  SELECT [wd].[DepositGroup],
   		 [TotalSum] = 
			SUM([wd].[DepositAmount])
    FROM [WizzardDeposits] AS [wd]
GROUP BY [wd].[DepositGroup]

-- 06. Deposits Sum for Ollivander Family
  SELECT [wd].[DepositGroup],
   		 [TotalSum] = 
			SUM([wd].[DepositAmount])
    FROM [WizzardDeposits] AS [wd]
   WHERE [wd].[MagicWandCreator] = 'Ollivander family'
GROUP BY [wd].[DepositGroup]

-- 07. Deposits Filter
  SELECT [wd].[DepositGroup],
   		 [TotalSum] = 
			SUM([wd].[DepositAmount])
    FROM [WizzardDeposits] AS [wd]
   WHERE [wd].[MagicWandCreator] = 'Ollivander family'
GROUP BY [wd].[DepositGroup]
  HAVING SUM([wd].[DepositAmount]) < 150000
ORDER BY [TotalSum] DESC

-- 08. Deposit Charge
  SELECT [wd].[DepositGroup],
  	     [wd].[MagicWandCreator],
  	     [MinDepositCharge] = 
  			MIN([wd].[DepositCharge])
    FROM [WizzardDeposits] AS [wd]
GROUP BY [wd].[DepositGroup], [wd].[MagicWandCreator]
ORDER BY [wd].[MagicWandCreator], [wd].[DepositGroup]

-- 09. Age Groups
WITH [CTE_AgeGroups] AS
(
	SELECT 
		CASE
			WHEN [wd].[Age] BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN [wd].[Age] BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN [wd].[Age] BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN [wd].[Age] BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN [wd].[Age] BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN [wd].[Age] BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS [AgeGroup]
  FROM [WizzardDeposits] AS [wd]
)

  SELECT [cte].[AgeGroup],
  	     COUNT(*) AS [WizardCount]
    FROM [CTE_AgeGroups] AS [cte]
GROUP BY [cte].[AgeGroup]
ORDER BY [cte].[AgeGroup]

-- 10. First Letter
  SELECT DISTINCT [FirstLetter] = SUBSTRING([wd].[FirstName], 1, 1)
    FROM [WizzardDeposits] AS [wd]
   WHERE [wd].[DepositGroup] = 'Troll Chest'
GROUP BY [wd].[FirstName]

-- 11. Average Interest
  SELECT [wd].[DepositGroup],
  	     [wd].[IsDepositExpired],
  	     [AverageInterest] = 
  			  AVG([wd].[DepositInterest])
    FROM [WizzardDeposits] AS [wd]
   WHERE [wd].[DepositStartDate] > '01/01/1985'
GROUP BY [wd].[DepositGroup], [wd].[IsDepositExpired]
ORDER BY [wd].[DepositGroup] DESC,
		 [wd].[IsDepositExpired]

-- 12. *Rich Wizard, Poor Wizard 
WITH [CTE_WizardComparison] AS
(
	SELECT [wd].[FirstName] AS [Host Wizzard],
		   [wd].[DepositAmount] AS [Host Wizzard Deposit],
		   LEAD([wd].[FirstName]) OVER (ORDER BY [wd].[Id]) AS [Guest Wizzard],
		   LEAD([wd].[DepositAmount]) OVER (ORDER BY [wd].[Id]) AS [Guest Wizzard Deposit],
		   ([wd].[DepositAmount] - LEAD([wd].[DepositAmount]) OVER (ORDER BY [wd].[Id])) AS [Difference]
	  FROM [WizzardDeposits] AS [wd]
)

SELECT SUM([cte].[Difference])
  FROM [CTE_WizardComparison] AS [cte]

---------------
USE [SoftUni]
GO

-- 13. Departments Total Salaries
  SELECT [e].[DepartmentID],
  	     [TotalSalary] = 
  			  SUM([e].[Salary])
    FROM [Employees] AS [e]
GROUP BY [e].[DepartmentID]
ORDER BY [e].[DepartmentID]

-- 14. Employees Minimum Salaries
  SELECT [e].[DepartmentID],
  	     [MinimumSalary] = 
  			  MIN([e].[Salary])
    FROM [Employees] AS [e]
   WHERE [e].[DepartmentID] IN (2, 5, 7) AND
		 [e].[HireDate] > '01/01/2000'
GROUP BY [e].[DepartmentID]

-- 15. Employees Average Salaries
SELECT *
  INTO [NewEmployees]
  FROM [Employees] AS [e]
 WHERE [e].[Salary] > 30000

DELETE 
  FROM [NewEmployees]
 WHERE [ManagerID] = 42

UPDATE [NewEmployees]
   SET [Salary] += 5000
 WHERE [DepartmentID] = 1

  SELECT [ne].[DepartmentID],
  	     [AverageSalary] = 
  			  AVG([ne].[Salary])
    FROM [NewEmployees] AS [ne]
GROUP BY [ne].[DepartmentID]

-- 16. Employees Maximum Salaries
  SELECT [e].[DepartmentID],
  	     [MaxSalary] = 
  			  MAX([e].[Salary])
    FROM [Employees] AS [e]
GROUP BY [e].[DepartmentID]
  HAVING MAX([e].[Salary]) NOT BETWEEN 30000 AND 70000

-- 17. Employees Count Salaries
SELECT COUNT(*) AS [Count]
  FROM [Employees] AS [e]
 WHERE [e].[ManagerID] IS NULL

-- 18. *3rd Highest Salary
WITH [CTE_HighestSalariesByDepartment] AS
(
	SELECT [e].[DepartmentID],
		   [HighestRanking] = 
				MAX([e].[Salary]),
	       DENSE_RANK() OVER (PARTITION BY [e].[DepartmentID] 
						          ORDER BY [e].[Salary] DESC) AS [SalaryRanking]
      FROM [Employees] AS [e]
	GROUP BY [e].[DepartmentID], [e].[Salary]
)

SELECT [cte].[DepartmentID], [cte].[HighestRanking]
  FROM [CTE_HighestSalariesByDepartment] AS [cte]
 WHERE [cte].[SalaryRanking] = 3

-- 19. **Salary Challenge
WITH CTE_DepartmentAvgSalaries AS
(
	  SELECT [e].[DepartmentID],
	  	     [AverageSalary] = 
	  			  AVG([e].[Salary])
	    FROM [Employees] AS [e]
	GROUP BY [e].[DepartmentID]
)

  SELECT TOP(10) [e].[FirstName], [e].[LastName], [e].[DepartmentID]
    FROM [Employees] AS [e]
    JOIN [CTE_DepartmentAvgSalaries] AS [cte] ON [e].[DepartmentID] = [cte].[DepartmentID]
   WHERE [e].[Salary] > [cte].[AverageSalary]
ORDER BY [e].[DepartmentID]
