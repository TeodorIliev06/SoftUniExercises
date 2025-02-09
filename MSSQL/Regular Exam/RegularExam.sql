CREATE DATABASE EuroLeagues
GO
USE EuroLeagues
GO

-- 01. DDL
CREATE TABLE Leagues
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Teams
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL,
	City NVARCHAR(50) NOT NULL,
	LeagueId INT FOREIGN KEY
		REFERENCES Leagues(Id) NOT NULL
)

CREATE TABLE Players
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	Position NVARCHAR(20) NOT NULL
)

CREATE TABLE Matches
(
	Id INT PRIMARY KEY IDENTITY,
	HomeTeamId INT FOREIGN KEY
		REFERENCES Teams(Id) NOT NULL,
	AwayTeamId INT FOREIGN KEY
		REFERENCES Teams(Id) NOT NULL,
	MatchDate DATETIME2 NOT NULL,
	HomeTeamGoals INT NOT NULL DEFAULT 0,
	AwayTeamGoals INT NOT NULL DEFAULT 0,
	LeagueId INT FOREIGN KEY
		REFERENCES Leagues(Id) NOT NULL
)

CREATE TABLE PlayersTeams
(
	PlayerId INT NOT NULL FOREIGN KEY
		REFERENCES Players(Id),
	TeamId INT NOT NULL FOREIGN KEY
		REFERENCES Teams(Id),
	CONSTRAINT PK_PlayersTeams PRIMARY KEY(PlayerId, TeamId)
)

CREATE TABLE PlayerStats
(
	PlayerId INT PRIMARY KEY,
	FOREIGN KEY (PlayerId) 
		REFERENCES Players(Id),
	Goals INT NOT NULL DEFAULT 0,
	Assists INT NOT NULL DEFAULT 0,
)

CREATE TABLE TeamStats
(
	TeamId INT PRIMARY KEY,
	FOREIGN KEY (TeamId) 
		REFERENCES Teams(Id),
	Wins INT NOT NULL DEFAULT 0,
	Draws INT NOT NULL DEFAULT 0,
	Losses INT NOT NULL DEFAULT 0,
)

-- 02. Insert
INSERT INTO Leagues([Name])
VALUES ('Eredivisie')

INSERT INTO Teams([Name], City, LeagueId)
VALUES ('PSV', 'Eindhoven', 6),
	   ('Ajax', 'Amsterdam', 6)

INSERT INTO Players([Name], Position)
VALUES ('Luuk de Jong', 'Forward'),
	   ('Josip Sutalo', 'Defender')

INSERT INTO Matches(HomeTeamId, AwayTeamId, MatchDate, HomeTeamGoals, AwayTeamGoals, LeagueId)
VALUES (98, 97, '2024-11-02 20:45:00', 3, 2, 6)

INSERT INTO PlayersTeams(PlayerId, TeamId)
VALUES (2305, 97),
	   (2306, 98)

INSERT INTO PlayerStats(PlayerId, Goals, Assists)
VALUES (2305, 2, 0),
	   (2306, 2, 0)

INSERT INTO TeamStats(TeamId, Wins, Draws, Losses)
VALUES (97, 15, 1, 3),
	   (98, 14, 3, 2)

-- 03. Update
UPDATE PlayerStats
   SET Goals = Goals + 1
 WHERE PlayerId IN 
 (
	 SELECT p.Id
	   FROM Players AS p
	   JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
	   JOIN Teams AS t ON t.Id = pt.TeamId
	   JOIN Leagues AS l ON l.Id = t.LeagueId
	  WHERE p.Position = 'Forward' AND
			l.[Name] = 'La Liga'
  )

-- 04. Delete
BEGIN TRANSACTION
	DECLARE @PlayersToDelete TABLE(Id INT)

	INSERT INTO @PlayersToDelete(Id)
	SELECT p.Id
	  FROM Players AS p
	  JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
	  JOIN Teams AS t ON t.Id = pt.TeamId
	  JOIN Leagues AS l ON l.Id = t.LeagueId
	 WHERE l.[Name] = 'Eredivisie'

	DELETE FROM PlayerStats
	 WHERE PlayerId IN (SELECT Id FROM @PlayersToDelete)

	DELETE FROM PlayersTeams
	 WHERE PlayerId IN (SELECT Id FROM @PlayersToDelete)

	DELETE FROM Players
	 WHERE Id IN (SELECT Id FROM @PlayersToDelete)
