CREATE VIEW [dbo].[udvUserCommunication]
	AS 
	SELECT 
		UL.UserId,
		UL.FirstName,
		UL.Password,
		UL.UserName
	FROM 
		udvUserLogin AS UL WITH(NOLOCK)
	INNER JOIN 
		tblUserCommunication AS UC WITH(NOLOCK)
	ON
		UL.UserId=UC.UserId
	GROUP BY 
		UL.UserId,
		UL.FirstName,
		UL.Password,
		UL.UserName

