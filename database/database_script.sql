
CREATE DATABASE UMarket;

USE UMarket;

CREATE TABLE Feira (
	nomeFeira VARCHAR(45) NOT NULL,
	tema VARCHAR(45) NOT NULL,
	descricao VARCHAR(8000) NOT NULL,
	localFeira VARCHAR(45) NULL,
	PRIMARY KEY (nomeFeira)
);

CREATE TABLE Vendedor (
	nifVendedor INT NOT NULL,
	nomeProprio VARCHAR(45) NOT NULL,
	apelido VARCHAR(45) NOT NULL,
	email VARCHAR(45) NOT NULL,
	passwordVendedor VARCHAR(45) NOT NULL,
	PRIMARY KEY (nifVendedor)
);


CREATE TABLE RegistoFeira (
	nomeFeira VARCHAR(45) NOT NULL,
	nifVendedor INT NOT NULL,
	PRIMARY KEY (nomeFeira, nifVendedor),
    FOREIGN KEY (nomeFeira) REFERENCES Feira (nomeFeira),
    FOREIGN KEY (nifVendedor) REFERENCES Vendedor (nifVendedor)
);


CREATE TABLE Produto (
	idProduto INT NOT NULL,
	nome VARCHAR(45) NOT NULL,
	preço DECIMAL(5,2) NOT NULL,
	stock INT NOT NULL,
	descricao VARCHAR(8000) NOT NULL,
	categoria VARCHAR(45) NOT NULL,
	avaliacaoMedia DECIMAL(1,1) NULL,
	fatorAceitacao FLOAT NULL,
	fatorTolerancia FLOAT NULL,
	fatorResposta FLOAT NULL,
	nomeFeira VARCHAR(45) NOT NULL,
	nifVendedor INT NOT NULL,
	PRIMARY KEY (idProduto),
    FOREIGN KEY (nomeFeira , nifVendedor) REFERENCES RegistoFeira (nomeFeira , nifVendedor)
);

CREATE TABLE Cliente (
	nifCliente INT NOT NULL,
	nomeProprio VARCHAR(45) NOT NULL,
	apelido VARCHAR(45) NOT NULL,
	email VARCHAR(45) NOT NULL,
	passwordCliente VARCHAR(45) NOT NULL,
	PRIMARY KEY (nifCliente)
);

CREATE TABLE Avaliacao (
	nifCliente INT NOT NULL,
	idProduto INT NOT NULL,
	valorAval INT NOT NULL,
	PRIMARY KEY (nifCliente, idProduto),
    FOREIGN KEY (nifCliente) REFERENCES Cliente (nifCliente),
    FOREIGN KEY (idProduto) REFERENCES Produto (idProduto)
);

CREATE TABLE Favorito (
	nifCliente INT NOT NULL,
	idProduto INT NOT NULL,
	PRIMARY KEY (nifCliente, idProduto),
    FOREIGN KEY (nifCliente) REFERENCES Cliente (nifCliente),
    FOREIGN KEY (idProduto) REFERENCES Produto (idProduto)
);


CREATE TABLE Carrinho (
	nifCliente INT NOT NULL,
	idProduto INT NOT NULL,
	valorVenda DECIMAL(5,2) NOT NULL,
	PRIMARY KEY (nifCliente, idProduto),
    FOREIGN KEY (nifCliente) REFERENCES Cliente (nifCliente),
    FOREIGN KEY (idProduto) REFERENCES Produto (idProduto)
);

CREATE TABLE Compra (
	idCompra INT NOT NULL,
	nomeFaturacao VARCHAR(45) NOT NULL,
	moradaEntrega VARCHAR(90) NOT NULL,
	telemovel VARCHAR(9) NOT NULL,
	valorTotal DECIMAL(5,2) NOT NULL,
	timestampCompra DATETIME NOT NULL,
	nifCliente INT NOT NULL,
	PRIMARY KEY (idCompra, nifCliente),
    FOREIGN KEY (nifCliente) REFERENCES Cliente (nifCliente)
);

CREATE TABLE ProdutoDaCompra (
	idCompra INT NOT NULL,
	nifCliente INT NOT NULL,
	valorVenda DECIMAL(5,2) NOT NULL,
	idProduto INT NOT NULL,
	PRIMARY KEY (idCompra, nifCliente, idProduto),
    FOREIGN KEY (idCompra, nifCliente) REFERENCES Compra (idCompra , nifCliente),
    FOREIGN KEY (idProduto) REFERENCES Produto (idProduto)
);

