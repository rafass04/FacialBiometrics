create database RuralPropertiesInformations

use RuralPropertiesInformations

create table UserPosition(
	id_user_position int identity(1,1) primary key,
	name_user_position varchar(50) not null
)

create table UserInfo(
	id_user int identity(1,1) primary key,
	name_user varchar(60) not null,
	username_user varchar(20) not null,
	password_user varchar(255) not null,
	salt_password_user varchar(255) not null,
	id_user_position int,

	foreign key(id_user_position) references UserPosition(id_user_position)
)

create table UsersFacialBiometrics(
	id_img int identity(1,1) primary key,
	name_img varchar(50) not null,
	user_img image not null,
	id_user int,

	foreign key(id_user) references UserInfo(id_user)
)

create table RuralPropertiesInfo(
	id_property_info int identity(1,1) primary key,
	property_text_info varchar(4096) not null,
	property_img_info image not null,
	id_user_position int,

	foreign key(id_user_position) references UserPosition(id_user_position)
)

create table ArticleChemicalProduct(
	id_article int identity(1,1) primary key,
	article_title varchar(400) not null,
	article_content varchar(4096) not null,
	id_user_position int,
	foreign key(id_user_position) references UserPosition(id_user_position)
)



insert into UserPosition values ('N1');
insert into UserPosition values ('N2');
insert into UserPosition values ('N3');

insert into ArticleChemicalProduct values
('T�tulo art.1 n�vel 1','Conte�do art.1 n�vel 1',1),
('T�tulo art.2 n�vel 1','Conte�do art.2 n�vel 1',1),
('T�tulo art.3 n�vel 1','Conte�do art.3 n�vel 1',1),
('T�tulo art.1 n�vel 2','Conte�do art.1 n�vel 2',2),
('T�tulo art.2 n�vel 2','Conte�do art.2 n�vel 2',2),
('T�tulo art.3 n�vel 2','Conte�do art.3 n�vel 2',2),
('T�tulo art.1 n�vel 2','Conte�do art.1 n�vel 3',3),
('T�tulo art.2 n�vel 2','Conte�do art.2 n�vel 3',3),
('T�tulo art.3 n�vel 2','Conte�do art.3 n�vel 3',3);