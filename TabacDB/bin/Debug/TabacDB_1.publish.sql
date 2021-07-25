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
PRINT N'L''opération de refactorisation de changement de nom avec la clé 4d08a462-47db-4340-8175-3526efbe479c est ignorée, l''élément [dbo].[Question].[Id] (SqlSimpleColumn) ne sera pas renommé en QuestionId';


GO
PRINT N'Création de Table [dbo].[Question]...';


GO
CREATE TABLE [dbo].[Question] (
    [QuestionId]   INT            IDENTITY (1, 1) NOT NULL,
    [QuestionText] NVARCHAR (MAX) NOT NULL,
    [QuestionType] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([QuestionId] ASC)
);


GO
-- Étape de refactorisation pour mettre à jour le serveur cible avec des journaux de transactions déployés
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '4d08a462-47db-4340-8175-3526efbe479c')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('4d08a462-47db-4340-8175-3526efbe479c')

GO

GO
PRINT N'Mise à jour terminée.';


GO
