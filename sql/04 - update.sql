UPDATE PersonsDB.dbo.Persons
	SET FirstName = 'D',
		Age = Age + 1
	WHERE LastName = 'Misik';