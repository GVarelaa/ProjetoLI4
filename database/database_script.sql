CREATE DATABASE IF NOT EXISTS UMarket;

USE UMarket;

CREATE TABLE IF NOT EXISTS Feira (
	nomeFeira VARCHAR(45) NOT NULL,
	tema VARCHAR(45) NOT NULL,
	descricao VARCHAR(8000) NOT NULL,
	localFeira VARCHAR(45) NULL,
	PRIMARY KEY (nomeFeira)
);

CREATE TABLE IF NOT EXISTS Vendedor (
	nifVendedor INT UNSIGNED NOT NULL,
	nomeProprio VARCHAR(45) NOT NULL,
	apelido VARCHAR(45) NOT NULL,
	email VARCHAR(45) NOT NULL,
	passwordVendedor VARBINARY(100) NOT NULL,
	PRIMARY KEY (nifVendedor)
);


CREATE TABLE IF NOT EXISTS RegistoFeira (
	idFeira INT UNSIGNED NOT NULL,
	nifVendedor INT UNSIGNED NOT NULL,
	PRIMARY KEY (idFeira, nifVendedor),
    FOREIGN KEY (idFeira) REFERENCES Feira (idFeira),
    FOREIGN KEY (nifVendedor) REFERENCES Vendedor (nifVendedor)
);


CREATE TABLE IF NOT EXISTS Produto (
	idProduto INT UNSIGNED NOT NULL,
	nome VARCHAR(45) NOT NULL,
	preço DECIMAL(5,2) NOT NULL,
	stock INT NOT NULL,
	descricao VARCHAR(8000) NOT NULL,
	categoria VARCHAR(45) NOT NULL,
	avaliacaoMedia DECIMAL(1,1) NULL,
	fatorAceitacao FLOAT NULL,
	fatorTolerancia FLOAT NULL,
	fatorResposta FLOAT NULL,
	idFeira INT UNSIGNED NOT NULL,
	nifVendedor INT UNSIGNED NOT NULL,
	PRIMARY KEY (idProduto),
    FOREIGN KEY (idFeira , nifVendedor) REFERENCES RegistoFeira (idFeira , nifVendedor)
);


CREATE TABLE IF NOT EXISTS Cliente (
	nifCliente INT UNSIGNED NOT NULL,
	nomeProprio VARCHAR(45) NOT NULL,
	apelido VARCHAR(45) NOT NULL,
	email VARCHAR(45) NOT NULL,
	passwordCliente VARBINARY(100) NOT NULL,
	PRIMARY KEY (nifCliente)
);

CREATE TABLE IF NOT EXISTS Avaliacao (
	nifCliente INT UNSIGNED NOT NULL,
	idProduto INT UNSIGNED NOT NULL,
	valorAval TINYINT(1) NOT NULL,
	PRIMARY KEY (nifCliente, idProduto),
    FOREIGN KEY (nifCliente) REFERENCES Cliente (nifCliente),
    FOREIGN KEY (idProduto) REFERENCES Produto (idProduto)
);

CREATE TABLE IF NOT EXISTS Favorito (
	nifCliente INT UNSIGNED NOT NULL,
	idProduto INT UNSIGNED NOT NULL,
	PRIMARY KEY (nifCliente, idProduto),
    FOREIGN KEY (nifCliente) REFERENCES Cliente (nifCliente),
    FOREIGN KEY (idProduto) REFERENCES Produto (idProduto)
);


CREATE TABLE IF NOT EXISTS Compra (
	idCompra INT UNSIGNED NOT NULL,
	nomeFaturacao VARCHAR(45) NOT NULL,
	moradaEntrega VARCHAR(90) NOT NULL,
	telemovel VARCHAR(9) NOT NULL,
	valorTotal DECIMAL(5,2) NOT NULL,
	timestampCompra DATETIME NOT NULL,
	nifCliente INT UNSIGNED NOT NULL,
	PRIMARY KEY (idCompra, nifCliente),
    FOREIGN KEY (nifCliente) REFERENCES Cliente (nifCliente)
);

CREATE TABLE IF NOT EXISTS ProdutoDaCompra (
	idCompra INT UNSIGNED NOT NULL,
	nifCliente INT UNSIGNED NOT NULL,
	valorVenda DECIMAL(5,2) NOT NULL,
	idProduto INT UNSIGNED NOT NULL,
	PRIMARY KEY (idCompra, nifCliente, idProduto),
    FOREIGN KEY (idCompra, nifCliente) REFERENCES Compra (idCompra , nifCliente),
    FOREIGN KEY (idProduto) REFERENCES Produto (idProduto)
);
