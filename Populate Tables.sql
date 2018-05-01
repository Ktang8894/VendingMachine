USE VendingMachineDB
GO

INSERT INTO VendingMachine.Item(Name, Flavor, WrapperColor, Price, StockCount, TrashCount)
VALUES ('Sour Apple', 'Sour', 'Green', 1.5, 10, 0),
('Red Hot', 'Spicy', 'Red', 1.5, 10, 0),
('Purple', 'Sweet', 'Purple', 1.5, 10, 0),
('Literal Salt', 'Salty', 'Blue', 1.5, 8, 2),
('Lemons', 'Sour', 'Yellow', 1.5, 10, 0)