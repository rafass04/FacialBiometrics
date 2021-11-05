--Query com os inserts nas tabelas
use RuralPropertiesInformations;
insert into UserPosition values ('N1');
insert into UserPosition values ('N2');
insert into UserPosition values ('N3');
go
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
		  