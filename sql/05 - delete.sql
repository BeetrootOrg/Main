-- 5: clear all rows without address --
UPDATE PersonsDB.dbo.Persons
	SET FirstName = Null,
	LastName = Null,
		Age = Null,
		Gender = Null;

-- 5: delete all rows without address --
ALTER TABLE PersonsDB.dbo.Persons
DROP COLUMN FirstName, LastName, Age, Gender;
