UPDATE BankAccountsDB.dbo.BankAccounts
	SET Balance = Balance + 1000
	WHERE AccountName = 'Petrov' AND AccountNumber = '1234';

UPDATE BankAccountsDB.dbo.BankAccounts
	SET Balance = Balance + 1000
	WHERE AccountName = 'Ivanov' AND AccountNumber = '5678';

UPDATE BankAccountsDB.dbo.BankAccounts
	SET Balance = Balance + 1000
	WHERE AccountName = 'Sidorov' AND AccountNumber = '1234';
