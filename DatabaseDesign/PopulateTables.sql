INSERT INTO VendingMachine.Item(Name, Flavor, WrapperColor)
VALUES ('Sour Apple', 'Sour', 'Green'),
('Red Hot', 'Spicy', 'Red'),
('Purple', 'Sweet', 'Purple'),
('Yummy Defrosting Salt', 'Salty', 'Blue'),
('Actual Lemons', 'Sour', 'Yellow'),
('Trash Demo', 'Sour', 'Green');

INSERT INTO VendingMachine.ItemQueue(ItemId, Price, StockCount)
VALUES (1, 1.5, 10),
(2, 1.0, 10),
(4, 1.5, 10),
(3, 2.5, 10),
(5, 1.5, 10),
(6, 1.5, 4);

INSERT INTO  VendingMachine.TrashCompartment(ItemId, WrapperCount)
VALUES (6, 6);