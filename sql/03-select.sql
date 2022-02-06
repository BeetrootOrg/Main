-- select all
SELECT * FROM PersonsDB.dbo.Persons;

-- select all males
SELECT *
	FROM PersonsDB.dbo.Persons
	WHERE GENDER = 'M';

--select all persons with age about 18
SELECT *
	FROM PersonsDB.dbo.Persons
	WHERE AGE = 18;

--select all persons without address
SELECT *
	FROM PersonsDB.dbo.Persons
	WHERE ADDRESS is null;