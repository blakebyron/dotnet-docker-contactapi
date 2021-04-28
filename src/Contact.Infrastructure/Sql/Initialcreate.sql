IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210402182410_Initialcreate')
BEGIN
    CREATE TABLE [Contact] (
        [ID] uniqueidentifier NOT NULL,
        [FirstName] nvarchar(50) NULL,
        [LastName] nvarchar(50) NOT NULL,
        [Organisation] nvarchar(50) NULL,
        CONSTRAINT [ContactID] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210402182410_Initialcreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210402182410_Initialcreate', N'5.0.4');
END;
GO

COMMIT;
GO

