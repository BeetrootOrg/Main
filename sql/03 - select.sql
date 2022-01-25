SELECT * FROM PersonsDB.dbo.Persons;

-- 1: select all males --
SELECT *
	FROM PersonsDB.dbo.Persons
	WHERE Gender = 'M';

-- 2: select all persons with age about 18 --
SELECT *
	FROM PersonsDB.dbo.Persons
	WHERE Age = 18;

-- 3: select all persons without address --
SELECT Id, FirstName, LastName, Age, Gender 
    FROM PersonsDB.dbo.Persons;
