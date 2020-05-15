CREATE TABLE [dbo].[MetaTag]
(
	[MetaTagKey] INT IDENTITY(1,11) NOT NULL PRIMARY KEY,
	[MetaTagGuid] UNIQUEIDENTIFIER NOT NULL,
	[Key] NVARCHAR(300) NOT NULL,
	[Description] NVARCHAR(3000) NOT NULL,
	[Type] NVARCHAR(200) NULL,
	[CreatedAt] DATE NOT NULL DEFAULT(getdate()), 
    [CreatedBy] INT NOT NULL, 
    [UpdatedAt] DATE NOT NULL DEFAULT(getdate()), 
    [UpdatedBy] INT NOT NULL, 
    CONSTRAINT [FK_MetaTagCreatedBy] FOREIGN KEY (CreatedBy) REFERENCES [User]([UserKey]),
    CONSTRAINT [FK_MetaTagUpdatedBy] FOREIGN KEY (UpdatedBy) REFERENCES [User]([UserKey])
)
