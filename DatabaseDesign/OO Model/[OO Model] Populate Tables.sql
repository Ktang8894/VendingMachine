USE VendingMachineDB
GO

INSERT INTO VendingMachine.WrapperColors(WrapperColor)
VALUES ('RED'), ('GREEN'), ('BLUE'), ('YELLOW'), ('PURPLE')

INSERT INTO VendingMachine.Flavors(Flavor)
VALUES ('SOUR'), ('SWEET'), ('SPICY'), ('SALTY')

INSERT INTO VendingMachine.Items(Name, FlavorId, WrapperColorId)
VALUES ('Sour Apple', (SELECT FlavorId FROM VendingMachine.Flavors WHERE Flavor = 'Sour'), (SELECT WrapperColorId FROM VendingMachine.WrapperColors WHERE WrapperColor = 'Green')), 
('RedHot', (SELECT FlavorId FROM VendingMachine.Flavors WHERE Flavor = 'Spicy'), (SELECT WrapperColorId FROM VendingMachine.WrapperColors WHERE WrapperColor = 'Red')), 
('Purple', (SELECT FlavorId FROM VendingMachine.Flavors WHERE Flavor = 'Sweet'), (SELECT WrapperColorId FROM VendingMachine.WrapperColors WHERE WrapperColor = 'Purple')), 
('Literal Salt', (SELECT FlavorId FROM VendingMachine.Flavors WHERE Flavor = 'Salty'), (SELECT WrapperColorId FROM VendingMachine.WrapperColors WHERE WrapperColor = 'Blue')), 
('Lemons', (SELECT FlavorId FROM VendingMachine.Flavors WHERE Flavor = 'Sour'), (SELECT WrapperColorId FROM VendingMachine.WrapperColors WHERE WrapperColor = 'Yellow'))

INSERT INTO VendingMachine.ItemQueues(ItemId, Price, StockCount, TrashCount)
VALUES ((SELECT ItemId FROM VendingMachine.Items WHERE ItemId = 1), 1.5, 10, 0),
((SELECT ItemId FROM VendingMachine.Items WHERE ItemId = 2), 1.5, 10, 0),
((SELECT ItemId FROM VendingMachine.Items WHERE ItemId = 3), 1.5, 10, 0),
((SELECT ItemId FROM VendingMachine.Items WHERE ItemId = 4), 1.5, 10, 0),
((SELECT ItemId FROM VendingMachine.Items WHERE ItemId = 5), 1.5, 10, 0)