Create Table Books(
	BookId Int Identity(1,1) Not Null Primary Key,
	NameBook Varchar(100) Not Null,
	AuthorId Int Foreign Key References Authors(AuthorId),
	History Int Foreign Key References HistoryBook(BookId));

Create Table Authors(
	AuthorId Int Identity(1,1) Not Null Primary Key,
	FirstName Varchar(100) Not Null,
	LastName Varchar(100) Not Null);

Create Table CountOfEachBook(
	BookId Int Foreign Key References Authors(BookId),
	CountBook Int Not Null);

Create Table Customers(
	CustomerId Int Identity(1,1) Not Null Primary Key,
	FirstName Varchar(100) Not Null,
	LastName Varchar(100) Not Null,
	PhoneNumber Varchar(50) Not Null,
	Email Varchar(100) Not Null);

Create Table HistoryBook(
	BookId Int Foreign Key References Authors(BookId),
	TakenByCustomer Int Foreign Key References Customers(CustomerId),
	TakenTime DateTime Not Null,
	ReturnedTimf DateTime Not Null);
