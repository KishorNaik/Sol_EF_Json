CREATE VIEW [dbo].[udvUserLogin]
	AS 
	SELECT 
		U.UserId,
		U.FirstName,
		U.LastName,
		UL.UserName,
		UL.Password
	FROM 
		tblUsers AS U WITH(NOLOCK)
	INNER JOIN 
		tblUserLogin AS UL WITH(NOLOCK)
	ON 
		U.UserId=UL.UserId
