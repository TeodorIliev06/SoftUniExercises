CREATE DATABASE Travel
GO

USE Travel
GO

--1.
CREATE TABLE Countries 
(
	ID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30)
)

--2.
CREATE TABLE Destinations
(
	ID INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30),
	Distance INT,
	Duration INT,
	Price DECIMAL(10,2),
	CountryId INT FOREIGN KEY
		REFERENCES Countries(ID)
)

--3.
INSERT INTO Countries([Name])
VALUES ('France'),
	   ('Germany'),
	   ('Italy'),
	   ('Spain'),
	   ('Austria')

--4.
INSERT INTO Destinations(Town, Distance, Duration, Price, CountryId)
VALUES ('Paris', 2169, 4, 1800.00, 1),
	   ('Berlin', 4006, 6, 2100.00, 2),
	   ('Rome', 1666, 3, 1500.00, 3),
	   ('Madrid', 2966, 7, 1800.00, 4),
	   ('Milan', 1408, 4, 1900.00, 3),
	   ('Venice', 1152, 3, 1200.00, 3),
	   ('Barcelona', 2375, 7, 1800.00, 4)

--5.
UPDATE Destinations
   SET Price = 1700
 WHERE Town = 'Paris'

--6.
DELETE FROM Destinations
 WHERE Town LIKE 'Ba%'

--7.
SELECT c.[Name], d.Distance
  FROM Countries AS c
  JOIN Destinations AS d ON c.ID = d.CountryId
 WHERE d.Distance BETWEEN 1500 AND 2500

--8.
SELECT TOP(1) 
	   Town, Price
  FROM Destinations
ORDER BY Price DESC

--9.
SELECT c.[Name], COUNT(*) AS DestinationCount
FROM Destinations AS d
JOIN Countries AS c ON c.ID = d.CountryId
GROUP BY d.CountryId, c.[Name]
ORDER BY DestinationCount DESC, c.[Name]

SELECT * FROM Destinations AS d JOIN Countries AS c ON c.ID = d.CountryId
