namespace VendingMachine.States
{
    public interface IVendingMachineState
    {
        void InsertMoney(double money);
        void SelectItem(ItemQueue itemQueue);
    }
}
