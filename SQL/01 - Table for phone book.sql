Create Table PhoneBook(
	ContactId BIGINT IDENTITY(1, 1) NOT NULL Primary Key,
	PhoneNumber Varchar(20) NOT NULL,
	FirstName Varchar(100) NOT NULL,
	LastName Varchar(100) NOT NULL,
	Age Int,
	City Varchar(100));