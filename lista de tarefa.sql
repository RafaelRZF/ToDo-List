create database lista_de_serviço;
use lista_de_serviço;

create table tarefas(
id int auto_increment primary key,
titulo varchar(255)not null,
concluida boolean default false,
criada_em datetime default current_timestamp

);

