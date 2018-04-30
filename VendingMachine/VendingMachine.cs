using System;
using System.Collections.Generic;
using VendingMachine.States;

namespace VendingMachine
{
    public class VendingMachine
    {
        public IVendingMachineState MoneyInsertedState { get; }
        public IVendingMachineState NoMoneyInsertedState { get; }
        public IVendingMachineState CurrentState { get; set; }

        public Dictionary<string, ItemQueue> Shelves = new Dictionary<string, ItemQueue>();
        public double MoneyInserted { get; set; }
        public TrashCompartment Trash = new TrashCompartment();

        public void InsertMoney(double money)
        {
            CurrentState.InsertMoney(money);
        }

        public void SelectItem(string itemInput)
        {
            var itemQueue = Shelves[itemInput];
            if (itemQueue.IsInStock()) { 
                CurrentState.SelectItem(itemQueue);
            }
            else
            {
                MachineOutput.DisplaySoldOutError();
            }
        }

        public void SetState(IVendingMachineState state)
        {
            CurrentState = state;
        }

        public VendingMachine()
        {
            MoneyInsertedState = new MoneyInsertedState(this);
            NoMoneyInsertedState = new NoMoneyInsertedState(this);
            Console.WriteLine("[DEBUG] Enter currency value following a '$' or enter item coordinates (default A-D, 1-5)");
            CurrentState = new NoMoneyInsertedState(this);
        }
    }
}
