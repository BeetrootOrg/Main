Create Table TransactionAccount(
	TransactionId BIGINT IDENTITY(1, 1) NOT NULL Primary Key,
	FromAccount Varchar(200) NOT NULL,
	ToAccount Varchar(200) NOT NULL,
	Summ Money NOT NULL,
	TransactionTime Datetime NOT NULL,
	PurposeOfPayment Text);