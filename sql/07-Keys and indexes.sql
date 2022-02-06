--Create normalized tables for the library domain. it should include:
--books
--authors
--count of each book
--customers
--history which book was taken by whom and when

CREATE TABLE dbo.Authors
(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	DateOfBirth Date NOT Null,
);

CREATE TABLE dbo.Books
(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	BookName VARCHAR(100) NOT NULL,
	AuthorId INT NOT NULL,
	DateOfCreating Date NOT NULL,
	QuanityInLibrary INT NULL,

);

CREATE TABLE dbo.Customers
(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	
);

CREATE TABLE dbo.HistoryOfBooksReading
(
	BookId INT NOT NULL,
	CustomerId INT NOT NULL,
	DateOfBorrow Date NOT NULL,
	DateOfReturn Date NULL,
	
	
);


ALTER TABLE dbo.Books ADD FOREIGN KEY (AuthorId) REFERENCES dbo.Authors(Id);
ALTER TABLE dbo.HistoryOfBooksReading ADD FOREIGN KEY (BookId) REFERENCES dbo.Books(Id);
ALTER TABLE dbo.HistoryOfBooksReading ADD FOREIGN KEY (CustomerId) REFERENCES dbo.Customers(Id);

