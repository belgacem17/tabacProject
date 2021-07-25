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
PRINT N'Création de Clé étrangère [dbo].[FK_News_Users]...';


GO
ALTER TABLE [dbo].[News] WITH NOCHECK
    ADD CONSTRAINT [FK_News_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Question_Users]...';


GO
ALTER TABLE [dbo].[Question] WITH NOCHECK
    ADD CONSTRAINT [FK_Question_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE;


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Reclamations_Commantaire]...';


GO
ALTER TABLE [dbo].[Reclamation] WITH NOCHECK
    ADD CONSTRAINT [FK_Reclamations_Commantaire] FOREIGN KEY ([CommantaireId]) REFERENCES [dbo].[Commantaire] ([CommantaireId]) ON DELETE CASCADE;


GO
PRINT N'Création de Clé étrangère [dbo].[FK_Reclamations_Users]...';


GO
ALTER TABLE [dbo].[Reclamation] WITH NOCHECK
    ADD CONSTRAINT [FK_Reclamations_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE;


GO
PRINT N'Vérification de données existantes par rapport aux nouvelles contraintes';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[News] WITH CHECK CHECK CONSTRAINT [FK_News_Users];

ALTER TABLE [dbo].[Question] WITH CHECK CHECK CONSTRAINT [FK_Question_Users];

ALTER TABLE [dbo].[Reclamation] WITH CHECK CHECK CONSTRAINT [FK_Reclamations_Commantaire];

ALTER TABLE [dbo].[Reclamation] WITH CHECK CHECK CONSTRAINT [FK_Reclamations_Users];


GO
PRINT N'Mise à jour terminée.';


GO
