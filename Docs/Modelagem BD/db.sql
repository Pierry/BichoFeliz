/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     03/10/2013 20:55:22                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ANIMAL') and o.name = 'FK_ANIMAL_REFERENCE_TIPO')
alter table ANIMAL
   drop constraint FK_ANIMAL_REFERENCE_TIPO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ANIMAL') and o.name = 'FK_ANIMAL_REFERENCE_CONTATO')
alter table ANIMAL
   drop constraint FK_ANIMAL_REFERENCE_CONTATO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LOGACESSO') and o.name = 'FK_LOGACESS_REFERENCE_USUARIO')
alter table LOGACESSO
   drop constraint FK_LOGACESS_REFERENCE_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RACA') and o.name = 'FK_RACA_REFERENCE_TIPO')
alter table RACA
   drop constraint FK_RACA_REFERENCE_TIPO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SERVICO') and o.name = 'FK_SERVICO_REFERENCE_ANIMAL')
alter table SERVICO
   drop constraint FK_SERVICO_REFERENCE_ANIMAL
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SERVICO') and o.name = 'FK_SERVICO_REFERENCE_TIPOSERV')
alter table SERVICO
   drop constraint FK_SERVICO_REFERENCE_TIPOSERV
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SERVICO') and o.name = 'FK_SERVICO_REFERENCE_CONTATO')
alter table SERVICO
   drop constraint FK_SERVICO_REFERENCE_CONTATO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIO') and o.name = 'FK_USUARIO_REFERENCE_CONTATO')
alter table USUARIO
   drop constraint FK_USUARIO_REFERENCE_CONTATO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ANIMAL')
            and   type = 'U')
   drop table ANIMAL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CONTATO')
            and   type = 'U')
   drop table CONTATO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LOGACESSO')
            and   type = 'U')
   drop table LOGACESSO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RACA')
            and   type = 'U')
   drop table RACA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SERVICO')
            and   type = 'U')
   drop table SERVICO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIPO')
            and   type = 'U')
   drop table TIPO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIPOSERVICO')
            and   type = 'U')
   drop table TIPOSERVICO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO')
            and   type = 'U')
   drop table USUARIO
go

/*==============================================================*/
/* Table: ANIMAL                                                */
/*==============================================================*/
create table ANIMAL (
   IDANIMAL             integer              identity,
   IDTIPO               integer              null,
   IDCONTATO            integer              null,
   NOME                 text                 null,
   constraint PK_ANIMAL primary key (IDANIMAL)
)
go

/*==============================================================*/
/* Table: CONTATO                                               */
/*==============================================================*/
create table CONTATO (
   IDCONTATO            integer              identity,
   NOME                 text                 null,
   CPF                  text                 null,
   ENDERECO             text                 null,
   BAIRRO               text                 null,
   CIDADE               text                 null,
   ESTADO               text                 null,
   STATUS               integer              null,
   PERFIL               integer              null,
   constraint PK_CONTATO primary key (IDCONTATO)
)
go

/*==============================================================*/
/* Table: LOGACESSO                                             */
/*==============================================================*/
create table LOGACESSO (
   IDTOKEN              integer              identity,
   IDUSUARIO            integer              null,
   TOKEN                text                 null,
   DATAHORA             datetime             null,
   constraint PK_LOGACESSO primary key (IDTOKEN)
)
go

/*==============================================================*/
/* Table: RACA                                                  */
/*==============================================================*/
create table RACA (
   IDRACA               integer              identity,
   IDTIPO               integer              null,
   NOME                 text                 null,
   constraint PK_RACA primary key (IDRACA)
)
go

/*==============================================================*/
/* Table: SERVICO                                               */
/*==============================================================*/
create table SERVICO (
   IDSERVICO            integer              identity,
   IDTIPOSERVICO        integer              null,
   IDCONTATO            integer              null,
   IDANIMAL             integer              null,
   DATAHORA             datetime             null,
   PERIODO              integer              null,
   STATUS               integer              null,
   constraint PK_SERVICO primary key (IDSERVICO)
)
go

/*==============================================================*/
/* Table: TIPO                                                  */
/*==============================================================*/
create table TIPO (
   IDTIPO               integer              identity,
   NOME                 text                 null,
   constraint PK_TIPO primary key (IDTIPO)
)
go

/*==============================================================*/
/* Table: TIPOSERVICO                                           */
/*==============================================================*/
create table TIPOSERVICO (
   IDTIPOSERVICO        integer              identity,
   NOME                 text                 null,
   constraint PK_TIPOSERVICO primary key (IDTIPOSERVICO)
)
go

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO (
   IDUSUARIO            integer              identity,
   IDCONTATO            integer              null,
   EMAIL                text                 null,
   SENHA                text                 null,
   constraint PK_USUARIO primary key (IDUSUARIO)
)
go

alter table ANIMAL
   add constraint FK_ANIMAL_REFERENCE_TIPO foreign key (IDTIPO)
      references TIPO (IDTIPO)
go

alter table ANIMAL
   add constraint FK_ANIMAL_REFERENCE_CONTATO foreign key (IDCONTATO)
      references CONTATO (IDCONTATO)
go

alter table LOGACESSO
   add constraint FK_LOGACESS_REFERENCE_USUARIO foreign key (IDUSUARIO)
      references USUARIO (IDUSUARIO)
go

alter table RACA
   add constraint FK_RACA_REFERENCE_TIPO foreign key (IDTIPO)
      references TIPO (IDTIPO)
go

alter table SERVICO
   add constraint FK_SERVICO_REFERENCE_ANIMAL foreign key (IDANIMAL)
      references ANIMAL (IDANIMAL)
go

alter table SERVICO
   add constraint FK_SERVICO_REFERENCE_TIPOSERV foreign key (IDTIPOSERVICO)
      references TIPOSERVICO (IDTIPOSERVICO)
go

alter table SERVICO
   add constraint FK_SERVICO_REFERENCE_CONTATO foreign key (IDCONTATO)
      references CONTATO (IDCONTATO)
go

alter table USUARIO
   add constraint FK_USUARIO_REFERENCE_CONTATO foreign key (IDCONTATO)
      references CONTATO (IDCONTATO)
go

