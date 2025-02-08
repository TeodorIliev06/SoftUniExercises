CREATE DATABASE RailwaysDb
GO
USE RailwaysDb
GO

-- 01. DDL
CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL,
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
)

CREATE TABLE RailwayStations
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	TownId INT FOREIGN KEY
		REFERENCES Towns(Id)
)

CREATE TABLE Trains
(
	Id INT PRIMARY KEY IDENTITY,
	HourOfDeparture VARCHAR(5) NOT NULL,
	HourOfArrival VARCHAR(5) NOT NULL,
	DepartureTownId INT FOREIGN KEY
		REFERENCES Towns(Id),
	ArrivalTownId INT FOREIGN KEY
		REFERENCES Towns(Id)
)

CREATE TABLE TrainsRailwayStations
(
	TrainId INT FOREIGN KEY
		REFERENCES Trains(Id),
	RailwayStationId INT FOREIGN KEY
		REFERENCES RailwayStations(Id),
	CONSTRAINT PK_TrainsRailwayStations PRIMARY KEY(TrainId,RailwayStationId)
)

CREATE TABLE MaintenanceRecords
(
	Id INT PRIMARY KEY IDENTITY,
	DateOfMaintenance DATE NOT NULL,
	Details VARCHAR(2000) NOT NULL,
	TrainId INT FOREIGN KEY
		REFERENCES Trains(Id)
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(18,2) NOT NULL,
	DateOfDeparture DATE NOT NULL,
	DateOfArrival DATE NOT NULL,
	TrainId INT FOREIGN KEY
		REFERENCES Trains(Id),
	PassengerId INT FOREIGN KEY
		REFERENCES Passengers(Id)
)

-- 02. Insert
INSERT INTO Trains(HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId)
VALUES ('07:00', '19:00', 1, 3),
	   ('08:30', '20:30', 5, 6),
	   ('09:00', '21:00', 4, 8),
	   ('06:45', '03:55', 27, 7),
	   ('10:15', '12:15', 15, 5)

INSERT INTO TrainsRailwayStations(TrainId, RailwayStationId)
VALUES (36, 1), (37, 13), (38, 10), (39, 68), (40, 41),
	   (36, 4), (37, 54), (38, 50), (39, 3), (40, 7),
	   (36, 31), (37, 60), (38, 52), (39, 31), (40,	52),
	   (36, 57), (37, 16), (38,	22), (39, 19), (40,	13),
	   (36, 7) 
	   	   	   	   	  	  
INSERT INTO Tickets(Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId)
VALUES (90.00, '2023-12-01', '2023-12-01', 36, 1),
	   (115.00,	'2023-08-02', '2023-08-02',	37,	2),
	   (160.00,	'2023-08-03', '2023-08-03',	38,	3),
	   (255.00,	'2023-09-01', '2023-09-02', 39,	21),
	   (95.00, '2023-09-02', '2023-09-03', 40, 22)

-- 03. Update
UPDATE Tickets
   SET DateOfDeparture = DATEADD(DAY, 7, DateOfDeparture),
	   DateOfArrival = DATEADD(DAY, 7, DateOfArrival)
 WHERE MONTH(DateOfDeparture) IN (11, 12)

-- 04. Delete
BEGIN TRANSACTION
	DECLARE @trainsToDelete TABLE(Id INT)

	INSERT INTO @trainsToDelete(Id)
	SELECT tr.Id
	  FROM Trains AS tr
	  JOIN Towns AS t ON tr.DepartureTownId = t.Id
	 WHERE t.[Name] = 'Berlin'

	DELETE FROM TrainsRailwayStations
	 WHERE TrainId IN (SELECT Id FROM @trainsToDelete)

	DELETE FROM MaintenanceRecords
	 WHERE TrainId IN (SELECT Id FROM @trainsToDelete)

	DELETE FROM Tickets
	 WHERE TrainId IN (SELECT Id FROM @trainsToDelete)

	DELETE FROM Trains
	 WHERE Id IN (SELECT Id FROM @trainsToDelete)
COMMIT TRANSACTION

-- 05. Tickets by Price and Date Departure
  SELECT t.DateOfDeparture,
  	     t.Price AS TicketPrice
    FROM Tickets AS t
ORDER BY t.Price, t.DateOfDeparture DESC

-- 06. Passengers with their Tickets
  SELECT p.[Name] AS PassengerName,
  	     t.Price AS TicketPrice,
		 t.DateOfDeparture,
		 t.TrainId AS TrainID
    FROM Tickets AS t
	JOIN Passengers AS p ON t.PassengerId = p.Id
ORDER BY t.Price DESC, PassengerName

-- 07. Railway Stations without Passing Trains
  SELECT t.[Name] AS Town,
		 rs.[Name] AS RailwayStation
    FROM RailwayStations AS rs
	JOIN Towns AS t ON rs.TownId = t.Id
   WHERE rs.Id NOT IN (SELECT RailwayStationId FROM TrainsRailwayStations)
ORDER BY Town, RailwayStation

-- 08. First 3 Trains Between 08:00 and 08:59
  SELECT TOP(3) tr.Id AS TrainId,
  	     tr.HourOfDeparture,
  	     t.Price AS TicketPrice,
  	     ts.[Name] AS Destination
    FROM Trains AS tr
    JOIN Tickets AS t ON tr.Id = t.TrainId
    JOIN Towns AS ts ON tr.ArrivalTownId = ts.Id
   WHERE CAST(tr.HourOfDeparture AS TIME) BETWEEN '08:00' AND '08:59' AND
  	     t.Price > 50
ORDER BY TicketPrice

-- 09. Count of Passengers Paid More Than Average
DECLARE @avgTicketPrice DECIMAL(4,2) = 76.99

  SELECT ts.[Name] AS TownName,
  	     COUNT(p.Id) AS PassengersCount
    FROM Passengers AS p
	JOIN Tickets AS t ON p.Id = t.PassengerId
    JOIN Trains AS tr ON t.TrainId = tr.Id
    JOIN Towns AS ts ON tr.ArrivalTownId = ts.Id
   WHERE t.Price > @avgTicketPrice
GROUP BY ts.[Name]
ORDER BY TownName

-- 10. Maintenance Inspection with Town and Station
  SELECT mr.TrainId AS TrainID,
  	     t.[Name] AS DepartureTown,
  	     mr.Details
    FROM MaintenanceRecords AS mr
    JOIN Trains AS tr ON mr.TrainId = tr.Id
    JOIN Towns AS t ON tr.DepartureTownId = t.Id
   WHERE mr.Details LIKE '%inspection%'
ORDER BY TrainID

-- 11. Towns with Trains
CREATE FUNCTION udf_TownsWithTrains(@name VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN
	(
		SELECT COUNT(t.Id)
		  FROM Trains AS t
		 WHERE t.ArrivalTownId IN (SELECT Id FROM Towns WHERE [Name] = @name) OR
			   t.DepartureTownId IN (SELECT Id FROM Towns WHERE [Name] = @name)
	)
END

-- 12. Search Passengers travelling to Specific Town
CREATE PROCEDURE usp_SearchByTown(@townName VARCHAR(30))
	AS
 BEGIN
	   SELECT p.[Name] AS PassengerName,
			  tk.DateOfDeparture,
			  tr.HourOfDeparture
	     FROM Trains AS tr
		 JOIN Tickets AS tk ON tr.Id = tk.TrainId
		 JOIN Passengers AS p ON tk.PassengerId = p.Id
		WHERE tr.ArrivalTownId IN (SELECT Id FROM Towns WHERE [Name] = @townName)
	   ORDER BY tk.DateOfDeparture DESC, PassengerName
   END