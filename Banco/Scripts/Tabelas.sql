--IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'DB_Salut')
--  BEGIN
--    CREATE DATABASE [DB_Salut]
--  END

--go

--Tabela CanalCompra
IF OBJECT_ID(N'dbo.CanalCompra', N'U') IS NULL
CREATE TABLE dbo.CanalCompra (
    id_canalcompra int IDENTITY(1,1) primary key,
    des_canalcompra varchar(300),
	dt_inclusão datetime,
	dt_alteracao datetime,
	flg_situacao bit
    );

go

--Tabela produto
IF OBJECT_ID(N'dbo.Produto', N'U') IS NULL
CREATE TABLE dbo.Produto (
    id_produto int IDENTITY(1,1) primary key,
	des_produto varchar (200),
	dt_inclusão datetime,
	dt_alteracao datetime,
	flg_situacao bit
    );

go

	--Tabela Nota fiscal
IF OBJECT_ID(N'dbo.NotaFiscal', N'U') IS NULL
CREATE TABLE dbo.NotaFiscal (
    id_notafiscal int IDENTITY(1,1) primary key,
    des_cnpj varchar(50),
    cod_canalcompra int,--fk
    dt_compra datetime,
    des_notafiscal varchar (100),
	quantidade int,
	des_caminhoAnexo varchar(5000),
	cod_produto int,--fk
	dt_inclusão datetime,
	dt_alteracao datetime,
	flg_situacao bit,
	FOREIGN KEY (cod_canalcompra) REFERENCES CanalCompra(id_CanalCompra),
	FOREIGN KEY (cod_produto) REFERENCES Produto(id_Produto)
    );



	
insert CanalCompra values 
('e-commerces', GETDATE(), null, 1),
('marketplaces', GETDATE(), null, 1),
('redes sociais', GETDATE(), null, 1),
('pontos de vendas', GETDATE(), null, 1)



insert Produto values 
('Produto 1', GETDATE(), null, 1),
('Produto 2', GETDATE(), null, 1),
('Produto 3', GETDATE(), null, 1),
('Produto 4', GETDATE(), null, 1)