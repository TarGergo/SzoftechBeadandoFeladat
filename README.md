# SzoftechBeadandoFeladat

USE master
GO

if exists (select * from sysdatabases where name='ProductDatabase')
		drop database ProductDatabase


drop table if exists ProductDatabase.dbo.Customers
create table Customers (
	Name varchar (40) not null,
	Date datetime not null,
	PurchaseID int PRIMARY KEY not null,
	FullPrice int not null
)


drop table if exists ProductDatabase.dbo.Product

create table Product 
( 
Id int not null, 
Name varchar(30) not null, 
Manufacturer varchar(30) not null, 
Quantity int null, 
Price int not null,
Width int not null, 
Length int not null, 
Height int not null 
constraint pk_Product primary key(Id)
)


drop table if exists ProductDatabase.dbo.Purchases
create table Purchases (
Id int identity PRIMARY KEY,
PurchaseID int not null,
CustomerID int not null,
Quantity int not null,
Price int not null

CONSTRAINT "FK_Purchases_Customers" FOREIGN KEY 
(
	CustomerID
) REFERENCES dbo.Customers (
	PurchaseId
),
CONSTRAINT "FK_Purchases_Product" FOREIGN KEY
(
PurchaseID
) REFERENCES dbo.Product (
Id
)

)
