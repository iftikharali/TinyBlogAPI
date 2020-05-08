CREATE TABLE [dbo].[Comment]
(
	[CommentKey] INT NOT NULL PRIMARY KEY,
	[CommentGuid] UNIQUEIDENTIFIER NOT NULL,
	[ParentCommentKey] INT NULL,
	[Content] NVARCHAR(1000) NOT NULL,
	[PostKey] INT NOT NULL,
	[CreatedAt] DATE NOT NULL DEFAULT(getdate()), 
    [CreatedBy] INT NOT NULL, 
    [UpdatedAt] DATE NOT NULL DEFAULT(getdate()), 
    [UpdatedBy] INT NOT NULL, 
    CONSTRAINT [FK_CommentCreatedBy] FOREIGN KEY (CreatedBy) REFERENCES [User]([UserKey]),
    CONSTRAINT [FK_CommentUpdatedBy] FOREIGN KEY (UpdatedBy) REFERENCES [User]([UserKey])
)
