USE [EMSDB]
GO

/****** Object: Table [dbo].[Employees] Script Date: 2/6/2023 9:53:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Employees];


GO
CREATE TABLE [dbo].[Employees] (
    [EmployeeId]  INT           NOT NULL,
    [FirstName]   VARCHAR (50)  NOT NULL,
    [LastName]    VARCHAR (50)  NOT NULL,
    [EmailId]     VARCHAR (100) NOT NULL,
    [CreatedDate] DATETIME      NOT NULL,
    [UpdatedDate] DATETIME      NOT NULL
);


