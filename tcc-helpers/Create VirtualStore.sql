C:\Users\luizedua\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\v11.0


-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/07/2018 16:33:20
-- Generated from EDMX file: C:\Users\luizedua\Downloads\Meus\Dev\VirtualStore\VirtualStore.Data\VirtualStoreModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [VirtualStore];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Category__UserID__24927208]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Category] DROP CONSTRAINT [FK__Category__UserID__24927208];
GO
IF OBJECT_ID(N'[dbo].[FK__Order__440B1D61]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK__Order__440B1D61];
GO
IF OBJECT_ID(N'[dbo].[FK__Order__UserID__44FF419A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK__Order__UserID__44FF419A];
GO
IF OBJECT_ID(N'[dbo].[FK__OrderItem__Order__47DBAE45]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderItem] DROP CONSTRAINT [FK__OrderItem__Order__47DBAE45];
GO
IF OBJECT_ID(N'[dbo].[FK__OrderItem__Produ__48CFD27E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderItem] DROP CONSTRAINT [FK__OrderItem__Produ__48CFD27E];
GO
IF OBJECT_ID(N'[dbo].[FK__Product__Categor__276EDEB3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK__Product__Categor__276EDEB3];
GO
IF OBJECT_ID(N'[dbo].[FK__Product__UserID__286302EC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK__Product__UserID__286302EC];
GO
IF OBJECT_ID(N'[dbo].[FK__User__RoleID__014935CB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK__User__RoleID__014935CB];
GO
IF OBJECT_ID(N'[dbo].[FK__UserAddre__UserI__2B3F6F97]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserAddress] DROP CONSTRAINT [FK__UserAddre__UserI__2B3F6F97];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[OrderItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderItem];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserAddress];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [CategoryGUID] uniqueidentifier  NOT NULL,
    [Title] nvarchar(50)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [UserAddressID] int  NOT NULL,
    [OrderGUID] uniqueidentifier  NOT NULL,
    [IsOrderSent] bit  NOT NULL,
    [TotalPrice] decimal(22,2)  NOT NULL,
    [OrderingIn] datetime  NOT NULL,
    [Status] int  NOT NULL
);
GO

-- Creating table 'OrderItems'
CREATE TABLE [dbo].[OrderItems] (
    [OrderItemID] int IDENTITY(1,1) NOT NULL,
    [OrderID] int  NOT NULL,
    [ProductID] int  NOT NULL,
    [OrderItemGUID] uniqueidentifier  NOT NULL,
    [Price] decimal(22,2)  NOT NULL,
    [Title] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [CategoryID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [ProductGUID] uniqueidentifier  NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Price] decimal(22,2)  NOT NULL,
    [Stock] int  NOT NULL,
    [References] nvarchar(100)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [RoleID] int  NOT NULL,
    [UserGUID] uniqueidentifier  NOT NULL,
    [Name] nvarchar(255)  NOT NULL,
    [Email] nvarchar(128)  NOT NULL,
    [Password] nvarchar(255)  NOT NULL,
    [PasswordQuestion] nvarchar(255)  NOT NULL,
    [PasswordAnswer] nvarchar(255)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [DeactivatedOn] datetime  NULL,
    [LastActivityOn] datetime  NULL,
    [LastLoginOn] datetime  NULL,
    [LastPasswordChangedDate] datetime  NULL,
    [LockedOutOn] datetime  NULL,
    [FailedPasswordAttemptCount] int  NOT NULL,
    [FailedPasswordAttemptWindowStart] datetime  NULL,
    [FailedPasswordAnswerAttemptCount] int  NOT NULL,
    [FailedPasswordAnswerAttemptWindowStart] datetime  NULL
);
GO

-- Creating table 'UserAddresses'
CREATE TABLE [dbo].[UserAddresses] (
    [UserAddressID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [UserAddressGUID] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] nvarchar(45)  NOT NULL,
    [Phone1] nvarchar(45)  NULL,
    [Phone2] nvarchar(45)  NULL,
    [Address] nvarchar(45)  NOT NULL,
    [City] nvarchar(45)  NOT NULL,
    [State] nvarchar(45)  NOT NULL,
    [ZipCode] nvarchar(45)  NOT NULL,
    [Country] nvarchar(45)  NULL,
    [AdditionalInfo] nvarchar(max)  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CategoryID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryID] ASC);
GO

-- Creating primary key on [OrderID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- Creating primary key on [OrderItemID] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [PK_OrderItems]
    PRIMARY KEY CLUSTERED ([OrderItemID] ASC);
GO

-- Creating primary key on [ProductID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [RoleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [UserAddressID], [UserID] in table 'UserAddresses'
ALTER TABLE [dbo].[UserAddresses]
ADD CONSTRAINT [PK_UserAddresses]
    PRIMARY KEY CLUSTERED ([UserAddressID], [UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK__Category__UserID__24927208]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Category__UserID__24927208'
CREATE INDEX [IX_FK__Category__UserID__24927208]
ON [dbo].[Categories]
    ([UserID]);
GO

-- Creating foreign key on [CategoryID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK__Product__Categor__276EDEB3]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[Categories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Product__Categor__276EDEB3'
CREATE INDEX [IX_FK__Product__Categor__276EDEB3]
ON [dbo].[Products]
    ([CategoryID]);
GO

-- Creating foreign key on [UserAddressID], [UserID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK__Order__440B1D61]
    FOREIGN KEY ([UserAddressID], [UserID])
    REFERENCES [dbo].[UserAddresses]
        ([UserAddressID], [UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Order__440B1D61'
CREATE INDEX [IX_FK__Order__440B1D61]
ON [dbo].[Orders]
    ([UserAddressID], [UserID]);
GO

-- Creating foreign key on [UserID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK__Order__UserID__44FF419A]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Order__UserID__44FF419A'
CREATE INDEX [IX_FK__Order__UserID__44FF419A]
ON [dbo].[Orders]
    ([UserID]);
GO

-- Creating foreign key on [OrderID] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [FK__OrderItem__Order__47DBAE45]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[Orders]
        ([OrderID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__OrderItem__Order__47DBAE45'
CREATE INDEX [IX_FK__OrderItem__Order__47DBAE45]
ON [dbo].[OrderItems]
    ([OrderID]);
GO

-- Creating foreign key on [ProductID] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [FK__OrderItem__Produ__48CFD27E]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__OrderItem__Produ__48CFD27E'
CREATE INDEX [IX_FK__OrderItem__Produ__48CFD27E]
ON [dbo].[OrderItems]
    ([ProductID]);
GO

-- Creating foreign key on [UserID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK__Product__UserID__286302EC]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Product__UserID__286302EC'
CREATE INDEX [IX_FK__Product__UserID__286302EC]
ON [dbo].[Products]
    ([UserID]);
GO

-- Creating foreign key on [RoleID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK__User__RoleID__014935CB]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__User__RoleID__014935CB'
CREATE INDEX [IX_FK__User__RoleID__014935CB]
ON [dbo].[Users]
    ([RoleID]);
GO

-- Creating foreign key on [UserID] in table 'UserAddresses'
ALTER TABLE [dbo].[UserAddresses]
ADD CONSTRAINT [FK__UserAddre__UserI__2B3F6F97]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__UserAddre__UserI__2B3F6F97'
CREATE INDEX [IX_FK__UserAddre__UserI__2B3F6F97]
ON [dbo].[UserAddresses]
    ([UserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------


-- user

INSERT [dbo].[Users] ([UserID], [RoleID], [Name], [Email], [Password], [PasswordQuestion], 
[PasswordAnswer], [IsActive], [CreatedOn], 
[LastActivityOn], [LastLoginOn], [LastPasswordChangedDate], 
[LockedOutOn], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], 
[FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart]) 
VALUES (1, 1, N'Luiz Eduardo Pirani Moreira', N'luizepm@hotmail.com', N'yy9Qi1f9iyV6hovQsaBUjJkWS8U=', N'', N'', 1, 
CAST(0x0000A064015B2432 AS DateTime), CAST(0x0000A0650174F137 AS DateTime), CAST(0x0000A0650174F137 AS DateTime), NULL, 
NULL, 1, CAST(0x0000A0650160D8DC AS DateTime), 0, NULL)


-- category

INSERT INTO [dbo].[Categories] ([UserID], [CategoryGUID], [Title], [Description], [IsActive], [CreatedOn]) VALUES (2, newid(), 'Smartphone', 'Smartphone', 1, getdate())
INSERT INTO [dbo].[Categories] ([UserID], [CategoryGUID], [Title], [Description], [IsActive], [CreatedOn]) VALUES (2, newid(), 'Computador', 'Computador', 1, getdate())
INSERT INTO [dbo].[Categories] ([UserID], [CategoryGUID], [Title], [Description], [IsActive], [CreatedOn]) VALUES (2, newid(), 'Eletrodomésticos', 'Eletrodomésticos', 1, getdate())


-- products 

INSERT INTO [dbo].[Products] ([CategoryID], [UserID], [ProductGUID], [Title], [Description], [Price], [Stock], 
[References], [IsActive], [CreatedOn]) 
VALUES (6, 2, newid(), 'iPhone X', 'iPhone X', 999, 10, 'iPhone X top', 1, getdate())


INSERT INTO [dbo].[Products] ([CategoryID], [UserID], [ProductGUID], [Title], [Description], [Price], [Stock], 
[References], [IsActive], [CreatedOn]) 
VALUES (6, 2, newid(), 'iPhone 8', 'iPhone 8', 799, 10, 'iPhone X top', 1, getdate())