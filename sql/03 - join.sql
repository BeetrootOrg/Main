SELECT bc.Id, a.Name AS Writer, b.Title, bc.Quantity
	FROM dbo.BookCount AS bc
		JOIN dbo.Authors AS a ON bc.AuthorId = a.Id
		LEFT JOIN dbo.Books AS b ON bc.BookId = b.Id;
