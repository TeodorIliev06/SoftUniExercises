CREATE DATABASE ShoesApplicationDb
GO
USE ShoesApplicationDb
GO

-- 01. DDL
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(50) UNIQUE NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
	PhoneNumber NVARCHAR(15),
	Email NVARCHAR(100) UNIQUE NOT NULL,
)

CREATE TABLE Brands
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Sizes
(
	Id INT PRIMARY KEY IDENTITY,
	EU Decimal(5,2) NOT NULL,
	US Decimal(5,2) NOT NULL,
	UK Decimal(5,2) NOT NULL,
	CM Decimal(5,2) NOT NULL,
	[IN] Decimal(5,2) NOT NULL,
)

CREATE TABLE Shoes
(
	Id INT PRIMARY KEY IDENTITY,
	Model NVARCHAR(30) UNIQUE NOT NULL,
	Price Decimal(10,2) NOT NULL,
	BrandId INT FOREIGN KEY
		REFERENCES Brands(Id) NOT NULL,
)

CREATE TABLE Orders
(
	Id INT PRIMARY KEY IDENTITY,
	ShoeId INT FOREIGN KEY
		REFERENCES Shoes(Id) NOT NULL,
	SizeId INT FOREIGN KEY
		REFERENCES Sizes(Id) NOT NULL,	
	UserId INT FOREIGN KEY
		REFERENCES Users(Id) NOT NULL,	
)

CREATE TABLE ShoesSizes
(
	ShoeId INT FOREIGN KEY
		REFERENCES Shoes(Id) NOT NULL,
	SizeId INT FOREIGN KEY
		REFERENCES Sizes(Id) NOT NULL,
	CONSTRAINT PK_ShoesSizes PRIMARY KEY(ShoeId, SizeId)
)

-- 02. Insert
INSERT INTO Brands([Name])
VALUES ('Timberland'),
	   ('Birkenstock')

INSERT INTO Shoes(Model, Price, BrandId)
VALUES ('Reaxion Pro', 150.00, 12),
	   ('Laurel Cort Lace-Up', 160.00, 12),
	   ('Perkins Row Sandal', 170.00, 12),
	   ('Arizona', 80.00, 13),
	   ('Ben Mid Dip', 85.00, 13),
	   ('Gizeh', 90.00, 13)

INSERT INTO ShoesSizes(ShoeId, SizeId)
VALUES (70, 1),
	   (70, 2),
	   (70, 3),
	   (71, 2),
	   (71, 3),
	   (71, 4),
	   (72, 4),
	   (72, 5),
	   (72, 6),
	   (73, 1),
	   (73, 3),
	   (73, 5),
	   (74, 2),
	   (74, 4),
	   (74, 6),
	   (75, 1),
	   (75, 2),
	   (75, 3)

INSERT INTO Orders (ShoeId, SizeId, UserId)
VALUES (70, 2, 15),
	   (71, 3, 17),
	   (72, 6, 18),
	   (73, 5, 4),
	   (74, 4, 7),
	   (75, 1, 11)

-- 03. Update
UPDATE Shoes
   SET Price = Price * 1.15
 WHERE BrandId = 1

-- 04. Delete
BEGIN TRANSACTION
	DECLARE @shoesToDelete TABLE(Id INT)

	INSERT INTO @shoesToDelete(Id)
	SELECT s.Id
	  FROM Shoes AS s
	 WHERE s.Model = 'Joyride Run Flyknit'

	DELETE FROM ShoesSizes
	 WHERE ShoeId IN (SELECT Id FROM @shoesToDelete)

	DELETE FROM Orders
	 WHERE ShoeId IN (SELECT Id FROM @shoesToDelete)

	DELETE FROM Shoes
	 WHERE Id IN (SELECT Id FROM @shoesToDelete)
COMMIT TRANSACTION

