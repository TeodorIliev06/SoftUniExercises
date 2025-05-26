CREATE DATABASE music
GO

USE music
GO

-- 1.
CREATE TABLE singers
(
	id INT PRIMARY KEY,
	[name] VARCHAR(50),
	songs INT,
	[rank] INT,
	networth INT,
)

-- 2.
INSERT INTO singers(id, [name], [songs], [rank], [networth])
VALUES (1, 'Ivan Ivanov', 50, 1, 1000000),
	   (2, 'Maria Ivanova', 55, 3, 900000),
	   (3, 'Georgi Georgiev', 20, 4, 800000),
	   (4, 'Gergana Petrova', 55, 2, 1000000),
	   (5, 'Boris Borisov', 20, 5, 900000)

-- 3.
  SELECT TOP(3)
  	     s.[rank], s.[name]
    FROM singers AS s
ORDER BY [rank]

-- 4.
SELECT SUM(s.songs) AS [SongsCount],
	   AVG(s.networth) / 1.95583 AS [AvgNetworthInEuro]
  FROM singers AS s

-- 5.
UPDATE singers
   SET networth *= 1.1
 WHERE id BETWEEN 2 AND 4