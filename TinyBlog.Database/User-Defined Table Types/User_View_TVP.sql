
/****** Object:  UserDefinedTableType [dbo].[User_View_TVP]    Script Date: 5/7/2020 3:45:54 PM ******/
CREATE TYPE [dbo].[User_View_TVP] AS TABLE(
	[UserKey] [int] NOT NULL,
	[UserGuid] [uniqueidentifier] NOT NULL,
	[UserID] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[DateOfBirth] [date] NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](300) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Website] [nvarchar](300) NULL,
	[About] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[ProfileUrl] [nvarchar](max) NULL,
	[IsActive] [tinyint] NOT NULL DEFAULT ((0)),
	[Vote] [int] NOT NULL DEFAULT ((0)),
	[DateOfJoining] [date] NOT NULL DEFAULT (getdate()),
	[LastActive] [date] NULL,
	[BlogCount] [int] NOT NULL DEFAULT ((0)),
	[PostCount] [int] NOT NULL DEFAULT ((0)),
	[CreatedAt] [date] NOT NULL DEFAULT (getdate()),
	[CreatedBy] [int] NULL,
	[UpdatedAt] [date] NULL,
	[UpdatedBy] [int] NULL,
	PRIMARY KEY CLUSTERED 
(
	[UserKey] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO