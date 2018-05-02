using System;
using System.Collections.Generic;
using VendingMachine.States;

namespace VendingMachine
{
    public class VendingMachine
    {
        public IVendingMachineState MoneyInsertedState { get; set; }
        public IVendingMachineState NoMoneyInsertedState { get; set; }
        public IVendingMachineState CurrentState { get; set; }

        public Dictionary<string, ItemQueue> ItemQueues = new Dictionary<string, ItemQueue>();
        public double MoneyInserted { get; set; }
        public TrashCompartment Trash = new TrashCompartment();

        public void InsertMoney(double money)
        {
            CurrentState.InsertMoney(money);
        }

        public void SelectItem(string itemInput)
        {
            if (!ItemQueues.ContainsKey(itemInput)) { return; }

            var itemQueue = ItemQueues[itemInput];
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

        public void ReadInput()
        {
            while (true)
            {
                var input = Console.ReadLine().ToUpper();
                if (input != "")
                {
                    if (input[0] == '$' && double.TryParse(input.Substring(1), out var money))
                    {
                        InsertMoney(money);
                    }
                    else if (input.ToUpper() == "TRASH")
                    {
                        Trash.Report();
                    }
                    else
                    {
                       SelectItem(input);
                    }
                }
            }
        }

        public VendingMachine()
        {
            MachineOutput.DisplayInstructions();
            MoneyInsertedState = new MoneyInsertedState(this);
            NoMoneyInsertedState = new NoMoneyInsertedState(this);
            CurrentState = new NoMoneyInsertedState(this);
        }
    }
}
