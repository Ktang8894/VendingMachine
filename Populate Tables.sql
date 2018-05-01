USE VendingMachineDB
GO

INSERT INTO VendingMachine.WrapperColor(WrapperColor)
VALUES ('RED'), ('GREEN'), ('BLUE'), ('YELLOW'), ('PURPLE')

INSERT INTO VendingMachine.Flavor(Flavor)
VALUES ('SOUR'), ('SWEET'), ('SPICY'), ('SALTY')

INSERT INTO VendingMachine.Item(Name, FlavorId, WrapperColorId, Price, StockCount, TrashCount)
VALUES ('Sour Apple', (SELECT FlavorId FROM VendingMachine.Flavor WHERE Flavor = 'Sour'), (SELECT WrapperColorId FROM VendingMachine.WrapperColor WHERE WrapperColor = 'Green'), 1.5, 10, 0),
('Red Hot', (SELECT FlavorId FROM VendingMachine.Flavor WHERE Flavor = 'Spicy'), (SELECT WrapperColorId FROM VendingMachine.WrapperColor WHERE WrapperColor = 'Red'), 1.5, 10, 0),
('Purple', (SELECT FlavorId FROM VendingMachine.Flavor WHERE Flavor = 'Sweet'), (SELECT WrapperColorId FROM VendingMachine.WrapperColor WHERE WrapperColor = 'Purple'), 1.5, 10, 0),
('Literal Salt', (SELECT FlavorId FROM VendingMachine.Flavor WHERE Flavor = 'Salty'), (SELECT WrapperColorId FROM VendingMachine.WrapperColor WHERE WrapperColor = 'Blue'), 1.5, 8, 2),
('Lemons', (SELECT FlavorId FROM VendingMachine.Flavor WHERE Flavor = 'Sour'), (SELECT WrapperColorId FROM VendingMachine.WrapperColor WHERE WrapperColor = 'Yellow'), 1.5, 10, 0)