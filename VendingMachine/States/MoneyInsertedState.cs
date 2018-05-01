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
            MachineOutput.DisplayCurrentBalance(_vendingMachine.MoneyInserted);
        }

        public void SelectItem(ItemQueue itemQueue) 
        { 
            if (itemQueue.CheckPrice() > _vendingMachine.MoneyInserted)
            {
                MachineOutput.DisplayInsufficientFundsError(itemQueue.CheckPrice() - _vendingMachine.MoneyInserted);
            }
            else
            {
                itemQueue.Status(); //FOR DEBUGGING PURPOSES
                _vendingMachine.Trash.AddWrapper(itemQueue.DispenseItem().Name);
                _vendingMachine.MoneyInserted = 0;
                _vendingMachine.SetState(_vendingMachine.NoMoneyInsertedState);
            }
        }
    }
}