--05. Orders By Price of the Shoe
  SELECT s.Model AS ShoeModel,
  	     s.Price
    FROM Orders AS o
	JOIN Shoes s ON o.ShoeId = s.Id
ORDER BY s.Price DESC, s.Model 

--06. Shoes With Their Brand
  SELECT b.[Name] AS BrandName,
  	     s.Model AS ShoesCount
    FROM Shoes AS s
	JOIN Brands AS b ON s.BrandId = b.Id
ORDER BY b.[Name], s.Model 

--07. Top 10 Users By Total Money Spent
  SELECT TOP(10) u.Id AS UserId, u.FullName,
		 [TotalSpent] = SUM(s.Price)
    FROM Users AS u
	JOIN Orders AS o ON u.Id = o.UserId
	JOIN Shoes AS s ON o.ShoeId = s.Id
GROUP BY u.FullName, u.Id
ORDER BY [TotalSpent] DESC, u.FullName

--8. Average Price Of Orders
  SELECT u.Username, u.Email,
  		 [AvgPrice] = CAST(ROUND(AVG(s.Price), 2) AS DECIMAL(10,2))
    FROM Users AS u
  	JOIN Orders AS o ON u.Id = o.UserId
  	JOIN Shoes AS s ON o.ShoeId = s.Id
GROUP BY u.Email, u.Username
  HAVING COUNT(o.Id) > 2
ORDER BY [AvgPrice] DESC

--9. Running Shoes
  SELECT sh.Model,
  		 COUNT(DISTINCT sz.Id) AS [CountOfSizes],
		 b.[Name] AS [BrandName]
    FROM Shoes AS sh
  	JOIN Brands AS b ON sh.BrandId = b.Id
	JOIN ShoesSizes AS map ON sh.Id = map.ShoeId
	JOIN Sizes AS sz ON map.SizeId = sz.Id
   WHERE b.[Name] = 'Nike' AND
         sh.Model LIKE '%Run%'
GROUP BY sh.Model, b.Name
  HAVING COUNT(DISTINCT sz.Id) > 5
ORDER BY sh.Model DESC

--10. Phone Including Digits 345
  SELECT u.FullName, u.PhoneNumber, sh.Price,
         o.ShoeId, sh.BrandId,
		 CONCAT(sz.EU, 'EU/', sz.US, 'US/', sz.UK, 'UK') AS [ShoeSize]
    FROM Users AS u
    JOIN Orders AS o ON u.Id = o.UserId
    JOIN Shoes AS sh ON o.ShoeId = sh.Id
    JOIN Sizes AS sz ON o.SizeId = sz.Id
    JOIN Brands AS b ON sh.BrandId = b.Id
   WHERE u.PhoneNumber LIKE '%345%'
ORDER BY sh.Model

--11. Find All Orders By Email Address
CREATE FUNCTION udf_OrdersByEmail(@email VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN
	(
		SELECT COUNT(o.Id)
		  FROM Orders AS o
		  JOIN Users AS u ON o.UserId = u.Id
		 WHERE u.Email = @email
	)
END

--12. Shoe Details By Size
CREATE PROCEDURE usp_SearchByShoeSize(@shoeSize DECIMAL(5,2))
	AS
 BEGIN
	SELECT s.Model AS [ModelName],
		    u.FullName AS [UserFullName],
			CASE
			WHEN s.Price < 100 THEN 'Low'
			WHEN s.Price BETWEEN 100 AND 200 THEN 'Medium'
            ELSE 'High'
			END AS [PriceLevel],
			b.[Name] AS [BrandName],
			@shoeSize AS [SizeEU]
	    FROM Orders AS o
		JOIN Shoes AS s ON o.ShoeId = s.Id
		JOIN Sizes AS sz ON o.SizeId = sz.Id
		JOIN Users AS u ON o.UserId = u.Id
		JOIN Brands AS b ON s.BrandId = b.Id
	   WHERE sz.EU = @shoeSize
	ORDER BY [BrandName], [UserFullName] 
   END