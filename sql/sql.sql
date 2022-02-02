SELECT * FROM [dbo].[Persons] WHERE [Gender] = 'M';
SELECT * FROM [dbo].[Persons] WHERE [Age] > 18;
SELECT * FROM [dbo].[Persons] WHERE [Address] IS NULL;
UPDATE [dbo].[Persons] SET Age = Age + 1;
DELETE FROM [dbo].[Persons] WHERE [Address] IS NULL;
SELECT COUNT(1) FROM [dbo].[Persons];
SELECT Age, COUNT(1) FROM [dbo].[Persons] GROUP BY Age;
