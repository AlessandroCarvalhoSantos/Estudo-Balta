CREATE DATABASE [Cursos]
GO

USE [Cursos]
GO

CREATE TABLE [Categoria](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Nome] NVARCHAR(80) NOT NULL, 

    CONSTRAINT [PK_Categoria] PRIMARY KEY([Id]),
)
GO

CREATE TABLE [Curso](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Nome] NVARCHAR(80) NOT NULL, 
    [CategoriaId] INT NOT NULL,

    CONSTRAINT [PK_Curso] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY([CategoriaId])
        REFERENCES [Categoria]([Id])
)
GO

-- Executando inserts
INSERT INTO [Categoria]([Nome]) VALUES('Backend')
INSERT INTO [Categoria]([Nome]) VALUES('Frontend')
INSERT INTO [Categoria]([Nome]) VALUES('Mobile')

INSERT INTO [Curso]([Nome],[CategoriaId]) VALUES('Fundamentos de C#',1)
INSERT INTO [Curso]([Nome],[CategoriaId]) VALUES('Fundamentos de OOP',1)
INSERT INTO [Curso]([Nome],[CategoriaId]) VALUES('Fundamentos de Angular',2)
INSERT INTO [Curso]([Nome],[CategoriaId]) VALUES('Flutter',3)


-- Executando selects
SELECT * FROM [Curso]
SELECT TOP 1 [Nome],[Id] FROM [Curso]

SELECT
	[Id]
FROM [Curso]
WHERE [Id] = 1

SELECT DISTINCT
	[Nome]
FROM [Categoria]

-- Executando queries com WHERE

SELECT 
    [Id], [Nome], [CategoriaId]
FROM 
    [Curso]
WHERE
    [CategoriaId] < 1

SELECT 
    [Id], [Nome], [CategoriaId]
FROM 
    [Curso]
WHERE
    [CategoriaId] < 1 AND [CategoriaId] = 1 OR [CategoriaId] = 3



SELECT 
    [Id], [Nome], [CategoriaId]
FROM 
    [Curso]
WHERE
    [CategoriaId] IS NULL and [Id] IS NOT NULL

-- Utilizando Order By

SELECT [Id], [Nome] FROM [Categoria] ORDER BY [Nome] 
SELECT [Id], [Nome] FROM [Categoria] ORDER BY [Nome] ASC
SELECT [Id], [Nome] FROM [Categoria] ORDER BY [Nome] DESC
SELECT [Id], [Nome] FROM [Categoria] ORDER BY [Nome] DESC, [Id] ASC 


-- Utilizando Update

SELECT [Id], [Nome] FROM [Categoria]

UPDATE [Categoria] SET [Nome] = 'BackEnd' where [Id] = 4

BEGIN TRANSACTION

UPDATE [Categoria] SET [Nome] = 'Vasco' where [Id] = 4
SELECT [Id], [Nome] FROM [Categoria]


ROLLBACK

BEGIN TRANSACTION

UPDATE [Categoria] SET [Nome] = 'BackEnd' where [Id] = 4

COMMIT

-- Utilizando delete


BEGIN TRANSACTION

SELECT [Id], [Nome] FROM [Categoria]

DELETE FROM [Categoria] WHERE [Id] = 1004

ROLLBACK


-- Utilizando o COUNT

SELECT COUNT([Id]) FROM [Categoria]
SELECT COUNT(*) FROM [Categoria]


-- Utilizando o SUM

SELECT SUM([Id]) FROM [Categoria]

-- Utilizando o MIN

SELECT MIN([Id]) FROM [Categoria]

-- Utilizando o MAX

SELECT MAX([Id]) FROM [Categoria]


-- Utilizando o AVG

SELECT AVG([Id]) FROM [Categoria]


-- Utilizando o operador like

SELECT * FROM [Categoria] WHERE [Nome] LIKE 'C#' -- semelhante ao Igual
SELECT * FROM [Categoria] WHERE [Nome] LIKE '%C#' -- semelhante ao termina com
SELECT * FROM [Categoria] WHERE [Nome] LIKE 'C#%' -- semelhante ao começa com
SELECT * FROM [Categoria] WHERE [Nome] LIKE '%C#%' -- semelhante ao contains

