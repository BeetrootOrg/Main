--- 1 ---
CREATE TABLE dbo.Authors
(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Title VARCHAR(100) NOT NULL,
	Published DATETIME NOT NULL,
	Quantity INT NOT NULL,
);

CREATE TABLE dbo.Books
(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	AuthorId INT NOT NULL,
);

CREATE TABLE dbo.BookCount
(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	BookId INT NULL,
);



























--- 1 ---
CREATE TABLE dbo.Customers
(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
);

CREATE TABLE dbo.Salesmen
(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
);

CREATE TABLE dbo.Orders
(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	PurchaseAmount MONEY NOT NULL,
	OrderDatetime DATETIME NOT NULL,
	CustomerId INT NOT NULL,
	SalesmanId INT NOT NULL
);

SELECT * FROM dbo.Customers;
SELECT * FROM dbo.Salesmen;
SELECT * FROM dbo.Orders;

--- 2 ---
ALTER TABLE dbo.Orders ADD FOREIGN KEY (CustomerId) REFERENCES dbo.Customers(Id);
ALTER TABLE dbo.Orders ADD FOREIGN KEY (SalesmanId) REFERENCES dbo.Salesmen(Id);






































--1--
IF (NOT EXISTS (SELECT * 
	FROM sys.databases 
	WHERE name = 'BooksDB'))
BEGIN
	CREATE DATABASE [BooksDB]
END

;
GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Books'))
BEGIN
    CREATE TABLE BooksDB.dbo.Books
    (
      Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	  AuthorId INT NOT NULL,
    )
END
--2--
ALTER TABLE BooksDB.dbo.Books ADD FOREIGN KEY (AuthorId) REFERENCES AuthorsDB.dbo.Authors(Id);

ALTER TABLE BooksDB.dbo.Books 
ADD FOREIGN KEY (AuthorId) REFERENCES AuthorsDB.dbo.Authors(Id);
-------------------------------------------------------

--IF (NOT EXISTS (SELECT * 
--	FROM sys.databases 
--	WHERE name = 'PersonsDB'))
--BEGIN
--	CREATE DATABASE [PersonsDB]
--END

--;
--GO

--IF (NOT EXISTS (SELECT * 
--                 FROM INFORMATION_SCHEMA.TABLES 
--                 WHERE TABLE_SCHEMA = 'dbo' 
--                 AND  TABLE_NAME = 'Persons'))
--BEGIN
--    CREATE TABLE PersonsDB.dbo.Persons
--    (
--      PersonID int NOT NULL PRIMARY KEY,
--      LastName varchar(255) NOT NULL,
--      FirstName varchar(255),
--      Age int
--    )
--END

--SELECT * FROM PersonsDB.dbo.Persons;
--DELETE FROM PersonsDB.dbo.Persons;

-------------------------------------------------

--IF (NOT EXISTS (SELECT * 
--	FROM sys.databases 
--	WHERE name = 'OrdersDB'))
--BEGIN
--	CREATE DATABASE [OrdersDB]
--END

--;
--GO

--IF (NOT EXISTS (SELECT * 
--                 FROM INFORMATION_SCHEMA.TABLES 
--                 WHERE TABLE_SCHEMA = 'dbo' 
--                 AND  TABLE_NAME = 'Orders'))
--BEGIN
--    CREATE TABLE OrdersDB.dbo.Orders
--    (
--      OrderID int NOT NULL PRIMARY KEY,
--      OrderNumber int NOT NULL,
--      Person_ID int FOREIGN KEY REFERENCES PersonsDB.dbo.Persons(PersonID)
--    )
--END

----------------------------------------------------------------------------------