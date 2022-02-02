ALTER TABLE dbo.BookCount ADD FOREIGN KEY (AuthorId) REFERENCES dbo.Authors(Id);
ALTER TABLE dbo.BookCount ADD FOREIGN KEY (BookId) REFERENCES dbo.Books(Id);
