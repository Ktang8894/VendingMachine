using VendingMachine;
using NUnit.Framework;

namespace VendingMachineTests
{
    [TestFixture]
    public class VendingMachineTest
    {
        private VendingMachine.VendingMachine Vm { get; set; }
        private ItemQueue Iq { get; set; }
        private string QueueName = "TestShelf";

        [SetUp]
        public void SetUp()
        {
            Vm = new VendingMachine.VendingMachine();
            Iq = new ItemQueue(1.5);
            for (int i = 0; i < 5; i++)
            {
                Iq.QueueItem(new Item("TestName" + i, "TestFlavor" + i, "TestWrapperColor" + i));
            }
            Vm.ItemQueues.Add(QueueName, Iq);
        }

        [Test]
        public void VendingMachine_SetState_Test()
        {
            Vm.SetState(Vm.MoneyInsertedState);
            Assert.That(Vm.CurrentState == Vm.MoneyInsertedState);

            Vm.SetState(Vm.NoMoneyInsertedState);
            Assert.That(Vm.CurrentState == Vm.NoMoneyInsertedState);
        }

        [Test]
        public void VendingMachine_InsertMoney_Test()
        {
            Vm.SetState(Vm.NoMoneyInsertedState);
            Vm.InsertMoney(11.50);
            Assert.That(Vm.MoneyInserted.Equals(11.50));
            Vm.InsertMoney(2000.50);
            Assert.That(Vm.MoneyInserted.Equals(2012));
            Assert.That(Vm.CurrentState == Vm.MoneyInsertedState);
        }

        [Test]
        public void VendingMachine_SelectItemFromEmptyQueue_Test()
        {
            Vm.ItemQueues.Add("A1", new ItemQueue(1.5));
            Assert.DoesNotThrow(() => Vm.SelectItem("A1"));
            Vm.ItemQueues.Remove("A1");
            Assert.DoesNotThrow(() => Vm.SelectItem("A1"));
        }

        [Test]
        public void VendingMachine_SelectItem_Test()
        {
            Assert.DoesNotThrow(() => Vm.SelectItem(QueueName));
        }
    }
}
