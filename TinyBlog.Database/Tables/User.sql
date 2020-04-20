CREATE TABLE [dbo].[User]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [UserID] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(100) NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(300) NOT NULL, 
    [Phone] NVARCHAR(50) NULL, 
    [Website] NVARCHAR(300) NULL, 
    [About] NVARCHAR(MAX) NULL, 
    [ImageUrl] NVARCHAR(MAX) NULL, 
    [IsActive] TINYINT NOT NULL DEFAULT(0), 
    [Vote] INT NOT NULL DEFAULT(0), 
    [DateOfJoining] DATE NOT NULL DEFAULT(getdate()), 
    [LastActive] DATE NULL, 
    [CreatedAt] DATE NULL, 
    [CreatedBy] INT NULL, 
    [UpdatedAt] DATE NULL, 
    [UpdatedBy] INT NULL
)
