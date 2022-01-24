ALTER TABLE dbo.Orders ADD FOREIGN KEY (CustomerId) REFERENCES dbo.Customers(Id);
ALTER TABLE dbo.Orders ADD FOREIGN KEY (SalesmanId) REFERENCES dbo.Salesmen(Id);
