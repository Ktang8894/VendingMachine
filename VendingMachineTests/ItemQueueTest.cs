using VendingMachine;
using NUnit.Framework;

namespace VendingMachineTests
{
    [TestFixture]
    public class ItemQueueTest
    {
        private ItemQueue Iq { get; set; }
        private readonly int numItems = 5;
        private readonly double price = 1.23;

        [SetUp]
        public void ItemQueue_QueueItem_Setup()
        {
            Iq = new ItemQueue(price);
        }

        [Test]
        public void ItemQueue_CheckPrice_Test()
        {
            Assert.AreEqual(price, Iq.CheckPrice());
        }

        [Test]
        public void ItemQueue_IsInStock_Test()
        {
            for (int i = 0; i < numItems; i++)
            {
                Iq.QueueItem(new Item("TestName" + i, "TestFlavor" + i, "TestWrapperColor" + i));
            }
            Assert.IsTrue(Iq.IsInStock());
            for(int i = 0; i < numItems-1; i++)
            {
                Iq.DispenseItem();
            }
            Assert.IsTrue(Iq.IsInStock());
            Iq.DispenseItem();
            Assert.IsFalse(Iq.IsInStock());
        }

    }
}
