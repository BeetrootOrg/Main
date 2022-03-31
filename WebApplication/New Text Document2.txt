CREATE TABLE OrderDB.dbo.Orders
(
	Id BIGINT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Flash VARCHAR(20),
	Customer VARCHAR(60),
	Ord VARCHAR(25),
        Steel VARCHAR(60),
        Surface VARCHAR(60),
	Thickness FLOAT,
	Qty INT,
	Bending BIT,
	Dimension1 FLOAT,
	Dimension2 FLOAT,
        Note TEXT,
        Manager VARCHAR(60),
        Operator VARCHAR(60),
	Modified TIMESTAMP
);