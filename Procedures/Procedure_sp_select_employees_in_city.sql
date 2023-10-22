CREATE PROCEDURE [dbo].[sp_select_employees_in_city]
	@city NVARCHAR(50)
AS
	SELECT * FROM Employees WHERE FactoryID IN
	(SELECT Id FROM Factories WHERE City = @city)