CREATE VIEW [dbo].[Blog_View]
	AS 
	SELECT [BlogKey]
      ,[BlogGuid]
      ,[Title]
      ,[SubTitle]
      ,[MainContentImageUrl]
      ,[MainContentImageSubtitle]
      ,[BrowserTitle]
      ,[OwnerKey]
      ,U.[Name] OwnerName
      ,U.[UserGuid] OwnerGuid
      ,U.[About] OwnerAbout
      ,U.[ImageUrl]
      
	   [CategoryKey]
      ,[Url]
      ,[SortUrl]
      ,[Content]
      ,B.[IsActive]
      ,B.[IsDeleted]
      ,ISNULL(V.[SubscriberCount],0) SubscriberCount
      ,ISNULL(VR.[Recommend],0) Recommend
      ,B.[CreatedAt]
      ,B.[CreatedBy]
      ,B.[UpdatedAt]
      ,B.[UpdatedBy]
  FROM [dbo].[Blog] B
  JOIN [dbo].[User] U on B.OwnerKey = U.UserKey
  LEFT JOIN 
  (SELECT Count([Count]) SubscriberCount, MAX(EntityKey) EntityKey FROM [dbo].[Counter] V WHERE EntityType='Blog' and CounterType='Subscribe' GROUP BY EntityKey) V on B.BlogKey = V.EntityKey
  LEFT JOIN 
  (SELECT Count([Count]) Recommend, MAX(EntityKey) EntityKey FROM [dbo].[Counter] V WHERE EntityType='Blog' and CounterType='Recommend' GROUP BY EntityKey) VR on B.BlogKey = VR.EntityKey


