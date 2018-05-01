--Sour Items
SELECT Name
FROM VendingMachine.Item
WHERE Flavor = 'SOUR'

--Most common Wrapper Color (what if it's tied?)
SELECT Name
FROM VendingMachine.Item
WHERE TrashCount = (SELECT MAX(TrashCount) FROM VendingMachine.Item)

--Amount of candies on each shelf
SELECT Flavor, SUM(StockCount) AS FlavorCount
FROM VendingMachine.Item
GROUP BY Flavor