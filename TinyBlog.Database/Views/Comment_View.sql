CREATE VIEW [dbo].[Comment_View]
	AS 
	SELECT C.[CommentKey]
      ,C.[CommentGuid]
      ,C.[ParentCommentKey]
      ,C.[Content]
      ,C.[PostKey]
      ,C.[CreatedAt]
      
      ,C.[CreatedBy]
      ,U.[Name] CreatorName
      ,U.[UserGuid] CreatorGuid
      ,U.[About] CreatorAbout
      ,U.[ImageUrl] CreatorImageUrl

      ,C.[UpdatedAt]
      ,C.[UpdatedBy]
  FROM [dbo].[Comment] C
  JOIN [dbo].[User_View] U ON C.CreatedBy = U.UserKey
