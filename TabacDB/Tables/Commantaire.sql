CREATE TABLE [dbo].[Commantaire]
(
	[CommantaireId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CommantaireText] NVARCHAR(MAX) NOT NULL, 
    [UserId] INT NULL ,
    [NewsId] INT NULL,
    CONSTRAINT [FK_Commantaire_Users] FOREIGN KEY (UserId) REFERENCES [Users]([UserId]) ON DELETE CASCADE, 
    CONSTRAINT [FK_Commantaire_News] FOREIGN KEY (NewsId) REFERENCES [News]([NewsId]) ON DELETE CASCADE 
   

)
