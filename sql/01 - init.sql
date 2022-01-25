IF (NOT EXISTS (SELECT * 
	FROM sys.databases 
	WHERE name = 'PersonsDB'))
BEGIN
	CREATE DATABASE [PersonsDB]
END

;
GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Persons'))
BEGIN
    CREATE TABLE PersonsDB.dbo.Persons
    (
      Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
      FirstName VARCHAR(100) NULL,
      LastName VARCHAR(100) NULL,
      Age TINYINT NULL,
      Gender VARCHAR(1) NULL,
      Address VARCHAR(255)
    )
END
