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