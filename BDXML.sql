create database BDCADASTRO;
use BDCADASTRO;

create table CLIENTE(
ID int not null primary key auto_increment,
NOME varchar(50) not null,
ENDERECO varchar(50) not null,
CEP varchar(9) not null,
BAIRRO varchar(50) not null,
CIDADE varchar(50) not null,
UF varchar(2) not null,
TELEFONE varchar(15) not null
)engine=innodb;