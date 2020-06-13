CREATE TABLE [dbo].[RecommendedPost]
(
	[RecommendedPostKey] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[RecommendedPostGuid] UNIQUEIDENTIFIER NOT NULL,
	[FromPostKey] INT NOT NULL,
	[ToPostKey] INT NOT NULL,
	[Count] INT NOT NULL DEFAULT(1),
	[UserKey] INT NULL
)
