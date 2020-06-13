CREATE TABLE [dbo].[Comment]
(
	[CommentKey] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CommentGuid] UNIQUEIDENTIFIER NOT NULL,
	[ParentCommentKey] INT NULL,
	[Content] NVARCHAR(1000) NOT NULL,
	[PostKey] INT NOT NULL,
	[CreatedAt] DATETIME NOT NULL DEFAULT(getdate()), 
    [CreatedBy] INT NOT NULL, 
    [UpdatedAt] DATETIME NOT NULL DEFAULT(getdate()), 
    [UpdatedBy] INT NOT NULL, 
    CONSTRAINT [FK_CommentCreatedBy] FOREIGN KEY (CreatedBy) REFERENCES [User]([UserKey]),
    CONSTRAINT [FK_CommentUpdatedBy] FOREIGN KEY (UpdatedBy) REFERENCES [User]([UserKey])
)
