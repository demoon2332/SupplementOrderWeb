create database SupplementManagement
go
use SupplementManagement
go
select * from Account
-- CREATING TABLE
create table Account
(
	id bigint identity primary key ,
	displayName nvarchar(100) not null,
	userName nvarchar(100) not null unique,
	password nvarchar(1000) not null,
	phone nvarchar(20),
	gender int not null,
	birth varchar(20) ,
	dateBecomeMember varchar(22) default format(getDate(),'MM/dd/yyyy HH:mm:ss ') null
)
go

create table Customer
(
	id bigint identity primary key,
	fullName nvarchar(100) not null,
	address nvarchar(100) not null,
	phone nvarchar(15) not null unique,
	password nvarchar(1000) not null 
)
go

create table Type
(
	id tinyint identity primary key,
	name nvarchar(100) not null
)

create table Product
(
	id bigint identity primary key,
	name nvarchar(100) not null,
	unit nvarchar(50) not null,
	price float not null,
	type tinyint ,
	inventory int
	foreign key (type) references Type(id)
)	
go

create table GoodImport
(
	id bigint identity primary key,
	sid bigint not null,
	importDate varchar(22) default format(getDate(),'MM/dd/yyyy HH:mm:ss '),

	foreign key(sid) references dbo.Account(id),
	
)
go

create table ImportDetail
(
	id bigint identity primary key,
	bid bigint ,
	pid bigint,
	quantity int default 1,

	foreign key(bid) references GoodImport(id),
	foreign key(pid) references Product(id),
)
go
create table GoodExport
(
	id bigint identity primary key,
	cid bigint,
	sid bigint ,
	paymentType nvarchar(22) not null default 'Cashes',
	statusPayment bit default 0,
	statusDelivery varchar(10) default 'Waiting',
	exportDate varchar(22) default format(getDate(),'MM/dd/yyyy HH:mm:ss '),

	foreign key(cid) references Customer(id),
	foreign key(sid) references Account(id),
)
go

create table ExportDetail
(
	id bigint identity primary key,
	bid bigint,
	pid bigint,
	quantity int default 1,
	foreign key(bid) references GoodExport(id),
	foreign key(pid) references Product(id),
)
go

------------------------------- INSERTING --------------------------------------------------
-- Account 
insert into dbo.Account values
(N'Nguyễn Đức Trọng','admin','40bd001563085fc35165329ea1ff5c5ecbdbbeef','0909678191',1,'01/01/2001',getDate()),
(N'Nguyễn Minh Quang','minhquang88','7c222fb2927d828af22f592134e8932480637c0d','0811785321',1,getDate(),getDate()),
(N'Nguyễn Chí Tín','chitincute','7c222fb2927d828af22f592134e8932480637c0d','0805523561',1,'06/21/1999',getDate()),
(N'Lâm Anh Thy','thythy23','7c222fb2927d828af22f592134e8932480637c0d','1209322833',1,'04/21/1998',getDate()),
(N'Phạm Bảo Anh','baoanh22','7c222fb2927d828af22f592134e8932480637c0d','180800599',1,'05/19/2000',getDate())


-- Customer

insert into dbo.Customer values
(N'Nguyễn Đức Minh','19 Nguyen Huu Tho','0901356728','56728'),
(N'Trương Trung Trực','19 Nguyen Huu Tho','0772465158','65158'),
(N'Trần Đồng Chí','19 Nguyen Huu Tho','0807123890','23890'),
(N'Văn Mai Hương','19 Nguyen Huu Tho','0102465244','65244')

-- Type
insert into dbo.Type values
(N'Bone Strengthen (Calcium)'),
(N'Skincare'),
(N'Creatine'),
(N'Vitamin A'),
(N'Vitamin E'),
(N'Vitamin D'),
(N'Protein')

-- Product

insert into dbo.Product values
(N'Life Extension Bone Restore','Jar',430.839,'1',100),
(N'Calcium Bone Maker','Jar',268.340,'1',100),
(N'Now Foods Bone Meal','Jar',299.751,'1',100),
(N'Acne Cleanse','Jar',1054.965,'2','100'),
(N'Hyper Pigmentation','Jar',1054.965,'2',100),

(N'100% Micronized Creatine Monohydrate Ultimate Nutrition','Jar',690.000,'2',100),
(N'True Creatine 6 Elite Labs USA','Jar',500.000,'3',100),
(N'MyProtein Creatine Monohydrate','Jar',720.580,'3',100),
(N'Applied Nutrition Creatine','Jar',620.000,'3',100),

(N'Nature Made Vitamin A 2400mcg 8000IU','Jar',465.000,'4',100),
(N'Vitamin A Blackmore 5000IU','Jar',439.000,'4',100),
(N'Now Foods Vitamin A','Jar',560.095,'4',100),
(N'GNC Vitamin A','Jar',355.095,'4',100),

