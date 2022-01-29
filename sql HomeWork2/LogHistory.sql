CREATE DATABASE LogHistory;

--table to store user’s login history

SELECT * FROM LogHistory.dbo.LoginHistory;

CREATE TABLE LogHistory.dbo.LoginHistory
(
	Id BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	FirstName VARCHAR(40) NOT NULL,
	LastName VARCHAR(40) NOT NULL,
	EMail VARCHAR(228) NOT NULL,
	Pasword VARCHAR(4228) NOT NULL,
	DateAndTime DATETIME2 NOT NULL
);
