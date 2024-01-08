CREATE OR ALTER VIEW [vwCourses] AS 
    SELECT 
        [Course].[Id],
        [Course].[Tag],
        [Course].[Title],
        [Course].[Url],
        [Course].[CreateDate],
        [Course].[Summary],
        [Category].[Title] as Category,
        [Author].[Name] as Author
    FROM
        [Course]
    INNER JOIN [Category] ON [Course].[CategoryId] = [Category].[Id] 
    INNER JOIN [Author] ON [Course].[AuthorId] = [Author].[Id]
    WHERE [Active] = 1

SELECT *  FROM [vwCourses] ORDER BY [CreateDate] DESC


SELECT 
    [Id],
    [Title],
    [Url],
    (SELECT COUNT([CareerId]) FROM [CareerItem] WHERE [CareerId] = [Id]) AS [Courses]
FROM    
    [Career]

CREATE OR ALTER VIEW vwCareers AS
    SELECT 
        [Career].[Id],
        [Career].[Title],
        [Career].[Url],
        COUNT([Id]) AS [Courses]
    FROM
        [Career]
    INNER JOIN [CareerItem] ON  [CareerItem].[CareerId] = [Career].[Id]
    GROUP BY
        [Career].[Id],
        [Career].[Title],
        [Career].[Url]

SELECT * FROM [vwCareers]


SELECT * FROM [Course]
SELECT * FROM [Student]
SELECT * FROM [StudentCourse]

SELECT NEWID()



INSERT INTO 
    [Student]
    VALUES (
        '0ba73dac-f4c9-4bc7-84b7-ad1dd42d4c09',
        'Alessandro Carvalho',
        'Ale@gmail.com',
        '14333777999',
        '28999762587',
        null,
        GETDATE()
    )

INSERT INTO 
    [StudentCourse]
    VALUES (
        '5f5a33f8-4ff3-7e10-cc6e-3fa000000000',
        '0ba73dac-f4c9-4bc7-84b7-ad1dd42d4c09',
        50,
        0,
        '2020-01-13 12:05:53',
        GETDATE()
    )

DECLARE @StudentId UNIQUEIDENTIFIER = '0ba73dac-f4c9-4bc7-84b7-ad1dd42d4c09'


SELECT 
    [Student].[Name] AS [Student],
    [Course].[Title] AS [Course],
    [StudentCourse].[Progress],
    [StudentCourse].[LastUpdateDate]
FROM 
    [StudentCourse]
    INNER JOIN [Student] ON [StudentCourse].StudentId = [Student].[Id]
    INNER JOIN [Course] ON [StudentCourse].CourseId = [Course].[Id]
WHERE [StudentCourse].[StudentId] = @StudentId
    AND [StudentCourse].[Progress] < 100
    AND [StudentCourse].[Progress] > 0
ORDER BY [StudentCourse].[LastUpdateDate] DESC


SELECT 
    [Student].[Name] AS [Student],
    [Course].[Title] As [Course],
    [StudentCourse].[Progress],
    [StudentCourse].[LastUpdateDate]
FROM
    [Course]
    LEFT JOIN [StudentCourse] ON [StudentCourse].[CourseId] = [Course].[Id]
    LEFT JOIN [Student] ON [StudentCourse].[StudentId] = [Student].[Id]




CREATE OR ALTER PROCEDURE [spStudentProgress] @StudentId UNIQUEIDENTIFIER AS
    SELECT 
        [Student].[Name] AS [Student],
        [Course].[Title] AS [Course],
        [StudentCourse].[Progress],
        [StudentCourse].[LastUpdateDate]
    FROM 
        [StudentCourse]
        INNER JOIN [Student] ON [StudentCourse].StudentId = [Student].[Id]
        INNER JOIN [Course] ON [StudentCourse].CourseId = [Course].[Id]
    WHERE [StudentCourse].[StudentId] = @StudentId
        AND [StudentCourse].[Progress] < 100
        AND [StudentCourse].[Progress] > 0
    ORDER BY [StudentCourse].[LastUpdateDate] DESC

EXEC aaaa '0ba73dac-f4c9-4bc7-84b7-ad1dd42d4c09'




CREATE OR ALTER PROCEDURE [spDeleteStudent] @StudentId UNIQUEIDENTIFIER AS
    BEGIN TRANSACTION
        DELETE FROM 
            [StudentCourse]
        WHERE
            [StudentId] = @StudentId

        DELETE FROM 
            [Student]
        WHERE
            [Id] = @StudentId

    COMMIT

EXEC spDeleteStudent '0ba73dac-f4c9-4bc7-84b7-ad1dd42d4c09'
