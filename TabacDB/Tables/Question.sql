CREATE TABLE [dbo].[Question]
(
	[QuestionId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [QuestionText] NVARCHAR(MAX) NOT NULL, 
    [QuestionType] INT NOT NULL,  
    [UserId] INT NULL,
     CONSTRAINT [FK_Question_Users] FOREIGN KEY (UserId) REFERENCES [Users]([UserId]) , 


)
