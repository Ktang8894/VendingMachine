# VendingMachine

## VendingMachine Program

**Item.cs** - Represents an individual item that can be inserted added in a queue within the vending machine. Contains the following properties: Name, Flavor, WrapperColor.

**ItemQueue.cs** - Represents an item queue within the vending machine using a Queue<Item>. Contains the Price property (since the price of an item is declared on the physical queue's level by the vending machine owner, and not determined by an independent Item). Has basic functions for adding and dispensing items, checking prices, checking stock, and reporting queue status, which includes the  queue's items' name, flavor, and wrapper color, as well as number of remaining items(for debugging).

**TrashCompartment.cs** - Represents the trash compartment, where item wrappers are automatically added after the item is dispensed. Has a function to report the number of wrappers for each item (by name).

**VendingMachine.cs** - Represents the vending machine. Contains the total amount of inserted money, ItemQueues, a TrashCompartment, and state instances. Uses states to determine the behavior of when money is inserted and when items are selected.

**IVendingmachineState.cs** (*NTERFACE*) - Interface for vending machine states, which include signatures for the InsertMoney(double money) and SelectItem(ItemQueue itemQueue) functions.

**NoMoneyInsertedState.cs** - Implements the IVendingMachineState interface. Represents a state where no money has been inserted into the vending machine and the current balance is 0.

**MoneyInsertedState.cs** - Implements the IVendingMachineState interface. Represents a state where money has been inserted into the vending machine and the current balance is above 0.

**MachineOutput.cs** - The program's method of displaying messages to the console. 

**Actor.cs** (*MAIN*)

**Stocker.cs** - Contains the function to stock the vending machine. Stocks each shelf by flavor, represented by capital alphabet characters (starting with 'A' as the first shelf), and stocks each shelf's queues by item name. Item information is specified and pulled from the app.config file.


## Database Setup
1. In your database, execute CreateVendingMachineStoredProc.sql
2. Execute the stored procedure (EXEC VendingMachine.CreateVendingMachine)
	- Creates the VendingMachine schema
	- Creates the Colors, Flavors, ItemQueues, and Items tables
