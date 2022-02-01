Create Table BankAccount(
	Id BIGINT IDENTITY(1, 1) NOT NULL Primary Key,
	Login Varchar(100) NOT NULL,
	Password Varchar(100) NOT NULL,
	PhoneNumber Varchar(100) NOT NULL,
	Email Varchar(200) NOT NULL,
	AccountNumber Varchar(200) NOT NULL);