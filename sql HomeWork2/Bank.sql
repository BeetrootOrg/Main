CREATE DATABASE BankAccount;

--table to store bank accounts

SELECT * FROM BankAccount.dbo.BankAccount;

CREATE TABLE BankAccount.dbo.BankAccount
(
	Id BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	FirstName VARCHAR(40) NOT NULL,
	LastName VARCHAR(40) NOT NULL,
	NumberOfTheCard INT NOT NULL,
	EndDateOfCard DATETIME NOT NULL,
	AmountOFMoney MONEY NOT NULL,
);
