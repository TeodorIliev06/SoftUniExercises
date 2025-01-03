USE [Diablo]
GO

-- 01. Number of Users for Email Provider
WITH [cte_EmailProviders] AS
(
	SELECT [Email Provider] =
				SUBSTRING([u].[Email], CHARINDEX('@', [u].[Email]) + 1, LEN([u].[Email]))
	  FROM [Users] AS [u]
)

  SELECT [cte].[Email Provider],
	     [Number of Users] =
			  COUNT(*)
    FROM [cte_EmailProviders] AS [cte]
GROUP BY [cte].[Email Provider]
ORDER BY COUNT(*) DESC, [cte].[Email Provider]

-- 02. All Users in Games
  SELECT [g].[Name] AS [Game],
  	     [gt].[Name] AS [Game Type],
  	     [u].[Username],
  	     [ug].[Level],
  	     [ug].[Cash],
  	     [c].[Name] AS [Character]
    FROM [Users] AS [u]
    JOIN [UsersGames] AS [ug] ON [u].[Id] = [ug].[UserId]
    JOIN [Games] AS [g] ON [ug].[GameId] = [g].[Id]
    JOIN [GameTypes] AS [gt] ON [g].[GameTypeId] = [gt].[Id]
    JOIN [Characters] AS [c] ON [ug].[CharacterId] = [c].[Id]
ORDER BY [ug].[Level] DESC, [u].[Username], [g].[Name]

-- 03. Users in Games with Their Items
WITH [cte_UsersAndTheirItems] AS 
(
	SELECT [u].[Username],
		     [g].[Name] AS [Game],
		     [Items Count] =
		 		 COUNT(*),
			 [Items Price] =
				 SUM([i].[Price])
	  FROM [Users] AS [u]
	  JOIN [UsersGames] AS [ug] ON [u].[Id] = [ug].[UserId]
	  JOIN [Games] AS [g] ON [ug].[GameId] = [g].[Id]
	  JOIN [UserGameItems] AS [ugi] ON [ug].[Id] = [ugi].[UserGameId]
	  JOIN [Items] AS [i] ON [ugi].[ItemId] = [i].[Id]
  GROUP BY [u].[Username], [g].[Name]
)

  SELECT [cte].[Username],
  	     [cte].[Game],
  	     [cte].[Items Count],
  	     [cte].[Items Price]
    FROM [cte_UsersAndTheirItems] AS [cte]
   WHERE [cte].[Items Count] >= 10
ORDER BY [cte].[Items Count] DESC,
		 [cte].[Items Price] DESC,
		 [cte].[Username]

-- 04. *User in Games with Their Statistics
-- We group only by username and game name, not by character name
-- because a user can play with more than one characters in a given game
  SELECT [u].[Username],
		 [g].[Name] AS [Game],
  	     [Character] = 
			MAX([c].[Name]),
		 [Strength] =
			SUM([is].[Strength]) + MAX([cs].[Strength]) + MAX([gts].[Strength]),
		 [Defence] =
			SUM([is].[Defence]) + MAX([cs].[Defence]) + MAX([gts].[Defence]),
		 [Speed] =
			SUM([is].[Speed]) + MAX([cs].[Speed]) + MAX([gts].[Speed]),
		 [Mind] =
			SUM([is].[Mind]) + MAX([cs].[Mind]) + MAX([gts].[Mind]),
		 [Luck] =
			SUM([is].[Luck]) + MAX([cs].[Luck]) + MAX([gts].[Luck])
    FROM [Users] AS [u]
    JOIN [UsersGames] AS [ug] ON [u].[Id] = [ug].[UserId]
    JOIN [Games] AS [g] ON [ug].[GameId] = [g].[Id]
	JOIN [GameTypes] AS [gt] ON [g].[GameTypeId] = [gt].[Id]
	JOIN [Statistics] AS [gts] ON [gt].[BonusStatsId] = [gts].[Id]
    JOIN [Characters] AS [c] ON [ug].[CharacterId] = [c].[Id]
	JOIN [Statistics] AS [cs] ON [c].[StatisticId] = [cs].[Id]
	JOIN [UserGameItems] AS [ugi] ON [ug].[Id] = [ugi].[UserGameId]
	JOIN [Items] AS [i] ON [ugi].[ItemId] = [i].[Id]
	JOIN [Statistics] AS [is] ON [i].[StatisticId] = [is].[Id]
GROUP BY [u].[Username], [g].[Name]
ORDER BY [Strength] DESC, [Defence] DESC, [Speed] DESC, [Mind] DESC, [Luck] DESC

