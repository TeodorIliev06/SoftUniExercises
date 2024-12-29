USE [SoftUni]
GO
---------------
-- 01. Employee Address
  SELECT TOP(5) [EmployeeID], [JobTitle], [e].[AddressID], [AddressText]
    FROM [Employees] AS [e]
    JOIN [Addresses] AS [a] ON [a].[AddressID] = [e].[AddressID]
ORDER BY [e].[AddressID]

-- 02. Addresses with Towns
  SELECT TOP(50) [FirstName], [LastName], [t].[Name], [AddressText]
	FROM [Employees] AS [e]
    JOIN [Addresses] AS [a] ON [a].[AddressID] = [e].[AddressID]
    JOIN [Towns] AS [t] ON [t].TownID = [a].[TownID]
ORDER BY [FirstName], [LastName]

-- 03. Sales Employees
  SELECT [EmployeeID], [FirstName], [LastName], [d].[Name]
	FROM [Employees] AS [e]
    JOIN [Departments] AS [d] ON [d].[DepartmentID] = [e].[DepartmentID]
   WHERE [d].[Name] = 'Sales'
ORDER BY [EmployeeID]

-- 04. Employee Departments
  SELECT TOP(5) [EmployeeID], [FirstName], [Salary], [d].[Name]
	FROM [Employees] AS [e]
    JOIN [Departments] AS [d] ON [d].[DepartmentID] = [e].[DepartmentID]
   WHERE [Salary] > 15000
ORDER BY [d].[DepartmentID]

-- 05. Employees Without Projects
  SELECT TOP(3) [EmployeeID], [FirstName]
    FROM [Employees] AS [e]
   WHERE [e].[EmployeeID] NOT IN 
		 (
		   SELECT DISTINCT [EmployeeID] FROM [EmployeesProjects]								 
		 )
ORDER BY [EmployeeID]

-- 06. Employees Hired After
  SELECT [FirstName], [LastName], [HireDate], 
		 [d].[Name] AS [DeptName]
	FROM [Employees] AS [e]
    JOIN [Departments] AS [d] ON [d].[DepartmentID] = [e].[DepartmentID]
   WHERE YEAR([HireDate]) >= 1999 AND
	     [d].[Name] IN ('Sales', 'Finance')
ORDER BY [HireDate]

-- 07. Employees With Project
  SELECT TOP(5) [e].[EmployeeID], [FirstName], [p].[Name]
    FROM [Employees] AS [e]
    JOIN [EmployeesProjects] AS [ep] ON [e].[EmployeeID] = [ep].[EmployeeID]
	JOIN [Projects] AS [p] ON [ep].[ProjectID] = [p].[ProjectID]
   WHERE [p].[StartDate] > '2002-08-13' AND
         [p].[EndDate] IS NULL
ORDER BY [e].[EmployeeID]

-- 08. Employee 24
  SELECT [e].[EmployeeID], [FirstName], [ProjectName] =
		 CASE
			  WHEN YEAR([StartDate]) >= 2005 THEN NULL
			  ELSE [p].[Name]
	     END
    FROM [Employees] AS [e]
    JOIN [EmployeesProjects] AS [ep] ON [e].[EmployeeID] = [ep].[EmployeeID]
	JOIN [Projects] AS [p] ON [ep].[ProjectID] = [p].[ProjectID]
   WHERE [e].[EmployeeID] = 24

-- 09. Employee Manager
  SELECT [e].[EmployeeID], [e].[FirstName], [m].[EmployeeID], [m].[FirstName]
    FROM [Employees] AS [e]
    JOIN [Employees] AS [m] ON [e].[ManagerID] = [m].[EmployeeID]
   WHERE [e].[ManagerID] IN (3, 7)
ORDER BY [e].[EmployeeID]

-- 10. Employees Summary
  SELECT TOP(50) [e].[EmployeeID],
    CONCAT_WS(' ', [e].[FirstName], [e].[LastName]) AS [EmployeeName],
    CONCAT_WS(' ', [m].[FirstName], [m].[LastName]) AS [ManagerName],
	[d].[Name] AS [DepartmentName]
    FROM [Employees] AS [e]
    JOIN [Employees] AS [m] ON [e].[ManagerID] = [m].[EmployeeID]
	JOIN [Departments] AS [d] ON [e].[DepartmentID] = [d].[DepartmentID]
ORDER BY [e].[EmployeeID]

-- 11. Min Average Salary
  SELECT TOP(1) [MinAverageSalary] =
         AVG([e].[Salary])
    FROM [Employees] AS [e]
    JOIN [Departments] AS [d] ON [e].[DepartmentID] = [d].[DepartmentID]
GROUP BY [e].[DepartmentID]
ORDER BY [MinAverageSalary]

---------------
USE [Geography]
GO

