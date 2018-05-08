INSERT INTO VendingMachine.Item(Name, Flavor, WrapperColor)
VALUES ('Sour Apple', 'Sour', 'Green'),
('Red Hot', 'Spicy', 'Red'),
('Purple', 'Sweet', 'Purple'),
('Yummy Defrosting Salt', 'Salty', 'Blue'),
('Actual Lemons', 'Sour', 'Yellow'),
('Trash Demo', 'Sour', 'Green');

INSERT INTO VendingMachine.ItemQueue(ItemId, Price, StockCount, TrashCount)
VALUES (1, 1.5, 10, 0),
(2, 1.0, 10, 0),
(4, 1.5, 10, 0),
(3, 2.5, 10, 0),
(5, 1.5, 10, 0),
(6, 1.5, 4, 6);