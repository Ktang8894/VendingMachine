using System;
using System.Collections.Generic;

namespace VendingMachine.States
{
    class MoneyInsertedState : IVendingMachineState
    {
        private VendingMachine _vendingMachine;

        public MoneyInsertedState(VendingMachine vm)
        {
            _vendingMachine = vm;
        }

        public void InsertMoney(double money)
        {
            _vendingMachine.MoneyInserted += money;
            MachineOutput.DisplayTotalMoney(_vendingMachine.MoneyInserted);
        }

        public void SelectItem(ItemQueue itemQueue) 
        { 
            if (itemQueue.CheckPrice() > _vendingMachine.MoneyInserted)
            {
                MachineOutput.DisplayInsufficientFundsError(itemQueue.CheckPrice() - _vendingMachine.MoneyInserted);
            }
            else
            {
                itemQueue.Status(); //Debug
                _vendingMachine.Trash.AddWrapper(itemQueue.DispenseItem()); //Makes sense that this is one transaction
                _vendingMachine.MoneyInserted = 0;
                _vendingMachine.SetState(_vendingMachine.NoMoneyInsertedState);
            }
        }
    }
}
