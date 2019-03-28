
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/11/2019 16:32:02
-- Generated from EDMX file: C:\Users\Carlos Aracena\source\repos\agenda3\agenda3\Modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Agenda];
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

-- Creating table 'ModelFirstSet'
CREATE TABLE [dbo].[ModelFirstSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Telefono] nvarchar(max)  NOT NULL,
    [Direccion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EventosSet'
CREATE TABLE [dbo].[EventosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Evento] nvarchar(max)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Lugar] nvarchar(max)  NOT NULL,
    [ModelFirstId] int  NOT NULL,
    [ModelFirstId1] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ModelFirstSet'
ALTER TABLE [dbo].[ModelFirstSet]
ADD CONSTRAINT [PK_ModelFirstSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EventosSet'
ALTER TABLE [dbo].[EventosSet]
ADD CONSTRAINT [PK_EventosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ModelFirstId1] in table 'EventosSet'
ALTER TABLE [dbo].[EventosSet]
ADD CONSTRAINT [FK_ModelFirstEventos]
    FOREIGN KEY ([ModelFirstId1])
    REFERENCES [dbo].[ModelFirstSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModelFirstEventos'
CREATE INDEX [IX_FK_ModelFirstEventos]
ON [dbo].[EventosSet]
    ([ModelFirstId1]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------