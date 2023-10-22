CREATE PROCEDURE [dbo].[sp_select_factories_in_city]
	@city NVARCHAR(50)
AS
	SELECT * FROM factories WHERE City = @city