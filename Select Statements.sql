--Sour Items
SELECT Name
FROM VendingMachine.Item
WHERE FlavorId = 1

--Most common Wrapper Color (what if it's tied?)
SELECT Name
FROM VendingMachine.Item
WHERE TrashCount = (SELECT MAX(TrashCount) FROM VendingMachine.Item)

--Amount of candies on each shelf
SELECT F.Flavor, SUM(I.StockCount) AS FlavorCount
FROM VendingMachine.Flavor F
INNER JOIN VendingMachine.Item I
ON F.FlavorId = I.FlavorId
GROUP BY Flavor

SELECT *
FROM VendingMachine.Item

SELECT *
FROM VendingMachine.WrapperColor

SELECT *
FROM VendingMachine.Flavor

