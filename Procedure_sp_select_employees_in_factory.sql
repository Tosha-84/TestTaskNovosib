CREATE PROCEDURE [dbo].[sp_select_employees_in_factory]
	@factoryId int
AS
	SELECT * FROM Employees WHERE FactoryId = @factoryId