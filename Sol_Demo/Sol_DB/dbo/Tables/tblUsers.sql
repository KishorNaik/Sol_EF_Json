CREATE TABLE [dbo].[tblUsers] (
    [UserId]    NUMERIC (18)  IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (100) NULL,
    [LastName]  VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

