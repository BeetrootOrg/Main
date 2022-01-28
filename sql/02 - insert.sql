INSERT INTO dbo.Authors(Name, Title, Published, Quantity)
	VALUES ('Leo Tolstoy', 'War and Peace', '2001-01-01 00:00:00', 5),
		('Alexander Pushkin', 'Eugene Onegin', '2002-01-01 00:00:00', 10),
		('Fyodor Dostoevsky', 'The Gambler', '2003-01-01 00:00:00', 20);

ALTER TABLE dbo.Books ADD FOREIGN KEY (AuthorId) REFERENCES dbo.Authors(Id);
ALTER TABLE dbo.BookCount ADD FOREIGN KEY (BookId) REFERENCES dbo.Books(Id);