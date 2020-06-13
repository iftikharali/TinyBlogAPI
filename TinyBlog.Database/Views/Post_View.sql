CREATE VIEW [dbo].[Post_View]
	AS 
SELECT P.[PostKey]
      ,P.[PostGuid]
      ,P.[Title]
      ,P.[SubTitle]
      ,P.[BrowserTitle]
      ,P.[AuthorKey]
      ,P.[Url]
      ,P.[SortUrl]
      ,P.[MainContentImageUrl]
      ,P.[MainContentImageSubtitle]
      ,P.[Content]
      ,P.[IsPublished]
      ,P.[IsActive]
      ,P.[IsDeleted]
      ,P.[BlogKey]
      ,P.[Views]
      ,ISNULL(V.[Votes],0) as Votes
      ,P.[Previous]
      ,P.[Next]
      ,P.[CategoryKey]

      ,U.UserKey
      ,U.[UserGuid]
      ,U.[UserID]
      ,U.[Name]
      ,U.[About]
      ,U.[ImageUrl]
      ,U.[BlogCount]
      ,U.[PostCount]

      ,B.[BlogGuid]
      ,B.[Title] BlogTitle
      ,B.[MainContentImageUrl] BlogMainContentImageUrl
      ,B.[SubscriberCount]
      ,P.[CreatedAt]
      ,P.[CreatedBy]
      ,P.[UpdatedAt]
      ,P.[UpdatedBy]
  FROM [dbo].[Post] P
  JOIN [dbo].[User_View] U on P.CreatedBy = U.UserKey
  JOIN [dbo].[Blog_View] B on P.BlogKey = B.BlogKey
  LEFT JOIN 
  (SELECT Count([Count]) Votes, MAX(EntityKey) EntityKey FROM [dbo].[Counter] V WHERE EntityType='Post' and CounterType='Vote' GROUP BY EntityKey) V on P.PostKey = V.EntityKey
