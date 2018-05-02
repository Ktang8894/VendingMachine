# VendingMachine
Created by Kevin Tang

Written in C# (.NET Framework 4.6.1) using Visual Studio 2017

## 1. VendingMachine Program

**Item.cs** - Represents an individual item that can be inserted added in a queue within the vending machine. Contains the following properties: Name, Flavor, WrapperColor. The class is loosely defined as 'Items' for flexibility/reusability.

**ItemQueue.cs** - Represents an item queue within the vending machine using a Queue<Item>. Contains the Price property (since the price of an item is declared on the physical queue's level by the vending machine owner, and not determined by an independent Item). Has basic functions for adding and dispensing items, checking prices, checking stock, and reporting queue status, which includes the  queue's items' name, flavor, and wrapper color, as well as number of remaining items(for debugging).

**TrashCompartment.cs** - Represents the trash compartment, where item wrappers are automatically added after the item is dispensed. Has a function to report the number of wrappers for each item (by name).

**VendingMachine.cs** - Represents the vending machine and takes user input in a loop. Contains the total amount of inserted money, ItemQueues, a TrashCompartment, and state instances. Uses states to determine the behavior of when money is inserted and when items are selected. 

**IVendingmachineState.cs** (*NTERFACE*) - Interface for vending machine states, which include signatures for the InsertMoney(double money) and SelectItem(ItemQueue itemQueue) functions.

**NoMoneyInsertedState.cs** - Implements the IVendingMachineState interface. Represents a state where no money has been inserted into the vending machine and the current balance is 0.

**MoneyInsertedState.cs** - Implements the IVendingMachineState interface. Represents a state where money has been inserted into the vending machine and the current balance is above 0.

**VendingMachineSetup.cs** (*MAIN*) - Sets up the VendingMachine instance by creating the queues. Shelves are arranged by alphabet and the queues in the shelf are arranged numerically (first item on first shelf would be A1). The price of each queue, capacity of the queues, the number of queues on each shelf, and the number of shelves in the vending machine are defined in the *app.config* file.

**MachineOutput.cs** - The program's method of displaying messages to the console.

**Stocker.cs** - Used for simulation/demo purposes, as real hardware limitations enable the vending machine program to not care about how items are stocked. Represents a stocker filling the vending machine's queues. In this case, the shelves categorized by flavor and the queues on each shelf are categorized by color (or name, where the name is a combination of the color + flavor). 


## 2. Database Design

Database design can be seen in **/DatabaseDesign/VendingMachine_Schema.jpg**

### Setup
1. In your database, execute the script in CreateVendingMachineStoredProc.sql to create the VendingMachine.CreateVendingMachine stored procedure
2. Execute the stored procedure (EXEC VendingMachine.CreateVendingMachine)
	- Creates the VendingMachine schema
	- Creates the Items Table
3. To populate the table with test values, execute the query in **/DatabaseDesign/PouplateTables.sql**

## 3. Select Statements

Sample select statements can be found in **/DatabaseDesign/SelectStatements.sql**
