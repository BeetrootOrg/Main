IF (NOT EXISTS (SELECT * 
	FROM sys.databases 
	WHERE name = 'PhoneBookDB'))
BEGIN
	CREATE DATABASE [PhoneBookDB]
END

;
GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'PhoneBook'))
BEGIN
    CREATE TABLE PhoneBookDB.dbo.PhoneBook
    (
      Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
      FirstName VARCHAR(100) NOT NULL,
      LastName VARCHAR(100) NOT NULL,
      PhoneNumber VARCHAR(32) NOT NULL,
      Email VARCHAR(64) NOT NULL,
    )
END