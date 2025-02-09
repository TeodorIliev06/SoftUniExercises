CREATE DATABASE LibraryDb2
GO
USE LibraryDb2
GO

-- 01. DDL
CREATE TABLE Contacts
(
	Id INT PRIMARY KEY IDENTITY,
	Email NVARCHAR(100),
	PhoneNumber NVARCHAR(20),
	PostAddress NVARCHAR(200),
	Website NVARCHAR(50)
)

CREATE TABLE Authors
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	ContactId INT FOREIGN KEY
		REFERENCES Contacts(Id) NOT NULL
)

CREATE TABLE Libraries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	ContactId INT FOREIGN KEY
		REFERENCES Contacts(Id) NOT NULL
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
)

CREATE TABLE Books
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	YearPublished INT NOT NULL,
	ISBN NVARCHAR(13) UNIQUE NOT NULL
		CHECK(LEN(ISBN) = 13),
	AuthorId INT FOREIGN KEY
		REFERENCES Authors(Id) NOT NULL,
	GenreId INT FOREIGN KEY
		REFERENCES Genres(Id) NOT NULL
)

CREATE TABLE LibrariesBooks
(
	LibraryId INT FOREIGN KEY
		REFERENCES Libraries(Id) NOT NULL,
	BookId INT FOREIGN KEY
		REFERENCES Books(Id) NOT NULL,
	CONSTRAINT PK_LibrariesBooks PRIMARY KEY(LibraryId, BookId)
)

