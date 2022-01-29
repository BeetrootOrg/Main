CREATE DATABASE PersonsDB;

SELECT * FROM PersonsDB.dbo.PhoneBook;



--table for ‘phone book

CREATE TABLE PersonsDB.dbo.PhoneBook
(
	Id BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	FirstName VARCHAR(40) NOT NULL,
	LastName VARCHAR(40) NOT NULL,
	Adress VARCHAR(100) NOT NULL,
	NumberHouse VARCHAR(10) NOT NULL,
	PhoneNumber VARCHAR(40) NOT NULL
);


