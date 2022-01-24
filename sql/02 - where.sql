SELECT o.Id AS OrderId,
	o.PurchaseAmount,
	o.OrderDatetime,
	c.FirstName AS CustomerFirstName,
	c.LastName AS CustomerLastName,
	s.FirstName AS SalesFirstName,
	s.LastName AS SalesLastName
	FROM dbo.Orders AS o,
		dbo.Customers AS c,
		dbo.Salesmen AS s
	WHERE o.CustomerId = c.Id AND
		o.SalesmanId = s.Id;