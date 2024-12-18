-- 01. One-To-One Relationship
CREATE DATABASE [TableRelations]
USE [TableRelations]
GO

CREATE TABLE [Passports]
(
	[PassportID] INT PRIMARY KEY IDENTITY(101, 1),
	[PassportNumber] VARCHAR(8) NOT NULL
		CHECK(LEN([PassportNumber]) = 8),
)

CREATE TABLE [Persons]
(
	[PersonID] INT PRIMARY KEY IDENTITY(101, 1),
	[FirstName] VARCHAR(15) NOT NULL,
	[Salary] DECIMAL(7,2) NOT NULL,
	[PassportID] INT UNIQUE FOREIGN KEY REFERENCES [Passports](PassportID)
)

INSERT INTO [Passports] ([PassportNumber])
VALUES ('N34FG21B'),
	   ('K65LO4R7'),
	   ('ZE657QP2')

INSERT INTO [Persons] ([FirstName], [Salary], [PassportID])
VALUES ('Roberto', 43300.00, 102),
	   ('Tom', 56100.00, 103),
	   ('Yana', 60200.00, 101)

-- 02. One-To-Many Relationship
CREATE TABLE [Manufacturers]
(
	[ManufacturerID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
	[EstablishedOn] DATE NOT NULL
)

CREATE TABLE [Models]
(
	[ModelID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(20) NOT NULL,
	[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers](ManufacturerID)
)

INSERT INTO [Manufacturers] ([Name], [EstablishedOn])
VALUES ('BMW', '07/03/1916'),
	   ('Tesla', '01/01/2003'),
	   ('Lada', '01/05/1966')

INSERT INTO [Models] ([Name], [ManufacturerID])
VALUES ('X1', 1),
	   ('i6', 1),
	   ('Model S', 2),
	   ('Model X', 2),
	   ('Model 3', 2),
	   ('Nova', 3)

-- 03. Many-To-Many Relationship
CREATE TABLE [Students]
(
	[StudentID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
)

CREATE TABLE [Exams]
(
	[ExamID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(20) NOT NULL,
)

CREATE TABLE [StudentsExams]
(
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
	[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]),
	CONSTRAINT PK_StudentsExams PRIMARY KEY([StudentID], [ExamID])
)

INSERT INTO [Students] ([Name])
VALUES ('Mila'),
	   ('Toni'),
	   ('Ron')

INSERT INTO [Exams] ([Name])
VALUES ('SpringMVC'),
	   ('Neo4j'),
	   ('Oracle 11g')

INSERT INTO [StudentsExams] ([StudentID], [ExamID])
VALUES (1, 101),
	   (1, 102),
	   (2, 101),
	   (3, 103),
	   (2, 102),
	   (2, 103)

-- 04. Self-Referencing
CREATE TABLE [Teachers]
(
	[TeacherID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(20) NOT NULL,
	[ManagerID] INT REFERENCES [Teachers]([TeacherID])
)

INSERT INTO [Teachers] ([Name], [ManagerID])
VALUES ('John', NULL),
	   ('Maya', NULL),
	   ('Silvia', NULL),
	   ('Ted', NULL),
	   ('Mark', NULL),
	   ('Greta', NULL)

UPDATE [Teachers]
SET [ManagerID] = 106
WHERE [TeacherID] IN (102, 103)

UPDATE [Teachers]
SET [ManagerID] = 105
WHERE [TeacherID] = 104

UPDATE [Teachers]
SET [ManagerID] = 101
WHERE [TeacherID] IN (105, 106)

-- 05. Online Store Database
CREATE DATABASE OnlineStore
USE OnlineStore
GO

CREATE TABLE [Cities]
(
	[CityID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
)

CREATE TABLE [Customers]
(
	[CustomerID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
	[Birthday] DATE,
	[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID])
)

CREATE TABLE [Orders]
(
	[OrderID] INT PRIMARY KEY IDENTITY,
	[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID])
)

CREATE TABLE [ItemTypes]
(
	[ItemTypeID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
)

CREATE TABLE [Items]
(
	[ItemID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID])
)

CREATE TABLE [OrderItems]
(
	[OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID]),
	[ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID]),
	CONSTRAINT PK_OrderItems PRIMARY KEY([OrderID],[ItemID])
)

-- 06. University Database
CREATE DATABASE [University]
USE [University]
GO

CREATE TABLE [Majors]
(
	[MajorID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
)

CREATE TABLE [Students]
(
	[StudentID] INT PRIMARY KEY IDENTITY,
	[StudentNumber] INT UNIQUE NOT NULL,
	[StudentName] VARCHAR(20) NOT NULL,
	[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID])
)

CREATE TABLE [Payments]
(
	[PaymentID] INT PRIMARY KEY IDENTITY,
	[PaymentDate] DATETIME NOT NULL,
	[PaymentAmount] DECIMAL(6,2) NOT NULL,
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
)

CREATE TABLE [Subjects]
(
	[SubjectID] INT PRIMARY KEY IDENTITY,
	[SubjectName] VARCHAR(20) NOT NULL,
)

CREATE TABLE [Agenda]
(
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
	[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]),
	CONSTRAINT PK_Agenda PRIMARY KEY([StudentID],[SubjectID])
)

-- 09. *Peaks in Rila
USE [Geography]
GO

  SELECT [MountainRange], [PeakName], [Elevation]
    FROM [Peaks] AS [p]
    JOIN [Mountains] AS [m] ON [p].MountainId = [m].[Id]
   WHERE [MountainRange] = 'Rila'
ORDER BY [Elevation] DESC
