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
INNER JOIN VendingMachine.TrashCompartment tc
ON i.ItemId = tc.ItemId
WHERE tc.WrapperCount = (
	SELECT MAX(VendingMachine.TrashCompartment.WrapperCount) 
	FROM VendingMachine.TrashCompartment)
AND tc.WrapperCount > 0;

--Amount of candies on each shelf
SELECT Flavor, SUM(StockCount) AS FlavorCount
FROM VendingMachine.Item i
INNER JOIN VendingMachine.ItemQueue iq
ON i.ItemId = iq.ItemId
GROUP BY Flavor