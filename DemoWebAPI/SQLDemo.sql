create database FirstProject

use FirstProject

create table User_login
(
	UserId int primary key,
	UserName varchar(50),
	UserPassword varchar(50),	
	UserRole varchar(50),
	UserEmailId varchar(50)
)

insert into User_login values(1,'admin','123456','Admin','robin@gmail.com')
insert into User_login values(2,'user','123456','User','zoro@gmail.com')
insert into User_login values(3,'superadmin','123456','SuperAdmin','luffy@gmail.com')

create table Category
(
	Id int  primary key,
	Name varchar(40)
)

create table Product
(	
	Id int primary key,
	Name varchar(40),
	price money,
	category_id int,
	FOREIGN KEY (category_id) REFERENCES Category(Id),
)


insert into Category values(1,'rau cu')
insert into Category values(2,'ca')
insert into Category values(3,'do uong')

insert into Product values(1,'Ca Map',90.2,2)
insert into Product values(2,'Bo huc',12.2,3)
insert into Product values(3,'Sting',10,3)
insert into Product values(4,'Bap cai xanh',7.8,1)
insert into Product values(5,'hanh tay',10,1)
insert into Product values(6,'Ca loc',15.7,1)
insert into Product values(7,'sua dau nanh',5.2,3)
insert into Product values(8,'suplo',19.1,1)