--Sour Items
SELECT Name
FROM VendingMachine.Item i
INNER JOIN VendingMachine.ItemQueue iq
ON i.ItemId = iq.ItemId
WHERE Flavor = 'SOUR'
AND StockCount > 0;

--Most common wrapper color in the Trash Compartment
SELECT WrapperColor
FROM VendingMachine.Item i
INNER JOIN VendingMachine.ItemQueue iq
ON i.ItemId = iq.ItemId
WHERE iq.TrashCount = (
	SELECT MAX(VendingMachine.ItemQueue.TrashCount) 
	FROM VendingMachine.ItemQueue)
AND iq.TrashCount > 0;

--Amount of candies on each shelf
SELECT Flavor, SUM(StockCount) AS FlavorCount
FROM VendingMachine.Item i
INNER JOIN VendingMachine.ItemQueue iq
ON i.ItemId = iq.ItemId
GROUP BY Flavor