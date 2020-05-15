CREATE TABLE [dbo].[Blog]
(
	[BlogKey] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[BlogGuid] UNIQUEIDENTIFIER NOT NULL,
	[Title] NVARCHAR(300) NOT NULL,
	[SubTitle] NVARCHAR(300) NOT NULL,
	[MainContentImageUrl]  NVARCHAR(MAX) NOT NULL,
	[MainContentImageSubtitle]  NVARCHAR(300) NOT NULL,
	[BrowserTitle]  NVARCHAR(300) NOT NULL,
	[OwnerKey] INT NOT NULL,
	[Url]  NVARCHAR(MAX) NOT NULL,
	[SortUrl]  NVARCHAR(300) NOT NULL,
	[Content]  NVARCHAR(MAX) NOT NULL,
	[IsActive] TINYINT NOT NULL DEFAULT(1),
	[IsDeleted] TINYINT NOT NULL DEFAULT(0),
	[Votes] INT NOT NULL,
	[CreatedAt] DATETIME NOT NULL DEFAULT(getdate()), 
    [CreatedBy] INT NOT NULL, 
    [UpdatedAt] DATETIME NOT NULL DEFAULT(getdate()), 
    [UpdatedBy] INT NOT NULL, 
    CONSTRAINT [FK_BlogCreatedBy] FOREIGN KEY (CreatedBy) REFERENCES [User]([UserKey]),
    CONSTRAINT [FK_BlogUpdatedBy] FOREIGN KEY (UpdatedBy) REFERENCES [User]([UserKey])
)
