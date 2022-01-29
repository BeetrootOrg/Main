IF (NOT EXISTS (SELECT * 
	FROM sys.databases 
	WHERE name = 'UsersLoginHistoryDB'))
BEGIN
	CREATE DATABASE [UsersLoginHistoryDB]
END

;
GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'UsersLoginHistory'))
BEGIN
    CREATE TABLE UsersLoginHistoryDB.dbo.UsersLoginHistory
    (
      Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
      IpAddr VARCHAR(32) NOT NULL,
      UserName VARCHAR(100) NOT NULL,
	  OS VARCHAR(100) NOT NULL,
      LogInTime DATETIME NOT NULL,
      LogOutTime DATETIME NULL,
    )
END

