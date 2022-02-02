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

CREATE TABLE InventoryList(
Book int FOREIGN KEY REFERENCES Books(ID)
Qty int NOT NULL,
); 

CREATE TABLE Readers(
ID int PRIMARY KEY NOT NULL,
FirstName varchar(255),
LastName varchar(255),
RegistrationDate TimeStamp NOT NULL
);

CREATE TABLE Ledger(
BookID int FOREIGN KEY REFERENCES Books(ID) NOT NULL,
ReceivingTime  TimeStamp NOT NULL
ReturnTime  TimeStamp NOT NULL
ReaderID int FOREIGN KEY REFERENCES Readers(ID) NOT NULL
);