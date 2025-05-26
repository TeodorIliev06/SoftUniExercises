CREATE DATABASE may_2022_zad27
GO

USE may_2022_zad27
GO

--1.
CREATE TABLE [laptops]
(
	ID INT PRIMARY KEY IDENTITY,
	����� VARCHAR(50),
	����� VARCHAR(50),
	��������� INT,
	���� MONEY
)

--2.
INSERT INTO [laptops](�����, �����, ���������, ����)
VALUES ('Laptop1', 'L29KAS', 10, 1100),
	   ('Laptop2', '15FDR7', 14, 1350),
	   ('Laptop1', 'L29GTA', 12, 1500),
	   ('Laptop1', 'L29DFT', 8, 1499),
	   ('Laptop2', '15FDM5', 11, 1600)

--3.
DELETE FROM [laptops]
 WHERE ����� = '15FDR7'

--4.
SELECT *,
	   [���� ����] = ��������� * ���� * 1.2
  FROM [laptops]

--5.
SELECT *
  FROM [laptops] AS [l]
 WHERE [l].[�����] = 'Laptop1'