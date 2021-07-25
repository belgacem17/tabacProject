/*
Script de déploiement pour TabacDB

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "TabacDB"
:setvar DefaultFilePrefix "TabacDB"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'L''opération de refactorisation de changement de nom avec la clé 498ea03b-c94c-46d0-b521-3039094d65ee est ignorée, l''élément [dbo].[Response].[Id] (SqlSimpleColumn) ne sera pas renommé en ResponseId';


GO
PRINT N'L''opération de refactorisation de changement de nom avec la clé 5d5b212e-7a24-49ee-b880-6769915b1a35 est ignorée, l''élément [dbo].[Commantaire].[Id] (SqlSimpleColumn) ne sera pas renommé en CommantaireId';


GO
PRINT N'L''opération de refactorisation de changement de nom avec la clé ddc773f1-b61a-487b-a306-7c704f4d0832 est ignorée, l''élément [dbo].[News].[Id] (SqlSimpleColumn) ne sera pas renommé en NewsId';


GO
PRINT N'Modification de Table [dbo].[Question]...';


GO
ALTER TABLE [dbo].[Question]
    ADD [UserId] INT NULL;


GO
PRINT N'Création de Table [dbo].[Commantaire]...';


GO
CREATE TABLE [dbo].[Commantaire] (
    [CommantaireId]   INT            IDENTITY (1, 1) NOT NULL,
    [CommantaireText] NVARCHAR (MAX) NOT NULL,
    [UserId]          INT            NULL,
    [NewsId]          INT            NULL,
    PRIMARY KEY CLUSTERED ([CommantaireId] ASC)
);


GO
PRINT N'Création de Table [dbo].[News]...';


GO
CREATE TABLE [dbo].[News] (
    [NewsId]   INT            IDENTITY (1, 1) NOT NULL,
    [NewsText] NVARCHAR (MAX) NOT NULL,
    [UserId]   INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([NewsId] ASC)
);


GO
PRINT N'Création de Table [dbo].[Response]...';


GO
CREATE TABLE [dbo].[Response] (
    [ResponseId]   INT            IDENTITY (1, 1) NOT NULL,
    [ResponseText] NVARCHAR (MAX) NOT NULL,
    [UserId]       INT            NULL,
    [QuestionId]   INT            NULL,
    PRIMARY KEY CLUSTERED ([ResponseId] ASC)
);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Commantaire_Users]...';


GO
ALTER TABLE [dbo].[Commantaire] WITH NOCHECK
    ADD CONSTRAINT [FK_Commantaire_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE;


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Commantaire_News]...';


GO
ALTER TABLE [dbo].[Commantaire] WITH NOCHECK
    ADD CONSTRAINT [FK_Commantaire_News] FOREIGN KEY ([NewsId]) REFERENCES [dbo].[News] ([NewsId]) ON DELETE CASCADE;


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Response_Users]...';


GO
ALTER TABLE [dbo].[Response] WITH NOCHECK
    ADD CONSTRAINT [FK_Response_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE;


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Question_Response]...';


GO
ALTER TABLE [dbo].[Response] WITH NOCHECK
    ADD CONSTRAINT [FK_Question_Response] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([QuestionId]) ON DELETE CASCADE;


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Question_Users]...';


GO
ALTER TABLE [dbo].[Question] WITH NOCHECK
    ADD CONSTRAINT [FK_Question_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE;


GO
-- Étape de refactorisation pour mettre à jour le serveur cible avec des journaux de transactions déployés
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '498ea03b-c94c-46d0-b521-3039094d65ee')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('498ea03b-c94c-46d0-b521-3039094d65ee')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5d5b212e-7a24-49ee-b880-6769915b1a35')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5d5b212e-7a24-49ee-b880-6769915b1a35')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'ddc773f1-b61a-487b-a306-7c704f4d0832')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('ddc773f1-b61a-487b-a306-7c704f4d0832')

GO

GO
PRINT N'Vérification de données existantes par rapport aux nouvelles contraintes';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Commantaire] WITH CHECK CHECK CONSTRAINT [FK_Commantaire_Users];

ALTER TABLE [dbo].[Commantaire] WITH CHECK CHECK CONSTRAINT [FK_Commantaire_News];

ALTER TABLE [dbo].[Response] WITH CHECK CHECK CONSTRAINT [FK_Response_Users];

ALTER TABLE [dbo].[Response] WITH CHECK CHECK CONSTRAINT [FK_Question_Response];

ALTER TABLE [dbo].[Question] WITH CHECK CHECK CONSTRAINT [FK_Question_Users];


GO
PRINT N'Mise à jour terminée.';


GO
