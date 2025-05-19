CREATE DATABASE DZI
GO

USE DZI
GO

--1.
CREATE TABLE Subjects
(
	ID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Students
(
	ID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Town VARCHAR(50) NOT NULL,
	DZI2 INT FOREIGN KEY
		REFERENCES Subjects(ID) NOT NULL,
	DZI3 INT FOREIGN KEY
		REFERENCES Subjects(ID)
)

--2.
INSERT INTO Subjects([Name])
VALUES ('Английски език'),
	   ('Математика'),
	   ('Информатика'),
	   ('Информационни технологии'),
	   ('Биология и ЗО'),
	   ('География и икономика'),
	   ('История и цивилизации')

INSERT INTO Students([Name], Town, DZI2, DZI3)
VALUES ('Иван Иванов', 'София', 2, 1),
	   ('Петър Петров', 'Варна', 1, null),
	   ('Илияна Иванова', 'Плевен', 1, 6),
	   ('Елизабет Хаджиева', 'София', 3, 1),
	   ('Илиян Петров', 'София', 4, null),
	   ('Ивайла Димитрова', 'Плевен', 5, 4)

--3.
SELECT s.[Name], sub.[Name], sub2.[Name]
  FROM Students AS s
  JOIN Subjects AS sub ON s.DZI2 = sub.ID
  JOIN Subjects AS sub2 ON s.DZI3 = sub2.ID
 WHERE s.Town = 'София' AND s.DZI3 IS NOT NULL
ORDER BY s.[Name]

--4.
SELECT s.[Name], s.Town
  FROM Students AS s
 WHERE s.DZI3 IS NOT NULL AND s.[Name] LIKE 'И%'
ORDER BY s.[Name], s.Town

--5.
SELECT COUNT(*)
  FROM Students AS s
  JOIN Subjects AS sub ON s.DZI3 = sub.ID
 WHERE s.DZI3 IS NOT NULL

--6.
--SELECT s.Town
--  FROM Students AS s
--  JOIN Subjects AS sub ON s.DZI2 = sub.ID
--  JOIN Subjects AS sub2 ON s.DZI3 = sub2.ID
-- WHERE sub.ID <> 3 OR sub2.ID <> 3
--GROUP BY s.Town

SELECT DISTINCT s.Town
FROM Students AS s
WHERE NOT EXISTS (
    SELECT 1
    FROM Students AS innerS
    WHERE innerS.Town = s.Town
      AND (innerS.DZI2 = 3 OR innerS.DZI3 = 3)
)

--7.
SELECT COUNT(*)
  FROM Students AS s
GROUP BY s.Town