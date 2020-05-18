﻿CREATE TABLE [dbo].[Category]
(
	[CategoryKey] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CategoryGuid] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(300) NOT NULL,
	[Description] NVARCHAR(1000) NULL,
	[PostCount] INT NOT NULL DEFAULT(0),
	[Link] NVARCHAR(MAX) null,
	[CreatedAt] DATETIME NOT NULL DEFAULT(getdate()), 
    [CreatedBy] INT NOT NULL, 
    [UpdatedAt] DATETIME NOT NULL DEFAULT(getdate()), 
    [UpdatedBy] INT NOT NULL, 
    CONSTRAINT [FK_CategoryCreatedBy] FOREIGN KEY (CreatedBy) REFERENCES [User]([UserKey]),
    CONSTRAINT [FK_CategoryUpdatedBy] FOREIGN KEY (UpdatedBy) REFERENCES [User]([UserKey])


)
