
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/15/2016 15:28:55
-- Generated from EDMX file: H:\Documents\Visual Studio 2015\Projects\Clinic2.0\Clinic2.0\Models\KlinikModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Clinic];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MedicinePurchaseDetailMedicinePurchase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetailMedicinePurchases] DROP CONSTRAINT [FK_MedicinePurchaseDetailMedicinePurchase];
GO
IF OBJECT_ID(N'[dbo].[FK_MedicineMedicineStock]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MedicineStocks] DROP CONSTRAINT [FK_MedicineMedicineStock];
GO
IF OBJECT_ID(N'[dbo].[FK_MedicineDetailMedicinePurchase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetailMedicinePurchases] DROP CONSTRAINT [FK_MedicineDetailMedicinePurchase];
GO
IF OBJECT_ID(N'[dbo].[FK_PatientVisitDetailPatientVisit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetailPatientVisits] DROP CONSTRAINT [FK_PatientVisitDetailPatientVisit];
GO
IF OBJECT_ID(N'[dbo].[FK_PatientPatientVisit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatientVisits] DROP CONSTRAINT [FK_PatientPatientVisit];
GO
IF OBJECT_ID(N'[dbo].[FK_PatientDetailHospitalized]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetailHospitalizeds] DROP CONSTRAINT [FK_PatientDetailHospitalized];
GO
IF OBJECT_ID(N'[dbo].[FK_HospitalizedDetailHospitalized]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetailHospitalizeds] DROP CONSTRAINT [FK_HospitalizedDetailHospitalized];
GO
IF OBJECT_ID(N'[dbo].[FK_MsSectionMsPatient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MsPatients] DROP CONSTRAINT [FK_MsSectionMsPatient];
GO
IF OBJECT_ID(N'[dbo].[FK_MsDiagnoseDetailHospitalized]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetailHospitalizeds] DROP CONSTRAINT [FK_MsDiagnoseDetailHospitalized];
GO
IF OBJECT_ID(N'[dbo].[FK_MsDiagnosePatientVisit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatientVisits] DROP CONSTRAINT [FK_MsDiagnosePatientVisit];
GO
IF OBJECT_ID(N'[dbo].[FK_DetailPatientVisitMsMedicine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetailPatientVisits] DROP CONSTRAINT [FK_DetailPatientVisitMsMedicine];
GO
IF OBJECT_ID(N'[dbo].[FK_MsMedicineMsMedicineType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MsMedicines] DROP CONSTRAINT [FK_MsMedicineMsMedicineType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MsPatients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MsPatients];
GO
IF OBJECT_ID(N'[dbo].[PatientVisits]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatientVisits];
GO
IF OBJECT_ID(N'[dbo].[DetailPatientVisits]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetailPatientVisits];
GO
IF OBJECT_ID(N'[dbo].[MsMedicinePurchases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MsMedicinePurchases];
GO
IF OBJECT_ID(N'[dbo].[MsMedicines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MsMedicines];
GO
IF OBJECT_ID(N'[dbo].[MedicineStocks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MedicineStocks];
GO
IF OBJECT_ID(N'[dbo].[DetailMedicinePurchases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetailMedicinePurchases];
GO
IF OBJECT_ID(N'[dbo].[Admins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Admins];
GO
IF OBJECT_ID(N'[dbo].[DetailHospitalizeds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetailHospitalizeds];
GO
IF OBJECT_ID(N'[dbo].[MsHospitalizeds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MsHospitalizeds];
GO
IF OBJECT_ID(N'[dbo].[MsDiagnoses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MsDiagnoses];
GO
IF OBJECT_ID(N'[dbo].[MsSections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MsSections];
GO
IF OBJECT_ID(N'[dbo].[MsMedicineTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MsMedicineTypes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MsPatients'
CREATE TABLE [dbo].[MsPatients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BinusianId] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [BloodType] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [MsSection_Id] int  NOT NULL
);
GO

-- Creating table 'PatientVisits'
CREATE TABLE [dbo].[PatientVisits] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Anamnesis] nvarchar(max)  NOT NULL,
    [Implementation] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NULL,
    [VisitDate] datetime  NOT NULL,
    [Patient_Id] int  NOT NULL,
    [MsDiagnose_Id] int  NOT NULL
);
GO

-- Creating table 'DetailPatientVisits'
CREATE TABLE [dbo].[DetailPatientVisits] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Qty] int  NOT NULL,
    [PatientVisit_Id] int  NOT NULL,
    [MsMedicines_Id] int  NOT NULL
);
GO

-- Creating table 'MsMedicinePurchases'
CREATE TABLE [dbo].[MsMedicinePurchases] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Total] int  NOT NULL
);
GO

-- Creating table 'MsMedicines'
CREATE TABLE [dbo].[MsMedicines] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Qty] int  NOT NULL,
    [MsMedicineTypes_Id] int  NOT NULL
);
GO

-- Creating table 'MedicineStocks'
CREATE TABLE [dbo].[MedicineStocks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ExpDate] datetime  NOT NULL,
    [Medicine_Id] int  NOT NULL
);
GO

-- Creating table 'DetailMedicinePurchases'
CREATE TABLE [dbo].[DetailMedicinePurchases] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Price] nvarchar(max)  NOT NULL,
    [Qty] int  NOT NULL,
    [ExpDate] datetime  NOT NULL,
    [MedicinePurchase_Id] int  NOT NULL,
    [Medicine_Id] int  NOT NULL
);
GO

-- Creating table 'Admins'
CREATE TABLE [dbo].[Admins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Pass] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DetailHospitalizeds'
CREATE TABLE [dbo].[DetailHospitalizeds] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HospitalName] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [Patient_Id] int  NOT NULL,
    [Hospitalized_Id] int  NOT NULL,
    [MsDiagnose_Id] int  NOT NULL
);
GO

-- Creating table 'MsHospitalizeds'
CREATE TABLE [dbo].[MsHospitalizeds] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'MsDiagnoses'
CREATE TABLE [dbo].[MsDiagnoses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DiagnoseName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MsSections'
CREATE TABLE [dbo].[MsSections] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SectionName] nvarchar(max)  NOT NULL,
    [Abbr] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MsMedicineTypes'
CREATE TABLE [dbo].[MsMedicineTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'MsPatients'
ALTER TABLE [dbo].[MsPatients]
ADD CONSTRAINT [PK_MsPatients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PatientVisits'
ALTER TABLE [dbo].[PatientVisits]
ADD CONSTRAINT [PK_PatientVisits]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetailPatientVisits'
ALTER TABLE [dbo].[DetailPatientVisits]
ADD CONSTRAINT [PK_DetailPatientVisits]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MsMedicinePurchases'
ALTER TABLE [dbo].[MsMedicinePurchases]
ADD CONSTRAINT [PK_MsMedicinePurchases]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MsMedicines'
ALTER TABLE [dbo].[MsMedicines]
ADD CONSTRAINT [PK_MsMedicines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MedicineStocks'
ALTER TABLE [dbo].[MedicineStocks]
ADD CONSTRAINT [PK_MedicineStocks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetailMedicinePurchases'
ALTER TABLE [dbo].[DetailMedicinePurchases]
ADD CONSTRAINT [PK_DetailMedicinePurchases]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Admins'
ALTER TABLE [dbo].[Admins]
ADD CONSTRAINT [PK_Admins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetailHospitalizeds'
ALTER TABLE [dbo].[DetailHospitalizeds]
ADD CONSTRAINT [PK_DetailHospitalizeds]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MsHospitalizeds'
ALTER TABLE [dbo].[MsHospitalizeds]
ADD CONSTRAINT [PK_MsHospitalizeds]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MsDiagnoses'
ALTER TABLE [dbo].[MsDiagnoses]
ADD CONSTRAINT [PK_MsDiagnoses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MsSections'
ALTER TABLE [dbo].[MsSections]
ADD CONSTRAINT [PK_MsSections]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MsMedicineTypes'
ALTER TABLE [dbo].[MsMedicineTypes]
ADD CONSTRAINT [PK_MsMedicineTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MedicinePurchase_Id] in table 'DetailMedicinePurchases'
ALTER TABLE [dbo].[DetailMedicinePurchases]
ADD CONSTRAINT [FK_MedicinePurchaseDetailMedicinePurchase]
    FOREIGN KEY ([MedicinePurchase_Id])
    REFERENCES [dbo].[MsMedicinePurchases]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MedicinePurchaseDetailMedicinePurchase'
CREATE INDEX [IX_FK_MedicinePurchaseDetailMedicinePurchase]
ON [dbo].[DetailMedicinePurchases]
    ([MedicinePurchase_Id]);
GO

-- Creating foreign key on [Medicine_Id] in table 'MedicineStocks'
ALTER TABLE [dbo].[MedicineStocks]
ADD CONSTRAINT [FK_MedicineMedicineStock]
    FOREIGN KEY ([Medicine_Id])
    REFERENCES [dbo].[MsMedicines]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MedicineMedicineStock'
CREATE INDEX [IX_FK_MedicineMedicineStock]
ON [dbo].[MedicineStocks]
    ([Medicine_Id]);
GO

-- Creating foreign key on [Medicine_Id] in table 'DetailMedicinePurchases'
ALTER TABLE [dbo].[DetailMedicinePurchases]
ADD CONSTRAINT [FK_MedicineDetailMedicinePurchase]
    FOREIGN KEY ([Medicine_Id])
    REFERENCES [dbo].[MsMedicines]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MedicineDetailMedicinePurchase'
CREATE INDEX [IX_FK_MedicineDetailMedicinePurchase]
ON [dbo].[DetailMedicinePurchases]
    ([Medicine_Id]);
GO

-- Creating foreign key on [PatientVisit_Id] in table 'DetailPatientVisits'
ALTER TABLE [dbo].[DetailPatientVisits]
ADD CONSTRAINT [FK_PatientVisitDetailPatientVisit]
    FOREIGN KEY ([PatientVisit_Id])
    REFERENCES [dbo].[PatientVisits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientVisitDetailPatientVisit'
CREATE INDEX [IX_FK_PatientVisitDetailPatientVisit]
ON [dbo].[DetailPatientVisits]
    ([PatientVisit_Id]);
GO

-- Creating foreign key on [Patient_Id] in table 'PatientVisits'
ALTER TABLE [dbo].[PatientVisits]
ADD CONSTRAINT [FK_PatientPatientVisit]
    FOREIGN KEY ([Patient_Id])
    REFERENCES [dbo].[MsPatients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientPatientVisit'
CREATE INDEX [IX_FK_PatientPatientVisit]
ON [dbo].[PatientVisits]
    ([Patient_Id]);
GO

-- Creating foreign key on [Patient_Id] in table 'DetailHospitalizeds'
ALTER TABLE [dbo].[DetailHospitalizeds]
ADD CONSTRAINT [FK_PatientDetailHospitalized]
    FOREIGN KEY ([Patient_Id])
    REFERENCES [dbo].[MsPatients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientDetailHospitalized'
CREATE INDEX [IX_FK_PatientDetailHospitalized]
ON [dbo].[DetailHospitalizeds]
    ([Patient_Id]);
GO

-- Creating foreign key on [Hospitalized_Id] in table 'DetailHospitalizeds'
ALTER TABLE [dbo].[DetailHospitalizeds]
ADD CONSTRAINT [FK_HospitalizedDetailHospitalized]
    FOREIGN KEY ([Hospitalized_Id])
    REFERENCES [dbo].[MsHospitalizeds]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HospitalizedDetailHospitalized'
CREATE INDEX [IX_FK_HospitalizedDetailHospitalized]
ON [dbo].[DetailHospitalizeds]
    ([Hospitalized_Id]);
GO

-- Creating foreign key on [MsSection_Id] in table 'MsPatients'
ALTER TABLE [dbo].[MsPatients]
ADD CONSTRAINT [FK_MsSectionMsPatient]
    FOREIGN KEY ([MsSection_Id])
    REFERENCES [dbo].[MsSections]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MsSectionMsPatient'
CREATE INDEX [IX_FK_MsSectionMsPatient]
ON [dbo].[MsPatients]
    ([MsSection_Id]);
GO

-- Creating foreign key on [MsDiagnose_Id] in table 'DetailHospitalizeds'
ALTER TABLE [dbo].[DetailHospitalizeds]
ADD CONSTRAINT [FK_MsDiagnoseDetailHospitalized]
    FOREIGN KEY ([MsDiagnose_Id])
    REFERENCES [dbo].[MsDiagnoses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MsDiagnoseDetailHospitalized'
CREATE INDEX [IX_FK_MsDiagnoseDetailHospitalized]
ON [dbo].[DetailHospitalizeds]
    ([MsDiagnose_Id]);
GO

-- Creating foreign key on [MsDiagnose_Id] in table 'PatientVisits'
ALTER TABLE [dbo].[PatientVisits]
ADD CONSTRAINT [FK_MsDiagnosePatientVisit]
    FOREIGN KEY ([MsDiagnose_Id])
    REFERENCES [dbo].[MsDiagnoses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MsDiagnosePatientVisit'
CREATE INDEX [IX_FK_MsDiagnosePatientVisit]
ON [dbo].[PatientVisits]
    ([MsDiagnose_Id]);
GO

-- Creating foreign key on [MsMedicines_Id] in table 'DetailPatientVisits'
ALTER TABLE [dbo].[DetailPatientVisits]
ADD CONSTRAINT [FK_DetailPatientVisitMsMedicine]
    FOREIGN KEY ([MsMedicines_Id])
    REFERENCES [dbo].[MsMedicines]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetailPatientVisitMsMedicine'
CREATE INDEX [IX_FK_DetailPatientVisitMsMedicine]
ON [dbo].[DetailPatientVisits]
    ([MsMedicines_Id]);
GO

-- Creating foreign key on [MsMedicineTypes_Id] in table 'MsMedicines'
ALTER TABLE [dbo].[MsMedicines]
ADD CONSTRAINT [FK_MsMedicineMsMedicineType]
    FOREIGN KEY ([MsMedicineTypes_Id])
    REFERENCES [dbo].[MsMedicineTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MsMedicineMsMedicineType'
CREATE INDEX [IX_FK_MsMedicineMsMedicineType]
ON [dbo].[MsMedicines]
    ([MsMedicineTypes_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------