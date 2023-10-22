CREATE PROCEDURE [dbo].[sp_select_factories_and_employees_in_city]
	@city NVARCHAR(50)
AS
	SELECT * FROM factories WHERE City = @city
	SELECT * FROM Employees WHERE FactoryID IN
(SELECT Id FROM Factories WHERE City = @city)