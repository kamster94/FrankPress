CREATE DATABASE [FrankPress]
GO

USE [FrankPress]
GO

CREATE LOGIN [FrankPress_app] WITH PASSWORD = 'AppPassword1', DEFAULT_DATABASE = [FrankPress]
GO

CREATE USER [FrankPress_app] FOR LOGIN [FrankPress_app] WITH DEFAULT_SCHEMA = [dbo]
GO

ALTER ROLE [db_datareader] ADD MEMBER [FrankPress_app]
GO

ALTER ROLE [db_datawriter] ADD MEMBER [FrankPress_app]
GO

ALTER ROLE [db_ddladmin] ADD MEMBER [FrankPress_app]
GO