(N'Nature Made Vitamin E 180 soft gel 400IU','Jar',480.000,'5',100),
(N'Vitamin E Kirkland 180mg 400 capsules','Jar',445.000,'5',100),
(N'Vitamin E Blackmore 1000IU 30 capsules','Jar',337.000,'5',100),

(N'Nature Made Vitamin D3 1000IU 650 soft gel','Jar',570.000,'6',100),
(N'Vitamin D3 Blackmores 1000IU 200 capsules ','Jar',445.000,'6',100),
(N'Mega D-3 & MK-7 Veg Capsules','Jar',573.582,'6',100)

(N'Organic Protein Powder, Creamy Chocolate Fudge Orgain','Jar',599.000,'7',100),
(N'Super Advanced Whey Protein, Vanilla Body Fortress ','Jar',578.445,'7',100),
(N'Super Advanced Whey Protein, Chocolate Body Fortress','Jar',812.263,'7',100),
(N'Combat Protein Powder, Cookies n Cream Muscle Pharm','Pack',950.500,'7',100)

select * from Type

-- GoodImport
insert into dbo.GoodImport values
(1,format(getDate(),'MM/dd/yyyy HH:mm:ss tt')),
(2,format(getDate(),'MM/dd/yyyy HH:mm:ss tt'))

-- ImportDetail

insert into dbo.ImportDetail values
(1,1,2),
(1,2,3),
(2,1,1)

-- GoodExport
insert into dbo.GoodExport values
(2,1,'Credit Cards',0,'Waiting','12/29/2021 18:30:45 PM'),
(1,2,'Momo Wallet',0,'Waiting',format(getDate(),'MM/dd/yyyy HH:mm:ss ')),
(1,1,'Credit Cards',0,'Waiting',format(getDate(),'MM/dd/yyyy HH:mm:ss ')),
(2,2,'Cashes',1,'Shipping','12/25/2021 16:24:54 PM'),
(3,4,'Credit Cards',1,'Shipping','11/23/2021 09:20:23 AM'),
(3,3,'Momo Wallet',1,'Done','1/24/2021 12:42:14 PM')
-- ExportDetail

insert into dbo.ExportDetail values 
(1,4,10),
(1,10,1),
(2,8,2),
(2,12,4),
(3,19,1),
(3,1,2),
(4,1,10),
(5,2,20),
(5,6,12),
(6,7,2),
(6,10,2),
(6,12,8)



------------------------------- *PROCEDURE* --------------------------------------------------
---** CUSTOMER:

go
create proc customerLogin
@phone varchar(15), @password nvarchar(1000)
as
begin
	select * from dbo.Customer where phone = @phone and password = @password
end
go

Exec customerLogin @phone='0901356728' , @password ='1'

---- *** ACCOUNT : 
go
create proc UserLogin
@username nvarchar(100), @password nvarchar(1000)
as
begin
	select * from dbo.Account where username = @username and password = @password
end 
go


create proc getAccountByUsername
@username nvarchar(100)
as
begin
	select * from Account where userName = @username
end
go

create proc updateAccount
@username nvarchar(100), @disName nvarchar(100) , @phone nvarchar(20), @birth varchar(22)
as
begin
	update  Account
	set   displayName = @disName, phone=@phone , birth = @birth 
	where userName = @username
end
go


create proc resetPassword
@username nvarchar(100), @newPass nvarchar(1000)
as
begin
	update Account
	set password = @newPass
	where userName = @username
end
go


--------------------- ************* IMPORT GOOD ----------------------------------------------


go
create proc getImportStatistic
as
begin
	select bid as 'Bill ID',sid as 'Staff ID',t1.[Total Money],importDate from GoodImport as gi,
	(
		select d.bid,sum(p.price*quantity) as 'Total Money' from Product as p,ImportDetail as d
		where d.pid = p.id
		group by d.bid
	) t1
	where gi.id = t1.bid
	order by TRY_CONVERT( DATETIME, importDate) desc 
end
go




-- query import statistic by date
create proc getImportStatisticByDate
@start varchar(22) , @end varchar(22)
as begin
	select bid as 'Bill ID',sid as 'Staff ID',t1.[Total Money],importDate from GoodImport as gi,
	(
		select d.bid,sum(p.price*quantity) as 'Total Money' from Product as p,ExportDetail as d
		where d.pid = p.id
		group by d.bid
	) t1
	where gi.id = t1.bid
	and (TRY_CONVERT( DATETIME, importDate) between CONCAT(@start,' 00:00:00') and CONCAT(@end,' 23:59:59'))
	order by TRY_CONVERT( DATETIME, importDate) desc 
end
go

-- get full detail import

