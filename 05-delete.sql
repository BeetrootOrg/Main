--delete all rows without address
DELETE FROM PersonsDB.dbo.Persons WHERE Address is NULL;