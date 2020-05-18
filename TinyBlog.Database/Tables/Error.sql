CREATE TABLE [dbo].[Error]
(
	[ErrorKey] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ErrorGuid] UNIQUEIDENTIFIER NOT NULL,
	[Code] INT NOT NULL,
	[Message] NVARCHAR(600) NOT NULL,
	[severity] INT NOT NULL DEFAULT(0),
	[Type] INT NOT NULL DEFAULT(0),
	[CreatedAt] DATETIME NOT NULL DEFAULT(getdate()), 
    [CreatedBy] INT NOT NULL, 
    [UpdatedAt] DATETIME NOT NULL DEFAULT(getdate()), 
    [UpdatedBy] INT NOT NULL, 
    CONSTRAINT [FK_ErrorCreatedBy] FOREIGN KEY (CreatedBy) REFERENCES [User]([UserKey]),
    CONSTRAINT [FK_ErrorUpdatedBy] FOREIGN KEY (UpdatedBy) REFERENCES [User]([UserKey])
)
