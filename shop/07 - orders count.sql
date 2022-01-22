SELECT CustomerId, COUNT(1)
	FROM dbo.Orders
	GROUP BY CustomerId;