COMMIT TRANSACTION

--5. Matches by Goals and Date
  SELECT FORMAT(m.MatchDate, 'yyyy-MM-dd') AS [MatchDate],
  	     m.HomeTeamGoals, m.AwayTeamGoals,
  	     m.HomeTeamGoals + m.AwayTeamGoals AS [TotalGoals]
    FROM Matches AS m
   WHERE m.HomeTeamGoals + m.AwayTeamGoals >= 5
ORDER BY [TotalGoals] DESC, m.MatchDate

--6. Players with Common Part in Their Names
  SELECT p.[Name], t.City
    FROM Players AS p
    JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
    JOIN Teams AS t ON t.Id = pt.TeamId
   WHERE p.[Name] LIKE '%Aaron%'
ORDER BY p.[Name]

--7. Players in Teams Situated in London
  SELECT p.Id, p.[Name], p.Position
    FROM Players AS p
    JOIN PlayersTeams AS pt ON p.Id = pt.PlayerId
    JOIN Teams AS t ON t.Id = pt.TeamId
   WHERE t.City = 'London'
ORDER BY p.[Name]

--8. First 10 Matches in Early September
  SELECT TOP(10)
  	     ht.[Name] AS HomeTeamName,
  	     [at].[Name] AS AwayTeamName,
         l.[Name] AS LeagueName,
  	     FORMAT(m.MatchDate, 'yyyy-MM-dd') AS [MatchDate]
    FROM Matches AS m
    JOIN Teams AS ht ON m.HomeTeamId = ht.Id
    JOIN Teams AS [at] ON m.AwayTeamId = [at].Id
    JOIN Leagues l ON m.LeagueId = l.Id
   WHERE m.MatchDate BETWEEN '2024-09-01' AND '2024-09-15' AND
	     l.Id % 2 = 0
ORDER BY m.MatchDate, ht.[Name]

--9. Best Guest Teams
  SELECT t.Id, t.[Name],
         SUM(m.AwayTeamGoals) AS [TotalAwayGoals]
    FROM Teams AS t
    JOIN Matches AS m ON t.Id = m.AwayTeamId
GROUP BY t.Id, t.[Name]
  HAVING SUM(m.AwayTeamGoals) >= 6
ORDER BY [TotalAwayGoals] DESC, t.[Name]

--10. Average Scoring Rate
  SELECT l.[Name] AS [LeagueName],
         ROUND(
			CAST(
				SUM(m.HomeTeamGoals + m.AwayTeamGoals) AS FLOAT) / COUNT(*)
				, 2)
		 AS [AvgScoringRate]
    FROM Leagues AS l
    JOIN Matches AS m ON l.Id = m.LeagueId
GROUP BY l.[Name]
ORDER BY AvgScoringRate DESC

--11. League Top Scorrer
 CREATE FUNCTION udf_LeagueTopScorer(@leagueName VARCHAR(50)) 
RETURNS TABLE 
	 AS
 RETURN ( 
		    SELECT TOP(1) WITH TIES
				   p.[Name], ps.Goals
		      FROM Players AS p
		      JOIN PlayerStats ps ON p.Id = ps.PlayerId
              JOIN PlayersTeams pt ON p.Id = pt.PlayerId
              JOIN Teams t ON pt.TeamId = t.Id
              JOIN Leagues l ON t.LeagueId = l.Id
		     WHERE l.[Name] = @leagueName
		  ORDER BY ps.Goals DESC
		)

--12. Search for Teams from a Specific City
CREATE PROCEDURE usp_SearchByCountry(@country VARCHAR(50))
	AS
 BEGIN
	     SELECT t.[Name], t.PhoneNumber, t.Email,
			    COUNT(b.Id) AS CountOfBookings
	       FROM Tourists AS t
		   JOIN Bookings AS b ON t.Id = b.TouristId
		   JOIN Countries AS c ON t.CountryId = c.Id
		  WHERE c.[Name] = @country
	   GROUP BY t.[Name], t.PhoneNumber, t.Email
	   ORDER BY t.[Name], CountOfBookings DESC
   END