CREATE TABLE [dbo].[Tag]
(
	[TagKey] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TagGuid] UNIQUEIDENTIFIER NOT NULL,
	[Title] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(1000) NULL,	[CreatedAt] DATE NOT NULL DEFAULT(getdate()), 
    [CreatedBy] INT NOT NULL, 
    [UpdatedAt] DATE NOT NULL DEFAULT(getdate()), 
    [UpdatedBy] INT NOT NULL, 
    CONSTRAINT [FK_TagCreatedBy] FOREIGN KEY (CreatedBy) REFERENCES [User]([UserKey]),
    CONSTRAINT [FK_TagUpdatedBy] FOREIGN KEY (UpdatedBy) REFERENCES [User]([UserKey])
)
