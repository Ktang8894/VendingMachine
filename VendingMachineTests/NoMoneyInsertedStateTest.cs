using VendingMachine;
using NUnit.Framework;

namespace VendingMachineTests
{
    [TestFixture]
    public class NoMoneyInsertedStateTest
    {
        private VendingMachine.VendingMachine Vm { get; set; }
        private VendingMachine.States.NoMoneyInsertedState State { get; set; }
        private ItemQueue Iq { get; set; }
        private string QueueName = "TestShelf";

        [SetUp]
        public void SetUp()
        {
            Vm = new VendingMachine.VendingMachine();
            State = new VendingMachine.States.NoMoneyInsertedState(Vm);
            Iq = new ItemQueue(1.5);
            Iq.QueueItem(new Item("TestName", "TestFlavor", "TestWrapperColor"));
            Vm.ItemQueues.Add(QueueName, Iq);
        }

        [Test]
        public void NoMoneyInsertedState_InsertMoney_Test()
        {
            Vm.SetState(Vm.NoMoneyInsertedState);
            Vm.InsertMoney(0.01);
            Assert.That(Vm.CurrentState == Vm.MoneyInsertedState);
        }

        [Test]
        public void NoMoneyInsertedState_SelectItem_Test()
        {
            int count = Vm.ItemQueues.Count;
            State.SelectItem(Vm.ItemQueues[QueueName]);
            Assert.That(Vm.ItemQueues.Count.Equals(count));
        }
    }
}
