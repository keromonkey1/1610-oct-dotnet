

create schema Monster;
go

create table Monster.Monster
(
	MonsterID int not null identity(1,1),
	GenderID int null,
	TitleID int null --foreign key references Monster.Title(TitleID),
	,TypeID int not null,
	Name nvarchar(250) not null, 
	PicturePath nvarchar(256) null, 
	Active bit not null
);
go

create table Monster.MonsterType
(
	MonsterTypeID int not null identity(1,1) primary key,
	TypeName nvarchar(250) not null,
	Active bit not null
);
go

create table Monster.Gender
(
	GenderID int not null identity(1,1) primary key,
	GenderName nvarchar(250) not null,
	Active bit not null
);
go

create table Monster.Title
(
	TitleID int not null identity(1,1) primary key,
	TitleName nvarchar(250) not null,
	Active bit not null
);
go

alter table Monster.Monster 
	add constraint pk_monster_monsterid primary key clustered (MonsterID); 
go;

alter table Monster.Monster
	add constraint fk_monster_genderid foreign key (GenderID) references Monster.Gender(GenderID);
go

alter table Monster.Monster
	add constraint fk_monster_titleid foreign key (TitleID) references Monster.Title(TitleID);
go

alter table Monster.Monster
	add constraint fk_monster_typeid foreign key (TypeID) references Monster.MonsterType(MonsterTypeID);
	
go
