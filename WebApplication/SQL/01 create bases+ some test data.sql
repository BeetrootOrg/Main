IF (NOT EXISTS (SELECT * 
	FROM sys.databases 
	WHERE name = 'DocumentsDB'))
BEGIN
	CREATE DATABASE DocumentsDB
END;
GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Users'))
BEGIN
    CREATE TABLE DocumentsDB.dbo.Users  
    (
      Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
      FirstName VARCHAR(255) ,
      Patronymic VARCHAR(255),
	  LastName VARCHAR(255),
	  DateOfBirth date,
	  TaxNumber bigint NOT NULL,
      Address VARCHAR(255),
      Email VARCHAR(100)
    )	
END;

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Courts'))
BEGIN
    CREATE TABLE DocumentsDB.dbo.Courts
    (
      Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
      Name VARCHAR(100),
      Address VARCHAR(100)
    )
END

GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'StatementKinds'))
BEGIN
    CREATE TABLE DocumentsDB.dbo.StatementKinds
    (
      Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
      Type VARCHAR(100),
      Name VARCHAR(100)
    )
END

INSERT INTO DocumentsDB.dbo.StatementKinds
	VALUES ('divorce','Позовна заява про розлучення'),
		('courtorder','Судовий наказ'),
		('moneyclaim','Позовна заява про стягнення заборгованості')

INSERT INTO DocumentsDB.dbo.Courts
	VALUES ('Київський районний суд міста Одеси','65080, м. Одеса, вул. Варненська, 3-б'),
		('Малиновський районний суд міста Одеси','65033, м. Одеса, вул. Василя Стуса, 1а'),
		('ПРИМОРСЬКИЙ РАЙОННИЙ СУД МІСТА ОДЕСИ', 'м. Одеса, вул. Балківська, 33'),
		('Суворовський районний суд м. Одеси','65003, м. Одеса, вул. Чорнмоморського козацтва, 68')

INSERT INTO DocumentsDB.dbo.Users
	VALUES ('Іван','Іванович','Ковальов','2000-01-01',1231237890,'65027','test2@gmail.com'),
		('Анжела','Юрівна','Сукачова','1921-03-21',3213456219,'65012, м. Одеса, вул.Пушкніська, 12','test@text.gmail.com')

Select * FROM DocumentsDB.dbo.Users

Select * FROM DocumentsDB.dbo.Courts