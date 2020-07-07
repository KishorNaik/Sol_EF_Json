﻿SELECT 
(
		SELECT 
		 U.UserId As 'UserId',
		 U.FirstName As 'FirstName',
		 U.LastName As 'LastName',
	     UL.UserName as 'UserLogin.UserName',
		 UL.Password as 'UserLogin.Password'
	FROM 
		tblUsers AS U
	INNER JOIN
		tblUserLogin AS UL
	ON
		U.UserId=UL.UserId
	FOR JSON PATH
) AS UserJson

SELECT 
	U.UserId,
	U.FirstName,
	U.LastName,
	JSON_QUERY(
		(
			SELECT
				TOP 1
				UL.UserName,
				UL.Password
			FROM 
				tblUserLogin AS UL WITH(NOLOCK)
			WHERE
				UL.UserId=U.UserId
			FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
		)

	) AS 'UserLogin'
FROM 
	tblUsers AS U WITH(NOLOCK)
FOR JSON PATH