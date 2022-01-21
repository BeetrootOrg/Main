UPDATE PersonsDB.dbo.Persons
	SET FirstName = 'D',
		Age = Age + 1
	WHERE LastName = 'Misik';

ALTER TABLE PersonsDB.dbo.Persons
ADD Gender VARCHAR(1) NOT NULL

ALTER TABLE PersonsDB.dbo.Persons
ADD Address VARCHAR(255)