SELECT * FROM [Categoria] WHERE [Nome] LIKE 'a_a' -- semelhante ao Igual, busacando esse padrão
SELECT * FROM [Categoria] WHERE [Nome] LIKE '%_a' -- semelhante ao termina com,  buscando esse padrão
SELECT * FROM [Categoria] WHERE [Nome] LIKE '_a%' -- semelhante ao começa com, busacando esse padrão
SELECT * FROM [Categoria] WHERE [Nome] LIKE '%_a%' -- semelhante ao contains, busacando esse padrão

-- Utilizando o operador IN

SELECT * FROM [Categoria] WHERE [Id] IN(1,2,3)

-- Utilizando o operador BETWEEN

SELECT * FROM [Categoria] WHERE [Id] BETWEEN 1 AND 4


-- Utilizando o alias

SELECT [Id] AS 'Identificador a' FROM [Categoria]
SELECT [Id] AS Identificador FROM [Categoria] 
SELECT COUNT([Id]) AS Total FROM [Categoria] 


-- Utilizando inner join
SELECT * FROM [Categoria]
SELECT * FROM [Curso]

SELECT *
FROM [Curso]
INNER JOIN [Categoria] on [Curso].[CategoriaId] = [Categoria].[Id]


-- Utilizando left join


SELECT *
FROM [Curso]
LEFT JOIN [Categoria] on [Curso].[CategoriaId] = [Categoria].[Id]

-- Utilizando left join

SELECT *
FROM [Curso]
RIGHT JOIN [Categoria] on [Curso].[CategoriaId] = [Categoria].[Id]

-- Utilizando FULL OUTER join

SELECT *
FROM [Curso]
FULL OUTER JOIN [Categoria] on [Curso].[CategoriaId] = [Categoria].[Id]


-- Utilizando o UNION

SELECT [Id], [Nome] FROM [Curso]
UNION 
SELECT [Id], [Nome]  FROM [Categoria]

SELECT [Id], [Nome] FROM [Curso]
UNION ALL
SELECT [Id], [Nome]  FROM [Categoria]


-- Utilização group by


SELECT 
    [Curso].[Nome], 
    [Categoria].[Nome], 
    COUNT([Curso].[CategoriaId]) as 'Quantidade'
FROM [Curso]
INNER JOIN [Categoria] ON [Curso].[CategoriaId] = [Categoria].[Id]
GROUP BY [Curso].[Nome], [Categoria].[Nome] 

-- Utilização having

SELECT 
    [Curso].[Nome], 
    [Categoria].[Nome], 
    COUNT([Curso].[CategoriaId]) as 'Quantidade'
FROM [Curso]
INNER JOIN [Categoria] ON [Curso].[CategoriaId] = [Categoria].[Id]
GROUP BY [Curso].[Nome], [Categoria].[Nome] 
HAVING COUNT([Curso].[CategoriaId])  > 1
ORDER BY [Curso].[Nome]


-- Utilizando views

CREATE OR ALTER VIEW NomeView AS
    SELECT * FROM [Curso]


SELECT * FROM [Teste]


CREATE OR ALTER VIEW [Teste] AS 
    SELECT * FROM [Categoria]

CREATE VIEW [Teste] AS 
    SELECT * FROM [Categoria]

ALTER VIEW [Teste] AS 
    SELECT * FROM [Categoria]


-- Utilizando  Stored Procedures


CREATE PROCEDURE [NomeProcedure] AS
    Select * FROM [Curso]

ALTER PROCEDURE [NomeProcedure] AS
    Select * FROM [Curso]

CREATE OR ALTER PROCEDURE [NomeProcedure] AS
    Select * FROM [Curso]

EXEC NomeProcedure


DROP PROCEDURE [NomeProcedure]

-- Utilizando variáveis

DECLARE @teste INT

SET @teste = 2

Select @teste


DECLARE @CategoryId INT
SET @CategoryId = (SELECT TOP 1 [Id] FROM [Categoria] WHERE [Nome] = 'backend')

Select @CategoryId

-- Utilizando variáveis store procedure

CREATE OR ALTER PROCEDURE [ProcedureVariaveis] @param INT, @param2 INT AS
    SELECT * FROM [Categoria] WHERE [Id] IN (@param,@param2)

EXEC ProcedureVariaveis 1, 2