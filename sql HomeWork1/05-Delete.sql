--delete all rows without address
DELETE PersonsDB.dbo.Persons
	WHERE Address IS NULL;