SELECT o.Id AS OrderId,
	o.PurchaseAmount,
	o.OrderDatetime,
	c.FirstName AS CustomerFirstName,
	c.LastName AS CustomerLastName,
	s.FirstName AS SalesFirstName,
	s.LastName AS SalesLastName
	FROM dbo.Orders AS o
		JOIN dbo.Customers AS c ON o.CustomerId = c.Id
		LEFT JOIN dbo.Salesmen AS s ON o.SalesmanId = s.Id;