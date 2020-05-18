CREATE TABLE [dbo].[Counter]
(
	[CounterKey] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CounterGuid] UNIQUEIDENTIFIER,
	[EntityType] NVARCHAR(100) NOT NULL,
	[CounterType] NVARCHAR(100) NOT NULL,
	[EntityKey] int NOT NULL,
	[Count] int DEFAULT(1),
	[CreatedAt] DATETIME NOT NULL DEFAULT(getdate()), 
    [CreatedBy] INT NULL, 
    [UpdatedAt] DATETIME NOT NULL DEFAULT(getdate()), 
    [UpdatedBy] INT NULL, 
    CONSTRAINT [FK_Counter_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [User](UserKey), 
    CONSTRAINT [FK_Counter_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [User](UserKey)
)
