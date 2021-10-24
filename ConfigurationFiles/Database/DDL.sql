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
('Título art.1 nível 1','Conteúdo art.1 nível 1',1),
('Título art.2 nível 1','Conteúdo art.2 nível 1',1),
('Título art.3 nível 1','Conteúdo art.3 nível 1',1),
('Título art.1 nível 2','Conteúdo art.1 nível 2',2),
('Título art.2 nível 2','Conteúdo art.2 nível 2',2),
('Título art.3 nível 2','Conteúdo art.3 nível 2',2),
('Título art.1 nível 2','Conteúdo art.1 nível 3',3),
('Título art.2 nível 2','Conteúdo art.2 nível 3',3),
('Título art.3 nível 2','Conteúdo art.3 nível 3',3);