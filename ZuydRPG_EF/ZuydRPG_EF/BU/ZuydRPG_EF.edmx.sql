
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/08/2015 15:50:14
-- Generated from EDMX file: c:\users\tryan\documents\visual studio 2013\Projects\ZuydRPG_EF\ZuydRPG_EF\ZuydRPG_EF.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ZuydRPG];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CharacterSet'
CREATE TABLE [dbo].[CharacterSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LocationId] int  NOT NULL
);
GO

-- Creating table 'MonsterSet'
CREATE TABLE [dbo].[MonsterSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LocationId] int  NOT NULL
);
GO

-- Creating table 'LocationSet'
CREATE TABLE [dbo].[LocationSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'CharacterSet_Fighter'
CREATE TABLE [dbo].[CharacterSet_Fighter] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'CharacterSet_Mage'
CREATE TABLE [dbo].[CharacterSet_Mage] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'MonsterSet_Goomba'
CREATE TABLE [dbo].[MonsterSet_Goomba] (
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CharacterSet'
ALTER TABLE [dbo].[CharacterSet]
ADD CONSTRAINT [PK_CharacterSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MonsterSet'
ALTER TABLE [dbo].[MonsterSet]
ADD CONSTRAINT [PK_MonsterSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocationSet'
ALTER TABLE [dbo].[LocationSet]
ADD CONSTRAINT [PK_LocationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CharacterSet_Fighter'
ALTER TABLE [dbo].[CharacterSet_Fighter]
ADD CONSTRAINT [PK_CharacterSet_Fighter]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CharacterSet_Mage'
ALTER TABLE [dbo].[CharacterSet_Mage]
ADD CONSTRAINT [PK_CharacterSet_Mage]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MonsterSet_Goomba'
ALTER TABLE [dbo].[MonsterSet_Goomba]
ADD CONSTRAINT [PK_MonsterSet_Goomba]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LocationId] in table 'CharacterSet'
ALTER TABLE [dbo].[CharacterSet]
ADD CONSTRAINT [FK_CharacterLocation]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[LocationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CharacterLocation'
CREATE INDEX [IX_FK_CharacterLocation]
ON [dbo].[CharacterSet]
    ([LocationId]);
GO

-- Creating foreign key on [LocationId] in table 'MonsterSet'
ALTER TABLE [dbo].[MonsterSet]
ADD CONSTRAINT [FK_MonsterLocation]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[LocationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MonsterLocation'
CREATE INDEX [IX_FK_MonsterLocation]
ON [dbo].[MonsterSet]
    ([LocationId]);
GO

-- Creating foreign key on [Id] in table 'CharacterSet_Fighter'
ALTER TABLE [dbo].[CharacterSet_Fighter]
ADD CONSTRAINT [FK_Fighter_inherits_Character]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[CharacterSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'CharacterSet_Mage'
ALTER TABLE [dbo].[CharacterSet_Mage]
ADD CONSTRAINT [FK_Mage_inherits_Character]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[CharacterSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'MonsterSet_Goomba'
ALTER TABLE [dbo].[MonsterSet_Goomba]
ADD CONSTRAINT [FK_Goomba_inherits_Monster]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[MonsterSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------