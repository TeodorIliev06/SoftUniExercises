-- 01. Create Database
CREATE DATABASE Minions

-- 02. Create Tables
CREATE TABLE Minions
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50),
	Age INT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

-- 03. Alter Minions Table
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

-- 04. Insert Records in Both Tables
INSERT INTO Towns ([Name])
VALUES ('Sofia'),
	   ('Plovdiv'),
	   ('Varna')

INSERT INTO Minions ([Name], Age, TownId)
VALUES ('Kevin', 22, 1),
	   ('Bob', 15, 3),
	   ('Steward', NULL, 2)

-- 05. Truncate Table Minions
TRUNCATE TABLE Minions

-- 06. Drop All Tables
DROP TABLE Minions
DROP TABLE Towns

-- 07. Create Table People
CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL,
		CHECK(Gender in ('m', 'f')),
	Birthdate DATETIME2 NOT NULL,
	Biography VARCHAR(MAX)
)

INSERT INTO People ([Name], Gender, Birthdate)
VALUES ('Metodi', 'm', '1996-05-05'),
	   ('Preslav', 'm', '1997-05-05'),
	   ('Ivan', 'm', '1997-05-05'),
	   ('Nikolai', 'm', '1998-05-05'),
	   ('Krasimir', 'm', '1999-05-05')

-- 08. Create Table Users
CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME2,
	IsDeleted BIT
)

INSERT INTO Users (Username, [Password])
VALUES ('Metodi', 'totev'),
	   ('Preslav', 'petrov'),
	   ('Nikolai', 'pachev'),
	   ('Evgeni', 'smeshniq'),
	   ('Teodor', 'iliev')

--09. Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07C5CA3A29]

ALTER TABLE Users
ADD CONSTRAINT PK_UsersTable PRIMARY KEY(Id, Username)

--10. Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CHK_PasswordIsAtLeast5Symbols 
	CHECK(LEN(Password) >= 5)

--11. Set Default Value of a Field
UPDATE Users
SET LastLoginTime = GETDATE() 

--12. Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT [PK_UsersTable]

ALTER TABLE Users
ADD CONSTRAINT PK_UsersTable PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameIsAtLeast3Symbols
	CHECK(LEN(Username) >= 3)

ALTER TABLE Users
ADD CONSTRAINT UQ_Username UNIQUE(Username)

-- 13. Movies Database
CREATE DATABASE Movies
USE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName VARCHAR(50) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Directors (DirectorName)
VALUES ('Metodi'),
	   ('Preslav'),
	   ('Nikolai'),
	   ('Evgeni'),
	   ('Teodor')

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(50) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Genres (GenreName)
VALUES ('Action'),
	   ('Romance'),
	   ('Thriller'),
	   ('Horror'),
	   ('Comedy')

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Categories (CategoryName)
VALUES ('12+'),
	   ('14+'),
	   ('16+'),
	   ('18+'),
	   ('Forbidden')

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(50) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear INT,
	[Length] INT NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating DECIMAL(2,1) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Movies (Title, DirectorId, [Length], GenreId, CategoryId, Rating)
VALUES ('The Godfather', 2, 90, 1, 2, 9.7),
	   ('Star Wars', 5, 120, 2, 4, 8.9),
	   ('Oppenheimer', 3, 180, 2, 3, 9.8),
	   ('Interstellar', 3, 156, 3, 2, 9.7),
	   ('The Dark Knight', 4, 134, 5, 1, 9.4)

-- 14. CarRental Database
CREATE DATABASE CarRental
USE CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate DECIMAL(2,1),
	WeeklyRate DECIMAL(2,1),
	MonthlyRate DECIMAL(2,1),
	WeekendRate DECIMAL(2,1),
)

INSERT INTO Categories (CategoryName)
VALUES ('FamilyCar'),
	   ('SportCar'),
	   ('SuperCar')

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(12) NOT NULL,
	Manufacturer VARCHAR(50),
	Model VARCHAR(50),
	CarYear INT,
	CategoryId INT NOT NULL,
	Doors INT,
	Picture VARBINARY(MAX),
	Condition VARCHAR(50),
	Available BIT
)

INSERT INTO Cars (PlateNumber, CategoryId)
VALUES ('EN 1292 BH', 1),
	   ('SO 8512 ST', 2),
	   ('A 8915 KR', 3)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Title VARCHAR(50),
	Notes NVARCHAR(200)
)

INSERT INTO Employees (FirstName, LastName)
VALUES ('Metodi', 'Totev'),
	   ('Nikolai', 'Pachev'),
	   ('Teodor', 'Iliev')

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber INT,
	FullName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(50) NOT NULL,
	City VARCHAR(50) NOT NULL,
	ZIPCode VARCHAR(50),
	Notes NVARCHAR(200)
)

INSERT INTO Customers (FullName, [Address], City)
VALUES ('Metodi Totev', 'Druzhba 123', 'Pleven'),
	   ('Nikolai Pachev', 'Druzhba 456', 'Pleven'),
	   ('Teodor Iliev', 'Shesta dge', 'Pleven')

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT,
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATETIME2,
	EndDate DATETIME2,
	TotalDays INT,
	RateApplied DECIMAL(2,1),
	TaxRate DECIMAL(5,2),
	OrderStatus VARCHAR(20),
	Notes NVARCHAR(200)
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId)
VALUES (1, 3, 2),
	   (2, 2, 1),
	   (3, 1, 3)

