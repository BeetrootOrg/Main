IF (NOT EXISTS (SELECT * 
	FROM sys.databases 
	WHERE name = 'AuthorskDB'))
BEGIN
	CREATE DATABASE [AuthorsDB]
END

;
GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Authors'))
BEGIN
    CREATE TABLE AuthorsDB.dbo.Authors
    (
      Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
      Name VARCHAR(100) NOT NULL,
      Title VARCHAR(100) NOT NULL,
	  Published DATETIME NOT NULL,
    )
END
