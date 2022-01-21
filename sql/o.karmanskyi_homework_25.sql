SELECT *
	FROM PersonsDB.dbo.Persons
	WHERE Gender = 'M'

SELECT *
	FROM PersonsDB.dbo.Persons
	WHERE Age > 18

SELECT *
	FROM PersonsDB.dbo.Persons
	WHERE Address = NULL

UPDATE PersonsDB.dbo.Persons
	SET Age = Age + 1

DELETE FROM PersonsDB.dbo.Persons
	WHERE Address = NULL

SELECT COUNT(FirstName)
	FROM PersonsDB.dbo.Persons

SELECT Age 'Age Group',
	COUNT(*) 'No of people'
	FROM PersonsDB.dbo.Persons
	GROUP BY Age