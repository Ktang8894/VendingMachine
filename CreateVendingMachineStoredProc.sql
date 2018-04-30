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

	IF OBJECT_ID('VendingMachine.ItemQueues', 'U') IS NOT NULL
		DROP TABLE VendingMachine.ItemQueues;

	IF OBJECT_ID('VendingMachine.Items', 'U') IS NOT NULL
		DROP TABLE VendingMachine.Items;

	IF OBJECT_ID('VendingMachine.Flavors', 'U') IS NOT NULL
		DROP TABLE VendingMachine.Flavors;

	IF OBJECT_ID('VendingMachine.Colors', 'U') IS NOT NULL
		DROP TABLE VendingMachine.Colors;

	CREATE TABLE VendingMachine.Flavors (
		FlavorId int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		Flavor varchar(20) UNIQUE NOT NULL
	);

	CREATE TABLE VendingMachine.Colors (
		ColorId int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		Color varchar(20) UNIQUE NOT NULL
	);

	CREATE TABLE VendingMachine.Items (
		ItemId int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		Name varchar(20) NOT NULL,
		FlavorId int NOT NULL FOREIGN KEY REFERENCES VendingMachine.Flavors(FlavorId),
		WrapperColor int NOT NULL FOREIGN KEY REFERENCES VendingMachine.Colors(ColorId),
	);

	CREATE TABLE VendingMachine.ItemQueues (
		ItemId int UNIQUE NOT NULL FOREIGN KEY REFERENCES VendingMachine.Items(itemId),
		Price decimal(4, 2),
		StockCount int NOT NULL,
		TrashCount int NOT NULL
	);
END
GO