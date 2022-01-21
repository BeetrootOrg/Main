DELETE FROM PersonsDB.dbo.Persons WHERE FirstName = 'D';

DELETE FROM PersonsDB.dbo.Persons;

ALTER TABLE PersonsDB.dbo.Persons
DROP COLUMN Gender;

ALTER TABLE PersonsDB.dbo.Persons
DROP COLUMN Address;

UPDATE PersonsDB.dbo.Persons 
SET Address = NULL;
