--Criando um banco de dados
CREATE DATABASE [Curso]

--Deletando um banco de dados

DROP DATABASE [Curso]

--Script para matar um banco e dropar ele
USE [master];

DECLARE @kill varchar(8000) = '';
SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id)
FROM sys.dm_exec_sessions
WHERE database_id = db_id('Curso')

EXEC(@kill);

DROP DATABASE [Curso]

-- Definindo um banco
USE [Curso]


-- Criando uma tabela
CREATE TABLE [Aluno](
	[Id] INT,
	[Nome] NVARCHAR(160),
    [Nascimento] DATETIME,
    [Active] bit,
)

--Removendo uma tabela
DROP TABLE [Aluno]

-- Adicionando uma coluna
ALTER TABLE [Aluno]
	ADD [Document] NVARCHAR(160)

-- Removendo uma coluna
ALTER TABLE [Aluno]
	DROP COLUMN [Document]

-- Alterando o tipo de uma coluna
ALTER TABLE [Aluno]
	ALTER COLUMN [Document] CHAR(11)


-- Constraints núlavel ou não
CREATE TABLE [Aluno](
	[Id] INT NOT NULL,
	[Nome] NVARCHAR(160) NOT NULL,
    [Nascimento] DATETIME NULL,
    [Active] bit NULL,
)

-- Alterando Constraints núlavel ou não
ALTER TABLE [Aluno]
	ALTER COLUMN [Active] BIT NOT NULL

-- Utilizando o default
CREATE TABLE [Aluno](
    [Id] INT NOT NULL DEFAULT(1),
	[Nome] NVARCHAR(160) NOT NULL DEFAULT('Sem nome'),
    [Nascimento] DATETIME NOT NULL DEFAULT(GETDATE()),
    [Active] bit  NOT NULL DEFAULT(0),
)

-- Retornando a data atual do sistema
SELECT GETDATE();


-- Adicionando UNIQUE a uma coluna
CREATE TABLE [Aluno](
    [Id] INT NOT NULL UNIQUE,
    [Nome] NVARCHAR(160) NOT NULL,
    [Email] NVARCHAR(160) NOT NULL UNIQUE,
    [Nascimento] DATETIME NOT NULL DEFAULT(GETDATE()),
    [Active] bit  NOT NULL DEFAULT(0),
)

-- Definindo uma primary key
CREATE TABLE [Aluno](
    [Id] INT NOT NULL ,
    [Nome] NVARCHAR(160) NOT NULL,
    [Email] NVARCHAR(160) NOT NULL UNIQUE,
    [Nascimento] DATETIME NOT NULL DEFAULT(GETDATE()),
    [Active] bit  NOT NULL DEFAULT(0),
	PRIMARY KEY([Id]) 
)

-- Definindo uma chave composta
CREATE TABLE [Aluno](
    [Id] INT NOT NULL ,
    [Nome] NVARCHAR(160) NOT NULL,
    [Email] NVARCHAR(160) NOT NULL UNIQUE,
    [Nascimento] DATETIME NOT NULL DEFAULT(GETDATE()),
    [Active] bit  NOT NULL DEFAULT(0),
	PRIMARY KEY([Id],[Email]) -- Chave composta PRIMARY KEY([Id]) 
)

-- Adicionando uma primary key depois de criado a tabela
ALTER TABLE [Aluno]
	ADD PRIMARY KEY([Id])


-- Adicionado com nome a PK
CREATE TABLE [Aluno](
    [Id] INT NOT NULL ,
    [Nome] NVARCHAR(160) NOT NULL,
    [Email] NVARCHAR(160) NOT NULL UNIQUE,
    [Nascimento] DATETIME NOT NULL DEFAULT(GETDATE()),
    [Active] bit  NOT NULL DEFAULT(0),
    CONSTRAINT [PK_Aluno] PRIMARY KEY([Id]) -- Chave composta
)

-- Dropando a pk
ALTER TABLE [Aluno]
	DROP CONSTRAINT [PK_Aluno]

