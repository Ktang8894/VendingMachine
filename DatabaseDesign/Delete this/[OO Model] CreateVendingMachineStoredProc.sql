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

	IF OBJECT_ID('VendingMachine.ItemQueue', 'U') IS NOT NULL
		DROP TABLE VendingMachine.ItemQueue;

	IF OBJECT_ID('VendingMachine.Item', 'U') IS NOT NULL
		DROP TABLE VendingMachine.Item;

	IF OBJECT_ID('VendingMachine.Flavor', 'U') IS NOT NULL
		DROP TABLE VendingMachine.Flavor;

	IF OBJECT_ID('VendingMachine.WrapperColor', 'U') IS NOT NULL
		DROP TABLE VendingMachine.WrapperColor;

	CREATE TABLE VendingMachine.Flavor (
		FlavorId int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		Flavor varchar(20) UNIQUE NOT NULL
	);

	CREATE TABLE VendingMachine.WrapperColor (
		WrapperColorId int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		WrapperColor varchar(20) UNIQUE NOT NULL
	);

	CREATE TABLE VendingMachine.Item (
		ItemId int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		Name varchar(20) UNIQUE NOT NULL,
		FlavorId int NOT NULL FOREIGN KEY REFERENCES VendingMachine.Flavor(FlavorId),
		WrapperColorId int NOT NULL FOREIGN KEY REFERENCES VendingMachine.WrapperColor(WrapperColorId),
	);

	CREATE TABLE VendingMachine.ItemQueue (
		ItemId int UNIQUE NOT NULL FOREIGN KEY REFERENCES VendingMachine.Item(itemId),
		Price decimal(4, 2),
		StockCount int NOT NULL,
		TrashCount int NOT NULL
	);
END
GO