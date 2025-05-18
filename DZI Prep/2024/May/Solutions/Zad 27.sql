CREATE DATABASE Geo
GO

USE Geo
GO

--1.
CREATE TABLE Mountains
(
	ID INT PRIMARY KEY IDENTITY,
	MountainName NVARCHAR(20) NOT NULL,
	CountryCode VARCHAR(3) NOT NULL,
	Country NVARCHAR(20)
)

--2.
CREATE TABLE Peaks
(
	ID INT PRIMARY KEY IDENTITY,
	PeakName NVARCHAR(20) NOT NULL,
	Elevation INT NOT NULL
		CHECK(Elevation > 0),
	MountainId INT FOREIGN KEY
		REFERENCES Mountains(ID) NOT NULL
)

--3.
INSERT INTO Mountains(MountainName, CountryCode, Country)
VALUES ('����', 'BUL', '��������'),
	   ('�����', 'BUL', '��������'),
	   ('����� �������', 'BUL', '��������'),
	   ('����', 'ARG', '���������'),
	   ('����', 'CHL', '����'),
	   ('�������', 'NPL', '�����'),
	   ('����', 'SUI', '���������'),
	   ('����', 'ITA', '������'),
	   ('����', 'AUT', '�������'),
	   ('����', 'FRA', '�������'),
	   ('������', 'RUS', '�����'),
	   ('������', 'GEO', '������')

--4.
INSERT INTO Peaks(PeakName, Elevation, MountainId)
VALUES ('���������', 6962, 4),
	   ('�����', 2376, 3),
	   ('������', 2925, 1),
	   ('�������', 8849, 6),
	   ('������', 2914, 2),
	   ('���������', 2729, 1),
	   ('�������', 4809, 10),
	   ('���������', 4478, 8),
	   ('�����', 4634, 7),
	   ('������', 5642, 11),
	   ('���', 2015, 3),
	   ('�������', 2729, 6),
	   ('����', 2790, 1)

--5.
UPDATE Peaks
   SET Elevation = 2016
 WHERE PeakName = '���'

--6. 
SELECT AVG(Elevation) AS [AvgElevation]
  FROM Peaks AS p
 WHERE p.MountainId = 1

--7.
SELECT COUNT(*)
  FROM Peaks
 WHERE Elevation BETWEEN 5000 AND 9000

--8.
SELECT p.PeakName, p.Elevation, m.MountainName, m.Country
  FROM Peaks AS p
  JOIN Mountains AS m on p.MountainId = m.ID
 WHERE p.Elevation > 2900
ORDER BY m.Country, p.Elevation DESC

--9.
SELECT m.Country, COUNT(*)
  FROM Mountains AS m
GROUP BY m.Country
ORDER BY COUNT(*) DESC, m.Country