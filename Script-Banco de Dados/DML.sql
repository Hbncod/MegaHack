Use MegaHack
GO
INSERT INTO TipoUsuario(Tipo)
VALUES ('Administrador'),('Cliente'),('Comerciante')
GO
INSERT INTO TipoComercio(Tipo)
VALUES ('Moda'),('Alimentação'),('Artesanato')
GO
INSERT INTO Produto(NomeProduto)
VALUES ('Camiseta'),('Hamburger'),('Quadro')
GO
INSERT INTO Usuario(Nome,Rg,Cpf,Telefone,Email,Senha,Fk_TipoUsuario)
VALUES	('Admin','333226547','35432509326','11999999999','admin@admin.com','admin',1),
		('Cliente','433226547','45432509326','21999999999','cliente@cliente.com','cliente',2),
		('Comerciante','533226547','55432509326','31999999999','comerciante@comerciante.com','comerciante',3)
GO
INSERT INTO Comercio(NomeFantasia,Cnpj,Cep,Uf,Cidade,logradouro,Bairro,Numero,TelefoneFixo,TelefoneCelular,Fk_Usuario,Fk_TipoComercio,Descricao)
VALUES	('Veste Bem','123456789','000','sp','São Paulo','av..','bai..','123','11112121','11111111',3,1,'criamos as melhores roupas'),
		('Mata Fome','321654987','111','rj','Rio de Janeiro','rua...','bai..','321','222222222','2222222221',3,2,'Fazemos os melhores sanduiches')
GO
INSERT INTO Plano(Fim,Estado,Fk_Usuario)
VALUES	('01/05/2020',1,2)