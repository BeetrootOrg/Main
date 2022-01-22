SELECT CONVERT(date, OrderDatetime) AS 'PurchaseDate', SUM(PurchaseAmount) AS 'PurchaseAmount'
	FROM dbo.Orders
	GROUP BY CONVERT(date, OrderDatetime);
