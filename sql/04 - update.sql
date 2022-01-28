UPDATE dbo.Authors
	SET Quantity = Quantity + 1
	WHERE Name = 'Alexander Pushkin' AND Title = 'Eugene Onegin';
