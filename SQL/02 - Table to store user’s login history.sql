Create Table LoginHistoty(
	LoginId BIGINT IDENTITY(1, 1) NOT NULL Primary Key,
	UserName Varchar(100) NOT NULL,
	TimeLogin Datetime NOT NULL,
	TimeLogout Datetime NOT NULL,
	SessionTime Timestamp NOT NULL);