CREATE PROCEDURE [dbo].[uspGetUsers]

	@Command Varchar(MAX)=NULL

AS

	DECLARE @ErrorMessage Varchar(MAX)

	BEGIN 
		
		IF @Command='One-To-One'
			BEGIN

				BEGIN TRY 
					BEGIN TRANSACTION

						SELECT 
						(
								--SELECT 
								--	U.UserId,
								--	U.FirstName,
								--	U.LastName,
								--	JSON_QUERY(
								--		(
								--			SELECT
								--				TOP 1
								--				UL.UserName,
								--				UL.Password
								--			FROM 
								--				tblUserLogin AS UL WITH(NOLOCK)
								--			WHERE
								--				UL.UserId=U.UserId
								--			FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
								--		)

								--	) AS 'UserLogin'
								--FROM 
								--	tblUsers AS U WITH(NOLOCK)
								--FOR JSON PATH

								SELECT 
									UL.UserId,
									UL.FirstName,
									UL.LastName,
									UL.UserName AS 'UserLogin.UserName', -- Model Navigation Property Name should be Match
									UL.Password As 'UserLogin.Password' -- Model Navigation Property Name should be Match
								FROM 
									udvUserLogin As UL WITH(NOLOCK)
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

		ELSE IF @Command='One-To-Many'
			BEGIN

				BEGIN TRY 
					BEGIN TRANSACTION

					SELECT
					(
						SELECT 
									--One to One
									UL.UserId,
									UL.FirstName,
									UL.LastName,
									UL.UserName AS 'UserLogin.UserName', -- Model Navigation Property Name should be Match
									UL.Password As 'UserLogin.Password', -- Model Navigation Property Name should be Match
									-- One to Many
									JSON_QUERY(
										
										(
											SELECT 
												UC.UserCommunicationId,
												UC.MobileNo
											FROM 
												tblUserCommunication AS UC WITH(NOLOCK)
											WHERE
												UC.UserId=UL.UserId
											FOR JSON PATH
										)
										
									) as 'UserCommunicationList' -- Model Navigation Property Name should be Match
								FROM 
									udvUserLogin As UL WITH(NOLOCK)
								FOR JSON PATH
						) As UserJson

					COMMIT TRANSACTION
				END TRY

				BEGIN CATCH
					SET @ErrorMessage=ERROR_MESSAGE();
					RAISERROR(@ErrorMessage,16,1)
					ROLLBACK TRANSACTION
				END CATCH

			END
		

	END
	
GO