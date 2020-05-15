CREATE TABLE [dbo].[Vote]
(
	[VoteKey] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[VoteGuid] UNIQUEIDENTIFIER,
	[Type] NVARCHAR(100) NOT NULL,
	[Vote] int DEFAULT(1),
	[CreatedAt] DATETIME NOT NULL DEFAULT(getdate()), 
    [CreatedBy] INT NULL, 
    [UpdatedAt] DATETIME NOT NULL DEFAULT(getdate()), 
    [UpdatedBy] INT NULL, 
    CONSTRAINT [FK_Vote_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [User](UserKey), 
    CONSTRAINT [FK_Vote_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [User](UserKey)
)
