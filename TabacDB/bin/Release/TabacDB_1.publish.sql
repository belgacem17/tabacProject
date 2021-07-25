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
-- Étape de refactorisation pour mettre à jour le serveur cible avec des journaux de transactions déployés
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '498ea03b-c94c-46d0-b521-3039094d65ee')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('498ea03b-c94c-46d0-b521-3039094d65ee')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5d5b212e-7a24-49ee-b880-6769915b1a35')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5d5b212e-7a24-49ee-b880-6769915b1a35')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'ddc773f1-b61a-487b-a306-7c704f4d0832')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('ddc773f1-b61a-487b-a306-7c704f4d0832')

GO

GO
PRINT N'Mise à jour terminée.';


GO
