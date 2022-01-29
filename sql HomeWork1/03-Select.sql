SELECT * FROM PersonsDB.dbo.Persons;

--select all males
SELECT *
	FROM PersonsDB.dbo.Persons
	WHERE Gender = 'M';

--select all persons with age about 18

SELECT *
	FROM PersonsDB.dbo.Persons
	WHERE Age > 18;

--select all persons without address
SELECT *
	FROM PersonsDB.dbo.Persons
	WHERE Address IS NULL;

--OPTIONAL: count the number of rows in the table
SELECT COUNT (*) AS NumberOfRows
	FROM PersonsDB.dbo.Persons;

--OPTIONAL: group persons by age and show how many persons with same age
SELECT *
	FROM PersonsDB.dbo.Persons
	ORDER BY Age
	