-- 05. All Items with Greater than Average Statistics
WITH [cte_AvgItemStats] AS
(
	  SELECT [AvgStrength] = AVG([s].[Strength]),
		     [AvgDefence] = AVG([s].[Defence]),
		     [AvgSpeed] = AVG([s].[Speed]),
		     [AvgLuck] = AVG([s].[Luck]),
		     [AvgMind] = AVG([s].[Mind])
        FROM [Statistics] AS [s]
)

  SELECT [i].[Name], [i].[Price], [i].[MinLevel],
	     [s].[Strength], [s].[Defence], [s].[Speed], [s].[Luck], [s].[Mind]
    FROM [Items] AS [i]
    JOIN [Statistics] AS [s] ON [i].[StatisticId] = [s].[Id]
   WHERE [s].[Mind] > (SELECT [AvgMind] FROM [cte_AvgItemStats]) AND
		 [s].[Luck] > (SELECT [AvgLuck] FROM [cte_AvgItemStats]) AND
		 [s].[Speed] > (SELECT [AvgSpeed] FROM [cte_AvgItemStats])
ORDER BY [i].[Name]

-- 06. Display All Items about Forbidden Game Type
  SELECT [i].[Name] AS [Item],
		 [i].[Price],
		 [i].[MinLevel],
		 [gt].[Name] AS [Forbidden Game Type]
    FROM [Items] AS [i]
    LEFT JOIN [GameTypeForbiddenItems] AS [gfi] ON [i].[Id] = [gfi].[ItemId]
    LEFT JOIN [GameTypes] AS [gt] ON [gfi].[GameTypeId] = [gt].[Id]
ORDER BY [Forbidden Game Type] DESC, [Item]

-- 07. Buy Items for User in Game
DECLARE @username VARCHAR(20) = 'Alex'
DECLARE @gameName VARCHAR(20) = 'Edinburgh'

DECLARE @userGameId INT =
(
	SELECT [ug].[Id]
	  FROM [UsersGames] AS [ug]
	  JOIN [Users] AS [u] ON [ug].[UserId] = [u].[Id]
	  JOIN [Games] AS [g] ON [ug].[GameId] = [g].[Id]
	 WHERE [u].[Username] = @username AND
		   [g].[Name] = @gameName
)

DECLARE @availableCash MONEY =
(
	SELECT [ug].[Cash]
	  FROM [UsersGames] AS [ug]
	 WHERE [ug].[Id] = @userGameId
)

DECLARE @purchasePrice MONEY =
(
	SELECT SUM([i].[Price])
	  FROM [Items] AS [i]
	 WHERE [i].[Name] IN 
	 (
		'Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)',
		'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'
	 )
)

IF(@availableCash >= @purchasePrice)
	BEGIN
		UPDATE [UsersGames]
		   SET [Cash] -= @purchasePrice
		 WHERE [Id] = @userGameId

		 INSERT INTO [UserGameItems](ItemId, UserGameId)
		 (
			SELECT [i].[Id], @userGameId
			  FROM [Items] AS [i]
			  WHERE [i].[Name] IN 
			(
				'Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)',
				'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'
			)
		 )
	  END

  SELECT [u].[Username],
  	     [g].[Name],
  	     [ug].[Cash],
  	     [i].[Name] AS [Item Name]
    FROM [UsersGames] AS [ug]
    JOIN [Users] AS [u] ON [ug].[UserId] = [u].[Id]
    JOIN [Games] AS [g] ON [ug].[GameId] = [g].[Id]
    JOIN [UserGameItems] AS [ugi] ON [ug].[Id] = [ugi].[UserGameId]
    JOIN [Items] AS [i] ON [ugi].[ItemId] = [i].[Id]
   WHERE [g].[Name] = @gameName
ORDER BY [Item Name]

--------------------------
USE [Geography]
GO

-- 08. Peaks and Mountains
  SELECT [p].[PeakName],
  	     [m].[MountainRange] AS [Mountain],
  	     [p].[Elevation]
    FROM [Peaks] AS [p]
    JOIN [Mountains] AS [m] ON [p].[MountainId] = [m].[Id]
ORDER BY [p].[Elevation] DESC, [p].[PeakName]

-- 09. Peaks with Mountain, Country and Continent
  SELECT [p].[PeakName],
  	     [m].[MountainRange] AS [Mountain],
		 [ctr].[CountryName],
		 [cont].[ContinentName]
    FROM [Peaks] AS [p]
    JOIN [Mountains] AS [m] ON [p].[MountainId] = [m].[Id]
	JOIN [MountainsCountries] AS [mc] ON [m].[Id] = [mc].[MountainId]
	JOIN [Countries] AS [ctr] ON [mc].[CountryCode] = [ctr].[CountryCode]
	JOIN [Continents] AS [cont] ON [ctr].[ContinentCode] = [cont].[ContinentCode]
ORDER BY [p].[PeakName], [ctr].[CountryName]

