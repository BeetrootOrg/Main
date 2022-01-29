--OPTIONAL: table to store school schedule
CREATE TABLE SchoolSchedule (
    LessonID int,
    TeatcherId int,
    GroupId int,
    LessonDate int,
    FormatId int
);
--OPTIONAL: table to store bank transactions data
CREATE TABLE BankTransactions(
    BankTransactionID int,
    TransactionDate datetime2,
    Amount Money,
    SenderId varchar(255),
    ReciverId varchar(255)
);
--table to store bank accounts
CREATE TABLE BankAccounts (
    BankAccountID int,
    LastName varchar(255),
    FirstName varchar(255),
    Amount Money,
    RegistrationDate date,
	IsVerified BIT 
);
--table to store user’s login history
CREATE TABLE LoginHistory (
    LoginHistoryID int,
    LastName varchar(255),
    FirstName varchar(255),
    Email varchar(255),
    LoginDate datetime2
); 
--table for ‘phone book
CREATE TABLE PhoneBook (
    PhoneBookID int,
    LastName varchar(255),
    FirstName varchar(255),
    Address varchar(255),
    Number varchar(255)
);