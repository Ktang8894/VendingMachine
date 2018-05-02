using VendingMachine;
using NUnit.Framework;

namespace VendingMachineTests
{
    [TestFixture]
    public class MoneyInsertedStateTest
    {
        private VendingMachine.VendingMachine Vm { get; set; }
        private VendingMachine.States.MoneyInsertedState State { get; set; }
        private ItemQueue Iq { get; set; }
        private string QueueName = "TestShelf";

        [SetUp]
        public void SetUp()
        {
            Vm = new VendingMachine.VendingMachine();
            State = new VendingMachine.States.MoneyInsertedState(Vm);
            Iq = new ItemQueue(1.5);
        }

        [Test]
        public void MoneyInsertedState_SelectItem_Test()
        {
            Iq.QueueItem(new Item("TestName", "TestFlavor", "TestWrapperColor"));
            Vm.ItemQueues.Add(QueueName, Iq);
            State.InsertMoney(1.5);
            State.SelectItem(Vm.ItemQueues[QueueName]);
            Assert.That(Vm.ItemQueues[QueueName].IsInStock() == false);
        }
    }
}
