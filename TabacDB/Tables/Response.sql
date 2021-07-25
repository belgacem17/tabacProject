CREATE TABLE [dbo].[Response]
(
	[ResponseId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ResponseText] NVARCHAR(MAX) NOT NULL, 
    [UserId] INT NULL, 
    [QuestionId] INT NULL, 
    CONSTRAINT [FK_Response_Users] FOREIGN KEY (UserId) REFERENCES [Users]([UserId]) ON DELETE CASCADE,
   CONSTRAINT [FK_Question_Response] FOREIGN KEY (QuestionId) REFERENCES [Question]([QuestionId]) ON DELETE CASCADE

)
