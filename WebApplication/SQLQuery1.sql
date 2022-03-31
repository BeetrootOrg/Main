CREATE TABLE OrderDB.dbo.Orders
(
	Id BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	MaterialName VARCHAR(80),
	MaterialLength FLOAT,
	MaterialWidth FLOAT,
	MaterialThickness FLOAT,
	ReceiptTime TIMESTAMP,
	MaterialSupplier VARCHAR(80),
	OrderExecutor VARCHAR(80)
);
