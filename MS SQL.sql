CREATE TABLE [dbo].[Cities] (
    [City] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([City] ASC)
);

CREATE TABLE [dbo].[Factories] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Type] NVARCHAR (50) NULL,
    [City] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([City]) REFERENCES [dbo].[Cities] ([City])
);

CREATE PROCEDURE [dbo].[sp_insert_into_WorkDatas]
	@city NVARCHAR(50),
	@factoryId INT,
	@employeeId INT,
	@brigade BIT,
	@workingShift TINYINT
AS
	INSERT INTO WorkDatas (City,FactoryId,EmployeeId,Brigade,WorkingShift) VALUES (
	@city,
	@factoryId,
	@employeeId,
	@brigade,
	@workingShift
);
SELECT @@identity
