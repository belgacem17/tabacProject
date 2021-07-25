CREATE TABLE [dbo].[News]
(
	[NewsId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NewsText] NVARCHAR(MAX) NOT NULL, 
    [UserId] INT NOT NULL 
    CONSTRAINT [FK_News_Users] FOREIGN KEY (UserId) REFERENCES [Users]([UserId]) , 
)
