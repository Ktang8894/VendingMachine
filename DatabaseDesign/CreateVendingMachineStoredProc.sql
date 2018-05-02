SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		KTang
-- Create date: 4/20/2018
-- Description:	Creates the VendingMachine schema + tables
-- =============================================
CREATE PROCEDURE VendingMachine.CreateVendingMachine 
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT * FROM sys.Schemas WHERE name = 'VendingMachine')
	BEGIN
		EXEC('CREATE SCHEMA VendingMachine');
	END

	IF OBJECT_ID('VendingMachine.Item', 'U') IS NOT NULL
		DROP TABLE VendingMachine.Item;

	CREATE TABLE VendingMachine.Item (
		ItemId int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		Name varchar(20) UNIQUE NOT NULL,
		Flavor varchar(20) NOT NULL,
		WrapperColor varchar(20) NOT NULL,
		Price decimal(4, 2) NOT NULL,
		StockCount int NOT NULL,
		TrashCount int NOT NULL
	);
END
GO