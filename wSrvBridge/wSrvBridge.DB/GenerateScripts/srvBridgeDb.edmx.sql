
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/01/2013 15:17:06
-- Generated from EDMX file: C:\Users\hakan\Documents\Visual Studio 2012\Projects\GncTrkCll\wSrvBridge\wSrvBridge.DB\srvBridgeDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [wanda_wsrvlocator];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[QDBOfferList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QDBOfferList];
GO
IF OBJECT_ID(N'[dbo].[QDBValueTrackers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QDBValueTrackers];
GO
IF OBJECT_ID(N'[dbo].[ServiceLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceLogs];
GO
IF OBJECT_ID(N'[dbo].[WebServices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WebServices];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'QDBValueTrackers'
CREATE TABLE [dbo].[QDBValueTrackers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LastTimestamp] datetime  NOT NULL,
    [LastProvId] int  NOT NULL,
    [CreatedAt] datetime  NOT NULL
);
GO

-- Creating table 'WebServices'
CREATE TABLE [dbo].[WebServices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PlatformType] int  NOT NULL,
    [Naming] nvarchar(max)  NOT NULL,
    [ConfigName] nvarchar(50)  NOT NULL,
    [ServiceUrl] nvarchar(max)  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [ModifiedAt] datetime  NULL
);
GO

-- Creating table 'ServiceLogs'
CREATE TABLE [dbo].[ServiceLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LogLevel] nvarchar(20)  NOT NULL,
    [Type] nvarchar(20)  NOT NULL,
    [Message] nvarchar(max)  NULL,
    [Naming] nvarchar(max)  NOT NULL,
    [Operation] nvarchar(max)  NOT NULL,
    [ExceptionType] nvarchar(50)  NULL,
    [ActivePlatform] int  NOT NULL,
    [ResponseData] nvarchar(max)  NOT NULL,
    [Referrer] nvarchar(max)  NULL,
    [CreatedAt] datetime  NOT NULL
);
GO

-- Creating table 'QDBOfferList'
CREATE TABLE [dbo].[QDBOfferList] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OfferId] varchar(100)  NOT NULL,
    [OfferUniqueName] nvarchar(max)  NOT NULL,
    [FilterStatus] bit  NOT NULL,
    [CreatedAt] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'QDBValueTrackers'
ALTER TABLE [dbo].[QDBValueTrackers]
ADD CONSTRAINT [PK_QDBValueTrackers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WebServices'
ALTER TABLE [dbo].[WebServices]
ADD CONSTRAINT [PK_WebServices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiceLogs'
ALTER TABLE [dbo].[ServiceLogs]
ADD CONSTRAINT [PK_ServiceLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'QDBOfferList'
ALTER TABLE [dbo].[QDBOfferList]
ADD CONSTRAINT [PK_QDBOfferList]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------