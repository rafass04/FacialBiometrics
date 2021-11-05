--Query com os inserts nas tabelas
use RuralPropertiesInformations;
insert into UserPosition values ('N1');
insert into UserPosition values ('N2');
insert into UserPosition values ('N3');
go
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
go
INSERT INTO UserInfo
           (name_user
           ,username_user
           ,password_user
           ,salt_password_user
           ,id_user_position)
     VALUES
           ('Caique Fernando de Souza','fernando.c','nando123','caique123',1)
		  ,('Jamal Rato de Lima', 'jamal.r', 'jamal13','rash123',2)
		  ,('Camily Cabral Silva', 'cabral.c', 'silva123', 'senha123',1)
		  ,('Emerson Gonzales Caval', 'gonza.e','caval123','minho123',3)
		  ,('Gringo Indiano Brito','brito.g','gringo123','india123',3)
		  ,('Root Teste de Barros','roor','root','root',2)
		  ,('Olivia Marques Marinho','marques.o','mar123','olimar123',2)
		  ,('Sol Mazzaro dos Santos','santos.s', 'mazzaro123','solRash',1)
		  ,('Katniss Snow Bastos','bastos.k', 'snow123','kat123',2)
		  ,('Priss Natan Melo','melo.p','natan123','melo123',3);
		  