SELECT TOP(1) CustomerId
	FROM dbo.Orders
	GROUP BY CustomerId
	ORDER BY SUM(PurchaseAmount) DESC;