-- 12. Highest Peaks in Bulgaria
  SELECT [mc].[CountryCode], [m].[MountainRange], [p].[PeakName], [p].Elevation
    FROM [MountainsCountries] AS [mc]
    JOIN [Mountains] AS [m] ON [mc].[MountainId] = [m].[Id]
    JOIN [Peaks] AS [p] ON [m].[Id] = [p].[MountainId]
   WHERE [mc].[CountryCode] = 'BG' AND
         [p].[Elevation] > 2835
ORDER BY [p].[Elevation] DESC

-- 13. Count Mountain Ranges
  SELECT [mc].[CountryCode], [MountainRanges] = 	   
		 COUNT([m].[MountainRange])
    FROM [MountainsCountries] AS [mc]
    JOIN [Mountains] AS [m] ON [mc].[MountainId] = [m].[Id]
   WHERE [mc].[CountryCode] IN ('BG', 'RU', 'US')
GROUP BY [mc].[CountryCode]

-- 14. Countries With or Without Rivers
  SELECT TOP(5) [c].[CountryName], [r].[RiverName]
    FROM [Countries] AS [c]
    LEFT JOIN [CountriesRivers] AS [cr] ON [c].[CountryCode] = [cr].[CountryCode]
    LEFT JOIN [Rivers] AS [r] ON [r].[Id] = [cr].[RiverId]
   WHERE [c].[ContinentCode] = 'AF'
ORDER BY [c].[CountryName]

-- 15. Continents and Currencies
WITH CTE_ContinentsAndCountries AS 
(
      SELECT [c].[ContinentCode], [c].[CurrencyCode], 
             [CurrencyUsage] = COUNT([c].[CurrencyCode]),
             DENSE_RANK() OVER(PARTITION BY [c].[ContinentCode] 
							       ORDER BY COUNT([c].[CurrencyCode]) DESC) AS [rn]
        FROM [Countries] AS [c]
        JOIN [Currencies] AS [cur] ON [c].[CurrencyCode] = [cur].[CurrencyCode]
    GROUP BY [c].[ContinentCode], [c].[CurrencyCode] HAVING COUNT([c].[CurrencyCode]) > 1
)

  SELECT [ContinentCode], [CurrencyCode], [CurrencyUsage]
    FROM CTE_ContinentsAndCountries
   WHERE [rn] = 1
ORDER BY [ContinentCode]

-- 16. Countries Without any Mountains
SELECT COUNT(*) AS [Count]
  FROM [Countries]
 WHERE [CountryCode] NOT IN 
 (
	SELECT DISTINCT [CountryCode]
	  FROM [MountainsCountries]
 )

-- 17. Highest Peak and Longest River by Country
   SELECT TOP(5) [c].[CountryName], 
	     MAX([p].[Elevation]) AS [HighestPeakElevation],
	     MAX([r].[Length]) AS [LongestRiverLength]
    FROM [Countries] AS [c]
    JOIN [MountainsCountries] AS [mc] ON [c].[CountryCode] = [mc].[CountryCode]
    JOIN [Mountains] AS [m] ON [mc].[MountainId] = [m].[Id]
    JOIN [Peaks] AS [p] ON [m].[Id] = [p].[MountainId]
    JOIN [CountriesRivers] AS [cr] ON [c].[CountryCode] = [cr].[CountryCode]
    JOIN [Rivers] AS [r] ON [cr].[RiverId] = [r].[Id]
GROUP BY [c].[CountryName]
ORDER BY [HighestPeakElevation] DESC,
		 [LongestRiverLength] DESC,
		 [c].[CountryName]

-- 18. Highest Peak Name and Elevation by Country
WITH CTE_PeaksRankedByElevation AS
(
	SELECT [c].[CountryName],
		   [p].[PeakName],
		   [p].[Elevation],
		   [m].[MountainRange],
		   DENSE_RANK() OVER
		   (
				PARTITION BY [c].[CountryName]
			        ORDER BY [p].[Elevation] DESC
		   ) AS [PeakRank]
	  FROM [Countries] AS [c]
	  LEFT JOIN [MountainsCountries] AS [mc] ON [c].[CountryCode] = [mc].[CountryCode]
	  LEFT JOIN [Mountains] AS [m] ON [mc].[MountainId] = [m].[Id]
	  LEFT JOIN [Peaks] AS [p] ON [m].[Id] = [p].[MountainId]
)

SELECT TOP(5) [cte].[CountryName] AS [Country],
	   ISNULL([cte].[PeakName], '(no highest peak)') AS [Highest Peak Name],
	   ISNULL([cte].[Elevation], 0) AS [Highest Peak Elevation],
	   ISNULL([cte].[MountainRange], '(no mountain)') AS [Mountain]
  FROM [CTE_PeaksRankedByElevation] AS [cte]
 WHERE [cte].[PeakRank] = 1
ORDER BY [cte].[CountryName],
		 [Highest Peak Name]