go
create proc getFullDetailImport 
@id bigint
as 
begin
	select d.bid,d.pid,p.name,p.unit,p.price,p.type,quantity,p.inventory,quantity*price as'IntoMoney' from ImportDetail as d,Product p
	where p.id = d.pid
	and bid = @id
end
go

-- get Lastes ID of Import 
go
create proc GetLastestIDimport
as
begin
    SELECT max(id) as id FROM GoodImport
end
go

--- write Import Good 
go
create proc writeImport
@sid bigint
as
begin
	insert into GoodImport values
	(@sid,format(getDate(),'MM/dd/yyyy HH:mm:ss tt'))
end
go


--- write Import detail
go 
create proc writeImportDetail
@bid bigint,@pid bigint,@quantity int
as
begin
	insert into ImportDetail values
	(@bid,@pid,@quantity)
end
go




----------------------- ************* EXPORT GOOD -------------------------------------------


go


--- query export statistic lastest

create proc getExportStatistic
as 
begin
	select bid as 'Bill ID',cid as 'Customer ID',sid as 'Staff ID',t1.[Total Money],paymentType,ExportDate,statusDelivery,statusPayment from GoodExport as gi,
	(
		select d.bid,sum(p.price*quantity) as 'Total Money' from Product as p,ExportDetail as d
		where d.pid = p.id
		group by d.bid
	) t1
	where gi.id = t1.bid
	order by TRY_CONVERT( DATETIME, exportDate) desc 
end
go

-- query export statistic by date
go 
create proc getExportStatisticByDate
@start varchar(22) , @end varchar(22)
as begin
	select bid as 'Bill ID',cid as 'Customer ID',sid as 'Staff ID',t1.[Total Money],paymentType,ExportDate,statusDelivery,statusPayment from GoodExport as gi,
	(
		select d.bid,sum(p.price*quantity) as 'Total Money' from Product as p,ExportDetail as d
		where d.pid = p.id
		group by d.bid
	) t1
	where gi.id = t1.bid
	and (TRY_CONVERT( DATETIME, exportDate) between CONCAT(@start,' 00:00:00') and CONCAT(@end,' 23:59:59'))
	order by TRY_CONVERT( DATETIME, exportDate) desc 
end
go

-- get Full detail export 
go
create proc getFullDetailExport 
@id bigint
as 
begin
	select d.bid,d.pid,p.name,p.unit,p.price,p.type,quantity,p.inventory,quantity*price as'IntoMoney' from ExportDetail as d,Product p
	where p.id = d.pid
	and bid = @id
end
go

-- get Full Detail export by Customer ID
go
create proc getFullDetailExportByCID 
@cid bigint
as 
begin
	select d.bid,p.name,p.unit,p.price,quantity,quantity*price as'IntoMoney' from ExportDetail as d,Product p,GoodExport b
	where p.id = d.pid
	and b.id = d.bid
	and cid = @cid
end
go
select * from Product
-- getFullDetailExportByCID @cid = 2

select * from Customer
-- get waiting/prepare export order



-- confirm export order


-- getLastest export
go
create proc GetLastestIDExport
as
begin
    SELECT max(id) as id FROM GoodExport
end
go

--- write Export Good 
select * from Product

go
create proc writeExport
@cid bigint,@sid bigint,@paymentType nvarchar(22),@statusPayment bit,@statusDelivery varchar(10)
as
begin
	insert into GoodExport values
	(@cid,@sid,@paymentType,@statusPayment,@statusDelivery,format(getDate(),'MM/dd/yyyy HH:mm:ss tt'))
end
go

--- write Export detail
go 
create proc writeExportDetail
@bid bigint,@pid bigint,@quantity int
as
begin
	insert into ExportDetail values
	(@bid,@pid,@quantity)
end
go
 
-- set type statusDelivery
-- confirmExport
go
create proc confirmExport
@id bigint , @sid bigint
as 
begin
	update GoodExport
	set statusPayment = 1,statusDelivery='Shipping', sid = @sid
	where id = @id
end 
go

--cancelExport

go
create proc cancelExport
@id bigint , @sid bigint
as 
begin
	update GoodExport
	set statusPayment = 0,statusDelivery='Cancel', sid = @sid
	where id = @id
end 
go

--doneExport
go
create proc doneExport
@id bigint , @sid bigint
as 
begin
	update GoodExport
	set statusPayment = 1,statusDelivery='Done', sid = @sid 
	where id = @id
end 
go


--------- ************* PRODUCT

go
create proc getProductsTypeId
@id tinyint 
as
begin 
	select * from Product where type=@id
end
go

go
create proc updateInventory
@id bigint, @quantity int
as
	begin
		update Product
		set inventory = inventory + @quantity
		where id = @id
	end
go


select * from Product



--- ***


---

---++++++++++++ TEST

-- DBCC CHECKIDENT (GoodExport, RESEED, 7)
-- 