-- 02. Insert
INSERT INTO Contacts(Email, PhoneNumber, PostAddress, Website)
VALUES (NULL, NULL, NULL, NULL),
	   (NULL, NULL, NULL, NULL),
	   ('stephen.king@example.com',	'+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
	   ('suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com')

INSERT INTO Authors([Name], ContactId)
VALUES ('George Orwell', 21),
	   ('Aldous Huxley', 22),
	   ('Stephen King',	23),
	   ('Suzanne Collins', 24)

INSERT INTO Books(Title, YearPublished, ISBN, AuthorId, GenreId)
VALUES ('1984',	1949, '9780451524935', 16, 2),
	   ('Animal Farm', 1945, '9780451526342', 16, 2),
	   ('Brave New World', 1932, '9780060850524', 17, 2),
	   ('The Doors of Perception', 1954, '9780060850531', 17, 2),
	   ('The Shining', 1977, '9780307743657', 18, 9),
	   ('It', 1986, '9781501142970', 18, 9),
	   ('The Hunger Games', 2008, '9780439023481', 19, 7),
	   ('Catching Fire', 2009, '9780439023498', 19, 7),
	   ('Mockingjay', 2010, '9780439023511', 19, 7)

INSERT INTO LibrariesBooks(LibraryId, BookId)
VALUES (1, 36),
	   (1, 37),
	   (2, 38),
	   (2, 39),
	   (3, 40),
	   (3, 41),
	   (4, 42),
	   (4, 43),
	   (5, 44)

-- 03. Update
UPDATE Contacts
   SET Website = CONCAT_WS('', 'www.', LOWER(REPLACE(a.[Name], ' ', '')), '.com')
  FROM Contacts AS c
  JOIN Authors AS a ON c.Id = a.ContactId
 WHERE c.Website IS NULL

-- 04. Delete
BEGIN TRANSACTION

DECLARE @authorsToDelete TABLE(Id INT)
DECLARE @booksToDelete TABLE(Id INT)

INSERT INTO @authorsToDelete(Id)
SELECT a.Id
  FROM Authors AS a
 WHERE a.[Name] = 'Alex Michaelides'

INSERT INTO @booksToDelete(Id)
SELECT b.Id
  FROM Books AS b
 WHERE b.AuthorId IN (SELECT Id FROM @authorsToDelete)

DELETE FROM LibrariesBooks
 WHERE BookId IN (SELECT Id FROM @booksToDelete)

DELETE FROM Books
 WHERE Id IN (SELECT Id FROM @booksToDelete)

DELETE FROM Authors
 WHERE Id IN (SELECT Id FROM @authorsToDelete)

COMMIT TRANSACTION

-- 05. Chronological Order
  SELECT b.Title AS [Book Title],
  	     b.ISBN,
  	     b.YearPublished AS YearReleased
    FROM Books AS b
ORDER BY YearReleased DESC, [Book Title]

-- 06. Books by Genre
  SELECT b.Id,
		 b.Title,
  	     b.ISBN,
		 g.[Name] AS Genre
    FROM Books AS b
	JOIN Genres AS g ON b.GenreId = g.Id
   WHERE g.[Name] IN ('Biography', 'Historical Fiction')
ORDER BY Genre, b.Title

-- 07. Missing Genre
DECLARE @booksWithSpecificGenre TABLE(Id INT)

INSERT INTO @booksWithSpecificGenre(Id)
SELECT b.Id
  FROM Books AS b
  JOIN Genres AS g ON b.GenreId = g.Id
 WHERE g.[Name] = 'Mystery'

  SELECT DISTINCT l.[Name] AS [Library],
  	     c.Email AS Email
    FROM Libraries AS l
    JOIN Contacts AS c ON l.ContactId = c.Id
   WHERE l.Id NOT IN (SELECT DISTINCT lb.LibraryId 
					    FROM LibrariesBooks AS lb 
					   WHERE lb.BookId IN (SELECT Id FROM @booksWithSpecificGenre))
ORDER BY [Library]

-- 08. First 3 Books
  SELECT TOP(3) b.Title,
  	     b.YearPublished AS [Year],
  	     g.[Name] AS Genre
    FROM Books AS b
    JOIN Genres AS g ON b.GenreId = g.Id
   WHERE (b.YearPublished > 2000 AND b.Title LIKE '%a%') OR
	     (b.YearPublished < 1950 AND g.[Name] LIKE '%Fantasy%')
ORDER BY b.Title, b.YearPublished DESC

-- 09. Authors from UK
  SELECT a.[Name] AS Author,
  	     c.Email AS Email,
  	     c.PostAddress AS [Address]
    FROM Authors AS a
    JOIN Contacts AS c ON a.ContactId = c.Id
   WHERE c.PostAddress LIKE '%UK%'
ORDER BY Author

-- 10. Fictions in Denver
  SELECT a.[Name] AS Author,
    	 b.Title,
    	 l.[Name] AS [Library],
  	     c.PostAddress AS [Library Address]
    FROM Books AS b
    LEFT JOIN Authors AS a ON b.AuthorId = a.Id
    LEFT JOIN LibrariesBooks AS lb ON b.Id = lb.BookId
    LEFT JOIN Libraries AS l ON lb.LibraryId = l.Id
    LEFT JOIN Contacts AS c ON l.ContactId = c.Id
    LEFT JOIN Genres AS g ON b.GenreId = g.Id
   WHERE g.[Name] = 'Fiction' AND
	     c.PostAddress LIKE '%Denver%'
ORDER BY b.Title

-- 11. Authors with Books
CREATE FUNCTION udf_AuthorsWithBooks(@name NVARCHAR(100)) 
RETURNS INT
AS
BEGIN
	RETURN
	(
		  SELECT COUNT(b.Id)
		    FROM Books AS b
		    JOIN Authors AS a ON b.AuthorId = a.Id
		   WHERE a.[Name] = @name
		GROUP BY a.[Name]
	)
END

-- 12. Search by Genre
CREATE PROCEDURE usp_SearchByGenre(@genreName NVARCHAR(30)) 
	AS
 BEGIN
	      SELECT b.Title,
		   	     b.YearPublished AS [Year],
		   	     b.ISBN,
		   	     a.[Name] AS Author,
		   	     g.[Name] AS Genre
	        FROM Books AS b
		    JOIN Authors AS a ON b.AuthorId = a.Id
		    JOIN Genres AS g ON b.GenreId = g.Id
		   WHERE g.[Name] = @genreName
		ORDER BY b.Title
   END