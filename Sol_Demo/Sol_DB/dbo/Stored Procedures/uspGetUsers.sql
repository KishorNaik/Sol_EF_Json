CREATE PROCEDURE [dbo].[uspGetUsers]
AS

	DECLARE @ErrorMessage Varchar(MAX)

	BEGIN 
		
		BEGIN TRY 
			BEGIN TRANSACTION

				SELECT 
				(
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
				) AS UserJson

			COMMIT TRANSACTION
		END TRY

		BEGIN CATCH
			SET @ErrorMessage=ERROR_MESSAGE();
			RAISERROR(@ErrorMessage,16,1)
			ROLLBACK TRANSACTION
		END CATCH

	END
	
GO