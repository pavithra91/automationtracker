
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/08/2019 12:05:18
-- Generated from EDMX file: C:\Users\pavithraj\Desktop\Development Project\AutomationTracker\AutomationTracker\AutomationTracker\OfficeAutomationdb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OfficeAutomationdb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CategoryIDfk_UnitType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UnitType] DROP CONSTRAINT [FK_CategoryIDfk_UnitType];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryIDfk_UserAssest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserAssets] DROP CONSTRAINT [FK_CategoryIDfk_UserAssest];
GO
IF OBJECT_ID(N'[dbo].[FK_Companyfk_Computers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Computers] DROP CONSTRAINT [FK_Companyfk_Computers];
GO
IF OBJECT_ID(N'[dbo].[FK_Companyfk_Phones]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhoneDongles] DROP CONSTRAINT [FK_Companyfk_Phones];
GO
IF OBJECT_ID(N'[dbo].[FK_Companyfk_VOIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VOIP] DROP CONSTRAINT [FK_Companyfk_VOIP];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyIDfk_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_CompanyIDfk_Users];
GO
IF OBJECT_ID(N'[dbo].[fk_UnitTypeID_Models]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ModelType] DROP CONSTRAINT [fk_UnitTypeID_Models];
GO
IF OBJECT_ID(N'[dbo].[FK_Marketfk_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Marketfk_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_ModelTypefk_Computers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Computers] DROP CONSTRAINT [FK_ModelTypefk_Computers];
GO
IF OBJECT_ID(N'[dbo].[FK_ModelTypefk_Phone]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhoneDongles] DROP CONSTRAINT [FK_ModelTypefk_Phone];
GO
IF OBJECT_ID(N'[dbo].[FK_ModelTypefk_VOIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VOIP] DROP CONSTRAINT [FK_ModelTypefk_VOIP];
GO
IF OBJECT_ID(N'[dbo].[FK_OfficeVersionfk_Computers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Computers] DROP CONSTRAINT [FK_OfficeVersionfk_Computers];
GO
IF OBJECT_ID(N'[dbo].[FK_OSfk_Computers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Computers] DROP CONSTRAINT [FK_OSfk_Computers];
GO
IF OBJECT_ID(N'[dbo].[FK_Providerfk_Phones]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhoneDongles] DROP CONSTRAINT [FK_Providerfk_Phones];
GO
IF OBJECT_ID(N'[dbo].[FK_UnitTypefk_Computers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Computers] DROP CONSTRAINT [FK_UnitTypefk_Computers];
GO
IF OBJECT_ID(N'[dbo].[FK_UnitTypefk_Phone]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhoneDongles] DROP CONSTRAINT [FK_UnitTypefk_Phone];
GO
IF OBJECT_ID(N'[dbo].[FK_UnitTypefk_VOIP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VOIP] DROP CONSTRAINT [FK_UnitTypefk_VOIP];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Company]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Company];
GO
IF OBJECT_ID(N'[dbo].[Computers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Computers];
GO
IF OBJECT_ID(N'[dbo].[DisposeList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DisposeList];
GO
IF OBJECT_ID(N'[dbo].[EmailConfig]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmailConfig];
GO
IF OBJECT_ID(N'[dbo].[Market]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Market];
GO
IF OBJECT_ID(N'[dbo].[ModelType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ModelType];
GO
IF OBJECT_ID(N'[dbo].[OutsourceUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OutsourceUsers];
GO
IF OBJECT_ID(N'[dbo].[PhoneDongles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhoneDongles];
GO
IF OBJECT_ID(N'[dbo].[Provider]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Provider];
GO
IF OBJECT_ID(N'[dbo].[Software]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Software];
GO
IF OBJECT_ID(N'[dbo].[SystemUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SystemUsers];
GO
IF OBJECT_ID(N'[dbo].[TransferAssestHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransferAssestHistory];
GO
IF OBJECT_ID(N'[dbo].[UnitType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UnitType];
GO
IF OBJECT_ID(N'[dbo].[UserAssets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserAssets];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[VOIP]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VOIP];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryID] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(20)  NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [CompanyID] int IDENTITY(1,1) NOT NULL,
    [CompanyCode] nvarchar(5)  NULL,
    [CompanyName] nvarchar(50)  NULL
);
GO

-- Creating table 'Computers'
CREATE TABLE [dbo].[Computers] (
    [AUOTID] int IDENTITY(1,1) NOT NULL,
    [UnitType] int  NULL,
    [ModelType] int  NULL,
    [AssestNo] nvarchar(100)  NULL,
    [SerialNo] nvarchar(100)  NULL,
    [RAM] nvarchar(20)  NULL,
    [OS] int  NULL,
    [OfficeVersion] int  NULL,
    [HDDCapacity] nvarchar(20)  NULL,
    [Remarks] nvarchar(500)  NULL,
    [PurchaseDate] datetime  NULL,
    [DisposeDate] datetime  NULL,
    [AddedDate] datetime  NULL,
    [AddedBy] nvarchar(1)  NULL,
    [UpdateDate] datetime  NULL,
    [UpdateBy] nvarchar(1)  NULL,
    [Company] int  NULL,
    [ActualAssignee] int  NULL,
    [WarrantyExpireDate] datetime  NULL,
    [IsActive] bit  NOT NULL,
    [DisposeRemark] nvarchar(500)  NULL
);
GO

-- Creating table 'DisposeLists'
CREATE TABLE [dbo].[DisposeLists] (
    [AUTOID] int IDENTITY(1,1) NOT NULL,
    [ItemID] int  NULL,
    [Category] int  NULL,
    [DisposeDate] datetime  NULL,
    [IsDisposed] bit  NULL,
    [UpdateDate] datetime  NULL,
    [UpdateBy] nvarchar(20)  NULL
);
GO

-- Creating table 'EmailConfigs'
CREATE TABLE [dbo].[EmailConfigs] (
    [AUTOID] int IDENTITY(1,1) NOT NULL,
    [EmailTo] nvarchar(500)  NULL,
    [EmailCC] nvarchar(500)  NULL,
    [EmailBCC] nvarchar(500)  NULL,
    [Subject] nvarchar(200)  NULL,
    [EmailFrom] nvarchar(200)  NULL
);
GO

-- Creating table 'Markets'
CREATE TABLE [dbo].[Markets] (
    [MarketID] int IDENTITY(1,1) NOT NULL,
    [MarketName] varchar(100)  NULL,
    [CompanyID] int  NULL
);
GO

-- Creating table 'ModelTypes'
CREATE TABLE [dbo].[ModelTypes] (
    [ModelID] int IDENTITY(1,1) NOT NULL,
    [ModelName] varchar(100)  NULL,
    [UnitType] int  NULL,
    [Description] nvarchar(300)  NULL,
    [AddedBy] nvarchar(100)  NULL,
    [AddedDate] datetime  NULL,
    [UpdateBy] nvarchar(100)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'OutsourceUsers'
CREATE TABLE [dbo].[OutsourceUsers] (
    [AUTOID] int IDENTITY(1,1) NOT NULL,
    [OutSourceID] nvarchar(20)  NULL
);
GO

-- Creating table 'PhoneDongles'
CREATE TABLE [dbo].[PhoneDongles] (
    [AUOTID] int IDENTITY(1,1) NOT NULL,
    [UnitType] int  NULL,
    [ModelType] int  NULL,
    [Provider] int  NULL,
    [AssestNo] nvarchar(50)  NULL,
    [SerialNo] nvarchar(50)  NULL,
    [ConnectionNo] int  NULL,
    [SimNo] int  NULL,
    [EMEINo1] int  NULL,
    [EMEINo2] int  NULL,
    [Remarks] nvarchar(500)  NULL,
    [AddedDate] datetime  NULL,
    [AddedBy] nvarchar(50)  NULL,
    [UpdateDate] datetime  NULL,
    [UpdateBy] nvarchar(50)  NULL,
    [Company] int  NULL,
    [ActualAssignee] int  NULL,
    [DisposeDate] datetime  NULL,
    [PurchaseDate] datetime  NULL,
    [IsEmailSend] bit  NULL,
    [IsActive] bit  NOT NULL,
    [DisposeRemark] nvarchar(500)  NULL
);
GO

-- Creating table 'Providers'
CREATE TABLE [dbo].[Providers] (
    [AUTOID] int IDENTITY(1,1) NOT NULL,
    [ProviderName] nvarchar(100)  NULL,
    [Description] nvarchar(500)  NULL
);
GO

-- Creating table 'Softwares'
CREATE TABLE [dbo].[Softwares] (
    [SoftwareID] int IDENTITY(1,1) NOT NULL,
    [SoftwareName] varchar(100)  NULL,
    [SoftwareType] varchar(50)  NULL
);
GO

-- Creating table 'SystemUsers'
CREATE TABLE [dbo].[SystemUsers] (
    [AUTOID] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(100)  NULL,
    [UserName] nvarchar(50)  NULL,
    [Password] nvarchar(100)  NULL,
    [Hashkey] nvarchar(100)  NULL,
    [IsActive] bit  NULL
);
GO

-- Creating table 'TransferAssestHistories'
CREATE TABLE [dbo].[TransferAssestHistories] (
    [AUTOID] int IDENTITY(1,1) NOT NULL,
    [PreviousUser] int  NULL,
    [NewUser] int  NULL,
    [ItemID] int  NULL,
    [Category] int  NULL,
    [AddedDate] datetime  NOT NULL,
    [AddedBy] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'UnitTypes'
CREATE TABLE [dbo].[UnitTypes] (
    [UnitTypeID] int IDENTITY(1,1) NOT NULL,
    [UnitTypeName] varchar(100)  NULL,
    [AddedBy] nvarchar(100)  NULL,
    [AddedDate] datetime  NULL,
    [UpdateBy] nvarchar(100)  NULL,
    [UpdateDate] datetime  NULL,
    [Category] int  NULL
);
GO

-- Creating table 'UserAssets'
CREATE TABLE [dbo].[UserAssets] (
    [AUTOID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [ItemID] int  NULL,
    [ActualAssignee] int  NULL,
    [PANo] varchar(20)  NULL,
    [Category] int  NULL,
    [UpdateBy] nvarchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [Title] varchar(20)  NULL,
    [FullName] varchar(100)  NULL,
    [Company] int  NULL,
    [Market] int  NULL,
    [PANo] varchar(20)  NOT NULL,
    [SAPNo] varchar(20)  NULL,
    [NIC] varchar(10)  NULL,
    [Remarks] varchar(500)  NULL,
    [IsActive] bit  NOT NULL,
    [AddedDate] datetime  NULL,
    [AddedBy] varchar(100)  NULL,
    [UpdateDate] datetime  NULL,
    [UpdateBy] varchar(100)  NULL,
    [IsUserOutSource] bit  NOT NULL
);
GO

-- Creating table 'VOIPs'
CREATE TABLE [dbo].[VOIPs] (
    [AUTOID] int IDENTITY(1,1) NOT NULL,
    [UnitType] int  NULL,
    [ModelType] int  NULL,
    [AssestNo] nvarchar(1)  NULL,
    [SerialNo] nvarchar(1)  NULL,
    [ExtentionNo] int  NULL,
    [Remarks] nvarchar(1)  NULL,
    [AddedDate] datetime  NULL,
    [AddedBy] nvarchar(1)  NULL,
    [UpdateDate] datetime  NULL,
    [UpdateBy] nvarchar(1)  NULL,
    [Company] int  NULL,
    [PurchaseDate] datetime  NULL,
    [DisposeDate] datetime  NULL,
    [ActualAssignee] int  NULL,
    [IsActive] bit  NOT NULL,
    [DisposeRemark] nvarchar(500)  NULL
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

-- Creating primary key on [CompanyID] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([CompanyID] ASC);
GO

-- Creating primary key on [AUOTID] in table 'Computers'
ALTER TABLE [dbo].[Computers]
ADD CONSTRAINT [PK_Computers]
    PRIMARY KEY CLUSTERED ([AUOTID] ASC);
GO

-- Creating primary key on [AUTOID] in table 'DisposeLists'
ALTER TABLE [dbo].[DisposeLists]
ADD CONSTRAINT [PK_DisposeLists]
    PRIMARY KEY CLUSTERED ([AUTOID] ASC);
GO

-- Creating primary key on [AUTOID] in table 'EmailConfigs'
ALTER TABLE [dbo].[EmailConfigs]
ADD CONSTRAINT [PK_EmailConfigs]
    PRIMARY KEY CLUSTERED ([AUTOID] ASC);
GO

-- Creating primary key on [MarketID] in table 'Markets'
ALTER TABLE [dbo].[Markets]
ADD CONSTRAINT [PK_Markets]
    PRIMARY KEY CLUSTERED ([MarketID] ASC);
GO

-- Creating primary key on [ModelID] in table 'ModelTypes'
ALTER TABLE [dbo].[ModelTypes]
ADD CONSTRAINT [PK_ModelTypes]
    PRIMARY KEY CLUSTERED ([ModelID] ASC);
GO

-- Creating primary key on [AUTOID] in table 'OutsourceUsers'
ALTER TABLE [dbo].[OutsourceUsers]
ADD CONSTRAINT [PK_OutsourceUsers]
    PRIMARY KEY CLUSTERED ([AUTOID] ASC);
GO

-- Creating primary key on [AUOTID] in table 'PhoneDongles'
ALTER TABLE [dbo].[PhoneDongles]
ADD CONSTRAINT [PK_PhoneDongles]
    PRIMARY KEY CLUSTERED ([AUOTID] ASC);
GO

-- Creating primary key on [AUTOID] in table 'Providers'
ALTER TABLE [dbo].[Providers]
ADD CONSTRAINT [PK_Providers]
    PRIMARY KEY CLUSTERED ([AUTOID] ASC);
GO

-- Creating primary key on [SoftwareID] in table 'Softwares'
ALTER TABLE [dbo].[Softwares]
ADD CONSTRAINT [PK_Softwares]
    PRIMARY KEY CLUSTERED ([SoftwareID] ASC);
GO

-- Creating primary key on [AUTOID] in table 'SystemUsers'
ALTER TABLE [dbo].[SystemUsers]
ADD CONSTRAINT [PK_SystemUsers]
    PRIMARY KEY CLUSTERED ([AUTOID] ASC);
GO

-- Creating primary key on [AUTOID] in table 'TransferAssestHistories'
ALTER TABLE [dbo].[TransferAssestHistories]
ADD CONSTRAINT [PK_TransferAssestHistories]
    PRIMARY KEY CLUSTERED ([AUTOID] ASC);
GO

-- Creating primary key on [UnitTypeID] in table 'UnitTypes'
ALTER TABLE [dbo].[UnitTypes]
ADD CONSTRAINT [PK_UnitTypes]
    PRIMARY KEY CLUSTERED ([UnitTypeID] ASC);
GO

-- Creating primary key on [AUTOID] in table 'UserAssets'
ALTER TABLE [dbo].[UserAssets]
ADD CONSTRAINT [PK_UserAssets]
    PRIMARY KEY CLUSTERED ([AUTOID] ASC);
GO

-- Creating primary key on [UserID], [PANo] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID], [PANo] ASC);
GO

-- Creating primary key on [AUTOID] in table 'VOIPs'
ALTER TABLE [dbo].[VOIPs]
ADD CONSTRAINT [PK_VOIPs]
    PRIMARY KEY CLUSTERED ([AUTOID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Category] in table 'UnitTypes'
ALTER TABLE [dbo].[UnitTypes]
ADD CONSTRAINT [FK_CategoryIDfk_UnitType]
    FOREIGN KEY ([Category])
    REFERENCES [dbo].[Categories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryIDfk_UnitType'
CREATE INDEX [IX_FK_CategoryIDfk_UnitType]
ON [dbo].[UnitTypes]
    ([Category]);
GO

-- Creating foreign key on [Category] in table 'UserAssets'
ALTER TABLE [dbo].[UserAssets]
ADD CONSTRAINT [FK_CategoryIDfk_UserAssest]
    FOREIGN KEY ([Category])
    REFERENCES [dbo].[Categories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryIDfk_UserAssest'
CREATE INDEX [IX_FK_CategoryIDfk_UserAssest]
ON [dbo].[UserAssets]
    ([Category]);
GO

-- Creating foreign key on [Company] in table 'Computers'
ALTER TABLE [dbo].[Computers]
ADD CONSTRAINT [FK_Companyfk_Computers]
    FOREIGN KEY ([Company])
    REFERENCES [dbo].[Companies]
        ([CompanyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Companyfk_Computers'
CREATE INDEX [IX_FK_Companyfk_Computers]
ON [dbo].[Computers]
    ([Company]);
GO

-- Creating foreign key on [Company] in table 'PhoneDongles'
ALTER TABLE [dbo].[PhoneDongles]
ADD CONSTRAINT [FK_Companyfk_Phones]
    FOREIGN KEY ([Company])
    REFERENCES [dbo].[Companies]
        ([CompanyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Companyfk_Phones'
CREATE INDEX [IX_FK_Companyfk_Phones]
ON [dbo].[PhoneDongles]
    ([Company]);
GO

-- Creating foreign key on [Company] in table 'VOIPs'
ALTER TABLE [dbo].[VOIPs]
ADD CONSTRAINT [FK_Companyfk_VOIP]
    FOREIGN KEY ([Company])
    REFERENCES [dbo].[Companies]
        ([CompanyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Companyfk_VOIP'
CREATE INDEX [IX_FK_Companyfk_VOIP]
ON [dbo].[VOIPs]
    ([Company]);
GO

-- Creating foreign key on [Company] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_CompanyIDfk_Users]
    FOREIGN KEY ([Company])
    REFERENCES [dbo].[Companies]
        ([CompanyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyIDfk_Users'
CREATE INDEX [IX_FK_CompanyIDfk_Users]
ON [dbo].[Users]
    ([Company]);
GO

-- Creating foreign key on [ModelType] in table 'Computers'
ALTER TABLE [dbo].[Computers]
ADD CONSTRAINT [FK_ModelTypefk_Computers]
    FOREIGN KEY ([ModelType])
    REFERENCES [dbo].[ModelTypes]
        ([ModelID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModelTypefk_Computers'
CREATE INDEX [IX_FK_ModelTypefk_Computers]
ON [dbo].[Computers]
    ([ModelType]);
GO

-- Creating foreign key on [OfficeVersion] in table 'Computers'
ALTER TABLE [dbo].[Computers]
ADD CONSTRAINT [FK_OfficeVersionfk_Computers]
    FOREIGN KEY ([OfficeVersion])
    REFERENCES [dbo].[Softwares]
        ([SoftwareID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OfficeVersionfk_Computers'
CREATE INDEX [IX_FK_OfficeVersionfk_Computers]
ON [dbo].[Computers]
    ([OfficeVersion]);
GO

-- Creating foreign key on [OS] in table 'Computers'
ALTER TABLE [dbo].[Computers]
ADD CONSTRAINT [FK_OSfk_Computers]
    FOREIGN KEY ([OS])
    REFERENCES [dbo].[Softwares]
        ([SoftwareID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OSfk_Computers'
CREATE INDEX [IX_FK_OSfk_Computers]
ON [dbo].[Computers]
    ([OS]);
GO

-- Creating foreign key on [UnitType] in table 'Computers'
ALTER TABLE [dbo].[Computers]
ADD CONSTRAINT [FK_UnitTypefk_Computers]
    FOREIGN KEY ([UnitType])
    REFERENCES [dbo].[UnitTypes]
        ([UnitTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnitTypefk_Computers'
CREATE INDEX [IX_FK_UnitTypefk_Computers]
ON [dbo].[Computers]
    ([UnitType]);
GO

-- Creating foreign key on [Market] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Marketfk_Users]
    FOREIGN KEY ([Market])
    REFERENCES [dbo].[Markets]
        ([MarketID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Marketfk_Users'
CREATE INDEX [IX_FK_Marketfk_Users]
ON [dbo].[Users]
    ([Market]);
GO

-- Creating foreign key on [UnitType] in table 'ModelTypes'
ALTER TABLE [dbo].[ModelTypes]
ADD CONSTRAINT [fk_UnitTypeID_Models]
    FOREIGN KEY ([UnitType])
    REFERENCES [dbo].[UnitTypes]
        ([UnitTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_UnitTypeID_Models'
CREATE INDEX [IX_fk_UnitTypeID_Models]
ON [dbo].[ModelTypes]
    ([UnitType]);
GO

-- Creating foreign key on [ModelType] in table 'PhoneDongles'
ALTER TABLE [dbo].[PhoneDongles]
ADD CONSTRAINT [FK_ModelTypefk_Phone]
    FOREIGN KEY ([ModelType])
    REFERENCES [dbo].[ModelTypes]
        ([ModelID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModelTypefk_Phone'
CREATE INDEX [IX_FK_ModelTypefk_Phone]
ON [dbo].[PhoneDongles]
    ([ModelType]);
GO

-- Creating foreign key on [ModelType] in table 'VOIPs'
ALTER TABLE [dbo].[VOIPs]
ADD CONSTRAINT [FK_ModelTypefk_VOIP]
    FOREIGN KEY ([ModelType])
    REFERENCES [dbo].[ModelTypes]
        ([ModelID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModelTypefk_VOIP'
CREATE INDEX [IX_FK_ModelTypefk_VOIP]
ON [dbo].[VOIPs]
    ([ModelType]);
GO

-- Creating foreign key on [Provider] in table 'PhoneDongles'
ALTER TABLE [dbo].[PhoneDongles]
ADD CONSTRAINT [FK_Providerfk_Phones]
    FOREIGN KEY ([Provider])
    REFERENCES [dbo].[Providers]
        ([AUTOID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Providerfk_Phones'
CREATE INDEX [IX_FK_Providerfk_Phones]
ON [dbo].[PhoneDongles]
    ([Provider]);
GO

-- Creating foreign key on [UnitType] in table 'PhoneDongles'
ALTER TABLE [dbo].[PhoneDongles]
ADD CONSTRAINT [FK_UnitTypefk_Phone]
    FOREIGN KEY ([UnitType])
    REFERENCES [dbo].[UnitTypes]
        ([UnitTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnitTypefk_Phone'
CREATE INDEX [IX_FK_UnitTypefk_Phone]
ON [dbo].[PhoneDongles]
    ([UnitType]);
GO

-- Creating foreign key on [UnitType] in table 'VOIPs'
ALTER TABLE [dbo].[VOIPs]
ADD CONSTRAINT [FK_UnitTypefk_VOIP]
    FOREIGN KEY ([UnitType])
    REFERENCES [dbo].[UnitTypes]
        ([UnitTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnitTypefk_VOIP'
CREATE INDEX [IX_FK_UnitTypefk_VOIP]
ON [dbo].[VOIPs]
    ([UnitType]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------