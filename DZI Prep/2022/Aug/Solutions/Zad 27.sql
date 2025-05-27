CREATE DATABASE aug_2022_zad27
GO

USE aug_2022_zad27
GO

--1.
CREATE TABLE [students]
(
	ID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50),
	BEL INT,
	English INT,
	Math INT,
	Informatics INT,
	IT INT,
)

--2.
INSERT INTO [students]([Name], BEL, English, Math, Informatics, IT)
VALUES ('Антония Колева', 4, 5, 6, 6, 4),
	   ('Асен Ангелов', 5, 5, 6, 4, 5),
	   ('Борислав Ганев', 4, 4, 5, 5, 6),
	   ('Бояна Тодорова', 5, 6, 6, 6, 6),
	   ('Валери Илиев', 6, 6, 6, 6, 6)

--3.
SELECT *
  FROM [students] AS [s]
 WHERE [s].[ID] = 4

--4.
SELECT *
  FROM [students] AS [s]
 WHERE [s].[Math] = 6 AND
	   [s].[Informatics] = 6 AND
	   [s].[IT] = 6

--5.
SELECT [AvgBELGrade] = AVG([s].[BEL]),
	   [AvgMathGrade] = AVG([s].[Math])
  FROM [students] AS [s]

--6.
  SELECT [s].[Name],
  	     [AvgStudentGrades] = 
  			([s].[BEL] + [s].[English] + [s].[Math] + [s].[Informatics] + [s].[IT])/5.0
    FROM [students] AS [s]
ORDER BY [AvgStudentGrades] DESC,
		 [s].[Name]