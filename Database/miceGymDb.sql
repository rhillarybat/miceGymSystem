CREATE DATABASE mice_gym_db;
USE mice_gym_db;

CREATE TABLE Usuario(
id_user INT PRIMARY KEY AUTO_INCREMENT,
nome_user VARCHAR(100),
senha_user VARCHAR(100),
email_user VARCHAR(100),
cpf_user VARCHAR(100),
telefone_user VARCHAR(100)
);

CREATE TABLE Academia(
id_aca INT PRIMARY KEY AUTO_INCREMENT,
nome_aca VARCHAR(100),
endereco_aca VARCHAR(100),
numero_aca VARCHAR(100)
);

CREATE TABLE Fornecedor(
id_forn INT PRIMARY KEY AUTO_INCREMENT,
fantasia_forn VARCHAR(100),
cnpj_forn VARCHAR(100),
endereco_forn VARCHAR(100),
bairro_forn VARCHAR(100),
email_forn VARCHAR(100),
telefone_forn VARCHAR(100),
numero_forn VARCHAR(100)
);

CREATE TABLE Funcionario(
id_fun INT PRIMARY KEY AUTO_INCREMENT,
nome_fun VARCHAR(100),
cpf_fun VARCHAR(100),
cargo_fun VARCHAR(100),
email_fun VARCHAR(100),
telefone_fun VARCHAR(100),
experiencia_fun VARCHAR(100)
);

CREATE TABLE Cliente(
id_cli INT PRIMARY KEY AUTO_INCREMENT,
nome_cli VARCHAR(100),
cpf_cli VARCHAR(100),
email_cli VARCHAR(100),
telefone_cli VARCHAR(100),
fk_academia_cli INT,
FOREIGN KEY(fk_academia_cli) REFERENCES Academia(id_aca)
);

CREATE TABLE Equipamentos(
id_equi INT PRIMARY KEY AUTO_INCREMENT,
nome_equi VARCHAR(100),
valor_equi DOUBLE,
quantidade_equi INT,
descricao_equi VARCHAR(100),
codigo_equi VARCHAR(100),
fk_academia_equi INT,
FOREIGN KEY(fk_academia_equi) REFERENCES Academia(id_aca),
fk_fornecedor_equi INT,
FOREIGN KEY(fk_fornecedor_equi) REFERENCES Fornecedor(id_forn)
);

CREATE TABLE Pagamento(
id_pag INT PRIMARY KEY AUTO_INCREMENT,
forma_pag VARCHAR(100),
valor_pag DOUBLE,
data_pag DATE,
fk_cliente_pag INT,
FOREIGN KEY(fk_cliente_pag) REFERENCES Cliente(id_cli),
fk_academia_pag INT,
FOREIGN KEY(fk_academia_pag) REFERENCES Academia(id_aca)
);
