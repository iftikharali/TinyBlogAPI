﻿CREATE TABLE [dbo].[User]
(
	[UserKey] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [UserGuid] UNIQUEIDENTIFIER NOT NULL, 
    [UserID] NVARCHAR(100) NOT NULL,
    [Name] NVARCHAR(100) NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(300) NOT NULL, 
    [Phone] NVARCHAR(50) NULL, 
    [Website] NVARCHAR(300) NULL, 
    [About] NVARCHAR(MAX) NULL, 
    [ImageUrl] NVARCHAR(MAX) NULL, 
    [ProfileUrl] NVARCHAR(MAX) NULL,
    [IsActive] TINYINT NOT NULL DEFAULT(0), 
    [Vote] INT NOT NULL DEFAULT(0), 
    [DateOfJoining] DATE NOT NULL DEFAULT(getdate()), 
    [LastActive] DATE NULL, 
    [BlogCount] INT NOT NULL DEFAULT(0),
    [PostCount] INT NOT NULL DEFAULT(0),
    [CreatedAt] DATE NOT NULL DEFAULT(getdate()), 
    [CreatedBy] INT NULL, 
    [UpdatedAt] DATE NULL, 
    [UpdatedBy] INT NULL
)
