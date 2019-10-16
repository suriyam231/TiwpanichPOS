Create Table ProfileUser(
UserID int,
StoreID varchar(max),
StoreName varchar(30),
LocationNumber varchar(max),
Province varchar(30),
District varchar(30),
SubDistrict varchar(30),
ZipCode varchar(5),
Username varchar(30),
Password varchar(30),
Status varchar(30),
CONSTRAINT PK_ProfileUser PRIMARY KEY (UserID)
)

Select * from [dbo].[ProfileUser]

insert [dbo].[ProfileUser]
values ('0',null,null,null,null,null,null,null,'admin','admin','admin')

drop table [dbo].[ProfileUser]