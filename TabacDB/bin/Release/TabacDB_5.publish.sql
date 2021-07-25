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
PRINT N'L''opération de refactorisation de changement de nom avec la clé f528552e-5e67-4fb3-b623-d7894c6f166d est ignorée, l''élément [dbo].[Reclamation].[Id] (SqlSimpleColumn) ne sera pas renommé en ReclamationId';


GO
PRINT N'Création de Table [dbo].[Reclamation]...';


GO
CREATE TABLE [dbo].[Reclamation] (
    [ReclamationId]   INT             IDENTITY (1, 1) NOT NULL,
    [ReclamationText] VARBINARY (MAX) NOT NULL,
    [UserId]          INT             NOT NULL,
    [CommantaireId]   INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([ReclamationId] ASC)
);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Reclamations_Users]...';


GO
ALTER TABLE [dbo].[Reclamation] WITH NOCHECK
    ADD CONSTRAINT [FK_Reclamations_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Reclamations_Commantaire]...';


GO
ALTER TABLE [dbo].[Reclamation] WITH NOCHECK
    ADD CONSTRAINT [FK_Reclamations_Commantaire] FOREIGN KEY ([CommantaireId]) REFERENCES [dbo].[Commantaire] ([CommantaireId]);


GO
-- Étape de refactorisation pour mettre à jour le serveur cible avec des journaux de transactions déployés
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'f528552e-5e67-4fb3-b623-d7894c6f166d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('f528552e-5e67-4fb3-b623-d7894c6f166d')

GO

GO
PRINT N'Vérification de données existantes par rapport aux nouvelles contraintes';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Reclamation] WITH CHECK CHECK CONSTRAINT [FK_Reclamations_Users];

ALTER TABLE [dbo].[Reclamation] WITH CHECK CHECK CONSTRAINT [FK_Reclamations_Commantaire];


GO
PRINT N'Mise à jour terminée.';


GO