-- Alterando com nome a PK

ALTER TABLE [Aluno]
	ADD CONSTRAINT [PK_Aluno] PRIMARY KEY([Id])

-- Adicionando Constraint de Unique com nome

CREATE TABLE [Aluno](
    [Id] INT NOT NULL ,
    [Nome] NVARCHAR(160) NOT NULL,
    [Email] NVARCHAR(160) NOT NULL,
    [Nascimento] DATETIME NOT NULL DEFAULT(GETDATE()),
    [Active] bit  NOT NULL DEFAULT(0),
    CONSTRAINT [PK_Aluno] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_ALUNO_EMAIl] UNIQUE([Email]), -- Adicionando nome a nossa unique
)

-- Adicionando Constraint de Unique com nome depois de criado
ALTER TABLE [Aluno]
	ADD CONSTRAINT [UQ_ALUNO_EMAIL] UNIQUE([EMAIL])

-- Dropando um unique pelo nome
ALTER TABLE [Aluno]
	DROP CONSTRAINT [UQ_ALUNO_EMAIL]


--Entendendo  composite key e foreigh key

DROP table Curso
CREATE DATABASE Curso

CREATE TABLE [Aluno](
    [Id] INT NOT NULL ,
    [Nome] NVARCHAR(160) NOT NULL,
    [Email] NVARCHAR(160) NOT NULL,
    [Nascimento] DATETIME NOT NULL DEFAULT(GETDATE()),
    [Active] bit  NOT NULL DEFAULT(0),
    CONSTRAINT [PK_Aluno] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_ALUNO_EMAIl] UNIQUE([Email]), -- Adicionando nome a nossa unique
)

CREATE TABLE [Curso](
    [Id] INT NOT NULL ,
    [Nome] NVARCHAR(160) NOT NULL,
    [CategoriaId] INT NOT NULL ,

    CONSTRAINT [PK_Curso] PRIMARY KEY([Id]),
    CONSTRAINT [Fk_Categoria] FOREIGN KEY([CategoriaId]) -- chave estrangeira
			REFERENCES [Categoria]([Id])
)

CREATE TABLE [Categoria](
    [Id] INT NOT NULL ,
    [Nome] NVARCHAR(160) NOT NULL,
    CONSTRAINT [PK_Categoria] PRIMARY KEY([Id])
)


CREATE TABLE [ProgressoCurso](
    [AlunoId] INT NOT NULL ,
    [CursoId] INT NOT NULL ,
    [Progresso] INT NOT NULL,
    [UltimaAtualizacao] DATETIME NOT NULL DEFAULT(GETDATE()),
    CONSTRAINT [PK_Progresso_Curso] PRIMARY KEY([AlunoId],[CursoId])
)

-- Criando index

CREATE INDEX [IX_Aluno_Email] ON [Aluno]([Email])

-- Dropando INDEXcha
DROP INDEX [IX_Aluno_Email]

-- Comitando a operação
DROP INDEX [IX_Aluno_Email] ON [Aluno]


-- Gerando códigos automáticos com IDENTITY
drop TABLE Aluno
CREATE TABLE [Aluno](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Nome] NVARCHAR(160) NOT NULL,
    [Email] NVARCHAR(160) NOT NULL,
    [Nascimento] DATETIME NOT NULL DEFAULT(GETDATE()),
    [Active] bit  NOT NULL DEFAULT(0),
    CONSTRAINT [PK_Aluno] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_ALUNO_EMAIl] UNIQUE([Email]), 
)


CREATE TABLE [Aluno](
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    [Nome] NVARCHAR(160) NOT NULL,
    [Email] NVARCHAR(160) NOT NULL,
    [Nascimento] DATETIME NOT NULL DEFAULT(GETDATE()),
    [Active] bit  NOT NULL DEFAULT(0),
    CONSTRAINT [PK_Aluno] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_ALUNO_EMAIl] UNIQUE([Email]), 
)

GO

