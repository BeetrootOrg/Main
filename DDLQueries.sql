--table for ‘phone book’
CREATE TABLE AutomaticPhoneExchangeDB.dbo.PhoneBook
(
	Id BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	FirstName VARCHAR(40) NOT NULL,
	LastName VARCHAR(40) NOT NULL,
	Adress VARCHAR(100) NOT NULL,
	NumberHouse VARCHAR(10) NOT NULL,
	PhoneNumber VARCHAR(40) NOT NULL
);


--table to store user’s login history
CREATE TABLE DB.dbo.LoginHistory
(
	EntryId BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	UserId BIGINT NOT NULL,
	EntryTime TimeStamp NOT NULL
);


--table to store bank accounts
CREATE TABLE BankDB.dbo.BankAccount
(
	Id BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	FirstName VARCHAR(40) NOT NULL,
	LastName VARCHAR(40) NOT NULL,
	CardNumber BIGINT NOT NULL,
	ExpirationDate DATE NOT NULL,
	Debit MONEY NOT NULL
);

CREATE TABLE BankDB.dbo.TransactionsData
(
	TransactionId BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	PayerId BIGINT NOT NULL,
	PayeeId BIGINT NOT NULL,
	PaymentSum MONEY NOT NULL,
	TransactionCompletionTime TimeStamp NOT NULL
);

--table to store school schedule
CREATE TABLE SchoolDB.dbo.Schedule
(
	TeacherId smallint NOT NULL,
	ClassId VARCHAR(3) NOT NULL,
	SubjectName VARCHAR(30) NOT NULL,
	DayOfTheWeek smallint NOT NULL,
	LessonNumber smallint NOT NULL,
	CabinetNumber smallint NOT NULL,
	CONSTRAINT PK_CabinetNumber_DayOfTheWeek_LessonNumber PRIMARY KEY NONCLUSTERED (CabinetNumber, DayOfTheWeek, LessonNumber)
);