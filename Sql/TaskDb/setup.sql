CREATE DATABASE TaskDB;
GO
USE TaskDB;
GO

-- Create a new stored procedure called 'StoredProcedureName' in schema 'SchemaName'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'spTaskList'
)
DROP PROCEDURE dbo.spTaskList
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.spTaskList
AS

CREATE TABLE #Tasks
(
    Subject nvarchar(25),
    Description nvarchar(2500)
);

INSERT INTO #Tasks
Values
    ('Subject 1', 'This is a test description')
INSERT INTO #Tasks
Values
    ('Subject 2', '')
INSERT INTO #Tasks
Values
    ('Subject 3', '')

SELECT *
FROM #Tasks

DROP TABLE #Tasks

GO