namespace VendingMachine.States
{
    class NoMoneyInsertedState : IVendingMachineState
    {
        private VendingMachine _vendingMachine;

        public NoMoneyInsertedState(VendingMachine vm)
        {
            _vendingMachine = vm;
        }

        public void InsertMoney(double money)
        {
            _vendingMachine.MoneyInserted += money;
            MachineOutput.DisplayCurrentBalance(_vendingMachine.MoneyInserted);
            _vendingMachine.CurrentState = _vendingMachine.MoneyInsertedState;
        }

        public void SelectItem(ItemQueue itemQueue)
        {
            MachineOutput.DisplayItemCost(itemQueue.CheckPrice());
        }
    }
}
