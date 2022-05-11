create database SrezITCollege
go

use SrezITCollege
go

create table [User]
(
	ID int primary key identity,
	Email nvarchar(128) unique not null,
	[Password] nvarchar(128) not null,
	LastName nvarchar(128) not null,
	FirstName nvarchar(128) not null,
	Patronomyc nvarchar(128) not null,
	Photo varbinary(max) null,
)
go