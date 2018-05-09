# VendingMachine
Created by Kevin Tang

Written in C# (.NET Framework 4.6.1) using Visual Studio 2017

## 1. VendingMachine Program

### Execution

To execute the program outside of Visual Studio, run **/VendingMachine/bin/Debug/VendingMachine.exe**.

### State Diagram
![VendingMachine_StateDiagram](/VendingMachine_StateDiagram.jpg)

The Vending Machine was designed using the concept of the State design pattern. There are two states (NoMoneyInsertedState, MoneyInsertedState) which determine the behavior of the 
vending machine when the actor inserts money or selects an item. To dispense an item, the user must first insert the sufficient amount of money for their item of choice, and then select 
the item. Selecting an item with no money inserted will cause the vending machine to report the cost of that item, and selecting an item with insufficient money inserted will report the 
remaining funds needed to reach the cost of the item. The vending machine will not return any change and all excess money inserted will be consumed upon item selection.

### Objects

**Item.cs** - Represents an individual item that can be inserted added in a queue within the vending machine. Contains the following properties: Name, Flavor, WrapperColor. The class is 
loosely defined as 'Items' (rather than 'Candy' for example) for flexibility/reusability, as vending machines can essentially dispense whatever is stocked in the queues.

**ItemQueue.cs** - Represents an item queue within the vending machine using a Queue<Item>. Contains the Price property (since the price of an item is declared on the physical queue's 
level by the vending machine owner, and not determined by an independent Item). Has basic functions for adding and dispensing items, checking prices, checking stock, and reporting queue 
status (for debugging purposes), which includes the queue's items' name, flavor, and wrapper color, as well as number of remaining items.

**TrashCompartment.cs** - Represents the trash compartment, where item wrappers are automatically added after the item is dispensed. Has a function to report the number of wrappers for 
each item (by name).

**VendingMachine.cs** - Represents the vending machine and takes user input in a loop. Contains the total amount of inserted money, ItemQueues, a TrashCompartment, and state instances. 
Uses states to determine the behavior of when money is inserted and when items are selected. The ItemQueues are represented by a Dictionary<string, ItemQueues> object, where the key is 
the letter-number combination that represents the position in the machine, which is what the user inputs to select an item. Each shelf (each which is supposed to contain items of a 
different flavor) is not assigned to an individual flavor by design. This is because a vending machine should be open to whatever item it is stocked with, and it is up to the stocker to 
stock the shelves by flavor. In this program, the Stocker class does this and can be denoted by the letter in the letter-number combination.

**IVendingmachineState.cs** (*INTERFACE*) - Interface for vending machine states, which include signatures for the InsertMoney and SelectItem functions.

**NoMoneyInsertedState.cs** - Implements the IVendingMachineState interface. Represents a state where no money has been inserted into the vending machine and the current balance is 0.

**MoneyInsertedState.cs** - Implements the IVendingMachineState interface. Represents a state where money has been inserted into the vending machine and the current balance is above 0.

**VendingMachineSetup.cs** (*MAIN*) - Sets up the VendingMachine instance by creating the queues. Shelves are arranged by alphabet and the queues in the shelf are arranged numerically 
(first item on first shelf would be A1). The price of each queue, capacity of the queues, the number of queues on each shelf, and the number of shelves in the vending machine are defined 
in the *app.config* file.

**MachineOutput.cs** - The program's method of displaying messages to the console.

**Stocker.cs** - Used for simulation/demo purposes, as real hardware limitations enable the vending machine program to not care about how items are stocked. Represents a stocker filling 
the vending machine's queues. In this case, the shelves categorized by flavor and the queues on each shelf are categorized by color (or name, where the name is a combination of the 
color + flavor). 


## 2. Database Design

### VendingMachine Schema Design
![VendingMachine_Schema](/DatabaseDesign/VendingMachine_Schema.jpg)

The VendingMachine schema was designed based on the object models in the VendingMachine program. The primary objects that the VendingMachine holds other than the states and the current 
amount of money inserted (which is not necessary in a database) are the TrashCompartment and ItemQueues (which contains Items). The Item table contains the basic information of an Item 
object, including name, flavor, and wrapper color fields, as well as an ItemId which acts as the table's primary key. The ItemQueue table, like the class, contains information on the price 
and stock, and has an ItemId which is a foreign key that references the Item table's ItemId. The TrashCompartment table simply has a field for the wrapper count, and an ItemId foreign key 
which also references VendingMachine.Item.ItemId. 

Note that this would not be the preferred schema design in a practical situation and is specifically designed to model the objects in the program. In such a case, an approach that reduces 
the amount of joins necessary and that avoids over-normalization would be taken, which would involve combining the three tables into one.

### Setup

1. In your database, execute the script in **/DatabaseDesign/CreateVendingMachineStoredProc.sql** to create the VendingMachine.CreateVendingMachine stored procedure
2. Execute the stored procedure (EXEC VendingMachine.CreateVendingMachine)
	- Creates the VendingMachine schema
	- Creates the Items Table
3. To populate the table with test values, execute the query in **/DatabaseDesign/PopulateTables.sql**

## 3. SELECT Statements

These SELECT statements can be found in **/DatabaseDesign/SelectStatements.sql**

### Sour Items
```
SELECT Name
FROM VendingMachine.Item i
INNER JOIN VendingMachine.ItemQueue iq
ON i.ItemId = iq.ItemId
WHERE Flavor = 'SOUR'
AND StockCount > 0;
```

### Most common wrapper color in the Trash Compartment
```
SELECT WrapperColor
FROM VendingMachine.Item i
INNER JOIN VendingMachine.TrashCompartment tc
ON i.ItemId = tc.ItemId
WHERE tc.WrapperCount = (
	SELECT MAX(VendingMachine.TrashCompartment.WrapperCount) 	
	FROM VendingMachine.TrashCompartment)	
AND tc.WrapperCount > 0;
```

### Amount of candies on each shelf
```
SELECT Flavor, SUM(StockCount) AS FlavorCount
FROM VendingMachine.Item i
INNER JOIN VendingMachine.ItemQueue iq
ON i.ItemId = iq.ItemId
GROUP BY Flavor;
```
