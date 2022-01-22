-- works only if odd count
SELECT TOP(1) PurchaseAmount
	FROM dbo.Orders
	WHERE Id IN (SELECT TOP(50) PERCENT Id
		FROM dbo.Orders
		ORDER BY PurchaseAmount) 
	ORDER BY PurchaseAmount DESC;
