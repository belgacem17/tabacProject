CREATE TABLE [dbo].[Reclamation]
(
	[ReclamationId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ReclamationText] VARBINARY(MAX) NOT NULL, 
    [UserId] INT NOT NULL, 
    [CommantaireId] INT NOT NULL ,
    CONSTRAINT [FK_Reclamations_Users] FOREIGN KEY (UserId) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_Reclamations_Commantaire] FOREIGN KEY (CommantaireId) REFERENCES [Commantaire] (CommantaireId) ON DELETE CASCADE , 
)
