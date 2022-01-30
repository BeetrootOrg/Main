CREATE TABLE Authors(
ID int NOT NULL PRIMARY KEY,
LastName varchar(255) NOT NULL,
FirstName varchar(255)
);

CREATE TABLE Books(
ID int NOT NULL PRIMARY KEY,
BookName varchar(255) NOT NULL,
AuthorID int FOREIGN KEY REFERENCES Authors(ID)
);

CREATE TABLE CountOfEachBook(
Amount int NOT NULL,
Book int FOREIGN KEY REFERENCES Books(ID)
); 
CREATE TABLE Customer(
ID int PRIMARY KEY NOT NULL,
NickName varchar (255) NOT NULL,
FirstName varchar(255),
LastName varchar(255),
Balance Money NOT NULL,
RegistrationDate Datetime NOT NULL
);
CREATE TABLE BookHistory(
BookID int FOREIGN KEY REFERENCES Books(ID) NOT NULL,
ReservationTime Datetime NOT NULL,
CustomerID int FOREIGN KEY REFERENCES Customer(ID) NOT NULL
);
