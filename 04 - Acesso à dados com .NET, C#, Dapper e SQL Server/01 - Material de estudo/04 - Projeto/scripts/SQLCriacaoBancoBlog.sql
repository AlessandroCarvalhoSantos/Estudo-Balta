CREATE DATABASE [Brog]
GO

USE [Brog]
GO


--Tabela de usuário

CREATE TABLE [User]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(80) NOT NULL,
    [Email] VARCHAR(200) NOT NULL,
    [PasswordHash] VARCHAR(255) NOT NULL,
    [Bio] TEXT NOT  NULL,
    [Image] VARCHAR(2000) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,

    CONSTRAINT [PK_User] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_User_Email] UNIQUE([Email]),
    CONSTRAINT [UQ_User_Slug] UNIQUE([Slug])
)

CREATE NONCLUSTERED INDEX [IX_User_Email] ON [User]([Email])
CREATE NONCLUSTERED INDEX [IX_User_Slug] ON [User]([Slug]) 

-- Tabela role(PErmissões)

CREATE TABLE [Role](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Role] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Role_Slug] UNIQUE([Slug])
)

CREATE NONCLUSTERED INDEX [IX_Role_Slug] ON [Role]([Slug]) 

-- Tabela relacionamento User x role

CREATE TABLE [UserRole](
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    CONSTRAINT [PK_UserRole] UNIQUE([UserId],[RoleId])
)

-- Tabela de categoria

CREATE TABLE [Category](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Category] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Category_Slug] UNIQUE([Slug])
)

CREATE NONCLUSTERED INDEX [IX_Category_Slug] ON [Category]([Slug]) 

-- Tabela de Post

CREATE TABLE [Post](
    [Id] INT NOT NULL IDENTITY(1,1),
    [CategoryId] INT NOT NULL,
    [AuthorId] INT NOT NULL,
    [Title] NVARCHAR(160) NOT NULL,
    [Summary] NVARCHAR(255) NOT NULL,
    [Body] TEXT NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    [CreateDate] DATETIME NOT NULL DEFAULT(GETDATE()),
    [LastUpdateDate] DATETIME NOT NULL DEFAULT(GETDATE()),

    CONSTRAINT [PK_Post] PRIMARY KEY([Id]),
    CONSTRAINT [Fk_Post_Category] FOREIGN KEY([CategoryId]) REFERENCES [Category]([Id]),
    CONSTRAINT [Fk_Post_Author] FOREIGN KEY([AuthorId]) REFERENCES [User]([Id]),
    CONSTRAINT [UQ_Post_Slug] UNIQUE([Slug]) 
)

CREATE NONCLUSTERED INDEX [IX_Post_Slug] ON [Post]([Slug]) 


-- Tabela de Tag
CREATE TABLE [Tag](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Tag] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Tag_Slug] UNIQUE([Slug])
)

CREATE NONCLUSTERED INDEX [IX_Tag_Slug] ON [Tag]([Slug]) 


-- Tabela relacionamento Tag e Post
CREATE TABLE [PostTag](
    [PostId] INT NOT NULL,
    [TagId] INT NOT NULL,
    CONSTRAINT [PK_UserRole] UNIQUE([PostId],[TagId])
)