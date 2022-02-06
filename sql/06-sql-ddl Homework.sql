--Create few tables schemas (min 5 columns):
--table for ‘phone book
CREATE TABLE PhoneBookDB.dbo.PhoneBook
(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    PhoneNumber VARCHAR(40) NOT NULL,
	Address VARCHAR(255) NULL,

)

--table to store user’s login history
CREATE TABLE Users.dbo.LoginHistory
(
	AccountLogin VARCHAR(100) NOT NULL Primary key,
	SessionNumber INT IDENTITY(1, 1) NOT NULL, 
    DateOfLogin DateTime NOT NULL,	
    NumberOfTryBeforeSuccess TinyInt NOT NULL,
    IpAdress VARCHAR(16) NOT NULL,
)

--table to store bank accounts
CREATE TABLE Bank.dbo.BankAccounts
(
	Id INT IDENTITY(1, 1) NOT NULL Primary key, 
    AccountNumber VARCHAR(30) NOT NULL,	
	AccountBalance MONEY NOT NULL,
	OwnerName VARCHAR(155) NOT NULL,
	OwnerLastName VARCHAR(155) NOT NULL,
	ContactTelephone VARCHAR(70) NULL,
	ResponsibleManager INT NOT NULL

)

--OPTIONAL: table to store bank transactions data
CREATE TABLE Bank.dbo.BankTansaction
(
	Id INT IDENTITY(1, 1) NOT NULL Primary key, 
    SenderAccount VARCHAR(30) NOT NULL,	
	ReceiveAccount VARCHAR(30) NOT NULL,
	SumOfTransanciont MONEY NOT NULL,
	TimeOfTransaction DateTime NOT NULL,
	BankComission MONEY NOT NULL
)

--OPTIONAL: table to store school schedule
CREATE TABLE School.dbo.SchoolSchedule
(
	Class Tinyint NOT NULL Primary key, 
    Subject VARCHAR(30) NOT NULL,
	ResponsibleTeacher INT NULL,
	NumberOfRoom INT NOT NULL,
	DayOfStudy DateTime NOT NULL,
)
	