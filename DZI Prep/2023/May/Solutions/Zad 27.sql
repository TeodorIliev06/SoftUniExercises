CREATE DATABASE university
GO

USE university
GO

--1.
CREATE TABLE students
(
	Admission_no INT PRIMARY KEY,
	First_name VARCHAR(25),
	Last_name VARCHAR(25),
	City VARCHAR(25)
)

--2.
CREATE TABLE fee
(
	Admission_no INT FOREIGN KEY
		REFERENCES students(Admission_no),
	Course VARCHAR(25),
	Amount_paid INT
)

--3.
INSERT INTO students(Admission_no, First_name, Last_name, City)
VALUES (3354, 'Georgi', 'Georgiev', 'Varna'),
	   (4321, 'Milena', 'Georgieva', 'Stara Zagora'),
	   (8345, 'Mihail', 'Martinov', 'Plovdiv'),
	   (7555, 'Antonio', 'Tachev', 'Stara Zagora'),
	   (2135, 'Martin', 'Ivanov', 'Sofia')

--4.
INSERT INTO fee(Admission_no, Course, Amount_paid)
VALUES (3354, 'Java', 2000),
	   (7555, 'C#', 2000),
	   (4321, 'SQL', 2000),
	   (4321, 'Java', 2000),
	   (8345, 'C++', 2000)