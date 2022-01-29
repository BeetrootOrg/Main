-- select all males
SELECT TOP (1000) [Id]
      ,[FirstName]
      ,[LastName]
      ,[Age]
      ,[Gender]
      ,[Address]
  FROM [PersonsDB].[dbo].[Persons]
 Where Gender = 'M'
 --select all persons with age about 18
 SELECT TOP (1000) [Id]
      ,[FirstName]
      ,[LastName]
      ,[Age]
      ,[Gender]
      ,[Address]
  FROM [PersonsDB].[dbo].[Persons]
 Where Age > 18
 --select all persons without address
  SELECT TOP (1000) [Id]
      ,[FirstName]
      ,[LastName]
      ,[Age]
      ,[Gender]
      ,[Address]
  FROM [PersonsDB].[dbo].[Persons]
 Where Address = NULL
 --update age of all persons, add 1 year
 SELECT TOP (1000) [Id]
      ,[FirstName]
      ,[LastName]
      ,[Age]
      ,[Gender]
      ,[Address]
  FROM [PersonsDB].[dbo].[Persons]
 UPDATE PersonsDB.dbo.Persons
	SET Age = Age + 1
--delete all rows without address
 SELECT TOP (1000) [Id]
      ,[FirstName]
      ,[LastName]
      ,[Age]
      ,[Gender]
      ,[Address]
  FROM [PersonsDB].[dbo].[Persons]
DELETE FROM PersonsDB.dbo.Persons WHERE Address = Null;
--OPTIONAL: count the number of rows in the table
 SELECT COUNT(*) FROM [PersonsDB].[dbo].[Persons]
--OPTIONAL: group persons by age and show how many persons with same age
SELECT Age, COUNT(*) as Counted
FROM [PersonsDB].[dbo].[Persons] 
GROUP BY Age;
