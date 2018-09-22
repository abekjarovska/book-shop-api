use globalgaming;

CREATE TABLE Books(
	`BookId` nvarchar(20) NOT NULL,
	`Title` nvarchar(250) NOT NULL,
	`Author` nvarchar(250) NOT NULL,
	`Price` decimal(12, 2) NOT NULL,
 CONSTRAINT `PK_books` PRIMARY KEY 
(
	`bookId` ASC
) 
);

CREATE TABLE Users(
	`UserId` nvarchar(50) NOT NULL,
	`Name` nvarchar(50) NOT NULL,
	`Address` nvarchar(250) NOT NULL,
	`City` nvarchar(50) NOT NULL,
	`ZIP` nvarchar(6) NOT NULL,
	`Country` nvarchar(50) NOT NULL,
	`email` nvarchar(250) NULL,
	`registred` smallint NOT NULL,
 CONSTRAINT `PK_users` PRIMARY KEY 
(
	`userId` ASC
) 
);

CREATE TABLE Purchases(
	`PurchaseID` int AUTO_INCREMENT NOT NULL,
	`DateOfPurchase` date NOT NULL,
	`PurchasedBy` nvarchar(50) NOT NULL,
	`Status` nchar(1) NOT NULL,
	`DeliveredOn` date NULL,
 CONSTRAINT `PK_purchases` PRIMARY KEY 
(
	`purchaseID` ASC
) 
);

CREATE TABLE PurchaseItems(
	`PurchaseItemId` int AUTO_INCREMENT NOT NULL,
	`Purchase` int NOT NULL,
	`Book` nvarchar(20) NOT NULL,
	`Qty` int NOT NULL,
	`UnitPrice` decimal(12, 2) NOT NULL,
	`Note` nvarchar(250) NULL,
 CONSTRAINT `PK_purchaseItems` PRIMARY KEY 
(
	`purchaseItemId` ASC
) 
);
ALTER TABLE `books` CHANGE COLUMN `Price` `Price` DECIMAL(12,2) NOT NULL DEFAULT 0 ;
ALTER TABLE `purchaseItems` CHANGE COLUMN `qty` `qty` int NOT NULL DEFAULT 1 ;
ALTER TABLE `purchaseItems` CHANGE COLUMN `UnitPrice` `UnitPrice` DECIMAL(12,2) NOT NULL DEFAULT 0 ;
ALTER TABLE `purchases` CHANGE COLUMN `Status` `Status` nchar(1)  NOT NULL DEFAULT '0' ;
ALTER TABLE `users` CHANGE COLUMN `Country` `Country` nvarchar(50) NOT NULL DEFAULT  'Malta' ;
ALTER TABLE `users` CHANGE COLUMN `registred` `registred` smallint NOT NULL DEFAULT 1 ;

ALTER TABLE purchaseItems ADD CONSTRAINT FK_purchaseItems_books FOREIGN KEY (book) REFERENCES books(bookId) ON UPDATE CASCADE;
ALTER TABLE purchaseItems ADD CONSTRAINT FK_purchaseItems_Purchases FOREIGN KEY (Purchase) REFERENCES Purchases(PurchaseID) ON UPDATE CASCADE;
ALTER TABLE purchases ADD CONSTRAINT FK_purchases_users FOREIGN KEY (PurchasedBy) REFERENCES  users(userId) ;

