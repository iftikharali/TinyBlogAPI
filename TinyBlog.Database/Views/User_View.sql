CREATE VIEW [dbo].[User_View]
	AS 
SELECT
     [UserKey]
    ,[UserGuid]
    ,[UserID]
    ,[Name]
    ,[DateOfBirth]
    ,[Email]
    ,[Password]
    ,[Phone]
    ,[Website]
    ,[About]
    ,[ImageUrl]
    ,[ProfileUrl]
    ,[IsActive]
    ,[Vote]
    ,[DateOfJoining]
    ,[LastActive]
    ,ISNULL(B.[BlogCount],0) BlogCount
    ,ISNULL(P.[PostCount],0) PostCount
    ,[CreatedAt]
    ,U.[CreatedBy]
    ,[UpdatedAt]
    ,[UpdatedBy]
  FROM 
    [dbo].[User] U
	LEFT JOIN 
  (Select count([BlogKey]) BlogCount, MAX(CreatedBy) CreatedBy from [dbo].[Blog] GROUP BY CreatedBy) B ON B.CreatedBy=U.UserKey
  LEFT JOIN
  (Select count([PostKey]) PostCount, MAX(CreatedBy) CreatedBy from [dbo].[Post] GROUP BY CreatedBy) P ON P.CreatedBy=U.UserKey
