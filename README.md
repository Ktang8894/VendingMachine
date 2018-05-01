# VendingMachine

VendingMachine Program
Actor.cs
Item.cs
ItemQueue.cs
MachineOutput.cs
Stocker.cs
TrashCompartment.cs
VendingMachine.cs
IVendingmachineState.cs
MoneyInsertedState.cs
NoMoneyInsertedState.cs


Database Setup
1. In your database, execute CreateVendingMachineStoredProc.sql
2. Execute the stored procedure (EXEC VendingMachine.CreateVendingMachine)
	- Creates the VendingMachine schema
	- Creates the Colors, Flavors, ItemQueues, and Items tables