-- 10. Rivers by Country
WITH [cte_RiversByCountries] AS 
(
	  SELECT [ctr].[CountryName],
	  	     [cont].[ContinentName],
	  	     COUNT([r].[Id]) AS [RiversCount],
	  	     COALESCE(SUM([r].[Length]),0) AS [TotalLength]
	    FROM [Countries] AS [ctr]
	    JOIN [Continents] AS [cont] ON [ctr].[ContinentCode] = [cont].[ContinentCode]
	    LEFT JOIN [CountriesRivers] AS [cr] ON [ctr].[CountryCode] = [cr].[CountryCode]
	    LEFT JOIN [Rivers] AS [r] ON [cr].[RiverId] = [r].[Id]
	GROUP BY [ctr].[CountryName], [cont].[ContinentName]
)

  SELECT *
    FROM [cte_RiversByCountries] AS [cte]
ORDER BY [cte].[RiversCount] DESC,
		 [cte].[TotalLength] DESC,
		 [cte].[CountryName]

-- 11. Count of Countries by Currency
  SELECT [cur].[CurrencyCode],
  	     [cur].[Description] AS [Currency],
  	     COUNT([c].[CurrencyCode]) AS [NumberOfCountries]
    FROM [Currencies] AS [cur]
    LEFT JOIN [Countries] AS [c] ON [cur].[CurrencyCode] = [c].[CurrencyCode]
GROUP BY [cur].[CurrencyCode], [cur].[Description]
ORDER BY [NumberOfCountries] DESC, [Currency] 

-- 12. Population and Area by Continent
  SELECT [c].[ContinentName],
  	     SUM(CAST([ctr].[AreaInSqKm] AS BIGINT)) AS [CountriesArea],
  	     SUM(CAST([ctr].[Population] AS BIGINT)) AS [CountriesPopulation]
    FROM [Continents] AS [c]
    JOIN [Countries] AS [ctr] ON [c].[ContinentCode] = [ctr].[ContinentCode]
GROUP BY [c].[ContinentName]
ORDER BY [CountriesPopulation] DESC

-- 13. Monasteries by Country
CREATE TABLE [Monasteries]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[CountryCode] CHAR(2) FOREIGN KEY
		REFERENCES [Countries]([CountryCode])
)

INSERT INTO [Monasteries]([Name], [CountryCode]) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

IF NOT EXISTS (
    SELECT 1 
    FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Countries' 
    AND COLUMN_NAME = 'IsDeleted'
)
BEGIN
    ALTER TABLE [Countries]
    ADD [IsDeleted] BIT DEFAULT 0 WITH VALUES
END

UPDATE [Countries]
   SET [IsDeleted] = 1
 WHERE [CountryCode] IN 
	   (
		   SELECT [c].[CountryCode]
		     FROM [Countries] AS [c]
		     JOIN [CountriesRivers] AS [cr] ON [c].[CountryCode] = [cr].[CountryCode]
		     JOIN [Rivers] AS [r] ON [cr].[RiverId] = [r].[Id]
		 GROUP BY [c].[CountryCode]
		   HAVING COUNT([r].[Id]) >= 3
	   )

  SELECT [m].[Name] AS [Monastery],
  	     [c].[CountryName] AS [Country]
    FROM [Monasteries] AS [m]
    JOIN [Countries] AS [c] ON [m].[CountryCode] = [c].[CountryCode]
   WHERE [c].[IsDeleted] = 0
ORDER BY [Monastery]

-- 14. Monasteries by Continents and Countries
UPDATE [Countries]
   SET [CountryName] = 'Burma'
 WHERE [CountryName] = 'Myanmar'

INSERT INTO [Monasteries]([Name], [CountryCode]) 
VALUES ('Hanga Abbey', (SELECT [CountryCode] FROM [Countries] WHERE [CountryName] = 'Tanzania'))
INSERT INTO [Monasteries]([Name], [CountryCode]) 
VALUES ('Myin-Tin-Daik', (SELECT [CountryCode] FROM [Countries] WHERE [CountryName] = 'Maynmar'))

  SELECT [cont].[ContinentName] AS [ContinentName],
  	     [ctr].[CountryName] AS [CountryName],
  	     COUNT([m].Id) AS [MonasteriesCount]
    FROM [Countries] AS [ctr]
    JOIN [Continents] AS [cont] ON [ctr].[ContinentCode] = [cont].[ContinentCode]
    LEFT JOIN [Monasteries] AS [m] ON [ctr].[CountryCode] = [m].[CountryCode]
   WHERE [ctr].[IsDeleted] = 0
GROUP BY [cont].[ContinentName], [ctr].[CountryName]
ORDER BY [MonasteriesCount] DESC, [ctr].[CountryName]