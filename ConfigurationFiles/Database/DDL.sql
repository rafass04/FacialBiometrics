create database RuralPropertiesInformations
go
use RuralPropertiesInformations
go
create table UserPosition(
	id_user_position int identity(1,1) primary key,
	name_user_position varchar(50) not null
)
go
create table UserInfo(
	id_user int identity(1,1) primary key,
	name_user varchar(60) not null,
	username_user varchar(20) not null,
	password_user varchar(255) not null,
	salt_password_user varchar(255) not null,
	id_user_position int,

	foreign key(id_user_position) references UserPosition(id_user_position)
)
go
create table UsersFacialBiometrics(
	id_img int identity(1,1) primary key,
	name_img varchar(50) not null,
	user_img image not null,
	id_user int,

	foreign key(id_user) references UserInfo(id_user)
)
go
create table ArticleChemicalProduct(
	id_article int identity(1,1) primary key,
	article_title varchar(400) not null,
	article_content varchar(4096) not null,
	id_user_position int,
	foreign key(id_user_position) references UserPosition(id_user_position)
)
go
