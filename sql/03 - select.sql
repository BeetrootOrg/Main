SELECT * FROM PersonsDB.dbo.Persons;

SELECT FirstName, LastName 
	FROM PersonsDB.dbo.Persons;

SELECT *
	FROM PersonsDB.dbo.Persons
	WHERE Age > 20;

SELECT *
	FROM PersonsDB.dbo.Persons
	ORDER BY Age;

SELECT *
	FROM PersonsDB.dbo.Persons
	ORDER BY Age DESC;

SELECT *
	FROM PersonsDB.dbo.Persons
	ORDER BY LastName DESC, FirstName;

SELECT AVG(Age) AS AverageAge
	FROM PersonsDB.dbo.Persons;

SELECT MAX(Age) AS MaxAge, MIN(Age) AS MingAge
	FROM PersonsDB.dbo.Persons;

SELECT FirstName, COUNT(*) AS Number
	FROM PersonsDB.dbo.Persons
	GROUP BY FirstName;

SELECT FirstName, COUNT(*) AS Number
	FROM PersonsDB.dbo.Persons
	GROUP BY FirstName
	HAVING FirstName LIKE '%D%';

SELECT FirstName AS FN, COUNT(1) AS Number
	FROM PersonsDB.dbo.Persons
	GROUP BY FirstName
	HAVING COUNT(1) > 1
	ORDER BY Number DESC;

SELECT *
	FROM PersonsDB.dbo.Persons
	WHERE FirstName IN (SELECT FirstName
		FROM PersonsDB.dbo.Persons
		GROUP BY FirstName
		HAVING COUNT(1) > 1);