drop table if exists ProductDatabase.dbo.Product

create table Product
(
	Id int not null,
	Name varchar(30) not null,
	Manufacturer varchar(30) not null,
	Quantity int,
	Price int,
	Width int,
	Length int,
	Height int
	constraint pk_Product primary key(Id)
)