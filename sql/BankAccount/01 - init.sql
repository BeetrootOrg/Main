IF (NOT EXISTS (SELECT * 
	FROM sys.databases 
	WHERE name = 'BankAccountsDB'))
BEGIN
	CREATE DATABASE [BankAccountsDB]
END

;
GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'BankAccounts'))
BEGIN
    CREATE TABLE BankAccountsDB.dbo.BankAccounts
    (
      Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
      AccountName VARCHAR(100) NOT NULL,
      AccountCode VARCHAR(100) NOT NULL,
	  BankName VARCHAR(100) NOT NULL,
      AccountNumber VARCHAR(100) NOT NULL,
      Balance MONEY NOT NULL,
	  Status VARCHAR(32) NOT NULL
    )
END