-- 15. Hotel Database
CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Title VARCHAR(50),
	Notes NVARCHAR(200)
)

INSERT INTO Employees (FirstName, LastName)
VALUES ('Metodi', 'Totev'),
	   ('Nikolai', 'Pachev'),
	   ('Teodor', 'Iliev')

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(10) NOT NULL
		CHECK(LEN(PhoneNumber) = 10),
	EmergencyName VARCHAR(50),
	EmergencyNumber INT,
	Notes NVARCHAR(200)
)

INSERT INTO Customers (FirstName, LastName, PhoneNumber)
VALUES ('Metodi', 'Totev',   '0891234567'),
	   ('Nikolai', 'Pachev', '0872345678'),
	   ('Teodor', 'Iliev',   '0883456789')

CREATE TABLE RoomStatus 
(
    RoomStatus VARCHAR(50) PRIMARY KEY,
    Notes NVARCHAR(500)
)

INSERT INTO RoomStatus (RoomStatus)
VALUES ('Cleaned'),
	   ('In use'),
	   ('Out of order')

CREATE TABLE RoomTypes 
(
    RoomType VARCHAR(50) PRIMARY KEY,
    Notes NVARCHAR(500)
)

INSERT INTO RoomTypes (RoomType)
VALUES ('Single'),
	   ('Apartment'),
	   ('Box')

CREATE TABLE BedTypes 
(
    BedType VARCHAR(50) PRIMARY KEY,
    Notes NVARCHAR(500)
)

INSERT INTO BedTypes (BedType)
VALUES ('Large'),
	   ('Double'),
	   ('KingSize')

CREATE TABLE Rooms 
(
    RoomNumber INT PRIMARY KEY IDENTITY(100, 1),
    RoomType VARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
    BedType VARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
    Rate DECIMAL(2,1),
    RoomStatus BIT,
    Notes NVARCHAR(1000)
)

INSERT INTO Rooms (RoomType, BedType)
VALUES ('Single', 'Large'),
	   ('Single', 'Large'),
	   ('Apartment', 'Double')

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATETIME,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATETIME,
	LastDateOccupied DATETIME,
	TotalDays INT,
	AmountCharged DECIMAL(5,2),
	TaxRate DECIMAL(4,2),
	PaymentTotal DECIMAL(5,2),
	Notes NVARCHAR(200)
)

INSERT INTO Payments (EmployeeId, AccountNumber)
VALUES (1, 2),
	   (2, 3),
	   (3, 1)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATETIME,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber)
		CHECK(RoomNumber >=100),
	LastDateOccupied DATETIME,
	RateApplied DECIMAL(2,1),
	PhoneCharge DECIMAL(3,2),
	Notes NVARCHAR(200)
)

INSERT INTO Occupancies (EmployeeId, AccountNumber, RoomNumber)
VALUES (1, 2, 100),
	   (2, 3, 101),
	   (3, 1, 102)

-- 16. Create SoftUni Database
CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(50),
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE,
	Salary DECIMAL(6,2),
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

--17. Backup Database
BACKUP DATABASE SoftUni
TO DISK = 'D:\SQL2019\MSSQL15.MSSQLSERVER\MSSQL\Backup\softuni-backup.bak'
WITH FORMAT, 
     MEDIANAME = 'SoftUniBackup',
     NAME = 'Full Backup of SoftUni'

DROP DATABASE SoftUni;

-- Restore the SoftUni database from the backup file
RESTORE DATABASE SoftUni
FROM DISK = 'D:\SQL2019\MSSQL15.MSSQLSERVER\MSSQL\Backup\softuni-backup.bak'
WITH MOVE 'SoftUni' TO 'D:\SQL2019\MSSQL15.MSSQLSERVER\MSSQL\DATA\SoftUni.mdf', 
     MOVE 'SoftUni_log' TO 'D:\SQL2019\MSSQL15.MSSQLSERVER\MSSQL\DATA\SoftUni_log.ldf'

--18.Basic Insert
INSERT INTO Towns ([Name])
VALUES ('Sofia'),
	   ('Plovdiv'),
	   ('Varna'),
	   ('Burgas')

INSERT INTO Departments([Name])
VALUES ('Engineering'),
	   ('Sales'),
	   ('Marketing'),
	   ('Software Development'),
	   ('Quality Assurance')
	   
INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
	   ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
	   ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
	   ('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
	   ('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)	 
	   
--19. Basic Select All Fields
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--20. Basic Select All Fields and Order Them
SELECT * FROM Towns
ORDER BY [Name] ASC

SELECT * FROM Departments
ORDER BY [Name] ASC

SELECT * FROM Employees
ORDER BY Salary DESC

--21. Basic Select Some Fields
SELECT [Name] FROM Towns
ORDER BY [Name] ASC

SELECT [Name] FROM Departments
ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--22. Increase Employees Salary
USE SoftUni
UPDATE Employees
SET Salary = Salary * 1.10

SELECT Salary FROM Employees

--23. Decrease Tax Rate
USE Hotel
UPDATE Payments
SET TaxRate = TaxRate * 0.97

SELECT TaxRate FROM Payments

--24. Delete All Records
USE Hotel
TRUNCATE TABLE Occupancies