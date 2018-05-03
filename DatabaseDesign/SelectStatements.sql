--Sour Items
SELECT *
FROM VendingMachine.Item
WHERE Flavor = 'SOUR'
AND StockCount > 0;

--Most common Wrapper Color in the Trash Compartment
SELECT WrapperColor
FROM VendingMachine.Item
WHERE TrashCount = (SELECT MAX(TrashCount) FROM VendingMachine.Item)

--Amount of candies on each shelf
SELECT Flavor, SUM(StockCount) AS FlavorCount
FROM VendingMachine.Item
GROUP BY Flavor